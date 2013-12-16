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
    public partial class OKCoin_Form : Form
    {
        #region 构造器
        public OKCoin_Form()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            interval = int.Parse(txtRefreshInterval.Text);
            setNamesMap();
            setDragLabelMoveForm();
            setChangePlatform();
            currentUrl = ltcUrl;
            maxSize = this.Size;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // asyncThreadStart();
        }

        #endregion

        #region 窗口获取焦点事件
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
        // 获取数据
        void loadData()
        {
            // {"ticker":{"buy":"162.5","high":"184.4","last":"162.5","low":"141.49","sell":"162.2","vol":"6200727.0620006"}}
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
        void fillControlText()
        {
            txtLast.Text = "";
            txtHigh.Text = "";
            txtLow.Text = "";
            txtBuy.Text = "";
            txtSell.Text = "";
            txtVol.Text = "";
            try
            {
                if (jo != null)
                {
                    txtLast.Text = (string)jo["ticker"]["last"];
                    txtHigh.Text = (string)jo["ticker"]["high"];
                    txtLow.Text = (string)jo["ticker"]["low"];
                    txtBuy.Text = (string)jo["ticker"]["buy"];
                    txtSell.Text = (string)jo["ticker"]["sell"];
                    txtVol.Text = Regex.Replace((string)jo["ticker"]["vol"], @"^(.*\.\d{2}).*", "$1");
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
        // 死循环自动获取并刷新数据
        void autoLoadData()
        {
            while (true)
            {
                loadData();
                this.Invoke(new fillControlTextCallback(fillControlText));
                Thread.Sleep(interval * 1000);
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
            // Utility.Utility.isTopMost = !Utility.Utility.isTopMost;
            //this.TopMost = Utility.Utility.isTopMost ? true : false;
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
            // namesMap.Add("ErrMsg", new string[] { "ErrMsg", "预留错误信息" });
            namesMap.Add("tsmiChangeLanguage", new string[] { "中文", "English" });
            namesMap.Add("tsmiExit", new string[] { "Exit", "退出" });
            namesMap.Add("tsmiSetTopMost", new string[] { "Topmost", "置顶" });
            namesMap.Add("tsmiResizeForm", new string[] { "Resize Form", "缩小/放大界面" });
            namesMap.Add("tsmiChangeCoin", new string[] { "Btc/Ltc", "Btc/Ltc切换" });
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
        }
        #endregion

        #region 缩小/方法界面
        Size miniSize = new Size(165, 35);
        Size maxSize;
        bool isFormMini = false;
        private void tsmiResizeForm_Click(object sender, EventArgs e)
        {
            //this.Size = Utility.Utility.isFormMini ? maxSize : miniSize;
            //Utility.Utility.isFormMini = !Utility.Utility.isFormMini;
            isFormMini = !isFormMini;
            this.Size = isFormMini ? miniSize : maxSize;
        }
        #endregion

        #region 当前币&币地址&切换币
        const string ltcUrl = "https://www.okcoin.com/api/ticker.do?symbol=ltc_cny";
        const string btcUrl = "https://www.okcoin.com/api/ticker.do?symbol=btc_cny";
        string currentUrl = ltcUrl;
        // 切换货币显示
        private void tsmiChangeCoin_Click(object sender, EventArgs e)
        {
            currentUrl = currentUrl == ltcUrl ? btcUrl : ltcUrl;
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

        private static OKCoin_Form instance;
        public static OKCoin_Form getInstance()
        {
            if (instance == null)
            {
                instance = new OKCoin_Form();
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