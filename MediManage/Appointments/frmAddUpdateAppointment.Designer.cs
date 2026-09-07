namespace MediManage
{
    partial class frmAddUpdateAppointment
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFees = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numericDuration = new System.Windows.Forms.NumericUpDown();
            this.cbStatuses = new System.Windows.Forms.ComboBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlPatientInfoSummary1 = new MediManage.ctrlPatientInfoSummary();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(430, 761);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(626, 761);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(672, 51);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Add New Appointment                ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFees);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.numericDuration);
            this.groupBox1.Controls.Add(this.cbStatuses);
            this.groupBox1.Controls.Add(this.tbNotes);
            this.groupBox1.Controls.Add(this.tbReason);
            this.groupBox1.Controls.Add(this.cbDoctors);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 429);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Section 2 - Appointment Details";
            // 
            // tbFees
            // 
            this.tbFees.Location = new System.Drawing.Point(268, 245);
            this.tbFees.Name = "tbFees";
            this.tbFees.ReadOnly = true;
            this.tbFees.Size = new System.Drawing.Size(937, 40);
            this.tbFees.TabIndex = 183;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(268, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(937, 35);
            this.dateTimePicker1.TabIndex = 182;
            // 
            // numericDuration
            // 
            this.numericDuration.Location = new System.Drawing.Point(268, 145);
            this.numericDuration.Name = "numericDuration";
            this.numericDuration.Size = new System.Drawing.Size(937, 40);
            this.numericDuration.TabIndex = 181;
            this.numericDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cbStatuses
            // 
            this.cbStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatuses.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatuses.FormattingEnabled = true;
            this.cbStatuses.Location = new System.Drawing.Point(268, 295);
            this.cbStatuses.Name = "cbStatuses";
            this.cbStatuses.Size = new System.Drawing.Size(937, 36);
            this.cbStatuses.TabIndex = 180;
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(268, 341);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(937, 82);
            this.tbNotes.TabIndex = 179;
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(268, 195);
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(937, 40);
            this.tbReason.TabIndex = 178;
            // 
            // cbDoctors
            // 
            this.cbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctors.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.Location = new System.Drawing.Point(268, 54);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(937, 36);
            this.cbDoctors.TabIndex = 177;
            this.cbDoctors.SelectedIndexChanged += new System.EventHandler(this.cbDoctors_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 34);
            this.label9.TabIndex = 152;
            this.label9.Text = "Notes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 34);
            this.label7.TabIndex = 151;
            this.label7.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 34);
            this.label6.TabIndex = 150;
            this.label6.Text = "Fees:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 34);
            this.label4.TabIndex = 149;
            this.label4.Text = "Reason:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 34);
            this.label3.TabIndex = 148;
            this.label3.Text = "Duration:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 34);
            this.label1.TabIndex = 147;
            this.label1.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 34);
            this.label5.TabIndex = 146;
            this.label5.Text = "Doctor:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPatientInfoSummary1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbNationalNo);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1224, 226);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pection 1 - Patient Search";
            // 
            // ctrlPatientInfoSummary1
            // 
            this.ctrlPatientInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPatientInfoSummary1.Location = new System.Drawing.Point(16, 94);
            this.ctrlPatientInfoSummary1.Margin = new System.Windows.Forms.Padding(6);
            this.ctrlPatientInfoSummary1.Name = "ctrlPatientInfoSummary1";
            this.ctrlPatientInfoSummary1.Size = new System.Drawing.Size(1189, 128);
            this.ctrlPatientInfoSummary1.TabIndex = 145;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 34);
            this.label8.TabIndex = 144;
            this.label8.Text = "National No:";
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNo.ForeColor = System.Drawing.Color.Silver;
            this.tbNationalNo.Location = new System.Drawing.Point(209, 42);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(828, 40);
            this.tbNationalNo.TabIndex = 22;
            this.tbNationalNo.Text = "National No";
            this.tbNationalNo.Enter += new System.EventHandler(this.tbNationalNo_Enter);
            this.tbNationalNo.Leave += new System.EventHandler(this.tbNationalNo_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1043, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 47);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAddUpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 828);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateAppointment";
            this.Load += new System.EventHandler(this.frmAddUpdateAppointment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDoctors;
        private System.Windows.Forms.ComboBox cbStatuses;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.NumericUpDown numericDuration;
        private System.Windows.Forms.TextBox tbFees;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private ctrlPatientInfoSummary ctrlPatientInfoSummary1;
    }
}