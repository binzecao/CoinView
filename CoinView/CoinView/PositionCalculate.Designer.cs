namespace CoinView
{
    partial class PositionCalculate
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
            this.cmsDgv1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCalculateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearSelectedRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearAllRows = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgvcIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSinglePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttlblErrMsg = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblRefreshInterval = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtAvgSinglePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLeftoverWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmsDgv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsDgv1
            // 
            this.cmsDgv1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCalculateTable,
            this.tsmiClearSelectedRow,
            this.tsmiClearAllRows});
            this.cmsDgv1.Name = "cmsDgv1";
            this.cmsDgv1.Size = new System.Drawing.Size(191, 70);
            // 
            // tsmiCalculateTable
            // 
            this.tsmiCalculateTable.Name = "tsmiCalculateTable";
            this.tsmiCalculateTable.Size = new System.Drawing.Size(190, 22);
            this.tsmiCalculateTable.Text = "Calculate All Trades";
            this.tsmiCalculateTable.Click += new System.EventHandler(this.tsmiCalculateTable_Click);
            // 
            // tsmiClearSelectedRow
            // 
            this.tsmiClearSelectedRow.Name = "tsmiClearSelectedRow";
            this.tsmiClearSelectedRow.Size = new System.Drawing.Size(190, 22);
            this.tsmiClearSelectedRow.Text = "Delete Selected Row";
            this.tsmiClearSelectedRow.Click += new System.EventHandler(this.tsmiClearSelectedRow_Click);
            // 
            // tsmiClearAllRows
            // 
            this.tsmiClearAllRows.Name = "tsmiClearAllRows";
            this.tsmiClearAllRows.Size = new System.Drawing.Size(190, 22);
            this.tsmiClearAllRows.Text = "Clear All Rows";
            this.tsmiClearAllRows.Click += new System.EventHandler(this.tsmiClearAllRows_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIndex,
            this.dgvcSinglePrice,
            this.dgvcWeight,
            this.dgvcAmount,
            this.dgvcTotal});
            this.dgv1.ContextMenuStrip = this.cmsDgv1;
            this.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv1.Location = new System.Drawing.Point(11, 33);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(478, 377);
            this.dgv1.TabIndex = 53;
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            // 
            // dgvcIndex
            // 
            this.dgvcIndex.HeaderText = "Index";
            this.dgvcIndex.Name = "dgvcIndex";
            this.dgvcIndex.ReadOnly = true;
            this.dgvcIndex.Width = 50;
            // 
            // dgvcSinglePrice
            // 
            this.dgvcSinglePrice.HeaderText = "SinglePrice";
            this.dgvcSinglePrice.Name = "dgvcSinglePrice";
            // 
            // dgvcWeight
            // 
            this.dgvcWeight.HeaderText = "Weight";
            this.dgvcWeight.Name = "dgvcWeight";
            // 
            // dgvcAmount
            // 
            this.dgvcAmount.HeaderText = "Amount";
            this.dgvcAmount.Name = "dgvcAmount";
            this.dgvcAmount.ReadOnly = true;
            // 
            // dgvcTotal
            // 
            this.dgvcTotal.HeaderText = "Total";
            this.dgvcTotal.Name = "dgvcTotal";
            this.dgvcTotal.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "balance:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(309, 6);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(100, 21);
            this.txtBalance.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "SinglePrice";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Index";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(654, 382);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(77, 12);
            this.lblErrMsg.TabIndex = 62;
            this.lblErrMsg.Text = "预留错误信息";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(612, 382);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(17, 12);
            this.lblSecond.TabIndex = 61;
            this.lblSecond.Text = "秒";
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.AutoSize = true;
            this.lblRefreshInterval.Location = new System.Drawing.Point(499, 382);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(59, 12);
            this.lblRefreshInterval.TabIndex = 60;
            this.lblRefreshInterval.Text = "刷新间隔:";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(565, 379);
            this.txtRefreshInterval.MaxLength = 4;
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(41, 21);
            this.txtRefreshInterval.TabIndex = 59;
            this.txtRefreshInterval.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "current price:";
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Location = new System.Drawing.Point(119, 6);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.Size = new System.Drawing.Size(100, 21);
            this.txtCurrentPrice.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "TotalMoney:";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(596, 247);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(100, 21);
            this.txtTotalMoney.TabIndex = 56;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(596, 167);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 21);
            this.txtTotalAmount.TabIndex = 71;
            // 
            // txtAvgSinglePrice
            // 
            this.txtAvgSinglePrice.Location = new System.Drawing.Point(596, 202);
            this.txtAvgSinglePrice.Name = "txtAvgSinglePrice";
            this.txtAvgSinglePrice.Size = new System.Drawing.Size(100, 21);
            this.txtAvgSinglePrice.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 69;
            this.label6.Text = "Avg Price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 72;
            this.label9.Text = "Total Amount:";
            // 
            // txtLeftoverWeight
            // 
            this.txtLeftoverWeight.Location = new System.Drawing.Point(596, 128);
            this.txtLeftoverWeight.Name = "txtLeftoverWeight";
            this.txtLeftoverWeight.Size = new System.Drawing.Size(100, 21);
            this.txtLeftoverWeight.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 74;
            this.label10.Text = "Leftover Weight:";
            // 
            // PositionCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 429);
            this.Controls.Add(this.txtLeftoverWeight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtAvgSinglePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.txtTotalMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentPrice);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblRefreshInterval);
            this.Controls.Add(this.txtRefreshInterval);
            this.Name = "PositionCalculate";
            this.Text = "PositionCalculate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PositionCalculate_FormClosing);
            this.cmsDgv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsDgv1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalculateTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearSelectedRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAllRows;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ToolTip ttlblErrMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblRefreshInterval;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSinglePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtAvgSinglePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLeftoverWeight;
        private System.Windows.Forms.Label label10;
    }
}