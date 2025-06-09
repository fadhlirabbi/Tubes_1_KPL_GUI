namespace Tubes_KPL_GUI
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSidebar;
        private Panel panelMain;
        private PictureBox logoPictureBox;
        private Button btnBeranda;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnTandai;
        private Button btnHapus;
        private Button btnRiwayat;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private Button GetBtnBeranda()
        {
            return btnBeranda;
        }

        private void InitializeComponent(Button btnBeranda)
        {
            panelSidebar = new Panel();
            logoPictureBox = new PictureBox();
            btnBeranda = new Button();
            btnTambah = new Button();
            btnEdit = new Button();
            btnTandai = new Button();
            btnHapus = new Button();
            btnRiwayat = new Button();
            btnLogout = new Button();
            panelMain = new Panel();

            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightSkyBlue;
            panelSidebar.Controls.Add(logoPictureBox);
            panelSidebar.Controls.Add(btnBeranda);
            panelSidebar.Controls.Add(btnTambah);
            panelSidebar.Controls.Add(btnEdit);
            panelSidebar.Controls.Add(btnTandai);
            panelSidebar.Controls.Add(btnHapus);
            panelSidebar.Controls.Add(btnRiwayat);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(312, 900);
            panelSidebar.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = Color.LightSkyBlue;
            logoPictureBox.Image = Properties.Resources.Gambar_WhatsApp_2025_06_06_pukul_16_24_58_9758d871_removebg_preview__1_;
            logoPictureBox.Location = new Point(65, 15);
            logoPictureBox.Margin = new Padding(4);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(173, 149);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // btnBeranda
            // 
            btnBeranda.BackColor = Color.White;
            btnBeranda.FlatAppearance.BorderSize = 0;
            btnBeranda.FlatStyle = FlatStyle.Flat;
            btnBeranda.Location = new Point(50, 201);
            btnBeranda.Margin = new Padding(4);
            btnBeranda.Name = "btnBeranda";
            btnBeranda.Size = new Size(200, 50);
            btnBeranda.TabIndex = 1;
            btnBeranda.Text = "Beranda";
            btnBeranda.UseVisualStyleBackColor = false;
            btnBeranda.Click += btnBeranda_Click;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.White;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Location = new Point(50, 271);
            btnTambah.Margin = new Padding(4);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(200, 50);
            btnTambah.TabIndex = 2;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(50, 341);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(200, 50);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnTandai
            // 
            btnTandai.BackColor = Color.White;
            btnTandai.FlatAppearance.BorderSize = 0;
            btnTandai.FlatStyle = FlatStyle.Flat;
            btnTandai.Location = new Point(50, 411);
            btnTandai.Margin = new Padding(4);
            btnTandai.Name = "btnTandai";
            btnTandai.Size = new Size(200, 50);
            btnTandai.TabIndex = 4;
            btnTandai.Text = "Tandai";
            btnTandai.UseVisualStyleBackColor = false;
            btnTandai.Click += btnTandai_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.White;
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Location = new Point(50, 481);
            btnHapus.Margin = new Padding(4);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(200, 50);
            btnHapus.TabIndex = 5;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.White;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Location = new Point(50, 551);
            btnRiwayat.Margin = new Padding(4);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(200, 50);
            btnRiwayat.TabIndex = 6;
            btnRiwayat.Text = "Riwayat";
            btnRiwayat.UseVisualStyleBackColor = false;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Location = new Point(50, 785);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Keluar";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(312, 0);
            panelMain.Margin = new Padding(4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(968, 900);
            panelMain.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 900);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }
    }
}
