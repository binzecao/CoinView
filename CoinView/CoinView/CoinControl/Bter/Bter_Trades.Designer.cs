namespace CoinView.CoinControl.Bter
{
    partial class Bter_Trades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTrades = new System.Windows.Forms.DataGridView();
            this.dgvcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.ttlblErrMsg = new System.Windows.Forms.ToolTip(this.components);
            this.lblHighLightYuan = new System.Windows.Forms.Label();
            this.lblHighLight = new System.Windows.Forms.Label();
            this.txtHighLight = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrades
            // 
            this.dgvTrades.AllowUserToAddRows = false;
            this.dgvTrades.AllowUserToDeleteRows = false;
            this.dgvTrades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvTrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcDate,
            this.dgvcPrice,
            this.dgvcAmount,
            this.dgvcTotal,
            this.dgvcType,
            this.dgvcTid});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrades.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTrades.Location = new System.Drawing.Point(0, 0);
            this.dgvTrades.Name = "dgvTrades";
            this.dgvTrades.ReadOnly = true;
            this.dgvTrades.RowHeadersVisible = false;
            this.dgvTrades.RowTemplate.Height = 23;
            this.dgvTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrades.Size = new System.Drawing.Size(402, 544);
            this.dgvTrades.TabIndex = 37;
            // 
            // dgvcDate
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvcDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcDate.HeaderText = "成交时间";
            this.dgvcDate.Name = "dgvcDate";
            this.dgvcDate.ReadOnly = true;
            this.dgvcDate.Width = 80;
            // 
            // dgvcPrice
            // 
            this.dgvcPrice.FillWeight = 87.14422F;
            this.dgvcPrice.HeaderText = "成交价(CURR_B)";
            this.dgvcPrice.Name = "dgvcPrice";
            this.dgvcPrice.ReadOnly = true;
            this.dgvcPrice.Width = 70;
            // 
            // dgvcAmount
            // 
            this.dgvcAmount.FillWeight = 87.14422F;
            this.dgvcAmount.HeaderText = "成交量(CURR_A)";
            this.dgvcAmount.Name = "dgvcAmount";
            this.dgvcAmount.ReadOnly = true;
            this.dgvcAmount.Width = 70;
            // 
            // dgvcTotal
            // 
            this.dgvcTotal.HeaderText = "成交额(CURR_B)";
            this.dgvcTotal.Name = "dgvcTotal";
            this.dgvcTotal.ReadOnly = true;
            // 
            // dgvcType
            // 
            this.dgvcType.HeaderText = "成交类型";
            this.dgvcType.Name = "dgvcType";
            this.dgvcType.ReadOnly = true;
            this.dgvcType.Width = 80;
            // 
            // dgvcTid
            // 
            this.dgvcTid.HeaderText = "tid";
            this.dgvcTid.Name = "dgvcTid";
            this.dgvcTid.ReadOnly = true;
            this.dgvcTid.Visible = false;
            this.dgvcTid.Width = 80;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(156, 597);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 41;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(114, 597);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 40;
            this.lblSecond.Text = "秒";
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(1, 597);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 39;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(67, 594);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 38;
            this.txtRefreshInterval.Text = "5";
            this.txtRefreshInterval.TextChanged += new System.EventHandler(this.txtRefreshInterval_TextChanged);
            this.txtRefreshInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshInterval_KeyPress);
            // 
            // lblHighLightYuan
            // 
            this.lblHighLightYuan.AutoSize = true;
            this.lblHighLightYuan.Location = new System.Drawing.Point(205, 565);
            this.lblHighLightYuan.Name = "lblHighLightYuan";
            this.lblHighLightYuan.Size = new System.Drawing.Size(17, 12);
            this.lblHighLightYuan.TabIndex = 44;
            this.lblHighLightYuan.Text = "元";
            // 
            // lblHighLight
            // 
            this.lblHighLight.AutoSize = true;
            this.lblHighLight.Location = new System.Drawing.Point(1, 565);
            this.lblHighLight.Name = "lblHighLight";
            this.lblHighLight.Size = new System.Drawing.Size(95, 12);
            this.lblHighLight.TabIndex = 43;
            this.lblHighLight.Text = "成交额高亮设置:";
            // 
            // txtHighLight
            // 
            this.txtHighLight.Location = new System.Drawing.Point(102, 562);
            this.txtHighLight.MaxLength = 10;
            this.txtHighLight.Name = "txtHighLight";
            this.txtHighLight.Size = new System.Drawing.Size(91, 21);
            this.txtHighLight.TabIndex = 42;
            this.txtHighLight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHighLight_KeyPress);
            // 
            // Bter_Trades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTrades);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblRefreshInterval);
            this.Controls.Add(this.txtRefreshInterval);
            this.Controls.Add(this.lblHighLightYuan);
            this.Controls.Add(this.lblHighLight);
            this.Controls.Add(this.txtHighLight);
            this.Name = "Bter_Trades";
            this.Size = new System.Drawing.Size(405, 619);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrades;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.ToolTip ttlblErrMsg;
        private System.Windows.Forms.Label lblHighLightYuan;
        private System.Windows.Forms.Label lblHighLight;
        private System.Windows.Forms.TextBox txtHighLight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTid;
    }
}
