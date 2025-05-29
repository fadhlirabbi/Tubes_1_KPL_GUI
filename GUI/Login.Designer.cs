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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.SkyBlue;
            button1.Location = new Point(915, 579);
            button1.Name = "button1";
            button1.Size = new Size(193, 61);
            button1.TabIndex = 0;
            button1.Text = "Masuk";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLight;
            button2.Location = new Point(290, 579);
            button2.Name = "button2";
            button2.Size = new Size(193, 61);
            button2.TabIndex = 1;
            button2.Text = "Daftar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.MenuBar;
            textBox1.Location = new Point(541, 406);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(567, 39);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.MenuBar;
            textBox2.Location = new Point(541, 472);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(567, 39);
            textBox2.TabIndex = 3;
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
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
    }
}