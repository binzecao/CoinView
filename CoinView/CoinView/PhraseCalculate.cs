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
    public partial class PhraseCalculate : Form
    {
        #region 窗体事件
        public PhraseCalculate()
        {
            InitializeComponent();
            dgv1.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv1.MultiSelect = false;
        }

        private void PhraseCalculate_Load(object sender, EventArgs e)
        {
            txtBalance.Text = "2.52";
            txtCoinAmount.Text = "2.69";
            txtChargeFree.Text = "0";
            txtTradeFree.Text = "0.002";
            txtWithDrawalFee.Text = "0.01";
            currentCoinIndex = Coins.getCoinIndex(Coins.Platform.OKCoin, "ltc_cny");
            asyncThreadStart();

        }

        private void PhraseCalculate_FormClosing(object sender, FormClosingEventArgs e)
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

        #region 计算总资产
        private void setTotalMoney()
        {
            decimal currentPrice;
            decimal balance;
            decimal coinAmount;
            decimal.TryParse(txtCurrentPrice.Text, out currentPrice);
            decimal.TryParse(txtBalance.Text, out balance);
            decimal.TryParse(txtCoinAmount.Text, out coinAmount);

            txtTotalMoney.Text = currentPrice * coinAmount + balance + "";
        }
        #endregion

        #region dgv事件
        // 设置单元格默认值
        private void dgv1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            decimal tradeFreeRatio;
            decimal.TryParse(txtTradeFree.Text, out tradeFreeRatio);
            e.Row.Cells["dgvcTradeFreeRatio"].Value = tradeFreeRatio;
        }

        // 为可输入的单元格中的控件添加事件
        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell.OwningColumn == dgvcAmount)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyPress -= new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.TextChanged -= new EventHandler(Amount_TextChanged);
                tb.TextChanged += new EventHandler(Amount_TextChanged);
            }
            if (currentCell.OwningColumn == dgvcSinglePrice)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyPress -= new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.TextChanged -= new EventHandler(SinglePrice_TextChanged);
                tb.TextChanged += new EventHandler(SinglePrice_TextChanged);
            }
            if (currentCell.OwningColumn == dgvcType)
            {
                DataGridViewComboBoxEditingControl cb = e.Control as DataGridViewComboBoxEditingControl;
                cb.SelectedIndexChanged -= new EventHandler(Type_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(Type_SelectedIndexChanged);
            }
            if (currentCell.OwningColumn == dgvcTradeFreeRatio)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyPress -= new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBoxCell_KeyPress);
                tb.TextChanged -= new EventHandler(TradeFreeRatio_TextChanged);
                tb.TextChanged += new EventHandler(TradeFreeRatio_TextChanged);
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
            //bug: 三个TextBox都添加了各自相应的TextChanged事件后，这个TextBox的事件会加上了不属于自己的TextChanged事件，变为会促发三个事件
            //bug2:进入单元格都会促发原事件
            if (dgv.CurrentCell.OwningColumn != dgvcSinglePrice)
            {
                //tb.TextChanged -= SinglePrice_TextChanged;
                return;
            }
            dgv.CurrentCell.Value = tb.Text;
            checkAmount(dgv.CurrentRow);
            calculateATrade(dgv.CurrentRow);
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = sender as DataGridViewTextBoxEditingControl;
            DataGridView dgv = tb.EditingControlDataGridView;
            //bug: 三个TextBox都添加了各自相应的TextChanged事件后，这个TextBox的事件会加上了不属于自己的TextChanged事件，变为会促发三个事件
            //bug2:进入单元格都会促发原事件
            if (dgv.CurrentCell.OwningColumn != dgvcAmount)
            {
                //tb.TextChanged -= Amount_TextChanged;
                return;
            }
            dgv.CurrentCell.Value = tb.Text;
            checkAmount(dgv.CurrentRow);
            calculateATrade(dgv.CurrentRow);
        }

        private void TradeFreeRatio_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = sender as DataGridViewTextBoxEditingControl;
            DataGridView dgv = tb.EditingControlDataGridView;
            //bug: 三个TextBox都添加了各自相应的TextChanged事件后，这个TextBox的事件会加上了不属于自己的TextChanged事件，变为会促发三个事件
            //bug2:进入单元格都会促发原事件
            if (dgv.CurrentCell.OwningColumn != dgvcTradeFreeRatio)
            {
                //tb.TextChanged -= Amount_TextChanged;
                //tb.TextChanged -= SinglePrice_TextChanged;
                return;
            }
            dgv.CurrentCell.Value = tb.Text;
            checkAmount(dgv.CurrentRow);
            calculateATrade(dgv.CurrentRow);
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl cb = sender as DataGridViewComboBoxEditingControl;
            DataGridView dgv = cb.EditingControlDataGridView;
            dgv.CurrentCell.Value = cb.SelectedItem.ToString();
            checkAmount(dgv.CurrentRow);
            calculateATrade(dgv.CurrentRow);
        }

        // 检查Amount输入(未加上手续费的判断)
        private void checkAmount(DataGridViewRow row)
        {
            if (row.Cells["dgvcType"].Value == null) return;
            bool isBuy = row.Cells["dgvcType"].Value + "" == "buy" ? true : false; // 是否是买

            bool isFirstRow = row.Index == 0; //该行是否是第一行

            decimal inputAmount;// 用户输入的数量
            decimal.TryParse(row.Cells["dgvcAmount"].Value + "", out inputAmount);

            decimal singlePrice;// 输入的单价
            decimal.TryParse(row.Cells["dgvcSinglePrice"].Value + "", out singlePrice);

            decimal maxAmount;// 实际上最多可输入的数量

            if (singlePrice != 0) // 输入的单价不是0
            {
                if (!isBuy) // sell
                {
                    // 得到maxAmount
                    if (isFirstRow)
                    {
                        decimal.TryParse(txtCoinAmount.Text, out maxAmount);
                    }
                    else
                    {
                        decimal.TryParse((dgv1.Rows[row.Index - 1].Cells["dgvcNewCoinAmount"].Value + ""), out maxAmount);
                    }
                }
                else // buy
                {
                    decimal balance;// 上一期 余额
                    if (isFirstRow)
                    {
                        decimal.TryParse(txtBalance.Text, out balance);
                    }
                    else
                    {
                        decimal.TryParse((dgv1.Rows[row.Index - 1].Cells["dgvcNewBalance"].Value + ""), out balance);
                    }
                    // 计算maxAmount
                    maxAmount = balance / singlePrice;
                }
                // 判断输入是否超过最大，超过后提示，不超过不提示
                if (inputAmount > maxAmount)
                {
                    row.Cells["dgvcAmount"].ErrorText = " amount must be less than or equal to " + maxAmount;
                }
                else
                {
                    row.Cells["dgvcAmount"].ErrorText = "";
                }
            }
        }

        // 计算
        private void calculateATrade(DataGridViewRow row)
        {
            // 三个输入项没填，清空后面的统计项
            if (string.IsNullOrWhiteSpace(row.Cells["dgvcSinglePrice"].Value as string) || string.IsNullOrWhiteSpace(row.Cells["dgvcAmount"].Value as string) ||
                string.IsNullOrWhiteSpace(row.Cells["dgvcType"].Value as string))
            {
                row.Cells["dgvcTotal"].Value = "";
                row.Cells["dgvcTradeFree"].Value = "";
                row.Cells["dgvcNewBalance"].Value = "";
                row.Cells["dgvcNewCoinAmount"].Value = "";
                row.Cells["dgvcNewTotalMoney"].Value = "";
                return;
            }

            decimal singlePrice;
            decimal.TryParse(row.Cells["dgvcSinglePrice"].Value + "", out singlePrice);

            decimal amount;
            decimal.TryParse(row.Cells["dgvcAmount"].Value + "", out amount);

            // 计算这一笔的总价
            decimal total = singlePrice * amount;

            decimal tradeFreeRatio;
            decimal.TryParse(row.Cells["dgvcTradeFreeRatio"].Value + "", out tradeFreeRatio); // 交易手续费率

            decimal newBalance;
            decimal newCoinAmount;
            decimal newTotalMoney;
            decimal tradeFree;
            decimal currentPrice;

            // 获取上一期的钱的余额和Coin的余额
            if (row.Index == 0) // 判断是否是第一行
            {
                decimal.TryParse(txtBalance.Text, out newBalance);
                decimal.TryParse(txtCoinAmount.Text, out newCoinAmount);
            }
            else
            {
                decimal.TryParse(dgv1.Rows[row.Index - 1].Cells["dgvcNewBalance"].Value + "", out newBalance);
                decimal.TryParse(dgv1.Rows[row.Index - 1].Cells["dgvcNewCoinAmount"].Value + "", out newCoinAmount);
            }
            decimal.TryParse(txtCurrentPrice.Text, out currentPrice); //最新价格

            bool isBuy = row.Cells["dgvcType"].Value + "" == "buy" ? true : false; // 是否是买

            tradeFree = total * tradeFreeRatio;
            newBalance += (isBuy ? -total : total) - tradeFree;
            newCoinAmount += isBuy ? amount : -amount;
            newTotalMoney = newBalance + newCoinAmount * currentPrice;

            row.Cells["dgvcTotal"].Value = total;
            row.Cells["dgvcTradeFree"].Value = tradeFree;
            row.Cells["dgvcNewBalance"].Value = newBalance;
            row.Cells["dgvcNewCoinAmount"].Value = newCoinAmount;
            row.Cells["dgvcNewTotalMoney"].Value = newTotalMoney;
        }

        // 计算整个表
        private void calculateAll()
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                checkAmount(dgv1.Rows[i]);
                calculateATrade(dgv1.Rows[i]);
            }
        }
        #endregion

        #region 提现
        private void btnWithDrawal_Click(object sender, EventArgs e)
        {
            decimal balance;
            decimal.TryParse(txtBalance.Text, out balance);
            decimal WithDrawalFree;
            decimal.TryParse(txtWithDrawalFee.Text, out WithDrawalFree);

            balance *= (1 - WithDrawalFree);
            MessageBox.Show(balance.ToString());
        }
        #endregion

        #region 右键
        private void tsmiClearAllRows_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
        }

        private void tsmiClearThisRow_Click(object sender, EventArgs e)
        {
            object o = dgv1.SelectedRows;
            if (dgv1.CurrentRow == null) return;
            if (dgv1.CurrentRow.IsNewRow) return;
            dgv1.Rows.Remove(dgv1.CurrentRow);
        }

        private void dgv1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;// 防止点击列头报错
                dgv1.CurrentCell = dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void tsmiCalculateTable_Click(object sender, EventArgs e)
        {
            calculateAll();
        }
        #endregion

        private void btnPositionCalculate_Click(object sender, EventArgs e)
        {
            new PositionCalculate().Show();
        }


    }
}
