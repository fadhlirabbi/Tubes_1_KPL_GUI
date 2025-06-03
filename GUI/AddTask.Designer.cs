using GUI;

namespace GUI
{
    partial class AddTask
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label taskNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label deadlineLabel;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox hourTextBox;
        private System.Windows.Forms.TextBox minuteTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PictureBox logoPictureBox;

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
            taskNameLabel = new Label();
            descriptionLabel = new Label();
            deadlineLabel = new Label();
            taskNameTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            dayTextBox = new TextBox();
            monthTextBox = new TextBox();
            yearTextBox = new TextBox();
            hourTextBox = new TextBox();
            minuteTextBox = new TextBox();
            addButton = new Button();
            logoPictureBox = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // taskNameLabel
            // 
            taskNameLabel.AutoSize = true;
            taskNameLabel.Font = new Font("Times New Roman", 12F);
            taskNameLabel.Location = new Point(50, 53);
            taskNameLabel.Name = "taskNameLabel";
            taskNameLabel.Size = new Size(113, 22);
            taskNameLabel.TabIndex = 0;
            taskNameLabel.Text = "Nama Tugas:";
            taskNameLabel.Click += taskNameLabel_Click;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Times New Roman", 12F);
            descriptionLabel.Location = new Point(50, 103);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(93, 22);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Deskripsi:";
            // 
            // deadlineLabel
            // 
            deadlineLabel.AutoSize = true;
            deadlineLabel.Font = new Font("Times New Roman", 12F);
            deadlineLabel.Location = new Point(50, 157);
            deadlineLabel.Name = "deadlineLabel";
            deadlineLabel.Size = new Size(180, 22);
            deadlineLabel.TabIndex = 2;
            deadlineLabel.Text = "Deadline(dd/mm/yy):";
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.Font = new Font("Times New Roman", 12F);
            taskNameTextBox.Location = new Point(310, 50);
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(567, 30);
            taskNameTextBox.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Font = new Font("Times New Roman", 12F);
            descriptionTextBox.Location = new Point(310, 100);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(567, 30);
            descriptionTextBox.TabIndex = 4;
            // 
            // dayTextBox
            // 
            dayTextBox.Font = new Font("Times New Roman", 12F);
            dayTextBox.Location = new Point(310, 154);
            dayTextBox.Name = "dayTextBox";
            dayTextBox.Size = new Size(60, 30);
            dayTextBox.TabIndex = 5;
            // 
            // monthTextBox
            // 
            monthTextBox.Font = new Font("Times New Roman", 12F);
            monthTextBox.Location = new Point(380, 154);
            monthTextBox.Name = "monthTextBox";
            monthTextBox.Size = new Size(60, 30);
            monthTextBox.TabIndex = 6;
            // 
            // yearTextBox
            // 
            yearTextBox.Font = new Font("Times New Roman", 12F);
            yearTextBox.Location = new Point(450, 154);
            yearTextBox.Name = "yearTextBox";
            yearTextBox.Size = new Size(80, 30);
            yearTextBox.TabIndex = 7;
            // 
            // hourTextBox
            // 
            hourTextBox.Font = new Font("Times New Roman", 12F);
            hourTextBox.Location = new Point(310, 204);
            hourTextBox.Name = "hourTextBox";
            hourTextBox.Size = new Size(60, 30);
            hourTextBox.TabIndex = 8;
            // 
            // minuteTextBox
            // 
            minuteTextBox.Font = new Font("Times New Roman", 12F);
            minuteTextBox.Location = new Point(380, 204);
            minuteTextBox.Name = "minuteTextBox";
            minuteTextBox.Size = new Size(60, 30);
            minuteTextBox.TabIndex = 9;
            // 
            // addButton
            // 
            addButton.Font = new Font("Times New Roman", 12F);
            addButton.Location = new Point(310, 279);
            addButton.Name = "addButton";
            addButton.Size = new Size(256, 61);
            addButton.TabIndex = 10;
            addButton.Text = "Tambah";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.image_removebg_preview__2_;
            logoPictureBox.Location = new Point(920, 30);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(200, 200);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 11;
            logoPictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(50, 207);
            label1.Name = "label1";
            label1.Size = new Size(99, 22);
            label1.TabIndex = 12;
            label1.Text = "Jam/Menit:";
            // 
            // AddTask
            // 
            ClientSize = new Size(1175, 391);
            Controls.Add(label1);
            Controls.Add(logoPictureBox);
            Controls.Add(addButton);
            Controls.Add(minuteTextBox);
            Controls.Add(hourTextBox);
            Controls.Add(yearTextBox);
            Controls.Add(monthTextBox);
            Controls.Add(dayTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(taskNameTextBox);
            Controls.Add(deadlineLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(taskNameLabel);
            Name = "AddTask";
            Text = "Tambah Tugas";
            Load += AddTask_Load;
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}