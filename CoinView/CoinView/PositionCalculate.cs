using CoinView.CoinControl;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView
{
    public partial class PositionCalculate : Form
    {
        #region 窗体事件
        public PositionCalculate()
        {
            InitializeComponent();
            dgv1.MultiSelect = false;
            currentCoinIndex = Coins.getCoinIndex(Coins.Platform.OKCoin, "ltc_cny");
            asyncThreadStart();
        }

        private void PositionCalculate_FormClosing(object sender, FormClosingEventArgs e)
        {
            abortAutoLoadDataThread();
        }
        #endregion

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
                if (jo != null)
                {
                    // {"ticker":{"buy":"162.5","high":"184.4","last":"162.5","low":"141.49","sell":"162.2","vol":"6200727.0620006"}}
                    txtCurrentPrice.Text = (string)jo["ticker"]["last"];
                    setTotalMoney();
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

        #region dgv事件
        // 为可输入的单元格中的控件添加事件
        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell.OwningColumn == dgvcSinglePrice)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyPress -= new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.TextChanged -= new EventHandler(SinglePrice_TextChanged);
                tb.TextChanged += new EventHandler(SinglePrice_TextChanged);
            }
            if (currentCell.OwningColumn == dgvcWeight)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyPress -= new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.TextChanged -= new EventHandler(Weight_TextChanged);
                tb.TextChanged += new EventHandler(Weight_TextChanged);
            }

        }

        // 限制输入数字
        private void DataGridViewTextBoxCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ikc = (int)e.KeyChar;
            if ((!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]")) && ikc != 46 && ikc != 8)
            {
                e.Handled = true;
                return;
            }
            TextBox tb = sender as TextBox;
            if (ikc == 46 && tb.Text.Length - tb.Text.Replace(".", "").Length > 0)
            {
                e.Handled = true;
                return;
            }
        }

        private void SinglePrice_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = sender as DataGridViewTextBoxEditingControl;
            DataGridView dgv = tb.EditingControlDataGridView;

            if (dgv.CurrentCell.OwningColumn != dgvcSinglePrice) return;

            dgv.CurrentCell.Value = tb.Text;
            checkWeight(dgv.CurrentRow);
            calculateARow(dgv.CurrentRow);
            summarize();
        }

        private void Weight_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = sender as DataGridViewTextBoxEditingControl;
            DataGridView dgv = tb.EditingControlDataGridView;

            if (dgv.CurrentCell.OwningColumn != dgvcWeight) return;
            dgv.CurrentCell.Value = tb.Text;

            checkWeight(dgv.CurrentRow);
            calculateARow(dgv.CurrentRow);
            summarize();
        }
        #endregion

        #region 计算
        // 检查权重
        private void checkWeight(DataGridViewRow row)
        {
            decimal weight;
            if (decimal.TryParse(row.Cells["dgvcWeight"].Value + "", out weight))
            {
                decimal leftoverWeight = 0m;
                decimal temp;
                foreach (DataGridViewRow item in dgv1.Rows)
                {
                    if (item == row) break;
                    decimal.TryParse(item.Cells["dgvcWeight"].Value + "", out temp);
                    leftoverWeight += temp;
                }
                leftoverWeight = (decimal)1 - leftoverWeight;
                if (weight > leftoverWeight)
                {
                    row.Cells["dgvcWeight"].ErrorText = " Weight must be less than or equal to " + leftoverWeight;
                }
                else
                {
                    row.Cells["dgvcWeight"].ErrorText = "";
                }
            }
        }

        // 计算一行的Amount和Total
        private void calculateARow(DataGridViewRow row)
        {
            // 输入项没填，清空后面的统计项
            if (string.IsNullOrWhiteSpace(row.Cells["dgvcSinglePrice"].Value as string) || string.IsNullOrWhiteSpace(row.Cells["dgvcWeight"].Value as string))
            {
                row.Cells["dgvcTotal"].Value = "";
                row.Cells["dgvcAmount"].Value = "";
                return;
            }

            decimal amount;
            decimal total;
            decimal singlePrice;
            decimal weight;
            decimal balance;

            decimal.TryParse(row.Cells["dgvcSinglePrice"].Value + "", out singlePrice);
            decimal.TryParse(row.Cells["dgvcWeight"].Value + "", out weight);
            decimal.TryParse(txtBalance.Text, out balance);

            total = weight * balance;
            if (singlePrice == 0)
            {
                row.Cells["dgvcAmount"].Value = "NAN";
            }
            else
            {
                amount = total / singlePrice;
                row.Cells["dgvcAmount"].Value = amount;
            }

            row.Cells["dgvcTotal"].Value = total;
        }

        // 汇总计算
        private void summarize()
        {
            decimal temp;
            decimal totalAmount = 0m;
            decimal leftoverWeight = 0m;
            decimal sum = 0m;
            foreach (DataGridViewRow item in dgv1.Rows)
            {
                decimal.TryParse(item.Cells["dgvcWeight"].Value + "", out temp);
                leftoverWeight += temp;
                decimal.TryParse(item.Cells["dgvcAmount"].Value + "", out temp);
                totalAmount += temp;
                decimal.TryParse(item.Cells["dgvcTotal"].Value + "", out temp);
                sum += temp;
            }
            leftoverWeight = 1 - leftoverWeight;
            txtLeftoverWeight.Text = leftoverWeight.ToString();
            txtTotalAmount.Text = totalAmount.ToString();
            if (totalAmount != 0)
            {
                decimal avgSinglePrice = sum / totalAmount;
                txtAvgSinglePrice.Text = avgSinglePrice.ToString();
            }
            else
            {
                txtAvgSinglePrice.Text = "NAN";
            }
            setTotalMoney();
        }

        // 计算总资产
        private void setTotalMoney()
        {
            decimal currentPrice;
            decimal.TryParse(txtCurrentPrice.Text, out currentPrice);
            decimal totalAmount;
            decimal.TryParse(txtTotalAmount.Text, out totalAmount);

            decimal leftoverWeight;
            decimal.TryParse(txtLeftoverWeight.Text, out leftoverWeight);

            decimal balance;
            decimal.TryParse(txtBalance.Text, out balance);

            decimal totalMoney = currentPrice * totalAmount + leftoverWeight * balance;
            txtTotalMoney.Text = totalMoney.ToString();
        }
        #endregion

        #region 右键
        private void tsmiCalculateTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                checkWeight(dgv1.Rows[i]);
                calculateARow(dgv1.Rows[i]);
            }
            summarize();
        }


        private void tsmiClearSelectedRow_Click(object sender, EventArgs e)
        {
            object o = dgv1.SelectedRows;
            if (dgv1.CurrentRow == null) return;
            if (dgv1.CurrentRow.IsNewRow) return;
            dgv1.Rows.Remove(dgv1.CurrentRow);
        }

        private void tsmiClearAllRows_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
        }
        #endregion

    }
}
