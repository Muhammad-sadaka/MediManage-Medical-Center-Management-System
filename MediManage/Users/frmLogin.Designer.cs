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
            panel1 = new System.Windows.Forms.Panel();
            tbUserName = new ReaLTaiizor.Controls.CyberTextBox();
            tbPassword = new ReaLTaiizor.Controls.CyberTextBox();
            crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            chkRememberMe = new System.Windows.Forms.CheckBox();
            btnLogin = new ReaLTaiizor.Controls.CyberButton();
            bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            airForm1.SuspendLayout();
            panel1.SuspendLayout();
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
            airForm1.Controls.Add(panel1);
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
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Login;
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(tbUserName);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(crownLabel1);
            panel1.Controls.Add(chkRememberMe);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(bigLabel3);
            panel1.Controls.Add(bigLabel2);
            panel1.Controls.Add(bigLabel1);
            panel1.Location = new System.Drawing.Point(0, 37);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1074, 551);
            panel1.TabIndex = 0;
            // 
            // tbUserName
            // 
            tbUserName.Alpha = 20;
            tbUserName.BackColor = System.Drawing.Color.Transparent;
            tbUserName.Background_WidthPen = 3F;
            tbUserName.BackgroundPen = true;
            tbUserName.ColorBackground = System.Drawing.Color.White;
            tbUserName.ColorBackground_Pen = System.Drawing.Color.FromArgb(192, 0, 0);
            tbUserName.ColorLighting = System.Drawing.Color.FromArgb(192, 0, 0);
            tbUserName.ColorPen_1 = System.Drawing.Color.FromArgb(192, 0, 0);
            tbUserName.ColorPen_2 = System.Drawing.Color.White;
            tbUserName.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            tbUserName.Font = new System.Drawing.Font("Franklin Gothic Medium", 14F);
            tbUserName.ForeColor = System.Drawing.Color.Gray;
            tbUserName.Lighting = false;
            tbUserName.LinearGradientPen = false;
            tbUserName.Location = new System.Drawing.Point(611, 181);
            tbUserName.Name = "tbUserName";
            tbUserName.PenWidth = 15;
            tbUserName.RGB = false;
            tbUserName.Rounding = true;
            tbUserName.RoundingInt = 60;
            tbUserName.Size = new System.Drawing.Size(347, 57);
            tbUserName.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            tbUserName.TabIndex = 14;
            tbUserName.Tag = "Cyber";
            tbUserName.TextButton = "Cyber Text";
            tbUserName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            tbUserName.Timer_RGB = 300;
            tbUserName.Enter += tbUserName_Enter;
            tbUserName.Leave += tbUserName_Leave;
            // 
            // tbPassword
            // 
            tbPassword.Alpha = 20;
            tbPassword.BackColor = System.Drawing.Color.Transparent;
            tbPassword.Background_WidthPen = 3F;
            tbPassword.BackgroundPen = true;
            tbPassword.ColorBackground = System.Drawing.Color.White;
            tbPassword.ColorBackground_Pen = System.Drawing.Color.FromArgb(192, 0, 0);
            tbPassword.ColorLighting = System.Drawing.Color.FromArgb(192, 0, 0);
            tbPassword.ColorPen_1 = System.Drawing.Color.FromArgb(192, 0, 0);
            tbPassword.ColorPen_2 = System.Drawing.Color.White;
            tbPassword.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            tbPassword.Font = new System.Drawing.Font("Franklin Gothic Medium", 14F);
            tbPassword.ForeColor = System.Drawing.Color.Gray;
            tbPassword.Lighting = false;
            tbPassword.LinearGradientPen = false;
            tbPassword.Location = new System.Drawing.Point(611, 253);
            tbPassword.Name = "tbPassword";
            tbPassword.PenWidth = 15;
            tbPassword.RGB = false;
            tbPassword.Rounding = true;
            tbPassword.RoundingInt = 60;
            tbPassword.Size = new System.Drawing.Size(347, 57);
            tbPassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            tbPassword.TabIndex = 15;
            tbPassword.Tag = "Cyber";
            tbPassword.TextButton = "Cyber Text";
            tbPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            tbPassword.Timer_RGB = 300;
            tbPassword.Enter += tbPassword_Enter;
            tbPassword.Leave += tbPassword_Leave;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkingArea;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ReaLTaiizor.Forms.AirForm airForm1;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private ReaLTaiizor.Controls.CyberButton btnLogin;
        private ReaLTaiizor.Controls.CyberTextBox tbPassword;
        private ReaLTaiizor.Controls.CyberTextBox tbUserName;
    }
}