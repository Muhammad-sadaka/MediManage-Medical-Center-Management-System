namespace MediManage
{
    partial class frmLogin
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
            components = new System.ComponentModel.Container();
            WorkingArea = new System.Windows.Forms.Panel();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            airForm1 = new ReaLTaiizor.Forms.AirForm();
            panelMain = new System.Windows.Forms.Panel();
            txtUserName = new MediManage.Controls.CustomTextBox();
            txtPassword = new MediManage.Controls.CustomTextBox();
            crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            chkRememberMe = new System.Windows.Forms.CheckBox();
            btnLogin = new ReaLTaiizor.Controls.CyberButton();
            bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            airForm1.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // WorkingArea
            // 
            WorkingArea.BackColor = System.Drawing.Color.FromArgb(236, 236, 236);
            WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            WorkingArea.Location = new System.Drawing.Point(0, 39);
            WorkingArea.Name = "WorkingArea";
            WorkingArea.Size = new System.Drawing.Size(1099, 437);
            WorkingArea.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // airForm1
            // 
            airForm1.BackColor = System.Drawing.Color.White;
            airForm1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            airForm1.Controls.Add(panelMain);
            airForm1.Customization = "AAAA/1paWv9ycnL/";
            airForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            airForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            airForm1.Image = null;
            airForm1.Location = new System.Drawing.Point(0, 0);
            airForm1.MinimumSize = new System.Drawing.Size(112, 35);
            airForm1.Movable = true;
            airForm1.Name = "airForm1";
            airForm1.NoRounding = false;
            airForm1.Sizable = true;
            airForm1.Size = new System.Drawing.Size(1074, 588);
            airForm1.SmartBounds = true;
            airForm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            airForm1.TabIndex = 0;
            airForm1.Text = "MediManage";
            airForm1.TransparencyKey = System.Drawing.Color.Fuchsia;
            airForm1.Transparent = false;
            // 
            // panelMain
            // 
            panelMain.BackgroundImage = Properties.Resources.Login;
            panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelMain.Controls.Add(txtUserName);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(crownLabel1);
            panelMain.Controls.Add(chkRememberMe);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(bigLabel3);
            panelMain.Controls.Add(bigLabel2);
            panelMain.Controls.Add(bigLabel1);
            panelMain.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            panelMain.Location = new System.Drawing.Point(0, 37);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(1074, 551);
            panelMain.TabIndex = 0;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = System.Drawing.Color.White;
            txtUserName.BorderColor = System.Drawing.Color.Maroon;
            txtUserName.BorderRadius = 15;
            txtUserName.BorderSize = 2;
            txtUserName.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtUserName.Location = new System.Drawing.Point(599, 183);
            txtUserName.Margin = new System.Windows.Forms.Padding(5);
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            txtUserName.PasswordChar = '\0';
            txtUserName.Size = new System.Drawing.Size(366, 55);
            txtUserName.TabIndex = 17;
            txtUserName.Text = "User Name";
            txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.Enter += txtUserName_Enter;
            txtUserName.Leave += txtUserName_Leave;
            txtUserName.Validating += txtUserName_Validating;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = System.Drawing.Color.White;
            txtPassword.BorderColor = System.Drawing.Color.Maroon;
            txtPassword.BorderRadius = 15;
            txtPassword.BorderSize = 2;
            txtPassword.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPassword.Location = new System.Drawing.Point(599, 257);
            txtPassword.Margin = new System.Windows.Forms.Padding(5);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(366, 55);
            txtPassword.TabIndex = 16;
            txtPassword.Text = "Password";
            txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // crownLabel1
            // 
            crownLabel1.AutoSize = true;
            crownLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            crownLabel1.ForeColor = System.Drawing.Color.Black;
            crownLabel1.Location = new System.Drawing.Point(625, 95);
            crownLabel1.Name = "crownLabel1";
            crownLabel1.Size = new System.Drawing.Size(315, 38);
            crownLabel1.TabIndex = 13;
            crownLabel1.Text = "  Login to Your Account";
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkRememberMe.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkRememberMe.ForeColor = System.Drawing.Color.Black;
            chkRememberMe.Location = new System.Drawing.Point(625, 339);
            chkRememberMe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new System.Drawing.Size(122, 24);
            chkRememberMe.TabIndex = 12;
            chkRememberMe.Text = "Remember me";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Alpha = 20;
            btnLogin.BackColor = System.Drawing.Color.Transparent;
            btnLogin.Background = true;
            btnLogin.Background_WidthPen = 4F;
            btnLogin.BackgroundPen = true;
            btnLogin.ColorBackground = System.Drawing.Color.DarkRed;
            btnLogin.ColorBackground_1 = System.Drawing.Color.Red;
            btnLogin.ColorBackground_2 = System.Drawing.Color.Red;
            btnLogin.ColorBackground_Pen = System.Drawing.Color.Red;
            btnLogin.ColorLighting = System.Drawing.Color.Red;
            btnLogin.ColorPen_1 = System.Drawing.Color.Red;
            btnLogin.ColorPen_2 = System.Drawing.Color.Red;
            btnLogin.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnLogin.Effect_1 = true;
            btnLogin.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(29, 200, 238);
            btnLogin.Effect_1_Transparency = 25;
            btnLogin.Effect_2 = true;
            btnLogin.Effect_2_ColorBackground = System.Drawing.Color.White;
            btnLogin.Effect_2_Transparency = 20;
            btnLogin.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnLogin.ForeColor = System.Drawing.Color.FromArgb(245, 245, 245);
            btnLogin.Lighting = false;
            btnLogin.LinearGradient_Background = false;
            btnLogin.LinearGradientPen = false;
            btnLogin.Location = new System.Drawing.Point(586, 371);
            btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.PenWidth = 15;
            btnLogin.Rounding = true;
            btnLogin.RoundingInt = 70;
            btnLogin.Size = new System.Drawing.Size(389, 71);
            btnLogin.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnLogin.TabIndex = 11;
            btnLogin.Tag = "Cyber";
            btnLogin.TextButton = "Login";
            btnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnLogin.Timer_Effect_1 = 5;
            btnLogin.Timer_RGB = 300;
            btnLogin.Click += btnLogin_Click;
            // 
            // bigLabel3
            // 
            bigLabel3.AutoSize = true;
            bigLabel3.BackColor = System.Drawing.Color.Transparent;
            bigLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bigLabel3.ForeColor = System.Drawing.Color.White;
            bigLabel3.Location = new System.Drawing.Point(55, 95);
            bigLabel3.Name = "bigLabel3";
            bigLabel3.Size = new System.Drawing.Size(78, 57);
            bigLabel3.TabIndex = 10;
            bigLabel3.Text = "TO";
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = System.Drawing.Color.Transparent;
            bigLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = System.Drawing.Color.White;
            bigLabel2.Location = new System.Drawing.Point(40, 166);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new System.Drawing.Size(277, 57);
            bigLabel2.TabIndex = 9;
            bigLabel2.Text = "MediManage";
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = System.Drawing.Color.Transparent;
            bigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = System.Drawing.Color.White;
            bigLabel1.Location = new System.Drawing.Point(0, 24);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new System.Drawing.Size(226, 57);
            bigLabel1.TabIndex = 8;
            bigLabel1.Text = "WELCOME";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1074, 588);
            Controls.Add(airForm1);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(128, 44);
            Name = "frmLogin";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "themeForm1";
            TransparencyKey = System.Drawing.Color.Fuchsia;
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            airForm1.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkingArea;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ReaLTaiizor.Forms.AirForm airForm1;
        private System.Windows.Forms.Panel panelMain;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private ReaLTaiizor.Controls.CyberButton btnLogin;
        private Controls.CustomTextBox txtUserName;
        private Controls.CustomTextBox txtPassword;
    }
}