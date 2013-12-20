namespace CoinView.CoinControl.OKCoin
{
    partial class OKCoin_Full
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
            this.okCoin_Depth = new CoinView.CoinControl.OKCoin.OKCoin_Depth();
            this.okCoin_Trades = new CoinView.CoinControl.OKCoin.OKCoin_Trades();
            this.gbTrades = new System.Windows.Forms.GroupBox();
            this.gbDelegate = new System.Windows.Forms.GroupBox();
            this.okCoin_Ticker = new CoinView.CoinControl.OKCoin.OKCoin_Ticker();
            this.gbTrades.SuspendLayout();
            this.gbDelegate.SuspendLayout();
            this.SuspendLayout();
            // 
            // okCoin_Depth
            // 
            this.okCoin_Depth.Location = new System.Drawing.Point(6, 20);
            this.okCoin_Depth.MaximumSize = new System.Drawing.Size(576, 617);
            this.okCoin_Depth.MinimumSize = new System.Drawing.Size(576, 617);
            this.okCoin_Depth.Name = "okCoin_Depth";
            this.okCoin_Depth.Size = new System.Drawing.Size(576, 617);
            this.okCoin_Depth.TabIndex = 1;
            // 
            // okCoin_Trades
            // 
            this.okCoin_Trades.Location = new System.Drawing.Point(6, 20);
            this.okCoin_Trades.MaximumSize = new System.Drawing.Size(405, 619);
            this.okCoin_Trades.MinimumSize = new System.Drawing.Size(405, 619);
            this.okCoin_Trades.Name = "okCoin_Trades";
            this.okCoin_Trades.Size = new System.Drawing.Size(405, 619);
            this.okCoin_Trades.TabIndex = 0;
            // 
            // gbTrades
            // 
            this.gbTrades.Controls.Add(this.okCoin_Trades);
            this.gbTrades.Location = new System.Drawing.Point(609, 102);
            this.gbTrades.Name = "gbTrades";
            this.gbTrades.Size = new System.Drawing.Size(426, 675);
            this.gbTrades.TabIndex = 7;
            this.gbTrades.TabStop = false;
            this.gbTrades.Text = "最新成交";
            // 
            // gbDelegate
            // 
            this.gbDelegate.Controls.Add(this.okCoin_Depth);
            this.gbDelegate.Location = new System.Drawing.Point(9, 102);
            this.gbDelegate.Name = "gbDelegate";
            this.gbDelegate.Size = new System.Drawing.Size(591, 675);
            this.gbDelegate.TabIndex = 6;
            this.gbDelegate.TabStop = false;
            this.gbDelegate.Text = "委托信息";
            // 
            // okCoin_Ticker
            // 
            this.okCoin_Ticker.Location = new System.Drawing.Point(0, 0);
            this.okCoin_Ticker.MaximumSize = new System.Drawing.Size(455, 93);
            this.okCoin_Ticker.MinimumSize = new System.Drawing.Size(165, 35);
            this.okCoin_Ticker.Name = "okCoin_Ticker";
            this.okCoin_Ticker.Size = new System.Drawing.Size(455, 93);
            this.okCoin_Ticker.TabIndex = 5;
            // 
            // OKCoin_Full
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTrades);
            this.Controls.Add(this.gbDelegate);
            this.Controls.Add(this.okCoin_Ticker);
            this.Name = "OKCoin_Full";
            this.Size = new System.Drawing.Size(1043, 776);
            this.gbTrades.ResumeLayout(false);
            this.gbDelegate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OKCoin_Depth okCoin_Depth;
        private OKCoin_Trades okCoin_Trades;
        private System.Windows.Forms.GroupBox gbTrades;
        private System.Windows.Forms.GroupBox gbDelegate;
        private OKCoin_Ticker okCoin_Ticker;
    }
}
