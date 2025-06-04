namespace GUI
{
    partial class Register
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
            DaftarBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            userTextBox = new TextBox();
            passTextBox = new TextBox();
            MasukBtn = new Button();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            DaftarBtn.BackColor = Color.SkyBlue;
            DaftarBtn.Location = new Point(915, 623);
            DaftarBtn.Name = "button1";
            DaftarBtn.Size = new Size(193, 61);
            DaftarBtn.TabIndex = 0;
            DaftarBtn.Text = "Daftar";
            DaftarBtn.UseVisualStyleBackColor = false;
            DaftarBtn.Click += DaftarBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 411);
            label1.Name = "label1";
            label1.Size = new Size(209, 31);
            label1.TabIndex = 1;
            label1.Text = "Nama Pengguna : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(290, 477);
            label2.Name = "label2";
            label2.Size = new Size(203, 31);
            label2.TabIndex = 2;
            label2.Text = "Kata Sandi         :";
            // 
            // textBox1
            // 
            userTextBox.BackColor = SystemColors.MenuBar;
            userTextBox.Location = new Point(541, 406);
            userTextBox.Name = "textBox1";
            userTextBox.Size = new Size(567, 39);
            userTextBox.TabIndex = 3;
            // 
            // textBox2
            // 
            passTextBox.BackColor = SystemColors.MenuBar;
            passTextBox.Location = new Point(541, 472);
            passTextBox.Name = "textBox2";
            passTextBox.Size = new Size(567, 39);
            passTextBox.TabIndex = 4;
            // 
            // button2
            // 
            MasukBtn.BackColor = SystemColors.ControlLight;
            MasukBtn.Location = new Point(290, 623);
            MasukBtn.Name = "button2";
            MasukBtn.Size = new Size(193, 61);
            MasukBtn.TabIndex = 5;
            MasukBtn.Text = "Kembali";
            MasukBtn.UseVisualStyleBackColor = false;
            MasukBtn.Click += MasukBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(290, 536);
            label3.Name = "label3";
            label3.Size = new Size(752, 23);
            label3.TabIndex = 6;
            label3.Text = "Kata sandi harus terdiri dari 8 karakter, ada huruf kapital, huruf kecil, dan karakter khusus";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(246, 321);
            label4.Name = "label4";
            label4.Size = new Size(915, 49);
            label4.TabIndex = 7;
            label4.Text = "Silakan isi nama pengguna dan kata sandi Anda";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_removebg_preview__2_;
            pictureBox1.Location = new Point(587, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1432, 828);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(MasukBtn);
            Controls.Add(passTextBox);
            Controls.Add(userTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DaftarBtn);
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DaftarBtn;
        private Label label1;
        private Label label2;
        private TextBox userTextBox;
        private TextBox passTextBox;
        private Button MasukBtn;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
    }
}