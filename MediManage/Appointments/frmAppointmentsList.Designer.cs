namespace MediManage
{
    partial class frmAppointmentsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DGVAppointmentsList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbStatuses = new System.Windows.Forms.ComboBox();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointmentsList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Green;
            this.btnAddNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(820, 26);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(371, 51);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "+  Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1197, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 51);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "x Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DGVAppointmentsList
            // 
            this.DGVAppointmentsList.AllowUserToAddRows = false;
            this.DGVAppointmentsList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.DGVAppointmentsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVAppointmentsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVAppointmentsList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAppointmentsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAppointmentsList.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGVAppointmentsList.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVAppointmentsList.Location = new System.Drawing.Point(21, 169);
            this.DGVAppointmentsList.Name = "DGVAppointmentsList";
            this.DGVAppointmentsList.ReadOnly = true;
            this.DGVAppointmentsList.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVAppointmentsList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVAppointmentsList.RowTemplate.Height = 26;
            this.DGVAppointmentsList.Size = new System.Drawing.Size(1366, 495);
            this.DGVAppointmentsList.TabIndex = 23;
            this.DGVAppointmentsList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAppointmentsList_CellContentClick);
            this.DGVAppointmentsList.DoubleClick += new System.EventHandler(this.DGVAppointmentsList_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(553, 51);
            this.label2.TabIndex = 24;
            this.label2.Text = "Appointments List             ";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(15, 683);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(77, 31);
            this.lblTotalRecords.TabIndex = 25;
            this.lblTotalRecords.Text = "Total: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(500, 35);
            this.dateTimePicker1.TabIndex = 168;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbStatuses
            // 
            this.cbStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatuses.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatuses.FormattingEnabled = true;
            this.cbStatuses.Items.AddRange(new object[] {
            "All"});
            this.cbStatuses.Location = new System.Drawing.Point(686, 121);
            this.cbStatuses.Name = "cbStatuses";
            this.cbStatuses.Size = new System.Drawing.Size(263, 36);
            this.cbStatuses.TabIndex = 169;
            this.cbStatuses.SelectedIndexChanged += new System.EventHandler(this.cbStatuses_SelectedIndexChanged);
            // 
            // cbDoctors
            // 
            this.cbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctors.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.Items.AddRange(new object[] {
            "All"});
            this.cbDoctors.Location = new System.Drawing.Point(1124, 121);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(263, 36);
            this.cbDoctors.Sorted = true;
            this.cbDoctors.TabIndex = 170;
            this.cbDoctors.SelectedIndexChanged += new System.EventHandler(this.cbDoctors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(578, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 32);
            this.label1.TabIndex = 171;
            this.label1.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1015, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 32);
            this.label3.TabIndex = 172;
            this.label3.Text = "Doctor:";
            // 
            // frmAppointmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 727);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDoctors);
            this.Controls.Add(this.cbStatuses);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVAppointmentsList);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAppointmentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAppointmentsList";
            this.Load += new System.EventHandler(this.frmAppointmentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointmentsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DGVAppointmentsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbStatuses;
        private System.Windows.Forms.ComboBox cbDoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}