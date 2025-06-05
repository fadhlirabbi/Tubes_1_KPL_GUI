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
            // masukButton
            // 
            masukButton.BackColor = Color.LightSkyBlue;
            masukButton.Location = new Point(1102, 633);
            masukButton.Name = "masukButton";
            masukButton.Size = new Size(193, 60);
            masukButton.TabIndex = 0;
            masukButton.Text = "Masuk";
            masukButton.UseVisualStyleBackColor = false;
            masukButton.Click += MasukButton_Click;
            // 
            // daftarButton
            // 
            daftarButton.BackColor = SystemColors.ActiveBorder;
            daftarButton.Location = new Point(452, 633);
            daftarButton.Name = "daftarButton";
            daftarButton.Size = new Size(193, 60);
            daftarButton.TabIndex = 1;
            daftarButton.Text = "Daftar";
            daftarButton.UseVisualStyleBackColor = false;
            daftarButton.Click += DaftarButton_Click;
            // 
            // userTextBox
            // 
            userTextBox.BackColor = Color.WhiteSmoke;
            userTextBox.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userTextBox.ForeColor = SystemColors.WindowText;
            userTextBox.Location = new Point(728, 430);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(567, 35);
            userTextBox.TabIndex = 2;
            // 
            // passTextBox
            // 
            passTextBox.BackColor = Color.WhiteSmoke;
            passTextBox.Location = new Point(728, 508);
            passTextBox.Name = "passTextBox";
            passTextBox.Size = new Size(567, 35);
            passTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(452, 434);
            label1.Name = "label1";
            label1.Size = new Size(209, 31);
            label1.TabIndex = 4;
            label1.Text = "Nama Pengguna : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(452, 513);
            label2.Name = "label2";
            label2.Size = new Size(203, 31);
            label2.TabIndex = 5;
            label2.Text = "Kata Sandi         :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(512, 356);
            label3.Name = "label3";
            label3.Size = new Size(722, 49);
            label3.TabIndex = 6;
            label3.Text = "Selamat Datang di aplikasi To Do List";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_removebg_preview__2_1;
            pictureBox1.Location = new Point(740, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 230);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1774, 829);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passTextBox);
            Controls.Add(userTextBox);
            Controls.Add(daftarButton);
            Controls.Add(masukButton);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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