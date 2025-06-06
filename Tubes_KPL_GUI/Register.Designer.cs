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
            logoPictureBox = new PictureBox();
            titleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            userTextBox = new TextBox();
            passTextBox = new TextBox();
            noteLabel = new Label();
            daftarBtn = new Button();
            kembaliBtn = new Button();

            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            //
            // logoPictureBox
            //
            logoPictureBox.Anchor = AnchorStyles.Top;
            logoPictureBox.Image = Properties.Resources.wallpaperflare_com_wallpaper;
            logoPictureBox.Location = new Point(240, 20);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(120, 100);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //
            // titleLabel
            //
            titleLabel.Text = "Silakan isi nama pengguna dan kata sandi Anda";
            titleLabel.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Location = new Point(50, 130);
            titleLabel.Size = new Size(500, 30);
            //
            // usernameLabel
            //
            usernameLabel.Text = "Nama Pengguna :";
            usernameLabel.Location = new Point(80, 190);
            usernameLabel.Size = new Size(140, 25);
            //
            // passwordLabel
            //
            passwordLabel.Text = "Kata Sandi :";
            passwordLabel.Location = new Point(80, 230);
            passwordLabel.Size = new Size(140, 25);
            //
            // userTextBox
            //
            userTextBox.Location = new Point(220, 190);
            userTextBox.Size = new Size(250, 31);
            //
            // passTextBox
            //
            passTextBox.Location = new Point(220, 230);
            passTextBox.Size = new Size(250, 31);
            passTextBox.PasswordChar = '*';
            //
            // noteLabel
            //
            noteLabel.Text = "Kata sandi harus terdiri dari ≥ 8 karakter, dengan huruf besar, kecil, angka, dan simbol.";
            noteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            noteLabel.ForeColor = Color.Gray;
            noteLabel.Location = new Point(50, 270);
            noteLabel.Size = new Size(500, 40);
            noteLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // daftarBtn
            //
            daftarBtn.Text = "Daftar";
            daftarBtn.BackColor = Color.LightSkyBlue;
            daftarBtn.Location = new Point(360, 320);
            daftarBtn.Size = new Size(110, 40);
            daftarBtn.Click += new EventHandler(DaftarBtn_Click);
            //
            // kembaliBtn
            //
            kembaliBtn.Text = "Kembali";
            kembaliBtn.Location = new Point(120, 320);
            kembaliBtn.Size = new Size(110, 40);
            kembaliBtn.Click += new EventHandler(KembaliBtn_Click);
            //
            // Register Form
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
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
            MaximizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
