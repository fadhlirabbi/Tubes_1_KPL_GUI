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

        private void InitializeComponent()
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
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightSkyBlue;
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Width = 250;
            panelSidebar.Controls.AddRange(new Control[] {
                logoPictureBox,
                btnBeranda,
                btnTambah,
                btnEdit,
                btnTandai,
                btnHapus,
                btnRiwayat,
                btnLogout
            });
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.wallpaperflare_com_wallpaper;
            logoPictureBox.Location = new Point(65, 20);
            logoPictureBox.Size = new Size(120, 100);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // btnBeranda
            // 
            InitNavButton(btnBeranda, "Beranda", 140, btnBeranda_Click);
            // 
            // btnTambah
            // 
            InitNavButton(btnTambah, "Tambah Tugas", 180, btnTambah_Click);
            // 
            // btnEdit
            // 
            InitNavButton(btnEdit, "Edit Tugas", 220, btnEdit_Click);
            // 
            // btnTandai
            // 
            InitNavButton(btnTandai, "Tandai Selesai", 260, btnTandai_Click);
            // 
            // btnHapus
            // 
            InitNavButton(btnHapus, "Hapus Tugas", 300, btnHapus_Click);
            // 
            // btnRiwayat
            // 
            InitNavButton(btnRiwayat, "Riwayat", 340, btnRiwayat_Click);
            // 
            // btnLogout
            // 
            btnLogout.Text = "Keluar";
            btnLogout.Location = new Point(50, 600);
            btnLogout.Size = new Size(150, 40);
            btnLogout.BackColor = Color.Silver;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.White;
            panelMain.Name = "panelMain";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 720);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;

            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).EndInit();
            ResumeLayout(false);
        }

        private void InitNavButton(Button button, string text, int top, EventHandler handler)
        {
            button.Text = text;
            button.Location = new Point(20, top);
            button.Size = new Size(200, 35);
            button.Font = new Font("Segoe UI", 10F);
            button.Click += handler;
            button.BackColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }
    }
}
