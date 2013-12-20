using CoinView.CoinControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView
{
    public partial class MainForm : Form
    {
        #region 窗体构造和Load
        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;
            Utility.Utility.setDragMoveForm(this);
            setPlatformAndCoinSelectBtns();
            initailizeControlsContainer();
            ni.Text = Coins.getPlatform(currentPlatformIndex);
            this.ShowInTaskbar = false;
            setNamesMap();
            setLanguage(currentLanguageIndex);
            setFormSize(isFormMini);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            okCoin_Full.asyncThreadStart();
        }
        #endregion

        private int currentCoinIndex = 0;
        private int currentPlatformIndex = 0;
        private int currentLanguageIndex = 1;
        private IList<object[]> controlsContainer = new List<object[]>();// 控件容器
        private bool isFormMini = false;

        #region 切换币
        // 设置平台和币的选择按钮
        private void setPlatformAndCoinSelectBtns()
        {
            int platformIndex = 0;
            foreach (string platformName in Coins.getPlatforms())
            {
                ToolStripMenuItem tsmiPlatform = new ToolStripMenuItem();
                tsmiPlatform.Name = "tsmiPlatform_" + platformName;
                tsmiPlatform.Text = platformName;
                tsmiPlatform.CheckOnClick = true;
                if (platformName == Coins.getPlatform(currentPlatformIndex)) tsmiPlatform.Checked = true;
                tsmiPlatform.Tag = platformIndex++;//保存对应的索引

                int coinIndex = 0;
                foreach (string coinName in Coins.getCoins(platformName))
                {
                    ToolStripMenuItem tsmiCoin = new ToolStripMenuItem();
                    tsmiCoin.Name = "tsmiCoin_" + Coins.getPlatform(currentPlatformIndex) + "_" + coinName[currentCoinIndex];
                    tsmiCoin.Text = coinName.Replace("_", "/");
                    tsmiCoin.CheckOnClick = true;
                    tsmiCoin.Tag = coinIndex++;//保存对应的索引
                    tsmiCoin.Click += changeCoin;
                    tsmiPlatform.DropDownItems.Add(tsmiCoin);
                }
                if (tsmiPlatform.Checked == true) ((ToolStripMenuItem)(tsmiPlatform.DropDownItems[currentCoinIndex])).Checked = true;

                tsmiChangeCoin.DropDownItems.Add(tsmiPlatform);
            }
        }

        // 初始化控件容器
        private void initailizeControlsContainer()
        {
            controlsContainer.Add(new object[] { Coins.getPlatformIndex(Coins.Platform.OKCoin.ToString()), typeof(CoinControl.OKCoin.OKCoin_Full), okCoin_Full });
            controlsContainer.Add(new object[] { Coins.getPlatformIndex(Coins.Platform.Bter.ToString()), typeof(CoinControl.Bter.Bter_Full), null });
        }
        // 切换币事件
        private void changeCoin(object sender, EventArgs e)
        {
            ToolStripMenuItem currentTsmi = (ToolStripMenuItem)sender;
            if (currentTsmi.Checked == false) // 点击自己等于无效点击
            {
                currentTsmi.Checked = true;
                return;
            }
            // 将点击前的按钮选中状态去掉
            ToolStripMenuItem previousSelectPlatform = ((ToolStripMenuItem)tsmiChangeCoin.DropDownItems[currentPlatformIndex]);
            previousSelectPlatform.Checked = false;
            ((ToolStripMenuItem)previousSelectPlatform.DropDownItems[currentCoinIndex]).Checked = false;
            // 隐藏控件并断开连接
            Control hideControl = null;
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    hideControl = ((Control)o[2]);
                    //((Control)o[2]).Hide();
                    ((Type)o[1]).GetMethod("abortAutoLoadDataThread").Invoke(o[2], null);
                }
            }
            // 得到选择的平台和币
            currentCoinIndex = (int)((ToolStripMenuItem)sender).Tag;
            currentPlatformIndex = (int)currentTsmi.OwnerItem.Tag;
            // 将点击的按钮的选中状态选上
            ToolStripMenuItem currentSelectPlatform = ((ToolStripMenuItem)tsmiChangeCoin.DropDownItems[currentPlatformIndex]);
            currentSelectPlatform.Checked = true;
            //((ToolStripMenuItem)currentSelectPlatform.DropDownItems[currentCoinIndex]).Checked = true;
            // 遍历容器得到相应的控件实例，将其显示，并且调用控件的设置币的方法
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    if (o[2] == null) o[2] = Activator.CreateInstance(((Type)o[1]));
                    Control ctrl = o[2] as Control;
                    this.Controls.Add(ctrl);
                    ((Type)o[1]).GetMethod("setLanguage").Invoke(o[2], new object[] { currentLanguageIndex });
                    ((Type)o[1]).GetMethod("setCurrentCoin").Invoke(o[2], new object[] { currentCoinIndex });
                    this.MinimumSize = ctrl.MinimumSize;
                    this.MaximumSize = new Size(ctrl.Width, ctrl.MaximumSize.Height + User32.GetSystemMetrics(User32.SM_CYCAPTION) + 10);
                    setFormSize(isFormMini);
                    ctrl.Location = new Point(0, 0);
                    ctrl.Show();
                    if (hideControl != ctrl) hideControl.Hide();
                }
            }
            ni.Text = Coins.getPlatform(currentPlatformIndex);
        }
        #endregion

        #region 置顶
        private void tsmiSetTopMost_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
        #endregion

        #region 切换中英文
        private IDictionary<string, string[]> namesMap = new Dictionary<string, string[]>();
        //设置控件文本中英文组合
        private void setNamesMap()
        {
            namesMap.Add("tsmiChangeLanguage", new string[] { "中文", "English" });
            namesMap.Add("tsmiExit", new string[] { "Exit", "退出" });
            namesMap.Add("tsmiSetTopMost", new string[] { "TopMost", "置顶" });
            namesMap.Add("tsmiResizeForm", new string[] { "Resize Form", "缩小/放大界面" });
            namesMap.Add("tsmiChangeCoin", new string[] { "Change Coin", "币切换" });
            namesMap.Add("tsmiChangePlatform", new string[] { "Change Platform", "切换平台" });
            namesMap.Add("tsmiShowOrHideForm", new string[] { "Show/Hide", "显示/隐藏" });
        }

        private void tsmiChangeLanguage_Click(object sender, EventArgs e)
        {
            currentLanguageIndex = currentLanguageIndex == 0 ? 1 : 0;
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    ((Type)o[1]).GetMethod("setLanguage").Invoke(o[2], new object[] { currentLanguageIndex });
                }
            }
            setLanguage(currentLanguageIndex);
        }

        private void setLanguage(int languageIndex)
        {
            foreach (ToolStripMenuItem tsmi in this.cmsForm.Items)
            {
                foreach (string key in namesMap.Keys)
                {
                    if (tsmi.Name.ToLower() == key.ToLower())
                    {
                        tsmi.Text = namesMap[key][languageIndex];
                    }
                }
            }
        }
        #endregion

        #region 缩小/放大界面
        private void tsmiResizeForm_Click(object sender, EventArgs e)
        {
            isFormMini = !isFormMini;
            setFormSize(isFormMini);
        }
        private void setFormSize(bool isFormMini)
        {
            if (isFormMini)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = getControlMiniSize();
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Size = new Size(getControlMaxSize().Width, getControlMaxSize().Height + User32.GetSystemMetrics(User32.SM_CYCAPTION) + 10);
            }
        }

        private Size getControlMiniSize()
        {
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    return ((Control)o[2]).MinimumSize;
                }
            }
            return new Size();
        }

        private Size getControlMaxSize()
        {
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    return ((Control)o[2]).MaximumSize;
                }
            }
            return new Size();
        }
        #endregion

        #region 退出
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            ni = null;
            this.Dispose();
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (object[] o in controlsContainer)
            {
                if (currentPlatformIndex == (int)o[0])
                {
                    ((Type)o[1]).GetMethod("abortAutoLoadDataThread").Invoke(o[2], null);
                }
            }
        }
        #endregion

        #region 窗体最小化
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void tsmiShowOrHideForm_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        #endregion

    }
}
