namespace CoinView.CoinControl.OKCoin
{
    partial class OKCoin_Ticker
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
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.lblVol = new System.Windows.Forms.Label();
            this.txtVol = new System.Windows.Forms.TextBox();
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
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(167, 70);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 34;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(125, 70);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 33;
            this.lblSecond.Text = "秒";
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(12, 70);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 32;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(78, 67);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 31;
            this.txtRefreshInterval.Text = "5";
            this.txtRefreshInterval.TextChanged += new System.EventHandler(this.txtRefreshInterval_TextChanged);
            this.txtRefreshInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshInterval_KeyPress);
            // 
            // lblVol
            // 
            this.lblVol.AutoSize = true;
            this.lblVol.Location = new System.Drawing.Point(297, 38);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(95, 12);
            this.lblVol.TabIndex = 30;
            this.lblVol.Text = "成交量(CURR_A):";
            // 
            // txtVol
            // 
            this.txtVol.Location = new System.Drawing.Point(376, 35);
            this.txtVol.Name = "txtVol";
            this.txtVol.Size = new System.Drawing.Size(108, 21);
            this.txtVol.TabIndex = 29;
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(167, 38);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(35, 12);
            this.lblLow.TabIndex = 28;
            this.lblLow.Text = "最低:";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(208, 35);
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(83, 21);
            this.txtLow.TabIndex = 27;
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(12, 38);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(35, 12);
            this.lblHigh.TabIndex = 26;
            this.lblHigh.Text = "最高:";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(64, 35);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(83, 21);
            this.txtHigh.TabIndex = 25;
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.Location = new System.Drawing.Point(317, 9);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(35, 12);
            this.lblSell.TabIndex = 24;
            this.lblSell.Text = "卖一:";
            // 
            // txtSell
            // 
            this.txtSell.Location = new System.Drawing.Point(358, 6);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(83, 21);
            this.txtSell.TabIndex = 23;
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(187, 9);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(35, 12);
            this.lblBuy.TabIndex = 22;
            this.lblBuy.Text = "买一:";
            // 
            // txtBuy
            // 
            this.txtBuy.Location = new System.Drawing.Point(228, 6);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(83, 21);
            this.txtBuy.TabIndex = 21;
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(12, 9);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(59, 12);
            this.lblLast.TabIndex = 20;
            this.lblLast.Text = "最新成交:";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(77, 6);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(83, 21);
            this.txtLast.TabIndex = 19;
            // 
            // OKCoin_Ticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblRefreshInterval);
            this.Controls.Add(this.txtRefreshInterval);
            this.Controls.Add(this.lblVol);
            this.Controls.Add(this.txtVol);
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
            this.Name = "OKCoin_Ticker";
            this.Size = new System.Drawing.Size(498, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttlblErrMsg;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label lblVol;
        private System.Windows.Forms.TextBox txtVol;
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
