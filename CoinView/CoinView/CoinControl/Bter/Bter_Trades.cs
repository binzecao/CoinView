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
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace CoinView.CoinControl.Bter
{
    public partial class Bter_Trades : UserControl, ICoinControl
    {
        public Bter_Trades()
        {
            InitializeComponent();
            Utility.Utility.setDragMoveForm(this);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        #region 获取数据&刷新显示
        // https://bter.com/api/1/trade/[CURR_A]_[CURR_B]/[TID] //返回从[TID]往后的最多1000历史成交记录,没有tid或者tid=0为返回最新,tid不能小于0
        public const string url = "https://bter.com/api/1/trade/[CURR_A]_[CURR_B]"; // 返回最新80条历史成交记录,
        private int currentCoinIndex;
        private JObject jo_trades; // 暂时存放jobject数据,时间顺序(date值, 更严格地说是tid的值)按照从小到大(也即从古到今)
        private string errMsg; // 暂时存放错误信息
        // 获取数据
        private void loadData()
        {
            string currentUrl = url.Replace("[CURR_A]_[CURR_B]", Coins.getCoin(Coins.Platform.Bter, currentCoinIndex));
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
                    if (rtnJson == "null" || rtnJson == "\nnull")
                    {
                        jo_trades = new JObject();
                        jo_trades.Add("result", "null");
                    }
                    else
                    {
                        jo_trades = JObject.Parse(rtnJson);
                    }
                    sr.Close();
                }
                errMsg = "";
            }
            catch (Exception ex)
            {
                jo_trades = null;
                errMsg = ex.Message;
            }
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
        private DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        // 填充数据到dgv中
        private void fillControlsData()
        {
            dgvTrades.Rows.Clear();
            dgvcAmount.HeaderText = Regex.Replace(dgvcAmount.HeaderText, @"\(.*\)", "()");
            dgvcPrice.HeaderText = Regex.Replace(dgvcPrice.HeaderText, @"\(.*\)", "()");
            dgvcTotal.HeaderText = Regex.Replace(dgvcTotal.HeaderText, @"\(.*\)", "()");
            try
            {
                if (jo_trades != null)
                {
                    // {"result":"true","data":[{"date":"1387181566","price":5070,"amount":2.7756,"tid":"1688136","type":"sell"}],"elapsed":"0.453ms"}
                    // {"result":"true","data":[],"elapsed":"0.453ms"}
                    // {"result":"false","message":"Error: JRY or CNY is not supported"}
                    if ((string)jo_trades["result"] == "true")
                    {
                        double defaultHighLight;
                        double.TryParse(txtHighLight.Text, out defaultHighLight);
                        foreach (object o in jo_trades["data"])
                        {
                            JObject trade = (JObject)o;
                            DataGridViewRow dgvr = new DataGridViewRow();
                            DataGridViewTextBoxCell dgvcellDate = new DataGridViewTextBoxCell();
                            dgvcellDate.Value = dtStart.Add(new TimeSpan(long.Parse(trade["date"] + "0000000"))).ToString("HH:mm:ss");
                            DataGridViewTextBoxCell dgvcellAmount = new DataGridViewTextBoxCell();
                            dgvcellAmount.Value = trade["amount"];
                            DataGridViewTextBoxCell dgvcellPrice = new DataGridViewTextBoxCell();
                            dgvcellPrice.Value = trade["price"];
                            DataGridViewTextBoxCell dgvcelTotal = new DataGridViewTextBoxCell();
                            double totel = (double)trade["price"] * (double)trade["amount"];
                            dgvcelTotal.Value = totel;
                            DataGridViewTextBoxCell dgvcellType = new DataGridViewTextBoxCell();
                            dgvcellType.Value = trade["type"];
                            DataGridViewTextBoxCell dgvcellTid = new DataGridViewTextBoxCell();
                            dgvcellTid.Value = trade["tid"];

                            if (trade["type"].ToString() == "buy") dgvcellPrice.Style.ForeColor = Color.DarkGreen;
                            else if (trade["type"].ToString() == "sell") dgvcellPrice.Style.ForeColor = Color.Red;
                            if (defaultHighLight > 0 && totel > defaultHighLight) dgvcelTotal.Style.BackColor = Color.Pink;

                            dgvr.Cells.Add(dgvcellDate);
                            dgvr.Cells.Add(dgvcellPrice);
                            dgvr.Cells.Add(dgvcellAmount);
                            dgvr.Cells.Add(dgvcelTotal);
                            dgvr.Cells.Add(dgvcellType);
                            dgvr.Cells.Add(dgvcellTid);

                            dgvTrades.Rows.Insert(0, dgvr);
                            dgvTrades.ClearSelection();

                            // 将表格标题栏括号中的货币名刷新
                            string currentCoin = Coins.getCoin(Coins.Platform.Bter, currentCoinIndex);
                            string CURR_A_Name = currentCoin.Split('_')[0];
                            string CURR_B_Name = currentCoin.Split('_')[1];
                            dgvcAmount.HeaderText = dgvcAmount.HeaderText.Replace("()", "(" + CURR_B_Name + ")");
                            dgvcPrice.HeaderText = dgvcPrice.HeaderText.Replace("()", "(" + CURR_A_Name + ")");
                            dgvcTotal.HeaderText = dgvcTotal.HeaderText.Replace("()", "(" + CURR_B_Name + ")");
                        }
                    }
                    else if ((string)jo_trades["result"] == "false")
                    {
                        if (errMsg != string.Empty) errMsg += "\n";
                        errMsg += (string)jo_trades["message"];
                    }
                    else if ((string)jo_trades["result"] == "null")
                    {
                        if (errMsg != string.Empty) errMsg += "\n";
                        errMsg += "服务器直接返回null，原因未知无法处理";
                    }
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
        #endregion

        #region 设置币
        public void setCurrentCoin(int coinIndex)
        {
            currentCoinIndex = coinIndex;
            asyncThreadStart();
        }
        #endregion

        #region txtHighLight限制输入
        private void txtHighLight_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ikc = (int)e.KeyChar;
            if ((!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]")) && ((int)e.KeyChar) != 8)
            {
                e.Handled = true;
                return;
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

        #region 语言切换 TODO
        public void setLanguage(int languageIndex)
        {
            //throw new NotImplementedException();
        }
        #endregion
    }
}
