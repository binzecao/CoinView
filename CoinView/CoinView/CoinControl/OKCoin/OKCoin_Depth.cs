﻿using System;
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
using System.Threading;

namespace CoinView.CoinControl.OKCoin
{
    public partial class OKCoin_Depth : UserControl, ICoinControl
    {
        public OKCoin_Depth()
        {
            InitializeComponent();
            Utility.Utility.setDragMoveForm(this);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        #region 获取数据&刷新显示
        public const string url = "https://www.okcoin.com/api/depth.do?symbol=[CURR_A]_[CURR_B]";
        private int currentCoinIndex;
        private JObject jo_depth; // 暂时存放json数据,两种价格都是从高到低
        private string errMsg; // 暂时存放错误信息
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
                    jo_depth = JObject.Parse(rtnJson);
                    sr.Close();
                }
                errMsg = "";
            }
            catch (Exception ex)
            {
                jo_depth = null;
                errMsg = ex.Message;
            }
        }
        // 将获取的数据填入各表单中
        private void fillControlsData()
        {
            dgvBids.Rows.Clear();
            dgvAsks.Rows.Clear();
            try
            {
                if (jo_depth != null)
                {
                    fillDgvBids();
                    fillDgvAsks();
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

        private delegate void fillControlTextCallback(); //设置数据的委托
        private Thread autoLoadDataThread; // 自动刷新数据的线程
        private int interval; // 刷新时间间隔
        // 死循环自动获取并刷新数据
        private void autoLoadData()
        {
            while (true)
            {
                loadData();
                this.Invoke(new fillControlTextCallback(fillControlsData));
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
        // 填充数据到dgv中
        private void fillDgvBids()
        {
            //dgvBids.Rows.Clear();
            int index = 1;
            double defaultHighLight;
            double.TryParse(txtBidsHighLight.Text, out defaultHighLight);
            foreach (object o in jo_depth["bids"])
            {
                JArray bid = (JArray)o;
                DataGridViewRow dgvr = new DataGridViewRow();
                DataGridViewTextBoxCell dgvcellBidOrder = new DataGridViewTextBoxCell();
                dgvcellBidOrder.Value = "买(" + index++ + ")";
                DataGridViewTextBoxCell dgvcellBidSinglePrice = new DataGridViewTextBoxCell();
                dgvcellBidSinglePrice.Value = bid[0];
                DataGridViewTextBoxCell dgvcellBidVol = new DataGridViewTextBoxCell();
                dgvcellBidVol.Value = bid[1];
                DataGridViewTextBoxCell dgvcellBidTotal = new DataGridViewTextBoxCell();
                double totel = (double)bid[0] * (double)bid[1];
                dgvcellBidTotal.Value = totel;

                if (defaultHighLight > 0 && totel > defaultHighLight) dgvcellBidTotal.Style.BackColor = Color.Pink;

                dgvr.Cells.Add(dgvcellBidOrder);
                dgvr.Cells.Add(dgvcellBidSinglePrice);
                dgvr.Cells.Add(dgvcellBidVol);
                dgvr.Cells.Add(dgvcellBidTotal);
                dgvBids.Rows.Add(dgvr);
                dgvBids.ClearSelection();
            }
        }
        // 填充数据到dgv中
        private void fillDgvAsks()
        {
            //dgvAsks.Rows.Clear();
            int index = jo_depth["asks"].Count();
            double defaultHighLight;
            double.TryParse(txtAsksHighLight.Text, out defaultHighLight);
            foreach (object o in jo_depth["asks"])
            {
                JArray ask = (JArray)o;
                DataGridViewRow dgvr = new DataGridViewRow();
                DataGridViewTextBoxCell dgvcellAskOrder = new DataGridViewTextBoxCell();
                dgvcellAskOrder.Value = "卖(" + index-- + ")";
                DataGridViewTextBoxCell dgvcellAskSinglePrice = new DataGridViewTextBoxCell();
                dgvcellAskSinglePrice.Value = ask[0];
                DataGridViewTextBoxCell dgvcellAskVol = new DataGridViewTextBoxCell();
                dgvcellAskVol.Value = ask[1];
                DataGridViewTextBoxCell dgvcellAskTotal = new DataGridViewTextBoxCell();
                double totel = (double)ask[0] * (double)ask[1];
                dgvcellAskTotal.Value = totel;

                if (defaultHighLight > 0 && totel > defaultHighLight) dgvcellAskTotal.Style.BackColor = Color.Pink;

                dgvr.Cells.Add(dgvcellAskOrder);
                dgvr.Cells.Add(dgvcellAskSinglePrice);
                dgvr.Cells.Add(dgvcellAskVol);
                dgvr.Cells.Add(dgvcellAskTotal);
                dgvAsks.Rows.Insert(0, dgvr);
                dgvAsks.ClearSelection();
            }
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
