namespace CoinView
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowOrHideForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeCoin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResizeForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.okCoin_Full = new CoinView.CoinControl.OKCoin.OKCoin_Full();
            this.cmsForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // ni
            // 
            this.ni.ContextMenuStrip = this.cmsForm;
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "Bter";
            this.ni.Visible = true;
            // 
            // cmsForm
            // 
            this.cmsForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowOrHideForm,
            this.tsmiChangeCoin,
            this.tsmiChangeLanguage,
            this.tsmiSetTopMost,
            this.tsmiResizeForm,
            this.tsmiExit});
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(149, 136);
            // 
            // tsmiShowOrHideForm
            // 
            this.tsmiShowOrHideForm.Name = "tsmiShowOrHideForm";
            this.tsmiShowOrHideForm.Size = new System.Drawing.Size(148, 22);
            this.tsmiShowOrHideForm.Text = "隐藏";
            this.tsmiShowOrHideForm.Click += new System.EventHandler(this.tsmiShowOrHideForm_Click);
            // 
            // tsmiChangeCoin
            // 
            this.tsmiChangeCoin.Name = "tsmiChangeCoin";
            this.tsmiChangeCoin.Size = new System.Drawing.Size(148, 22);
            this.tsmiChangeCoin.Text = "币切换";
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
            // okCoin_Full
            // 
            this.okCoin_Full.Location = new System.Drawing.Point(0, 0);
            this.okCoin_Full.MaximumSize = new System.Drawing.Size(1043, 776);
            this.okCoin_Full.MinimumSize = new System.Drawing.Size(165, 35);
            this.okCoin_Full.Name = "okCoin_Full";
            this.okCoin_Full.Size = new System.Drawing.Size(1043, 776);
            this.okCoin_Full.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 785);
            this.ContextMenuStrip = this.cmsForm;
            this.Controls.Add(this.okCoin_Full);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.cmsForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CoinControl.OKCoin.OKCoin_Full okCoin_Full;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.ContextMenuStrip cmsForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeCoin;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetTopMost;
        private System.Windows.Forms.ToolStripMenuItem tsmiResizeForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowOrHideForm;
    }
}