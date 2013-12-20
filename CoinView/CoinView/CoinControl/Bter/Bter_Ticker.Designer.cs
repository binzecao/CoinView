namespace CoinView.CoinControl.Bter
{
    partial class Bter_Ticker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            abortAutoLoadDataThread();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ttlblErrMsg = new System.Windows.Forms.ToolTip(this.components);
            this.lblVol_CURR_B = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.txtAvg = new System.Windows.Forms.TextBox();
            this.txtVol_CURR_B = new System.Windows.Forms.TextBox();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.lblVol_CURR_A = new System.Windows.Forms.Label();
            this.txtVol_CURR_A = new System.Windows.Forms.TextBox();
            this.lblLow = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.lblHigh = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.lblSell = new System.Windows.Forms.Label();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.lblBuy = new System.Windows.Forms.Label();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblVol_CURR_B
            // 
            this.lblVol_CURR_B.AutoSize = true;
            this.lblVol_CURR_B.Location = new System.Drawing.Point(458, 38);
            this.lblVol_CURR_B.Name = "lblVol_CURR_B";
            this.lblVol_CURR_B.Size = new System.Drawing.Size(95, 12);
            this.lblVol_CURR_B.TabIndex = 43;
            this.lblVol_CURR_B.Text = "成交量(CURR_B):";
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(299, 38);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(59, 12);
            this.lblAvg.TabIndex = 41;
            this.lblAvg.Text = "平均价格:";
            // 
            // txtAvg
            // 
            this.txtAvg.Location = new System.Drawing.Point(359, 35);
            this.txtAvg.Name = "txtAvg";
            this.txtAvg.Size = new System.Drawing.Size(83, 21);
            this.txtAvg.TabIndex = 40;
            // 
            // txtVol_CURR_B
            // 
            this.txtVol_CURR_B.Location = new System.Drawing.Point(547, 33);
            this.txtVol_CURR_B.Name = "txtVol_CURR_B";
            this.txtVol_CURR_B.Size = new System.Drawing.Size(102, 21);
            this.txtVol_CURR_B.TabIndex = 42;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(167, 70);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 38;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(125, 70);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 37;
            this.lblSecond.Text = "秒";
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(12, 70);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 36;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(78, 67);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 35;
            this.txtRefreshInterval.Text = "5";
            this.txtRefreshInterval.TextChanged += new System.EventHandler(this.txtRefreshInterval_TextChanged);
            this.txtRefreshInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshInterval_KeyPress);
            // 
            // lblVol_CURR_A
            // 
            this.lblVol_CURR_A.AutoSize = true;
            this.lblVol_CURR_A.Location = new System.Drawing.Point(458, 9);
            this.lblVol_CURR_A.Name = "lblVol_CURR_A";
            this.lblVol_CURR_A.Size = new System.Drawing.Size(95, 12);
            this.lblVol_CURR_A.TabIndex = 34;
            this.lblVol_CURR_A.Text = "成交量(CURR_A):";
            // 
            // txtVol_CURR_A
            // 
            this.txtVol_CURR_A.Location = new System.Drawing.Point(547, 6);
            this.txtVol_CURR_A.Name = "txtVol_CURR_A";
            this.txtVol_CURR_A.Size = new System.Drawing.Size(102, 21);
            this.txtVol_CURR_A.TabIndex = 33;
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(167, 38);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(35, 12);
            this.lblLow.TabIndex = 32;
            this.lblLow.Text = "最低:";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(208, 35);
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(83, 21);
            this.txtLow.TabIndex = 31;
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(12, 38);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(35, 12);
            this.lblHigh.TabIndex = 30;
            this.lblHigh.Text = "最高:";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(64, 35);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(83, 21);
            this.txtHigh.TabIndex = 29;
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.Location = new System.Drawing.Point(317, 9);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(35, 12);
            this.lblSell.TabIndex = 28;
            this.lblSell.Text = "卖一:";
            // 
            // txtSell
            // 
            this.txtSell.Location = new System.Drawing.Point(358, 6);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(83, 21);
            this.txtSell.TabIndex = 27;
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(187, 9);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(35, 12);
            this.lblBuy.TabIndex = 26;
            this.lblBuy.Text = "买一:";
            // 
            // txtBuy
            // 
            this.txtBuy.Location = new System.Drawing.Point(228, 6);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(83, 21);
            this.txtBuy.TabIndex = 25;
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(12, 9);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(59, 12);
            this.lblLast.TabIndex = 24;
            this.lblLast.Text = "最新成交:";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(77, 6);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(83, 21);
            this.txtLast.TabIndex = 23;
            // 
            // Bter_Ticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVol_CURR_B);
            this.Controls.Add(this.lblAvg);
            this.Controls.Add(this.txtAvg);
            this.Controls.Add(this.txtVol_CURR_B);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblRefreshInterval);
            this.Controls.Add(this.txtRefreshInterval);
            this.Controls.Add(this.lblVol_CURR_A);
            this.Controls.Add(this.txtVol_CURR_A);
            this.Controls.Add(this.lblLow);
            this.Controls.Add(this.txtLow);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.txtHigh);
            this.Controls.Add(this.lblSell);
            this.Controls.Add(this.txtSell);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.txtBuy);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.txtLast);
            this.Name = "Bter_Ticker";
            this.Size = new System.Drawing.Size(664, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttlblErrMsg;
        private System.Windows.Forms.Label lblVol_CURR_B;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.TextBox txtAvg;
        private System.Windows.Forms.TextBox txtVol_CURR_B;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label lblVol_CURR_A;
        private System.Windows.Forms.TextBox txtVol_CURR_A;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TextBox txtLast;
    }
}
