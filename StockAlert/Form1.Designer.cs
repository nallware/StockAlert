namespace StockAlert
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.OrdTic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alert_Shares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alert_Avg_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alert_Current_Sell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit2_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.ckbxHigh = new System.Windows.Forms.CheckBox();
            this.tbMessages = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdTic,
            this.Alert_Shares,
            this.Alert_Avg_Cost,
            this.Alert_Current_Sell,
            this.Profit1,
            this.Profit2_5,
            this.Profit5,
            this.Profit10});
            this.dgvOrders.Location = new System.Drawing.Point(11, 10);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowTemplate.Height = 28;
            this.dgvOrders.Size = new System.Drawing.Size(804, 368);
            this.dgvOrders.TabIndex = 26;
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            // 
            // OrdTic
            // 
            this.OrdTic.HeaderText = "Ticker";
            this.OrdTic.Name = "OrdTic";
            // 
            // Alert_Shares
            // 
            this.Alert_Shares.HeaderText = "Shares";
            this.Alert_Shares.Name = "Alert_Shares";
            // 
            // Alert_Avg_Cost
            // 
            this.Alert_Avg_Cost.HeaderText = "MyCost";
            this.Alert_Avg_Cost.Name = "Alert_Avg_Cost";
            // 
            // Alert_Current_Sell
            // 
            this.Alert_Current_Sell.HeaderText = "Current$";
            this.Alert_Current_Sell.Name = "Alert_Current_Sell";
            // 
            // Profit1
            // 
            this.Profit1.HeaderText = "Profit$1";
            this.Profit1.Name = "Profit1";
            // 
            // Profit2_5
            // 
            this.Profit2_5.HeaderText = "Profit$2.50";
            this.Profit2_5.Name = "Profit2_5";
            // 
            // Profit5
            // 
            this.Profit5.HeaderText = "Profit$5";
            this.Profit5.Name = "Profit5";
            // 
            // Profit10
            // 
            this.Profit10.HeaderText = "Profit$10";
            this.Profit10.Name = "Profit10";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 526);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 36);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(273, 526);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(84, 36);
            this.btnReload.TabIndex = 27;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(109, 526);
            this.btnPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(148, 36);
            this.btnPause.TabIndex = 28;
            this.btnPause.Text = "Pause Tracking";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // ckbxHigh
            // 
            this.ckbxHigh.AutoSize = true;
            this.ckbxHigh.Checked = true;
            this.ckbxHigh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxHigh.Location = new System.Drawing.Point(410, 540);
            this.ckbxHigh.Name = "ckbxHigh";
            this.ckbxHigh.Size = new System.Drawing.Size(100, 21);
            this.ckbxHigh.TabIndex = 29;
            this.ckbxHigh.Text = "High Alert?";
            this.ckbxHigh.UseVisualStyleBackColor = true;
            // 
            // tbMessages
            // 
            this.tbMessages.BackColor = System.Drawing.SystemColors.Menu;
            this.tbMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessages.CausesValidation = false;
            this.tbMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessages.ForeColor = System.Drawing.Color.Red;
            this.tbMessages.Location = new System.Drawing.Point(12, 406);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.ReadOnly = true;
            this.tbMessages.Size = new System.Drawing.Size(792, 115);
            this.tbMessages.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 572);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.ckbxHigh);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "StockAlert Bot 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit2_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alert_Current_Sell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alert_Avg_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alert_Shares;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdTic;
        private System.Windows.Forms.Button btnReload;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.CheckBox ckbxHigh;
        private System.Windows.Forms.TextBox tbMessages;
    }
}

