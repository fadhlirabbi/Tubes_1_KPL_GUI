namespace GUI
{
    partial class Login
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
            masukButton = new Button();
            daftarButton = new Button();
            userTextBox = new TextBox();
            passTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            masukButton.BackColor = Color.SkyBlue;
            masukButton.Location = new Point(915, 579);
            masukButton.Name = "button1";
            masukButton.Size = new Size(193, 61);
            masukButton.TabIndex = 0;
            masukButton.Text = "Masuk";
            masukButton.UseVisualStyleBackColor = false;
            masukButton.Click += MasukButton_Click;
            // 
            // button2
            // 
            daftarButton.BackColor = SystemColors.ControlLight;

            daftarButton.Name = "button2";
            daftarButton.Location = new Point(290, 579);
            daftarButton.Size = new Size(193, 61);
            daftarButton.TabIndex = 1;
            daftarButton.Text = "Daftar";
            daftarButton.UseVisualStyleBackColor = false;
            daftarButton.Click += DaftarButton_Click;
            // 
            // textBox1
            // 
            userTextBox.BackColor = SystemColors.MenuBar;
            userTextBox.Location = new Point(541, 406);
            userTextBox.Name = "textBox1";
            userTextBox.Size = new Size(567, 39);
            userTextBox.TabIndex = 2;
            // 
            // textBox2
            // 
            passTextBox.BackColor = SystemColors.MenuBar;
            passTextBox.Location = new Point(541, 472);
            passTextBox.Name = "textBox2";
            passTextBox.Size = new Size(567, 39);
            passTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 411);
            label1.Name = "label1";
            label1.Size = new Size(209, 31);
            label1.TabIndex = 4;
            label1.Text = "Nama Pengguna : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(290, 477);
            label2.Name = "label2";
            label2.Size = new Size(203, 31);
            label2.TabIndex = 5;
            label2.Text = "Kata Sandi         :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(337, 321);
            label3.Name = "label3";
            label3.Size = new Size(722, 49);
            label3.TabIndex = 6;
            label3.Text = "Selamat Datang di aplikasi To Do List";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_removebg_preview__2_1;
            pictureBox1.Location = new Point(587, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1432, 828);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passTextBox);
            Controls.Add(userTextBox);
            Controls.Add(daftarButton);
            Controls.Add(masukButton);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button masukButton;
        private Button daftarButton;
        private TextBox userTextBox;
        private TextBox passTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
    }
}