﻿namespace AccountCreator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEmailCapitalTrick = new System.Windows.Forms.CheckBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkEmailDotTrick = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkUsernameNumbers = new System.Windows.Forms.CheckBox();
            this.chkAutoChangeNickname = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBirthMonth = new System.Windows.Forms.TextBox();
            this.txtBirthDay = new System.Windows.Forms.TextBox();
            this.txtBirthYear = new System.Windows.Forms.TextBox();
            this.chkRandomBirthday = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(149, 466);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 34);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(59, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(108, 24);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 506);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(374, 397);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(108, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(199, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRandomBirthday);
            this.groupBox1.Controls.Add(this.txtBirthYear);
            this.groupBox1.Controls.Add(this.txtBirthDay);
            this.groupBox1.Controls.Add(this.txtBirthMonth);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkAutoChangeNickname);
            this.groupBox1.Controls.Add(this.chkUsernameNumbers);
            this.groupBox1.Controls.Add(this.chkEmailCapitalTrick);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNickName);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.chkEmailDotTrick);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Location = new System.Drawing.Point(32, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 218);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account";
            // 
            // chkEmailCapitalTrick
            // 
            this.chkEmailCapitalTrick.AutoSize = true;
            this.chkEmailCapitalTrick.Checked = true;
            this.chkEmailCapitalTrick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailCapitalTrick.Location = new System.Drawing.Point(215, 146);
            this.chkEmailCapitalTrick.Name = "chkEmailCapitalTrick";
            this.chkEmailCapitalTrick.Size = new System.Drawing.Size(113, 17);
            this.chkEmailCapitalTrick.TabIndex = 12;
            this.chkEmailCapitalTrick.Text = "Email Capital Trick";
            this.chkEmailCapitalTrick.UseVisualStyleBackColor = true;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(108, 147);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.Text = "Ying";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 123);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 5;
            this.txtFirstName.Text = "Chang";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Last Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "First Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nickname:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email:";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(108, 97);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(100, 20);
            this.txtNickName.TabIndex = 4;
            this.txtNickName.Text = "WongKal";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(108, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // chkEmailDotTrick
            // 
            this.chkEmailDotTrick.AutoSize = true;
            this.chkEmailDotTrick.Checked = true;
            this.chkEmailDotTrick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailDotTrick.Location = new System.Drawing.Point(215, 125);
            this.chkEmailDotTrick.Name = "chkEmailDotTrick";
            this.chkEmailDotTrick.Size = new System.Drawing.Size(98, 17);
            this.chkEmailDotTrick.TabIndex = 11;
            this.chkEmailDotTrick.Text = "Email Dot Trick";
            this.chkEmailDotTrick.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(31, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 422);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCaptcha);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(32, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 153);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Captcha";
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Enabled = false;
            this.txtCaptcha.Location = new System.Drawing.Point(93, 116);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(199, 20);
            this.txtCaptcha.TabIndex = 10;
            this.txtCaptcha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 572);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 511);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "0/0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkProxy);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Location = new System.Drawing.Point(32, 242);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 59);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // chkProxy
            // 
            this.chkProxy.AutoSize = true;
            this.chkProxy.Location = new System.Drawing.Point(240, 25);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(52, 17);
            this.chkProxy.TabIndex = 16;
            this.chkProxy.Text = "Proxy";
            this.chkProxy.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkUsernameNumbers
            // 
            this.chkUsernameNumbers.AutoSize = true;
            this.chkUsernameNumbers.Checked = true;
            this.chkUsernameNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsernameNumbers.Location = new System.Drawing.Point(215, 103);
            this.chkUsernameNumbers.Name = "chkUsernameNumbers";
            this.chkUsernameNumbers.Size = new System.Drawing.Size(138, 17);
            this.chkUsernameNumbers.TabIndex = 10;
            this.chkUsernameNumbers.Text = "Username add numbers";
            this.chkUsernameNumbers.UseVisualStyleBackColor = true;
            // 
            // chkAutoChangeNickname
            // 
            this.chkAutoChangeNickname.AutoSize = true;
            this.chkAutoChangeNickname.Checked = true;
            this.chkAutoChangeNickname.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoChangeNickname.Location = new System.Drawing.Point(216, 169);
            this.chkAutoChangeNickname.Name = "chkAutoChangeNickname";
            this.chkAutoChangeNickname.Size = new System.Drawing.Size(137, 17);
            this.chkAutoChangeNickname.TabIndex = 13;
            this.chkAutoChangeNickname.Text = "Auto Change nickname";
            this.chkAutoChangeNickname.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Birthday:";
            // 
            // txtBirthMonth
            // 
            this.txtBirthMonth.Location = new System.Drawing.Point(108, 173);
            this.txtBirthMonth.Name = "txtBirthMonth";
            this.txtBirthMonth.Size = new System.Drawing.Size(26, 20);
            this.txtBirthMonth.TabIndex = 7;
            this.txtBirthMonth.Text = "02";
            // 
            // txtBirthDay
            // 
            this.txtBirthDay.Location = new System.Drawing.Point(140, 173);
            this.txtBirthDay.Name = "txtBirthDay";
            this.txtBirthDay.Size = new System.Drawing.Size(23, 20);
            this.txtBirthDay.TabIndex = 8;
            this.txtBirthDay.Text = "05";
            // 
            // txtBirthYear
            // 
            this.txtBirthYear.Location = new System.Drawing.Point(169, 173);
            this.txtBirthYear.Name = "txtBirthYear";
            this.txtBirthYear.Size = new System.Drawing.Size(38, 20);
            this.txtBirthYear.TabIndex = 9;
            this.txtBirthYear.Text = "1988";
            // 
            // chkRandomBirthday
            // 
            this.chkRandomBirthday.AutoSize = true;
            this.chkRandomBirthday.Checked = true;
            this.chkRandomBirthday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandomBirthday.Location = new System.Drawing.Point(216, 192);
            this.chkRandomBirthday.Name = "chkRandomBirthday";
            this.chkRandomBirthday.Size = new System.Drawing.Size(107, 17);
            this.chkRandomBirthday.TabIndex = 14;
            this.chkRandomBirthday.Text = "Random Birthday";
            this.chkRandomBirthday.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 594);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KalOnline GameAgit Account Creator by HighGamer.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtCaptcha;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckBox chkProxy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox chkUsernameNumbers;
        public System.Windows.Forms.CheckBox chkAutoChangeNickname;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtFirstName;
        public System.Windows.Forms.TextBox txtNickName;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.CheckBox chkEmailDotTrick;
        public System.Windows.Forms.CheckBox chkEmailCapitalTrick;
        public System.Windows.Forms.TextBox txtBirthYear;
        public System.Windows.Forms.TextBox txtBirthDay;
        public System.Windows.Forms.TextBox txtBirthMonth;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.CheckBox chkRandomBirthday;
    }
}

