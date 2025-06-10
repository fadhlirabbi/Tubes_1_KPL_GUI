using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tubes_KPL_GUI
{
    public partial class Dashboard : Form
    {
        private Panel panelSidebar;
        private Panel panelMain;
        private PictureBox logoPictureBox;
        private RoundedButton btnBeranda;
        private RoundedButton btnTambah;
        private RoundedButton btnEdit;
        private RoundedButton btnTandai;
        private RoundedButton btnHapus;
        private RoundedButton btnRiwayat;
        private RoundedButton btnLogout;

        public Dashboard()
        {
            InitializeComponent(); // Initialize components
        }

        private void InitializeComponent()
        {
            // inisialisasi
            panelSidebar = new Panel();
            logoPictureBox = new PictureBox();
            btnBeranda = new RoundedButton();
            btnTambah = new RoundedButton();
            btnEdit = new RoundedButton();
            btnTandai = new RoundedButton();
            btnHapus = new RoundedButton();
            btnRiwayat = new RoundedButton();
            btnLogout = new RoundedButton();
            panelMain = new Panel();

            // Set properties untuk panelsidebar
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
            panelSidebar.Size = new Size(312, 900);

            // Set properties untuk logoPictureBox
            logoPictureBox.Image = Properties.Resources.Gambar_WhatsApp_2025_06_06_pukul_16_24_58_9758d871_removebg_preview__1_;
            logoPictureBox.Location = new Point(65, 15);
            logoPictureBox.Size = new Size(173, 149);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Set properties untuk btnBeranda
            btnBeranda.Text = "Beranda";
            btnBeranda.Location = new Point(50, 201);
            btnBeranda.Size = new Size(200, 50);
            btnBeranda.Click += btnBeranda_Click;

            // Set properties untuk btnTambah
            btnTambah.Text = "Tambah Task";
            btnTambah.Location = new Point(50, 271);
            btnTambah.Size = new Size(200, 50);
            btnTambah.Click += btnTambah_Click;

            // Set properties untuk btnEdit
            btnEdit.Text = "Edit Task";
            btnEdit.Location = new Point(50, 341);
            btnEdit.Size = new Size(200, 50);
            btnEdit.Click += btnEdit_Click;

            // Set properties untuk btnTandai
            btnTandai.Text = "Tandai Task Selesai";
            btnTandai.Location = new Point(50, 411);
            btnTandai.Size = new Size(200, 50);
            btnTandai.Click += btnTandai_Click;

            // Set properties untuk btnHapus
            btnHapus.Text = "Hapus Task";
            btnHapus.Location = new Point(50, 481);
            btnHapus.Size = new Size(200, 50);
            btnHapus.Click += btnHapus_Click;

            // Set properties untuk btnRiwayat
            btnRiwayat.Text = "Riwayat Task";
            btnRiwayat.Location = new Point(50, 551);
            btnRiwayat.Size = new Size(200, 50);
            btnRiwayat.Click += btnRiwayat_Click;

            // Set properties untuk btnLogout
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(50, 785);
            btnLogout.Size = new Size(200, 50);
            btnLogout.Click += btnLogout_Click;

            // Set properties untuk panelMain
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Size = new Size(968, 900);

            // Set properties untuk Dashboard form
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1280, 900);
            this.Controls.Add(panelMain);
            this.Controls.Add(panelSidebar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += Dashboard_Load;
        }        
    }
}
