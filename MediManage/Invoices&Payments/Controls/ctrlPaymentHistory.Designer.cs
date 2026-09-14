namespace MediManage
{
    partial class ctrlPaymentHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVPaymentHistory = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPaymentHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVPaymentHistory);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1230, 367);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section 1: Payment History";
            // 
            // DGVPaymentHistory
            // 
            this.DGVPaymentHistory.AllowUserToAddRows = false;
            this.DGVPaymentHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVPaymentHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            this.DGVPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPaymentHistory.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVPaymentHistory.Location = new System.Drawing.Point(12, 39);
            this.DGVPaymentHistory.Name = "DGVPaymentHistory";
            this.DGVPaymentHistory.ReadOnly = true;
            this.DGVPaymentHistory.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVPaymentHistory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPaymentHistory.RowTemplate.Height = 26;
            this.DGVPaymentHistory.Size = new System.Drawing.Size(1201, 305);
            this.DGVPaymentHistory.TabIndex = 23;
            // 
            // ctrlPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ctrlPaymentHistory";
            this.Size = new System.Drawing.Size(1239, 377);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPaymentHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGVPaymentHistory;
    }
}
