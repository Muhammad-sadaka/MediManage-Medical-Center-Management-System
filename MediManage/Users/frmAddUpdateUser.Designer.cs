namespace MediManage
{
    partial class frmAddUpdateUser
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlPersonInfoSummary1 = new MediManage.ctrlPersonInfoSummary();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkIsActive = new MediManage.MyCustomCheckBox();
            this.chkPeople = new MediManage.MyCustomCheckBox();
            this.chkPatients = new MediManage.MyCustomCheckBox();
            this.chkDoctors = new MediManage.MyCustomCheckBox();
            this.chkPrescriptions = new MediManage.MyCustomCheckBox();
            this.chkExaminations = new MediManage.MyCustomCheckBox();
            this.chkAppointments = new MediManage.MyCustomCheckBox();
            this.chkUsers = new MediManage.MyCustomCheckBox();
            this.chkInvoicesPayments = new MediManage.MyCustomCheckBox();
            this.chkAnalyses = new MediManage.MyCustomCheckBox();
            this.gbSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(591, 51);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Add New User                       ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(439, 890);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 19;
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
            this.btnClose.Location = new System.Drawing.Point(635, 890);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.tbNationalNo);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 93);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1224, 100);
            this.gbSearch.TabIndex = 21;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "1 Search";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 34);
            this.label4.TabIndex = 144;
            this.label4.Text = "National No:";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPersonInfoSummary1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1224, 236);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2 Person Information";
            // 
            // ctrlPersonInfoSummary1
            // 
            this.ctrlPersonInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoSummary1.Location = new System.Drawing.Point(10, 42);
            this.ctrlPersonInfoSummary1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlPersonInfoSummary1.Name = "ctrlPersonInfoSummary1";
            this.ctrlPersonInfoSummary1.Size = new System.Drawing.Size(1195, 172);
            this.ctrlPersonInfoSummary1.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbConfirmPassword);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1224, 236);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Credentials";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 34);
            this.label7.TabIndex = 172;
            this.label7.Text = "Is Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 34);
            this.label2.TabIndex = 172;
            this.label2.Text = "Confirm Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 34);
            this.label1.TabIndex = 171;
            this.label1.Text = "Password";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(367, 139);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(670, 35);
            this.tbConfirmPassword.TabIndex = 170;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(367, 93);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(670, 35);
            this.tbPassword.TabIndex = 169;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(367, 46);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(670, 35);
            this.tbUsername.TabIndex = 168;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(73, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 34);
            this.label15.TabIndex = 167;
            this.label15.Text = "Username";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUsers);
            this.groupBox3.Controls.Add(this.chkInvoicesPayments);
            this.groupBox3.Controls.Add(this.chkAnalyses);
            this.groupBox3.Controls.Add(this.chkPrescriptions);
            this.groupBox3.Controls.Add(this.chkExaminations);
            this.groupBox3.Controls.Add(this.chkAppointments);
            this.groupBox3.Controls.Add(this.chkDoctors);
            this.groupBox3.Controls.Add(this.chkPatients);
            this.groupBox3.Controls.Add(this.chkPeople);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 683);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1224, 201);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permissions";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.Location = new System.Drawing.Point(367, 186);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(45, 38);
            this.chkIsActive.TabIndex = 174;
            this.chkIsActive.Text = " ";
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // chkPeople
            // 
            this.chkPeople.AutoSize = true;
            this.chkPeople.BackColor = System.Drawing.Color.Transparent;
            this.chkPeople.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPeople.Location = new System.Drawing.Point(14, 60);
            this.chkPeople.Name = "chkPeople";
            this.chkPeople.Size = new System.Drawing.Size(252, 38);
            this.chkPeople.TabIndex = 192;
            this.chkPeople.Text = "   Manage People";
            this.chkPeople.UseVisualStyleBackColor = false;
            // 
            // chkPatients
            // 
            this.chkPatients.AutoSize = true;
            this.chkPatients.BackColor = System.Drawing.Color.Transparent;
            this.chkPatients.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPatients.Location = new System.Drawing.Point(14, 104);
            this.chkPatients.Name = "chkPatients";
            this.chkPatients.Size = new System.Drawing.Size(269, 38);
            this.chkPatients.TabIndex = 193;
            this.chkPatients.Text = "   Manage Patients";
            this.chkPatients.UseVisualStyleBackColor = false;
            // 
            // chkDoctors
            // 
            this.chkDoctors.AutoSize = true;
            this.chkDoctors.BackColor = System.Drawing.Color.Transparent;
            this.chkDoctors.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoctors.Location = new System.Drawing.Point(14, 144);
            this.chkDoctors.Name = "chkDoctors";
            this.chkDoctors.Size = new System.Drawing.Size(265, 38);
            this.chkDoctors.TabIndex = 194;
            this.chkDoctors.Text = "   Manage Doctors";
            this.chkDoctors.UseVisualStyleBackColor = false;
            // 
            // chkPrescriptions
            // 
            this.chkPrescriptions.AutoSize = true;
            this.chkPrescriptions.BackColor = System.Drawing.Color.Transparent;
            this.chkPrescriptions.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrescriptions.Location = new System.Drawing.Point(360, 144);
            this.chkPrescriptions.Name = "chkPrescriptions";
            this.chkPrescriptions.Size = new System.Drawing.Size(327, 38);
            this.chkPrescriptions.TabIndex = 197;
            this.chkPrescriptions.Text = "   Manage Prescriptions";
            this.chkPrescriptions.UseVisualStyleBackColor = false;
            // 
            // chkExaminations
            // 
            this.chkExaminations.AutoSize = true;
            this.chkExaminations.BackColor = System.Drawing.Color.Transparent;
            this.chkExaminations.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExaminations.Location = new System.Drawing.Point(360, 104);
            this.chkExaminations.Name = "chkExaminations";
            this.chkExaminations.Size = new System.Drawing.Size(336, 38);
            this.chkExaminations.TabIndex = 196;
            this.chkExaminations.Text = "   Manage Examinations";
            this.chkExaminations.UseVisualStyleBackColor = false;
            // 
            // chkAppointments
            // 
            this.chkAppointments.AutoSize = true;
            this.chkAppointments.BackColor = System.Drawing.Color.Transparent;
            this.chkAppointments.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAppointments.Location = new System.Drawing.Point(360, 60);
            this.chkAppointments.Name = "chkAppointments";
            this.chkAppointments.Size = new System.Drawing.Size(341, 38);
            this.chkAppointments.TabIndex = 195;
            this.chkAppointments.Text = "   Manage Appointments";
            this.chkAppointments.UseVisualStyleBackColor = false;
            // 
            // chkUsers
            // 
            this.chkUsers.AutoSize = true;
            this.chkUsers.BackColor = System.Drawing.Color.Transparent;
            this.chkUsers.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsers.Location = new System.Drawing.Point(785, 142);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(240, 38);
            this.chkUsers.TabIndex = 200;
            this.chkUsers.Text = "   Manage Users";
            this.chkUsers.UseVisualStyleBackColor = false;
            // 
            // chkInvoicesPayments
            // 
            this.chkInvoicesPayments.AutoSize = true;
            this.chkInvoicesPayments.BackColor = System.Drawing.Color.Transparent;
            this.chkInvoicesPayments.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvoicesPayments.Location = new System.Drawing.Point(785, 102);
            this.chkInvoicesPayments.Name = "chkInvoicesPayments";
            this.chkInvoicesPayments.Size = new System.Drawing.Size(422, 38);
            this.chkInvoicesPayments.TabIndex = 199;
            this.chkInvoicesPayments.Text = "   Manage Invoices - Payments";
            this.chkInvoicesPayments.UseVisualStyleBackColor = false;
            // 
            // chkAnalyses
            // 
            this.chkAnalyses.AutoSize = true;
            this.chkAnalyses.BackColor = System.Drawing.Color.Transparent;
            this.chkAnalyses.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnalyses.Location = new System.Drawing.Point(785, 58);
            this.chkAnalyses.Name = "chkAnalyses";
            this.chkAnalyses.Size = new System.Drawing.Size(280, 38);
            this.chkAnalyses.TabIndex = 198;
            this.chkAnalyses.Text = "   Manage Analyses";
            this.chkAnalyses.UseVisualStyleBackColor = false;
            // 
            // frmAddUpdateUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1264, 956);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private ctrlPersonInfoSummary ctrlPersonInfoSummary1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private MyCustomCheckBox chkIsActive;
        private MyCustomCheckBox chkUsers;
        private MyCustomCheckBox chkInvoicesPayments;
        private MyCustomCheckBox chkAnalyses;
        private MyCustomCheckBox chkPrescriptions;
        private MyCustomCheckBox chkExaminations;
        private MyCustomCheckBox chkAppointments;
        private MyCustomCheckBox chkDoctors;
        private MyCustomCheckBox chkPatients;
        private MyCustomCheckBox chkPeople;
    }
}