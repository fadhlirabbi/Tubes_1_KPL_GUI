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
            titleLabel.Text = "Silakan isi nama pengguna dan kata sandi Anda";
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
            // userTextBox
            // 
            userTextBox.BackColor = SystemColors.Control;
            userTextBox.Location = new Point(636, 615);
            userTextBox.Margin = new Padding(5);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(607, 39);
            userTextBox.TabIndex = 4;
            // 
            // passTextBox
            // 
            passTextBox.BackColor = SystemColors.Control;
            passTextBox.Location = new Point(636, 690);
            passTextBox.Margin = new Padding(5);
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '*';
            passTextBox.Size = new Size(607, 39);
            passTextBox.TabIndex = 5;
            // 
            // noteLabel
            // 
            noteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            noteLabel.ForeColor = Color.Gray;
            noteLabel.Location = new Point(421, 749);
            noteLabel.Margin = new Padding(5, 0, 5, 0);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(812, 64);
            noteLabel.TabIndex = 6;
            noteLabel.Text = "Kata sandi harus terdiri dari ≥ 8 karakter, dengan huruf besar, kecil, angka, dan simbol.";
            noteLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // daftarBtn
            // 
            daftarBtn.BackColor = Color.LightSkyBlue;
            daftarBtn.Location = new Point(1026, 854);
            daftarBtn.Margin = new Padding(5);
            daftarBtn.Name = "daftarBtn";
            daftarBtn.Size = new Size(217, 63);
            daftarBtn.TabIndex = 7;
            daftarBtn.Text = "Daftar";
            daftarBtn.UseVisualStyleBackColor = false;
            daftarBtn.Click += DaftarBtn_Click;
            // 
            // kembaliBtn
            // 
            kembaliBtn.BackColor = SystemColors.ScrollBar;
            kembaliBtn.Location = new Point(405, 854);
            kembaliBtn.Margin = new Padding(5);
            kembaliBtn.Name = "kembaliBtn";
            kembaliBtn.Size = new Size(217, 63);
            kembaliBtn.TabIndex = 8;
            kembaliBtn.Text = "Kembali";
            kembaliBtn.UseVisualStyleBackColor = false;
            kembaliBtn.Click += KembaliBtn_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1664, 1152);
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
            Margin = new Padding(5);
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
