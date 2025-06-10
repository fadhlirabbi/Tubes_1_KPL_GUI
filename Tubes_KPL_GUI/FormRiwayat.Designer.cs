namespace Tubes_KPL_GUI
{
    partial class FormRiwayat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRiwayat;
        private System.Windows.Forms.Label lblRiwayat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvRiwayat = new System.Windows.Forms.DataGridView();
            this.lblRiwayat = new System.Windows.Forms.Label();

            // DataGridView columns
            var colTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                HeaderText = "Nama Tugas",
                Name = "colTaskName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                HeaderText = "Deskripsi",
                Name = "colDescription",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                HeaderText = "Tanggal",
                Name = "colTanggal",
                Width = 100
            };

            var colWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                HeaderText = "Waktu",
                Name = "colWaktu",
                Width = 80
            };

            var colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                Name = "colStatus",
                Width = 100
            };

            // 
            // dgvRiwayat
            // 
            this.dgvRiwayat.AllowUserToAddRows = false;
            this.dgvRiwayat.AllowUserToDeleteRows = false;
            this.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        colTaskName,
        colDescription,
        colTanggal,
        colWaktu,
        colStatus 
    });
            this.dgvRiwayat.Location = new System.Drawing.Point(20, 60);
            this.dgvRiwayat.Name = "dgvRiwayat";
            this.dgvRiwayat.ReadOnly = true;
            this.dgvRiwayat.RowHeadersVisible = false;
            this.dgvRiwayat.Size = new System.Drawing.Size(640, 300);
            this.dgvRiwayat.TabIndex = 0;

            // 
            // lblRiwayat
            // 
            this.lblRiwayat.AutoSize = true;
            this.lblRiwayat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRiwayat.Location = new System.Drawing.Point(20, 20);
            this.lblRiwayat.Name = "lblRiwayat";
            this.lblRiwayat.Size = new System.Drawing.Size(197, 25);
            this.lblRiwayat.Text = "Riwayat Tugas Selesai";

            // 
            // FormRiwayat
            // 
            this.ClientSize = new System.Drawing.Size(684, 381);
            this.Controls.Add(this.dgvRiwayat);
            this.Controls.Add(this.lblRiwayat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRiwayat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riwayat Tugas";
            this.Load += new System.EventHandler(this.FormRiwayat_Load);
        }

    }
}
