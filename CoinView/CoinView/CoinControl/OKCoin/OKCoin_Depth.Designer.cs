namespace CoinView.CoinControl.OKCoin
{
    partial class OKCoin_Depth
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAsks = new System.Windows.Forms.DataGridView();
            this.dgvBids = new System.Windows.Forms.DataGridView();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.lblBidsHighLightYuan = new System.Windows.Forms.Label();
            this.lblBidsHighLight = new System.Windows.Forms.Label();
            this.txtBidsHighLight = new System.Windows.Forms.TextBox();
            this.ttlblErrMsg = new System.Windows.Forms.ToolTip(this.components);
            this.lblAsksHighLightYuan = new System.Windows.Forms.Label();
            this.lblAsksHighLight = new System.Windows.Forms.Label();
            this.txtAsksHighLight = new System.Windows.Forms.TextBox();
            this.dgvcBidOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcBidSinglePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcBidVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcBidTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAskSinglePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAskVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAskTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBids)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAsks
            // 
            this.dgvAsks.AllowUserToAddRows = false;
            this.dgvAsks.AllowUserToDeleteRows = false;
            this.dgvAsks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvAsks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcAsk,
            this.dgvcAskSinglePrice,
            this.dgvcAskVol,
            this.dgvcAskTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAsks.Location = new System.Drawing.Point(298, 0);
            this.dgvAsks.Name = "dgvAsks";
            this.dgvAsks.ReadOnly = true;
            this.dgvAsks.RowHeadersVisible = false;
            this.dgvAsks.RowTemplate.Height = 23;
            this.dgvAsks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsks.Size = new System.Drawing.Size(278, 544);
            this.dgvAsks.TabIndex = 3;
            // 
            // dgvBids
            // 
            this.dgvBids.AllowUserToAddRows = false;
            this.dgvBids.AllowUserToDeleteRows = false;
            this.dgvBids.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvBids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcBidOrder,
            this.dgvcBidSinglePrice,
            this.dgvcBidVol,
            this.dgvcBidTotal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBids.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBids.Location = new System.Drawing.Point(3, 0);
            this.dgvBids.Name = "dgvBids";
            this.dgvBids.ReadOnly = true;
            this.dgvBids.RowHeadersVisible = false;
            this.dgvBids.RowTemplate.Height = 23;
            this.dgvBids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBids.Size = new System.Drawing.Size(278, 544);
            this.dgvBids.TabIndex = 2;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(176, 594);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 25;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(134, 594);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 24;
            this.lblSecond.Text = "秒";
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(21, 594);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 23;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(87, 591);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 22;
            this.txtRefreshInterval.Text = "5";
            this.txtRefreshInterval.TextChanged += new System.EventHandler(this.txtRefreshInterval_TextChanged);
            this.txtRefreshInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshInterval_KeyPress);
            // 
            // lblBidsHighLightYuan
            // 
            this.lblBidsHighLightYuan.AutoSize = true;
            this.lblBidsHighLightYuan.Location = new System.Drawing.Point(237, 559);
            this.lblBidsHighLightYuan.Name = "lblBidsHighLightYuan";
            this.lblBidsHighLightYuan.Size = new System.Drawing.Size(17, 12);
            this.lblBidsHighLightYuan.TabIndex = 31;
            this.lblBidsHighLightYuan.Text = "元";
            // 
            // lblBidsHighLight
            // 
            this.lblBidsHighLight.AutoSize = true;
            this.lblBidsHighLight.Location = new System.Drawing.Point(21, 559);
            this.lblBidsHighLight.Name = "lblBidsHighLight";
            this.lblBidsHighLight.Size = new System.Drawing.Size(95, 12);
            this.lblBidsHighLight.TabIndex = 30;
            this.lblBidsHighLight.Text = "买总价高亮设置:";
            // 
            // txtBidsHighLight
            // 
            this.txtBidsHighLight.Location = new System.Drawing.Point(134, 556);
            this.txtBidsHighLight.MaxLength = 10;
            this.txtBidsHighLight.Name = "txtBidsHighLight";
            this.txtBidsHighLight.Size = new System.Drawing.Size(91, 21);
            this.txtBidsHighLight.TabIndex = 29;
            this.txtBidsHighLight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHighLight_KeyPress);
            // 
            // lblAsksHighLightYuan
            // 
            this.lblAsksHighLightYuan.AutoSize = true;
            this.lblAsksHighLightYuan.Location = new System.Drawing.Point(518, 559);
            this.lblAsksHighLightYuan.Name = "lblAsksHighLightYuan";
            this.lblAsksHighLightYuan.Size = new System.Drawing.Size(17, 12);
            this.lblAsksHighLightYuan.TabIndex = 34;
            this.lblAsksHighLightYuan.Text = "元";
            // 
            // lblAsksHighLight
            // 
            this.lblAsksHighLight.AutoSize = true;
            this.lblAsksHighLight.Location = new System.Drawing.Point(302, 559);
            this.lblAsksHighLight.Name = "lblAsksHighLight";
            this.lblAsksHighLight.Size = new System.Drawing.Size(95, 12);
            this.lblAsksHighLight.TabIndex = 33;
            this.lblAsksHighLight.Text = "卖总价高亮设置:";
            // 
            // txtAsksHighLight
            // 
            this.txtAsksHighLight.Location = new System.Drawing.Point(415, 556);
            this.txtAsksHighLight.MaxLength = 10;
            this.txtAsksHighLight.Name = "txtAsksHighLight";
            this.txtAsksHighLight.Size = new System.Drawing.Size(91, 21);
            this.txtAsksHighLight.TabIndex = 32;
            this.txtAsksHighLight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHighLight_KeyPress);
            // 
            // dgvcBidOrder
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkGreen;
            this.dgvcBidOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcBidOrder.HeaderText = "买入";
            this.dgvcBidOrder.Name = "dgvcBidOrder";
            this.dgvcBidOrder.ReadOnly = true;
            this.dgvcBidOrder.Width = 60;
            // 
            // dgvcBidSinglePrice
            // 
            this.dgvcBidSinglePrice.FillWeight = 87.14422F;
            this.dgvcBidSinglePrice.HeaderText = "买入价";
            this.dgvcBidSinglePrice.Name = "dgvcBidSinglePrice";
            this.dgvcBidSinglePrice.ReadOnly = true;
            this.dgvcBidSinglePrice.Width = 70;
            // 
            // dgvcBidVol
            // 
            this.dgvcBidVol.FillWeight = 87.14422F;
            this.dgvcBidVol.HeaderText = "委单量";
            this.dgvcBidVol.Name = "dgvcBidVol";
            this.dgvcBidVol.ReadOnly = true;
            this.dgvcBidVol.Width = 70;
            // 
            // dgvcBidTotal
            // 
            this.dgvcBidTotal.FillWeight = 87.14422F;
            this.dgvcBidTotal.HeaderText = "买入总价";
            this.dgvcBidTotal.Name = "dgvcBidTotal";
            this.dgvcBidTotal.ReadOnly = true;
            this.dgvcBidTotal.Width = 80;
            // 
            // dgvcAsk
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.dgvcAsk.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcAsk.HeaderText = "卖出";
            this.dgvcAsk.Name = "dgvcAsk";
            this.dgvcAsk.ReadOnly = true;
            this.dgvcAsk.Width = 60;
            // 
            // dgvcAskSinglePrice
            // 
            this.dgvcAskSinglePrice.FillWeight = 87.14422F;
            this.dgvcAskSinglePrice.HeaderText = "卖出价";
            this.dgvcAskSinglePrice.Name = "dgvcAskSinglePrice";
            this.dgvcAskSinglePrice.ReadOnly = true;
            this.dgvcAskSinglePrice.Width = 70;
            // 
            // dgvcAskVol
            // 
            this.dgvcAskVol.FillWeight = 87.14422F;
            this.dgvcAskVol.HeaderText = "委单量";
            this.dgvcAskVol.Name = "dgvcAskVol";
            this.dgvcAskVol.ReadOnly = true;
            this.dgvcAskVol.Width = 70;
            // 
            // dgvcAskTotal
            // 
            this.dgvcAskTotal.FillWeight = 87.14422F;
            this.dgvcAskTotal.HeaderText = "卖出总价";
            this.dgvcAskTotal.Name = "dgvcAskTotal";
            this.dgvcAskTotal.ReadOnly = true;
            this.dgvcAskTotal.Width = 80;
            // 
            // OKCoin_Depth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAsksHighLightYuan);
            this.Controls.Add(this.lblAsksHighLight);
            this.Controls.Add(this.txtAsksHighLight);
            this.Controls.Add(this.lblBidsHighLightYuan);
            this.Controls.Add(this.lblBidsHighLight);
            this.Controls.Add(this.txtBidsHighLight);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblRefreshInterval);
            this.Controls.Add(this.txtRefreshInterval);
            this.Controls.Add(this.dgvAsks);
            this.Controls.Add(this.dgvBids);
            this.Name = "OKCoin_Depth";
            this.Size = new System.Drawing.Size(576, 617);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsks;
        private System.Windows.Forms.DataGridView dgvBids;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label lblBidsHighLightYuan;
        private System.Windows.Forms.Label lblBidsHighLight;
        private System.Windows.Forms.TextBox txtBidsHighLight;
        private System.Windows.Forms.ToolTip ttlblErrMsg;
        private System.Windows.Forms.Label lblAsksHighLightYuan;
        private System.Windows.Forms.Label lblAsksHighLight;
        private System.Windows.Forms.TextBox txtAsksHighLight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAskSinglePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAskVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAskTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcBidOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcBidSinglePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcBidVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcBidTotal;
    }
}
