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
            logoPictureBox.BackColor = SystemColors.Window;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.InitialImage = Properties.Resources.wallpaperflare_com_wallpaper;
            logoPictureBox.Location = new Point(474, 86);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(300, 300);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(229, 441);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(736, 64);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Selamat Datang di aplikasi To Do List";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(193, 531);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(217, 36);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Nama Pengguna :";
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(193, 606);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(233, 36);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Kata Sandi          :";
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = SystemColors.Control;
            usernameTextBox.Location = new Point(424, 531);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(607, 31);
            usernameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.Control;
            passwordTextBox.Location = new Point(424, 606);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(607, 31);
            passwordTextBox.TabIndex = 5;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.LightSkyBlue;
            loginButton.Location = new Point(814, 770);
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
            registerButton.Location = new Point(193, 770);
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
            lihatSandi.Location = new Point(872, 660);
            lihatSandi.Name = "lihatSandi";
            lihatSandi.Size = new Size(124, 29);
            lihatSandi.TabIndex = 8;
            lihatSandi.Text = "Lihat Sandi";
            lihatSandi.UseVisualStyleBackColor = true;
            lihatSandi.CheckedChanged += LihatSandi_CheckedChanged;
            // 
            // FormLogin
            // 
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1200, 900);
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
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Name = "FormLogin";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private CheckBox lihatSandi;
    }
}
