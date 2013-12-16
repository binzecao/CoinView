namespace CoinView
{
    partial class OKCoin_Form
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OKCoin_Form));
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblBuy = new System.Windows.Forms.Label();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.lblSell = new System.Windows.Forms.Label();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.lblHigh = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.lblLow = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.lblVol = new System.Windows.Forms.Label();
            this.txtVol = new System.Windows.Forms.TextBox();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.cmsForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChangeCoin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePlatform = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResizeForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.ttlblErrMsg = new System.Windows.Forms.ToolTip(this.components);
            this.cmsForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(77, 6);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(83, 21);
            this.txtLast.TabIndex = 2;
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(12, 9);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(59, 12);
            this.lblLast.TabIndex = 3;
            this.lblLast.Text = "最新成交:";
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(187, 9);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(35, 12);
            this.lblBuy.TabIndex = 5;
            this.lblBuy.Text = "买一:";
            // 
            // txtBuy
            // 
            this.txtBuy.Location = new System.Drawing.Point(228, 6);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(83, 21);
            this.txtBuy.TabIndex = 4;
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.Location = new System.Drawing.Point(317, 9);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(35, 12);
            this.lblSell.TabIndex = 7;
            this.lblSell.Text = "卖一:";
            // 
            // txtSell
            // 
            this.txtSell.Location = new System.Drawing.Point(358, 6);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(83, 21);
            this.txtSell.TabIndex = 6;
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(12, 38);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(35, 12);
            this.lblHigh.TabIndex = 9;
            this.lblHigh.Text = "最高:";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(64, 35);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(83, 21);
            this.txtHigh.TabIndex = 8;
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(167, 38);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(35, 12);
            this.lblLow.TabIndex = 11;
            this.lblLow.Text = "最低:";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(208, 35);
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(83, 21);
            this.txtLow.TabIndex = 10;
            // 
            // lblVol
            // 
            this.lblVol.AutoSize = true;
            this.lblVol.Location = new System.Drawing.Point(297, 38);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(47, 12);
            this.lblVol.TabIndex = 13;
            this.lblVol.Text = "成交量:";
            // 
            // txtVol
            // 
            this.txtVol.Location = new System.Drawing.Point(350, 35);
            this.txtVol.Name = "txtVol";
            this.txtVol.Size = new System.Drawing.Size(83, 21);
            this.txtVol.TabIndex = 12;
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(78, 67);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 14;
            this.txtRefreshInterval.Text = "5";
            this.txtRefreshInterval.TextChanged += new System.EventHandler(this.txtRefreshInterval_TextChanged);
            this.txtRefreshInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshInterval_KeyPress);
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(12, 70);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 15;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(125, 70);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 16;
            this.lblSecond.Text = "秒";
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(167, 70);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 17;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // cmsForm
            // 
            this.cmsForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangeCoin,
            this.tsmiChangePlatform,
            this.tsmiChangeLanguage,
            this.tsmiSetTopMost,
            this.tsmiResizeForm,
            this.tsmiExit});
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(149, 136);
            // 
            // tsmiChangeCoin
            // 
            this.tsmiChangeCoin.Name = "tsmiChangeCoin";
            this.tsmiChangeCoin.Size = new System.Drawing.Size(148, 22);
            this.tsmiChangeCoin.Text = "Btc/Ltc切换";
            this.tsmiChangeCoin.Click += new System.EventHandler(this.tsmiChangeCoin_Click);
            // 
            // tsmiChangePlatform
            // 
            this.tsmiChangePlatform.Name = "tsmiChangePlatform";
            this.tsmiChangePlatform.Size = new System.Drawing.Size(148, 22);
            this.tsmiChangePlatform.Text = "切换平台";
            // 
            // tsmiChangeLanguage
            // 
            this.tsmiChangeLanguage.Name = "tsmiChangeLanguage";
            this.tsmiChangeLanguage.Size = new System.Drawing.Size(148, 22);
            this.tsmiChangeLanguage.Text = "中英切换";
            this.tsmiChangeLanguage.Click += new System.EventHandler(this.tsmiChangeLanguage_Click);
            // 
            // tsmiSetTopMost
            // 
            this.tsmiSetTopMost.Checked = true;
            this.tsmiSetTopMost.CheckOnClick = true;
            this.tsmiSetTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiSetTopMost.Name = "tsmiSetTopMost";
            this.tsmiSetTopMost.Size = new System.Drawing.Size(148, 22);
            this.tsmiSetTopMost.Text = "置顶";
            this.tsmiSetTopMost.Click += new System.EventHandler(this.tsmiSetTopMost_Click);
            // 
            // tsmiResizeForm
            // 
            this.tsmiResizeForm.Name = "tsmiResizeForm";
            this.tsmiResizeForm.Size = new System.Drawing.Size(148, 22);
            this.tsmiResizeForm.Text = "缩小/放大界面";
            this.tsmiResizeForm.Click += new System.EventHandler(this.tsmiResizeForm_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(148, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(166, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 12);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // ni
            // 
            this.ni.ContextMenuStrip = this.cmsForm;
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "OKCoin";
            this.ni.Visible = true;
            // 
            // OKCoin_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 94);
            this.ContextMenuStrip = this.cmsForm;
            this.Controls.Add(this.pictureBox1);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OKCoin_Form";
            this.Text = "View";
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.cmsForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Label lblVol;
        private System.Windows.Forms.TextBox txtVol;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.ContextMenuStrip cmsForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetTopMost;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmiResizeForm;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeCoin;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePlatform;
        private System.Windows.Forms.ToolTip ttlblErrMsg;
    }
}

