using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView
{
    public partial class Bter_Form : Form
    {
        #region 构造器
        public Bter_Form()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            interval = int.Parse(txtRefreshInterval.Text);
            setNamesMap();
            setDragLabelMoveForm();
            setTradeCoinsSelectBtns();
            setChangePlatform();
            maxSize = this.Size;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            //asyncThreadStart();
        }
        #endregion

        #region 窗口激活事件
        bool isActivated = false;
        private void Form_Activated(object sender, EventArgs e)
        {
            if (!isActivated)
            {
                isActivated = true;
                this.isFormMini = Utility.Utility.isFormMini;
                this.Size = Utility.Utility.isFormMini ? miniSize : maxSize;
                this.TopMost = Utility.Utility.isTopMost;
                this.currentLanguageOrder = Utility.Utility.currentLanguage;
                setLanguage();
                ni.Visible = true;
                asyncThreadStart();
            }
        }
        #endregion

        #region 获取数据&刷新显示
        JObject jo; // 暂时存放json数据
        string errMsg; // 暂时存放网络的错误信息
        // 获取数据，用在委托中
        void loadData()
        {
            string currentCoinTrade = tradeCoins[currentCoinIndex];
            string currentUrl = url.Replace("[CURR_A]_[CURR_B]", currentCoinTrade);

            // {"result":"true","last":5700,"high":5880,"low":5103.01,"avg":5492.1,"sell":5710,"buy":5700,"vol_btc":7475.1856,"vol_cny":41054434.85}
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
                        jo = new JObject();
                        jo.Add("result", "null");
                    }
                    else
                    {
                        jo = JObject.Parse(rtnJson);
                    }
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
        void fillControlText()
        {
            try
            {
                txtLast.Text = "";
                txtHigh.Text = "";
                txtLow.Text = "";
                txtBuy.Text = "";
                txtSell.Text = "";
                txtAvg.Text = "";
                txtVol_CURR_A.Text = "";
                txtVol_CURR_B.Text = "";
                lblVol_CURR_A.Text = Regex.Replace(lblVol_CURR_A.Text, @"\(.*\)", "()");
                lblVol_CURR_B.Text = Regex.Replace(lblVol_CURR_B.Text, @"\(.*\)", "()");
                if (jo != null)
                {
                    // 现总共发现返回三种
                    // {"result":"true","last":5700,"high":5880,"low":5103.01,"avg":5492.1,"sell":5710,"buy":5700,"vol_btc":7475.1856,"vol_cny":41054434.85}
                    // {"result":"false","message":"Error: JRY or CNY is not supported"}
                    // null
                    if ((string)jo["result"] == "true")
                    {
                        txtLast.Text = (string)jo["last"];
                        txtHigh.Text = (string)jo["high"];
                        txtLow.Text = (string)jo["low"];
                        txtBuy.Text = (string)jo["buy"];
                        txtSell.Text = (string)jo["sell"];
                        txtAvg.Text = (string)jo["avg"];
                        string currentCoinTrade = tradeCoins[currentCoinIndex];
                        string CURR_A_Name = currentCoinTrade.Split('_')[0];
                        string CURR_B_Name = currentCoinTrade.Split('_')[1];
                        txtVol_CURR_A.Text = (string)jo["vol_" + CURR_A_Name];
                        txtVol_CURR_B.Text = (string)jo["vol_" + CURR_B_Name];
                        lblVol_CURR_A.Text = lblVol_CURR_A.Text.Replace("()", "(" + CURR_A_Name + ")");
                        lblVol_CURR_B.Text = lblVol_CURR_B.Text.Replace("()", "(" + CURR_B_Name + ")");
                    }
                    else if ((string)jo["result"] == "false")
                    {
                        if (errMsg != string.Empty) errMsg += "\n";
                        errMsg += (string)jo["message"];
                    }
                    else if ((string)jo["result"] == "null")
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

        delegate void fillControlTextCallback(); //设置数据的委托
        Thread autoLoadDataThread; // 自动刷新数据的线程
        int interval; // 刷新时间间隔
        // 死循环自动刷新数据
        void autoLoadData()
        {
            while (true)
            {
                while (true)
                {
                    loadData();
                    this.Invoke(new fillControlTextCallback(fillControlText));
                    Thread.Sleep(interval * 1000);
                }
            }
        }
        // 线程开启、重启方法
        void asyncThreadStart()
        {
            abortAutoLoadDataThread();
            autoLoadDataThread = new Thread(new ThreadStart(autoLoadData));
            autoLoadDataThread.Start();
        }
        // 中止获取数据的线程
        void abortAutoLoadDataThread()
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

        #region 窗体移动
        bool beginMove = false;//初始化 
        int currentXPosition;
        int currentYPosition;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标 
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x 
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标 
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            currentXPosition = 0; //设置初始状态
            currentYPosition = 0;
            beginMove = false;
        }

        void setDragLabelMoveForm()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.MouseDown += Form_MouseDown;
                    ctrl.MouseMove += Form_MouseMove;
                    ctrl.MouseUp += Form_MouseUp;
                }
            }
        }
        #endregion

        #region 右键菜单
        #region 退出
        // 点击退出
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
            System.Environment.Exit(0);
        }
        // 窗体关闭
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            abortAutoLoadDataThread();
        }
        #endregion

        #region 置顶
        private void tsmiSetTopMost_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
        #endregion

        #region 切换中英文
        int currentLanguageOrder = 1;//0:英文 1:中文 
        IDictionary<string, string[]> namesMap = new Dictionary<string, string[]>();
        //设置控件文本中英文组合
        void setNamesMap()
        {
            namesMap.Add("lblBuy", new string[] { "buy:", "买一:" });
            namesMap.Add("lblHigh", new string[] { "high:", "最高:" });
            namesMap.Add("lblLast", new string[] { "last:", "最新成交:" });
            namesMap.Add("lblLow", new string[] { "low:", "最低:" });
            namesMap.Add("lblRefreshInterval", new string[] { "refresh:", "刷新间隔:" });
            namesMap.Add("lblSecond", new string[] { "s", "秒" });
            namesMap.Add("lblSell", new string[] { "sell:", "卖一:" });
            namesMap.Add("lblVol", new string[] { "vol:", "成交量:" });
            namesMap.Add("lblVol_CURR_A", new string[] { "vol(CURR_A):", "成交量(CURR_A):" });
            namesMap.Add("lblVol_CURR_B", new string[] { "vol(CURR_B):", "成交量(CURR_B):" });
            namesMap.Add("lblAvg", new string[] { "avg:", "平均价格:" });
            // namesMap.Add("ErrMsg", new string[] { "ErrMsg", "预留错误信息" });
            namesMap.Add("tsmiChangeLanguage", new string[] { "中文", "English" });
            namesMap.Add("tsmiExit", new string[] { "Exit", "退出" });
            namesMap.Add("tsmiSetTopMost", new string[] { "Topmost", "置顶" });
            namesMap.Add("tsmiResizeForm", new string[] { "Resize Form", "缩小/放大界面" });
            namesMap.Add("tsmiChangeCoin", new string[] { "Change Coin", "币切换" });
            namesMap.Add("tsmiChangePlatform", new string[] { "Change Platform", "切换平台" });
        }
        // 点击切换
        private void tsmiChangeLanguage_Click(object sender, EventArgs e)
        {
            currentLanguageOrder = currentLanguageOrder == 0 ? 1 : 0;
            setLanguage();
        }
        // 设置语言
        void setLanguage()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    foreach (string key in namesMap.Keys)
                    {
                        if (control.Name.ToLower() == key.ToLower())
                        {
                            control.Text = namesMap[key][currentLanguageOrder];
                        }
                    }
                }
            }
            foreach (ToolStripMenuItem tsmi in this.cmsForm.Items)
            {
                foreach (string key in namesMap.Keys)
                {
                    if (tsmi.Name.ToLower() == key.ToLower())
                    {
                        tsmi.Text = namesMap[key][currentLanguageOrder];
                    }
                }
            }
            string currentCoinTrade = tradeCoins[currentCoinIndex];
            string CURR_A_Name = currentCoinTrade.Split('_')[0];
            string CURR_B_Name = currentCoinTrade.Split('_')[1];
            lblVol_CURR_A.Text = lblVol_CURR_A.Text.Replace("CURR_A", CURR_A_Name);
            lblVol_CURR_B.Text = lblVol_CURR_B.Text.Replace("CURR_B", CURR_B_Name);
        }
        #endregion

        #region 缩小/方法界面
        Size miniSize = new Size(165, 35);
        Size maxSize;
        bool isFormMini = false;
        private void tsmiResizeForm_Click(object sender, EventArgs e)
        {
            isFormMini = !isFormMini;
            this.Size = isFormMini ? miniSize : maxSize;
        }
        #endregion

        #region 当前币&币地址&切换币
        const string url = "https://bter.com/api/1/ticker/[CURR_A]_[CURR_B]";
        int currentCoinIndex = 0;
        string[] tradeCoins = new string[] { "btc_cny", "ltc_cny", "ftc_cny", "frc_cny", "ppc_cny", "trc_cny", "wdc_cny", "yac_cny", "cnc_cny", "bqc_cny", "ifc_cny", "zcc_cny", "cmc_cny", "jry_cny", "xpm_cny", "ppc_cny", "pts_cny", "tag_cny", "tix_cny", "src_cny", "mec_cny", "nmc_cny", "qrk_cny", "btb_cny", "exc_cny", "dtc_cny", "cent_cny", "red_cny", "zet_cny", "ftc_ltc", "frc_ltc", "ppc_ltc", "trc_ltc", "nmc_ltc", "wdc_ltc", "yac_ltc", "cnc_ltc", "bqc_ltc", "ifc_ltc", "red_ltc", "tix_ltc", "cent_ltc", "ltc_btc", "nmc_btc", "ppc_btc", "trc_btc", "frc_btc", "ftc_btc", "bqc_btc", "cnc_btc", "btb_btc", "yac_btc", "wdc_btc", "zcc_btc", "xpm_btc", "zet_btc", "src_btc", "sav_btc", "cdc_btc", "cmc_btc", "jry_btc", "tag_btc", "pts_btc", "dtc_btc", "exc_btc", "nec_btc", "mec_btc", "qrk_btc", "anc_btc", "nvc_btc", "buk_btc", "myminer_btc" };
        //添加货币选项到右键
        void setTradeCoinsSelectBtns()
        {
            int index = 0;
            foreach (string tradeCoin in tradeCoins)
            {
                ToolStripMenuItem newTsmi = new ToolStripMenuItem();
                newTsmi.Name = "tsmiTradeCoin_" + tradeCoins;
                newTsmi.Text = tradeCoin.Replace("_", "/");
                newTsmi.CheckOnClick = true;
                newTsmi.Tag = index++;//保存对应的索引
                newTsmi.Click += tsmiChangeCoin_Click;
                tsmiChangeCoin.DropDownItems.Add(newTsmi);
            }
            ((ToolStripMenuItem)(tsmiChangeCoin.DropDownItems[currentCoinIndex])).Checked = true;
        }

        // 切换货币
        private void tsmiChangeCoin_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem currentTsmi = (ToolStripMenuItem)sender;
            if (currentTsmi.Checked == false) // 点击自己等于无效点击
            {
                currentTsmi.Checked = true;
                return;
            }
            currentCoinIndex = (int)((ToolStripMenuItem)sender).Tag;
            foreach (ToolStripMenuItem tsmi in tsmiChangeCoin.DropDownItems)
            {
                if (tsmi != currentTsmi) tsmi.Checked = false;
            }
            asyncThreadStart();
        }
        #endregion

        #region 切换平台
        // 添加平台选项到右键
        void setChangePlatform()
        {
            foreach (string platform in Utility.Utility.platforms)
            {
                ToolStripMenuItem newTsmi = new ToolStripMenuItem();
                newTsmi.Name = "tsmiPlatform_" + platform;
                newTsmi.Text = platform;
                newTsmi.CheckOnClick = true;
                if (this.Name.ToLower() == (platform + "_Form").ToLower()) newTsmi.Checked = true;
                newTsmi.Tag = platform;
                newTsmi.Click += tsmiChangePlatform_Click;
                tsmiChangePlatform.DropDownItems.Add(newTsmi);
            }
        }
        private static Bter_Form instance;
        public static Bter_Form getInstance()
        {
            if (instance == null)
            {
                instance = new Bter_Form();
            }
            return instance;
        }
        // 切换平台
        private void tsmiChangePlatform_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem currentTsmi = (ToolStripMenuItem)sender;
            if (currentTsmi.Checked == false) // 点击自己等于无效点击
            {
                currentTsmi.Checked = true;
                return;
            }
            string formName = (string)currentTsmi.Tag + "_Form";
            Form form = null;
            try
            {
                string namespaceName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                // Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
                Type type = Type.GetType(namespaceName + "." + formName);
                form = (Form)type.GetMethod("getInstance").Invoke(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            foreach (ToolStripMenuItem tsmi in tsmiChangePlatform.DropDownItems)
            {
                tsmi.Checked = false;
                if (this.Name.ToLower() == (tsmi.Tag + "_Form").ToLower()) tsmi.Checked = true;
            }
            Utility.Utility.passFormState(this, form, currentLanguageOrder, isFormMini);
            abortAutoLoadDataThread();
            ni.Visible = false;
            isActivated = false;
            form.Show();
            this.Hide();
        }
        #endregion
        #endregion
    }
}