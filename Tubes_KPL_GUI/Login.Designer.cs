namespace Tubes_KPL_GUI
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox logoPictureBox;
        private Label titleLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button registerButton;
        private CheckBox lihatSandi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            logoPictureBox = new PictureBox();
            titleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            registerButton = new Button();
            lihatSandi = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // logoPictureBox
            // 
            logoPictureBox.Anchor = AnchorStyles.Top;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(686, 170);
            logoPictureBox.Margin = new Padding(5);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(300, 300);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(421, 525);
            titleLabel.Margin = new Padding(5, 0, 5, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(812, 48);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Silakan masukkan nama pengguna dan kata sandi Anda";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(405, 615);
            usernameLabel.Margin = new Padding(5, 0, 5, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(228, 40);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Nama Pengguna :";
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(405, 690);
            passwordLabel.Margin = new Padding(5, 0, 5, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(228, 40);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Kata Sandi          :";
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = SystemColors.Control;
            usernameTextBox.Location = new Point(636, 615);
            usernameTextBox.Margin = new Padding(5);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(607, 39);
            usernameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.Control;
            passwordTextBox.Location = new Point(636, 690);
            passwordTextBox.Margin = new Padding(5);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(607, 39);
            passwordTextBox.TabIndex = 5;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.LightSkyBlue;
            loginButton.Location = new Point(1026, 880);
            loginButton.Margin = new Padding(5);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(217, 63);
            loginButton.TabIndex = 6;
            loginButton.Text = "Masuk";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += LoginButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = SystemColors.ScrollBar;
            registerButton.Location = new Point(405, 880);
            registerButton.Margin = new Padding(5);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(217, 63);
            registerButton.TabIndex = 7;
            registerButton.Text = "Daftar";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += RegisterButton_Click;
            // 
            // lihatSandi
            // 
            lihatSandi.AutoSize = true;
            lihatSandi.Location = new Point(1084, 744);
            lihatSandi.Name = "lihatSandi";
            lihatSandi.Size = new Size(163, 36);
            lihatSandi.TabIndex = 8;
            lihatSandi.Text = "Lihat Sandi";
            lihatSandi.UseVisualStyleBackColor = true;
            lihatSandi.CheckedChanged += LihatSandi_CheckedChanged;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1664, 1152);
            Controls.Add(lihatSandi);
            Controls.Add(logoPictureBox);
            Controls.Add(titleLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Controls.Add(registerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
