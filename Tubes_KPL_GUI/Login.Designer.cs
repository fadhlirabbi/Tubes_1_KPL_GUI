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

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            logoPictureBox = new PictureBox();
            titleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            registerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // logoPictureBox
            // 
            logoPictureBox.Anchor = AnchorStyles.Top;
            logoPictureBox.BackColor = SystemColors.Window;
            logoPictureBox.Image = Properties.Resources.wallpaperflare_com_wallpaper;
            logoPictureBox.InitialImage = Properties.Resources.wallpaperflare_com_wallpaper;
            logoPictureBox.Location = new Point(187, 25);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(230, 105);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            logoPictureBox.Click += logoPictureBox_Click;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(110, 160);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(420, 30);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Selamat Datang di aplikasi To Do List";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(100, 220);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(140, 25);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Nama Pengguna :";
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(100, 260);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(140, 25);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Kata Sandi :";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(240, 220);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(230, 31);
            usernameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(240, 260);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(230, 31);
            passwordTextBox.TabIndex = 5;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.LightSkyBlue;
            loginButton.Location = new Point(380, 310);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(90, 35);
            loginButton.TabIndex = 6;
            loginButton.Text = "Masuk";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += LoginButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(240, 310);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(90, 35);
            registerButton.TabIndex = 7;
            registerButton.Text = "Daftar";
            registerButton.Click += RegisterButton_Click;
            // 
            // FormLogin
            // 
            ClientSize = new Size(600, 400);
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
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
