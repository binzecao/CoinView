using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace CoinView.CoinControl.OKCoin
{
    public partial class OKCoin_Ticker : UserControl, ICoinControl
    {
        public OKCoin_Ticker()
        {
            InitializeComponent();
            setNamesMap();
            Utility.Utility.setDragMoveForm(this);
            this.MinimumSize = new Size(165, 35);
            this.MaximumSize = this.Size;
        }

        #region 获取数据&刷新显示
        public const string url = "https://www.okcoin.com/api/ticker.do?symbol=[CURR_A]_[CURR_B]";
        private int currentCoinIndex;
        private JObject jo; // 暂时存放json数据
        private string errMsg; // 暂时存放网络的错误信息
        // 获取数据
        private void loadData()
        {
            string currentUrl = url.Replace("[CURR_A]_[CURR_B]", Coins.getCoin(Coins.Platform.OKCoin, currentCoinIndex));
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(currentUrl);
            hwr.ContentType = "application/x-www-form-urlencoded";
            hwr.Accept = "text/html, application/xhtml+xml, */*";
            hwr.Method = "GET";
            hwr.Timeout = 10 * 1000;
            try
            {
                using (Stream stream = hwr.GetResponse().GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("gbk"));
                    string rtnJson = sr.ReadToEnd();
                    jo = JObject.Parse(rtnJson);
                    sr.Close();
                }
                errMsg = "";
            }
            catch (Exception ex)
            {
                jo = null;
                errMsg = ex.Message;
            }
        }
        // 将获取的数据填入各表单中
        private void fillControlsData()
        {
            try
            {
                txtLast.Text = "";
                txtHigh.Text = "";
                txtLow.Text = "";
                txtBuy.Text = "";
                txtSell.Text = "";
                txtVol.Text = "";
                lblVol.Text = Regex.Replace(lblVol.Text, @"\(.*\)", "()");
                if (jo != null)
                {
                    // {"ticker":{"buy":"162.5","high":"184.4","last":"162.5","low":"141.49","sell":"162.2","vol":"6200727.0620006"}}
                    txtLast.Text = (string)jo["ticker"]["last"];
                    txtHigh.Text = (string)jo["ticker"]["high"];
                    txtLow.Text = (string)jo["ticker"]["low"];
                    txtBuy.Text = (string)jo["ticker"]["buy"];
                    txtSell.Text = (string)jo["ticker"]["sell"];
                    txtVol.Text = Regex.Replace((string)jo["ticker"]["vol"], @"^(.*\.\d{2}).*", "$1");

                    string currentCoin = Coins.getCoin(Coins.Platform.OKCoin, currentCoinIndex);
                    string CURR_A_Name = currentCoin.Split('_')[0];
                    lblVol.Text = lblVol.Text.Replace("()", "(" + CURR_A_Name + ")");
                }
            }
            catch (Exception ex)
            {
                if (errMsg != string.Empty) errMsg += "\n";
                errMsg += ex.Message;
            }
            lblErrMsg.Text = errMsg;
            ttlblErrMsg.SetToolTip(lblErrMsg, errMsg);
            // 获取刷新间隔
            int.TryParse(txtRefreshInterval.Text, out interval);
            if (interval <= 0) interval = 5;
        }

        private delegate void fillControlsDataCallback(); //设置数据的委托
        private Thread autoLoadDataThread; // 自动刷新数据的线程
        private int interval; // 刷新时间间隔
        // 死循环自动获取并刷新数据
        private void autoLoadData()
        {
            while (true)
            {
                loadData();
                this.Invoke(new fillControlsDataCallback(fillControlsData));
                Thread.Sleep(interval * 1000);
            }
        }
        // 线程开启、重启方法
        public void asyncThreadStart()
        {
            abortAutoLoadDataThread();
            autoLoadDataThread = new Thread(new ThreadStart(autoLoadData));
            autoLoadDataThread.Start();
        }
        // 中止获取数据的线程
        public void abortAutoLoadDataThread()
        {
            if (autoLoadDataThread != null)
            {
                try
                {
                    if (autoLoadDataThread.IsAlive) autoLoadDataThread.Abort();
                    autoLoadDataThread = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // GC.Collect();
                }
            }
        }
        #endregion

        #region txtRefreshInterval 控制刷新
        // 刷新间隔输入框输入限制
        private void txtRefreshInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ikc = (int)e.KeyChar;
            if ((!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]")) && ((int)e.KeyChar) != 8)
            {
                e.Handled = true;
                return;
            }
        }

        // 输入间隔后自动按新的间隔时间刷新数据
        private void txtRefreshInterval_TextChanged(object sender, EventArgs e)
        {
            interval = int.Parse(txtRefreshInterval.Text);
            asyncThreadStart();
        }
        #endregion

        #region 切换中英文
        private int currentLanguageIndex;//0:英文 1:中文 
        private IDictionary<string, string[]> namesMap = new Dictionary<string, string[]>();
        //设置控件文本中英文组合
        private void setNamesMap()
        {
            namesMap.Add("lblBuy", new string[] { "buy:", "买一:" });
            namesMap.Add("lblHigh", new string[] { "high:", "最高:" });
            namesMap.Add("lblLast", new string[] { "last:", "最新成交:" });
            namesMap.Add("lblLow", new string[] { "low:", "最低:" });
            namesMap.Add("lblRefreshInterval", new string[] { "refresh:", "刷新间隔:" });
            namesMap.Add("lblSecond", new string[] { "s", "秒" });
            namesMap.Add("lblSell", new string[] { "sell:", "卖一:" });
            namesMap.Add("lblVol", new string[] { "vol(CURR_A):", "成交量(CURR_A):" });
            // namesMap.Add("ErrMsg", new string[] { "ErrMsg", "预留错误信息" });
        }
        // 设置语言
        public void setLanguage(int languageIndex)
        {
            currentLanguageIndex = languageIndex;
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    foreach (string key in namesMap.Keys)
                    {
                        if (control.Name.ToLower() == key.ToLower())
                        {
                            control.Text = namesMap[key][currentLanguageIndex];
                        }
                    }
                }
            }
            string currentCoin = Coins.getCoin(Coins.Platform.OKCoin, currentCoinIndex);
            string CURR_A_Name = currentCoin.Split('_')[0];
            string CURR_B_Name = currentCoin.Split('_')[1];
            lblVol.Text = lblVol.Text.Replace("CURR_A", CURR_A_Name);
        }
        #endregion

        #region 设置币
        public void setCurrentCoin(int coinIndex)
        {
            currentCoinIndex = coinIndex;
            asyncThreadStart();
        }
        #endregion


    }
}
