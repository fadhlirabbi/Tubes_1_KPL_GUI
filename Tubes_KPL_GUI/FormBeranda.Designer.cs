namespace Tubes_KPL_GUI
{
    partial class FormBeranda
    {
        private System.ComponentModel.IContainer components = null;
        private Label welcomeLabel;
        private Label motivationLabel;
        private DataGridView taskGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            welcomeLabel = new Label();
            motivationLabel = new Label();
            taskGridView = new DataGridView();
            colTaskName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colWaktu = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)taskGridView).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            welcomeLabel.Location = new Point(50, 25);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(875, 50);
            welcomeLabel.TabIndex = 2;
            welcomeLabel.Text = "Selamat datang, [nama user]";
            // 
            // motivationLabel
            // 
            motivationLabel.Font = new Font("Segoe UI", 11F);
            motivationLabel.Location = new Point(50, 75);
            motivationLabel.Margin = new Padding(4, 0, 4, 0);
            motivationLabel.Name = "motivationLabel";
            motivationLabel.Size = new Size(875, 38);
            motivationLabel.TabIndex = 1;
            motivationLabel.Text = "Setiap langkah kecil adalah kemajuan besar, Berikut ini adalah catatan tugas kamu!.";
            motivationLabel.Click += motivationLabel_Click;
            // 
            // taskGridView
            // 
            taskGridView.AllowUserToAddRows = false;
            taskGridView.AllowUserToDeleteRows = false;
            taskGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taskGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            taskGridView.Columns.AddRange(new DataGridViewColumn[] { colTaskName, colDescription, colTanggal, colWaktu, colStatus });
            taskGridView.Location = new Point(50, 125);
            taskGridView.Margin = new Padding(4, 4, 4, 4);
            taskGridView.Name = "taskGridView";
            taskGridView.ReadOnly = true;
            taskGridView.RowHeadersVisible = false;
            taskGridView.RowHeadersWidth = 62;
            taskGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            taskGridView.Size = new Size(900, 438);
            taskGridView.TabIndex = 0;
            // 
            // colTaskName
            // 
            colTaskName.MinimumWidth = 8;
            colTaskName.Name = "Nama Tugas";
            colTaskName.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.MinimumWidth = 8;
            colDescription.Name = "Deskripsi";
            colDescription.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.MinimumWidth = 8;
            colTanggal.Name = "Tanggal";
            colTanggal.ReadOnly = true;
            // 
            // colWaktu
            // 
            colWaktu.MinimumWidth = 8;
            colWaktu.Name = "Waktu";
            colWaktu.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.MinimumWidth = 8;
            colStatus.Name = "Status";
            colStatus.ReadOnly = true;
            // 
            // FormBeranda
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(taskGridView);
            Controls.Add(motivationLabel);
            Controls.Add(welcomeLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormBeranda";
            Text = "FormBeranda";
            Load += FormBeranda_Load;
            ((System.ComponentModel.ISupportInitialize)taskGridView).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn colTaskName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colWaktu;
        private DataGridViewTextBoxColumn colStatus;
    }
}
