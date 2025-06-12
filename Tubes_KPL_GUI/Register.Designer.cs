namespace Tubes_KPL_GUI
{
    partial class Register
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox logoPictureBox;
        private Label titleLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox userTextBox;
        private TextBox passTextBox;
        private Label noteLabel;
        private Button daftarBtn;
        private Button kembaliBtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            logoPictureBox = new PictureBox();
            titleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            userTextBox = new TextBox();
            passTextBox = new TextBox();
            noteLabel = new Label();
            daftarBtn = new Button();
            kembaliBtn = new Button();
            lihatSandi = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // logoPictureBox
            // 
            logoPictureBox.Anchor = AnchorStyles.Top;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(366, 51);
            logoPictureBox.Margin = new Padding(4, 4, 4, 4);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(231, 234);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(162, 328);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(625, 38);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Silakan isi nama pengguna dan kata sandi Anda";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(150, 398);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(175, 31);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Nama Pengguna :";
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(150, 457);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(175, 31);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Kata Sandi          :";
            // 
            // userTextBox
            // 
            userTextBox.BackColor = SystemColors.Control;
            userTextBox.Location = new Point(327, 398);
            userTextBox.Margin = new Padding(4, 4, 4, 4);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(468, 31);
            userTextBox.TabIndex = 4;
            // 
            // passTextBox
            // 
            passTextBox.BackColor = SystemColors.Control;
            passTextBox.Location = new Point(327, 457);
            passTextBox.Margin = new Padding(4, 4, 4, 4);
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '*';
            passTextBox.Size = new Size(468, 31);
            passTextBox.TabIndex = 5;
            // 
            // noteLabel
            // 
            noteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            noteLabel.ForeColor = Color.Gray;
            noteLabel.Location = new Point(162, 530);
            noteLabel.Margin = new Padding(4, 0, 4, 0);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(625, 50);
            noteLabel.TabIndex = 6;
            noteLabel.Text = "Kata sandi harus terdiri dari ≥ 8 karakter, dengan huruf besar, kecil, angka, dan simbol.";
            noteLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // daftarBtn
            // 
            daftarBtn.BackColor = Color.LightSkyBlue;
            daftarBtn.Location = new Point(627, 606);
            daftarBtn.Margin = new Padding(4, 4, 4, 4);
            daftarBtn.Name = "daftarBtn";
            daftarBtn.Size = new Size(167, 49);
            daftarBtn.TabIndex = 7;
            daftarBtn.Text = "Daftar";
            daftarBtn.UseVisualStyleBackColor = false;
            daftarBtn.Click += DaftarBtn_Click;
            // 
            // kembaliBtn
            // 
            kembaliBtn.BackColor = SystemColors.ScrollBar;
            kembaliBtn.Location = new Point(150, 606);
            kembaliBtn.Margin = new Padding(4, 4, 4, 4);
            kembaliBtn.Name = "kembaliBtn";
            kembaliBtn.Size = new Size(167, 49);
            kembaliBtn.TabIndex = 8;
            kembaliBtn.Text = "Kembali";
            kembaliBtn.UseVisualStyleBackColor = false;
            kembaliBtn.Click += KembaliBtn_Click;
            // 
            // lihatSandi
            // 
            lihatSandi.AutoSize = true;
            lihatSandi.Location = new Point(672, 499);
            lihatSandi.Margin = new Padding(2, 2, 2, 2);
            lihatSandi.Name = "lihatSandi";
            lihatSandi.Size = new Size(124, 29);
            lihatSandi.TabIndex = 9;
            lihatSandi.Text = "Lihat Sandi";
            lihatSandi.UseVisualStyleBackColor = true;
            lihatSandi.CheckedChanged += LihatSandi_CheckedChanged;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1200, 900);
            Controls.Add(lihatSandi);
            Controls.Add(logoPictureBox);
            Controls.Add(titleLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(userTextBox);
            Controls.Add(passTextBox);
            Controls.Add(noteLabel);
            Controls.Add(daftarBtn);
            Controls.Add(kembaliBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private CheckBox lihatSandi;
    }
}
