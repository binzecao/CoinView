namespace CoinView.CoinControl.Bter
{
    partial class Bter_Full
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
            this.gbDelegate = new System.Windows.Forms.GroupBox();
            this.bter_Depth = new CoinView.CoinControl.Bter.Bter_Depth();
            this.gbTrades = new System.Windows.Forms.GroupBox();
            this.bter_Trades = new CoinView.CoinControl.Bter.Bter_Trades();
            this.bter_Ticker = new CoinView.CoinControl.Bter.Bter_Ticker();
            this.gbDelegate.SuspendLayout();
            this.gbTrades.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDelegate
            // 
            this.gbDelegate.Controls.Add(this.bter_Depth);
            this.gbDelegate.Location = new System.Drawing.Point(9, 102);
            this.gbDelegate.Name = "gbDelegate";
            this.gbDelegate.Size = new System.Drawing.Size(591, 675);
            this.gbDelegate.TabIndex = 7;
            this.gbDelegate.TabStop = false;
            this.gbDelegate.Text = "委托信息";
            // 
            // bter_Depth
            // 
            this.bter_Depth.Location = new System.Drawing.Point(6, 20);
            this.bter_Depth.Name = "bter_Depth";
            this.bter_Depth.Size = new System.Drawing.Size(576, 617);
            this.bter_Depth.TabIndex = 0;
            // 
            // gbTrades
            // 
            this.gbTrades.Controls.Add(this.bter_Trades);
            this.gbTrades.Location = new System.Drawing.Point(609, 102);
            this.gbTrades.Name = "gbTrades";
            this.gbTrades.Size = new System.Drawing.Size(426, 675);
            this.gbTrades.TabIndex = 8;
            this.gbTrades.TabStop = false;
            this.gbTrades.Text = "最新成交";
            // 
            // bter_Trades
            // 
            this.bter_Trades.Location = new System.Drawing.Point(6, 20);
            this.bter_Trades.MaximumSize = new System.Drawing.Size(405, 619);
            this.bter_Trades.MinimumSize = new System.Drawing.Size(405, 619);
            this.bter_Trades.Name = "bter_Trades";
            this.bter_Trades.Size = new System.Drawing.Size(405, 619);
            this.bter_Trades.TabIndex = 0;
            // 
            // bter_Ticker
            // 
            this.bter_Ticker.Location = new System.Drawing.Point(0, 0);
            this.bter_Ticker.MaximumSize = new System.Drawing.Size(664, 94);
            this.bter_Ticker.MinimumSize = new System.Drawing.Size(165, 35);
            this.bter_Ticker.Name = "bter_Ticker";
            this.bter_Ticker.Size = new System.Drawing.Size(664, 94);
            this.bter_Ticker.TabIndex = 0;
            // 
            // Bter_Full
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTrades);
            this.Controls.Add(this.gbDelegate);
            this.Controls.Add(this.bter_Ticker);
            this.Name = "Bter_Full";
            this.Size = new System.Drawing.Size(1043, 776);
            this.gbDelegate.ResumeLayout(false);
            this.gbTrades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bter_Ticker bter_Ticker;
        private System.Windows.Forms.GroupBox gbDelegate;
        private Bter_Depth bter_Depth;
        private System.Windows.Forms.GroupBox gbTrades;
        private Bter_Trades bter_Trades;
    }
}
