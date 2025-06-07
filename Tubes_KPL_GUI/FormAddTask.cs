namespace Tubes_KPL_GUI
{
    partial class FormAddTask
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

        #region Windows Form Designer generated code

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
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Font = new Font("Segoe UI", 10F);
            lblTaskName.Location = new Point(40, 30);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(110, 23);
            lblTaskName.TabIndex = 7;
            lblTaskName.Text = "Nama Tugas:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(40, 80);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(86, 23);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Deskripsi :";
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Font = new Font("Segoe UI", 10F);
            lblDeadline.Location = new Point(40, 121);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(86, 23);
            lblDeadline.TabIndex = 5;
            lblDeadline.Text = "Deadline :";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 10F);
            lblDay.Location = new Point(132, 131);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(73, 23);
            lblDay.TabIndex = 4;
            lblDay.Text = "Tanggal:";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 10F);
            lblMonth.Location = new Point(134, 169);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(62, 23);
            lblMonth.TabIndex = 3;
            lblMonth.Text = "Bulan :";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 10F);
            lblYear.Location = new Point(134, 205);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(60, 23);
            lblYear.TabIndex = 2;
            lblYear.Text = "Tahun:";
            // 
            // lblHour
            // 
            lblHour.AutoSize = true;
            lblHour.Font = new Font("Segoe UI", 10F);
            lblHour.Location = new Point(321, 133);
            lblHour.Name = "lblHour";
            lblHour.Size = new Size(49, 23);
            lblHour.TabIndex = 1;
            lblHour.Text = "Jam :";
            // 
            // lblMinute
            // 
            lblMinute.AutoSize = true;
            lblMinute.Font = new Font("Segoe UI", 10F);
            lblMinute.Location = new Point(307, 173);
            lblMinute.Name = "lblMinute";
            lblMinute.Size = new Size(63, 23);
            lblMinute.TabIndex = 0;
            lblMinute.Text = "Menit :";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(170, 30);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(200, 27);
            txtTaskName.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(170, 80);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 27);
            txtDescription.TabIndex = 1;
            // 
            // txtDay
            // 
            txtDay.Location = new Point(233, 129);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(60, 27);
            txtDay.TabIndex = 2;
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(233, 168);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(60, 27);
            txtMonth.TabIndex = 3;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(233, 206);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(60, 27);
            txtYear.TabIndex = 4;
            // 
            // txtHour
            // 
            txtHour.Location = new Point(387, 133);
            txtHour.Name = "txtHour";
            txtHour.Size = new Size(50, 27);
            txtHour.TabIndex = 5;
            // 
            // txtMinute
            // 
            txtMinute.Location = new Point(387, 172);
            txtMinute.Name = "txtMinute";
            txtMinute.Size = new Size(50, 27);
            txtMinute.TabIndex = 6;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.LightSkyBlue;
            btnAddTask.Location = new Point(170, 239);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(200, 40);
            btnAddTask.TabIndex = 7;
            btnAddTask.Text = "Tambah";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // FormAddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 300);
            Controls.Add(lblMinute);
            Controls.Add(lblHour);
            Controls.Add(lblYear);
            Controls.Add(lblMonth);
            Controls.Add(lblDay);
            Controls.Add(lblDeadline);
            Controls.Add(lblDescription);
            Controls.Add(lblTaskName);
            Controls.Add(txtMinute);
            Controls.Add(txtHour);
            Controls.Add(txtYear);
            Controls.Add(txtMonth);
            Controls.Add(txtDay);
            Controls.Add(txtDescription);
            Controls.Add(txtTaskName);
            Controls.Add(btnAddTask);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAddTask";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}