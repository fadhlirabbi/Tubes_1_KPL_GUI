namespace Tubes_KPL_GUI
{
    partial class FormMarkDone
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTaskName;
        private Label lblDescription;
        private Label lblDeadline;
        private Label lblDay;
        private Label lblMonth;
        private Label lblYear;
        private Label lblHour;
        private Label lblMinute;

        private TextBox txtTaskName;
        private TextBox txtDescription;
        private TextBox txtDay;
        private TextBox txtMonth;
        private TextBox txtYear;
        private TextBox txtHour;
        private TextBox txtMinute;

        private Button btnAddTask;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTaskName = new Label();
            lblDescription = new Label();
            lblDeadline = new Label();
            lblDay = new Label();
            lblMonth = new Label();
            lblYear = new Label();
            lblHour = new Label();
            lblMinute = new Label();

            txtTaskName = new TextBox();
            txtDescription = new TextBox();
            txtDay = new TextBox();
            txtMonth = new TextBox();
            txtYear = new TextBox();
            txtHour = new TextBox();
            txtMinute = new TextBox();

            btnAddTask = new Button();
            SuspendLayout();

            // Labels
            lblTaskName.AutoSize = true;
            lblTaskName.Font = new Font("Segoe UI", 10F);
            lblTaskName.Location = new Point(40, 30);
            lblTaskName.Text = "Nama Tugas:";

            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(40, 80);
            lblDescription.Text = "Deskripsi :";

            lblDeadline.AutoSize = true;
            lblDeadline.Font = new Font("Segoe UI", 10F);
            lblDeadline.Location = new Point(40, 121);
            lblDeadline.Text = "Deadline :";

            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 10F);
            lblDay.Location = new Point(132, 131);
            lblDay.Text = "Tanggal:";

            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 10F);
            lblMonth.Location = new Point(134, 169);
            lblMonth.Text = "Bulan :";

            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 10F);
            lblYear.Location = new Point(134, 205);
            lblYear.Text = "Tahun:";

            lblHour.AutoSize = true;
            lblHour.Font = new Font("Segoe UI", 10F);
            lblHour.Location = new Point(321, 133);
            lblHour.Text = "Jam :";

            lblMinute.AutoSize = true;
            lblMinute.Font = new Font("Segoe UI", 10F);
            lblMinute.Location = new Point(307, 173);
            lblMinute.Text = "Menit :";

            // Textboxes
            txtTaskName.Location = new Point(170, 30);
            txtTaskName.Size = new Size(200, 27);

            txtDescription.Location = new Point(170, 80);
            txtDescription.Size = new Size(200, 27);

            txtDay.Location = new Point(233, 129);
            txtDay.Size = new Size(60, 27);

            txtMonth.Location = new Point(233, 168);
            txtMonth.Size = new Size(60, 27);

            txtYear.Location = new Point(233, 206);
            txtYear.Size = new Size(60, 27);

            txtHour.Location = new Point(387, 133);
            txtHour.Size = new Size(50, 27);

            txtMinute.Location = new Point(387, 172);
            txtMinute.Size = new Size(50, 27);

            // Button
            btnAddTask.BackColor = Color.LightSkyBlue;
            btnAddTask.Location = new Point(170, 239);
            btnAddTask.Size = new Size(200, 40);
            btnAddTask.Text = "Tandai Selesai";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnTandaiSelesai_Click;

            // FormMarkDone
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 300);
            Controls.Add(lblTaskName);
            Controls.Add(lblDescription);
            Controls.Add(lblDeadline);
            Controls.Add(lblDay);
            Controls.Add(lblMonth);
            Controls.Add(lblYear);
            Controls.Add(lblHour);
            Controls.Add(lblMinute);
            Controls.Add(txtTaskName);
            Controls.Add(txtDescription);
            Controls.Add(txtDay);
            Controls.Add(txtMonth);
            Controls.Add(txtYear);
            Controls.Add(txtHour);
            Controls.Add(txtMinute);
            Controls.Add(btnAddTask);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMarkDone";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMarkDone";
            Load += FormMarkDone_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
