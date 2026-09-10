namespace MediManage
{
    partial class frmAddExamination
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbHeartRate = new System.Windows.Forms.TextBox();
            this.tbBloodPressure = new System.Windows.Forms.TextBox();
            this.numericTemperature = new System.Windows.Forms.NumericUpDown();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDiagosis = new System.Windows.Forms.TextBox();
            this.tbSymptoms = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.ctrlAppointmentInfoSummary1 = new MediManage.ctrlAppointmentInfoSummary();
            this.numericAppointmentID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperature)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAppointmentID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(431, 815);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(627, 815);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbWeight);
            this.groupBox1.Controls.Add(this.tbHeartRate);
            this.groupBox1.Controls.Add(this.tbBloodPressure);
            this.groupBox1.Controls.Add(this.numericTemperature);
            this.groupBox1.Controls.Add(this.tbNotes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDiagosis);
            this.groupBox1.Controls.Add(this.tbSymptoms);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 440);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Examination Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 34);
            this.label6.TabIndex = 181;
            this.label6.Text = "Note";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 34);
            this.label5.TabIndex = 180;
            this.label5.Text = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 34);
            this.label3.TabIndex = 179;
            this.label3.Text = "Heart Rate";
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(328, 322);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(238, 40);
            this.tbWeight.TabIndex = 178;
            // 
            // tbHeartRate
            // 
            this.tbHeartRate.Location = new System.Drawing.Point(328, 273);
            this.tbHeartRate.Name = "tbHeartRate";
            this.tbHeartRate.Size = new System.Drawing.Size(238, 40);
            this.tbHeartRate.TabIndex = 177;
            // 
            // tbBloodPressure
            // 
            this.tbBloodPressure.Location = new System.Drawing.Point(328, 175);
            this.tbBloodPressure.Name = "tbBloodPressure";
            this.tbBloodPressure.Size = new System.Drawing.Size(872, 40);
            this.tbBloodPressure.TabIndex = 176;
            // 
            // numericTemperature
            // 
            this.numericTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTemperature.Location = new System.Drawing.Point(328, 224);
            this.numericTemperature.Name = "numericTemperature";
            this.numericTemperature.Size = new System.Drawing.Size(238, 40);
            this.numericTemperature.TabIndex = 175;
            this.numericTemperature.Value = new decimal(new int[] {
            46,
            0,
            0,
            65536});
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(328, 371);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.PasswordChar = '*';
            this.tbNotes.Size = new System.Drawing.Size(872, 56);
            this.tbNotes.TabIndex = 170;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 34);
            this.label7.TabIndex = 172;
            this.label7.Text = "Temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 34);
            this.label2.TabIndex = 172;
            this.label2.Text = "Blood Pressure";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 34);
            this.label1.TabIndex = 171;
            this.label1.Text = "Diagnosis";
            // 
            // tbDiagosis
            // 
            this.tbDiagosis.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiagosis.Location = new System.Drawing.Point(328, 110);
            this.tbDiagosis.Multiline = true;
            this.tbDiagosis.Name = "tbDiagosis";
            this.tbDiagosis.PasswordChar = '*';
            this.tbDiagosis.Size = new System.Drawing.Size(872, 56);
            this.tbDiagosis.TabIndex = 169;
            // 
            // tbSymptoms
            // 
            this.tbSymptoms.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSymptoms.Location = new System.Drawing.Point(328, 45);
            this.tbSymptoms.Multiline = true;
            this.tbSymptoms.Name = "tbSymptoms";
            this.tbSymptoms.Size = new System.Drawing.Size(872, 56);
            this.tbSymptoms.TabIndex = 168;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(69, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 34);
            this.label15.TabIndex = 167;
            this.label15.Text = "Symptoms";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.ctrlAppointmentInfoSummary1);
            this.gbSearch.Controls.Add(this.numericAppointmentID);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 84);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1214, 279);
            this.gbSearch.TabIndex = 25;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Appointment Search";
            // 
            // ctrlAppointmentInfoSummary1
            // 
            this.ctrlAppointmentInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAppointmentInfoSummary1.Location = new System.Drawing.Point(10, 85);
            this.ctrlAppointmentInfoSummary1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlAppointmentInfoSummary1.Name = "ctrlAppointmentInfoSummary1";
            this.ctrlAppointmentInfoSummary1.Size = new System.Drawing.Size(1190, 185);
            this.ctrlAppointmentInfoSummary1.TabIndex = 146;
            // 
            // numericAppointmentID
            // 
            this.numericAppointmentID.Location = new System.Drawing.Point(265, 42);
            this.numericAppointmentID.Name = "numericAppointmentID";
            this.numericAppointmentID.Size = new System.Drawing.Size(437, 40);
            this.numericAppointmentID.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 34);
            this.label4.TabIndex = 144;
            this.label4.Text = "Appointment ID";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(708, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 47);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(750, 51);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Add New Examination                       ";
            // 
            // frmAddExamination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 878);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddExamination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddExamination";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperature)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAppointmentID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TextBox tbDiagosis;
        private System.Windows.Forms.TextBox tbSymptoms;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NumericUpDown numericAppointmentID;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.TextBox tbHeartRate;
        private System.Windows.Forms.TextBox tbBloodPressure;
        private System.Windows.Forms.NumericUpDown numericTemperature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private ctrlAppointmentInfoSummary ctrlAppointmentInfoSummary1;
        private System.Windows.Forms.Label lblTitle;
    }
}