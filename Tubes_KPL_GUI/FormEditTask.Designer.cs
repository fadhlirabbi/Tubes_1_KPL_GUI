namespace Tubes_KPL_GUI
{
    partial class FormEditTask
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblOldTaskName, lblTaskName, lblDescription, lblDeadline, lblDay, lblMonth, lblYear, lblHour, lblMinute;
        private TextBox txtOldTaskName, txtTaskName, txtDescription, txtDay, txtMonth, txtYear, txtHour, txtMinute;
        private Button btnUpdateTask;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblOldTaskName = new Label();
            lblTaskName = new Label();
            lblDescription = new Label();
            lblDeadline = new Label();
            lblDay = new Label();
            lblMonth = new Label();
            lblYear = new Label();
            lblHour = new Label();
            lblMinute = new Label();
            txtOldTaskName = new TextBox();
            txtTaskName = new TextBox();
            txtDescription = new TextBox();
            txtDay = new TextBox();
            txtMonth = new TextBox();
            txtYear = new TextBox();
            txtHour = new TextBox();
            txtMinute = new TextBox();
            btnUpdateTask = new Button();
            SuspendLayout();
            // 
            // lblOldTaskName
            // 
            lblOldTaskName.Location = new Point(40, 30);
            lblOldTaskName.Name = "lblOldTaskName";
            lblOldTaskName.Size = new Size(200, 25);
            lblOldTaskName.TabIndex = 0;
            lblOldTaskName.Text = "Nama Tugas yang lama :";
            // 
            // lblTaskName
            // 
            lblTaskName.Location = new Point(40, 70);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(120, 25);
            lblTaskName.TabIndex = 2;
            lblTaskName.Text = "Nama Tugas :";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(40, 110);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(120, 25);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Deskripsi :";
            // 
            // lblDeadline
            // 
            lblDeadline.Location = new Point(40, 150);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(100, 25);
            lblDeadline.TabIndex = 6;
            lblDeadline.Text = "Tenggat :";
            // 
            // lblDay
            // 
            lblDay.BackColor = Color.Transparent;
            lblDay.Location = new Point(80, 180);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(80, 23);
            lblDay.TabIndex = 7;
            lblDay.Text = "Tanggal :";
            lblDay.Click += lblDay_Click;
            // 
            // lblMonth
            // 
            lblMonth.Location = new Point(80, 210);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(74, 23);
            lblMonth.TabIndex = 8;
            lblMonth.Text = "Bulan :";
            // 
            // lblYear
            // 
            lblYear.Location = new Point(80, 240);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(74, 23);
            lblYear.TabIndex = 9;
            lblYear.Text = "Tahun :";
            // 
            // lblHour
            // 
            lblHour.Location = new Point(250, 180);
            lblHour.Name = "lblHour";
            lblHour.Size = new Size(64, 23);
            lblHour.TabIndex = 10;
            lblHour.Text = "Jam :";
            // 
            // lblMinute
            // 
            lblMinute.Location = new Point(250, 210);
            lblMinute.Name = "lblMinute";
            lblMinute.Size = new Size(64, 23);
            lblMinute.TabIndex = 11;
            lblMinute.Text = "Menit :";
            // 
            // txtOldTaskName
            // 
            txtOldTaskName.Location = new Point(250, 30);
            txtOldTaskName.Name = "txtOldTaskName";
            txtOldTaskName.Size = new Size(400, 27);
            txtOldTaskName.TabIndex = 1;
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(250, 70);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(400, 27);
            txtTaskName.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(250, 110);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(400, 27);
            txtDescription.TabIndex = 5;
            // 
            // txtDay
            // 
            txtDay.Location = new Point(160, 180);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(60, 27);
            txtDay.TabIndex = 12;
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(160, 210);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(60, 27);
            txtMonth.TabIndex = 13;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(160, 240);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(60, 27);
            txtYear.TabIndex = 14;
            // 
            // txtHour
            // 
            txtHour.Location = new Point(320, 180);
            txtHour.Name = "txtHour";
            txtHour.Size = new Size(60, 27);
            txtHour.TabIndex = 15;
            // 
            // txtMinute
            // 
            txtMinute.Location = new Point(320, 210);
            txtMinute.Name = "txtMinute";
            txtMinute.Size = new Size(60, 27);
            txtMinute.TabIndex = 16;
            // 
            // btnUpdateTask
            // 
            btnUpdateTask.BackColor = Color.LightSkyBlue;
            btnUpdateTask.Location = new Point(550, 260);
            btnUpdateTask.Name = "btnUpdateTask";
            btnUpdateTask.Size = new Size(100, 40);
            btnUpdateTask.TabIndex = 17;
            btnUpdateTask.Text = "Perbarui";
            btnUpdateTask.UseVisualStyleBackColor = false;
            btnUpdateTask.Click += BtnUpdateTask_Click;
            // 
            // FormEditTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 320);
            Controls.Add(lblOldTaskName);
            Controls.Add(txtOldTaskName);
            Controls.Add(lblTaskName);
            Controls.Add(txtTaskName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblDeadline);
            Controls.Add(lblDay);
            Controls.Add(lblMonth);
            Controls.Add(lblYear);
            Controls.Add(lblHour);
            Controls.Add(lblMinute);
            Controls.Add(txtDay);
            Controls.Add(txtMonth);
            Controls.Add(txtYear);
            Controls.Add(txtHour);
            Controls.Add(txtMinute);
            Controls.Add(btnUpdateTask);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEditTask";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEditTask";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
