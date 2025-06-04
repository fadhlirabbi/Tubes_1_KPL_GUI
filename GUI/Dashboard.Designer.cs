using Microsoft.AspNetCore.Http;
using StatusModel = API.Model.Status;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;

namespace GUI
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.DataGridView taskGridView;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button editTaskButton;
        private System.Windows.Forms.Button deleteTaskButton;
        private System.Windows.Forms.Button markCompletedButton;
        private System.Windows.Forms.Button reminderButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.ComboBox statusComboBox;  

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            welcomeLabel = new Label();
            logoPictureBox = new PictureBox();
            taskGridView = new DataGridView();
            addTaskButton = new Button();
            editTaskButton = new Button();
            deleteTaskButton = new Button();
            markCompletedButton = new Button();
            reminderButton = new Button();
            historyButton = new Button();
            statusComboBox = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskGridView).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.Font = new Font("Times New Roman", 25F, FontStyle.Bold);
            welcomeLabel.Location = new Point(38, 79);
            welcomeLabel.Margin = new Padding(2, 0, 2, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(664, 67);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Selamat datang, [username]";
            welcomeLabel.Click += welcomeLabel_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.image_removebg_preview__2_;
            logoPictureBox.Location = new Point(955, 39);
            logoPictureBox.Margin = new Padding(2);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(171, 178);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // taskGridView
            // 
            taskGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taskGridView.ColumnHeadersHeight = 34;
            taskGridView.Location = new Point(38, 260);
            taskGridView.Margin = new Padding(2);
            taskGridView.Name = "taskGridView";
            taskGridView.ReadOnly = true;
            taskGridView.RowHeadersWidth = 62;
            taskGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            taskGridView.Size = new Size(846, 508);
            taskGridView.TabIndex = 2;
            // 
            // addTaskButton
            // 
            addTaskButton.Font = new Font("Times New Roman", 10F);
            addTaskButton.Location = new Point(205, 791);
            addTaskButton.Margin = new Padding(2);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(148, 48);
            addTaskButton.TabIndex = 3;
            addTaskButton.Text = "Tambah Tugas";
            addTaskButton.UseVisualStyleBackColor = true;
            addTaskButton.Click += addTaskButton_Click;
            // 
            // editTaskButton
            // 
            editTaskButton.Font = new Font("Times New Roman", 10F);
            editTaskButton.Location = new Point(374, 791);
            editTaskButton.Margin = new Padding(2);
            editTaskButton.Name = "editTaskButton";
            editTaskButton.Size = new Size(148, 48);
            editTaskButton.TabIndex = 4;
            editTaskButton.Text = "Edit Tugas";
            editTaskButton.UseVisualStyleBackColor = true;
            editTaskButton.Click += editTaskButton_Click;
            // 
            // deleteTaskButton
            // 
            deleteTaskButton.Font = new Font("Times New Roman", 10F);
            deleteTaskButton.Location = new Point(543, 791);
            deleteTaskButton.Margin = new Padding(2);
            deleteTaskButton.Name = "deleteTaskButton";
            deleteTaskButton.Size = new Size(148, 48);
            deleteTaskButton.TabIndex = 5;
            deleteTaskButton.Text = "Hapus Tugas";
            deleteTaskButton.UseVisualStyleBackColor = true;
            deleteTaskButton.Click += deleteTaskButton_Click;
            // 
            // markCompletedButton
            // 
            markCompletedButton.Font = new Font("Times New Roman", 10F);
            markCompletedButton.Location = new Point(966, 416);
            markCompletedButton.Margin = new Padding(2);
            markCompletedButton.Name = "markCompletedButton";
            markCompletedButton.Size = new Size(148, 48);
            markCompletedButton.TabIndex = 6;
            markCompletedButton.Text = "Tandai Selesai";
            markCompletedButton.UseVisualStyleBackColor = true;
            markCompletedButton.Click += markCompletedButton_Click;
            // 
            // reminderButton
            // 
            reminderButton.Font = new Font("Times New Roman", 10F);
            reminderButton.Location = new Point(966, 338);
            reminderButton.Margin = new Padding(2);
            reminderButton.Name = "reminderButton";
            reminderButton.Size = new Size(148, 48);
            reminderButton.TabIndex = 7;
            reminderButton.Text = "Lihat Reminder";
            reminderButton.UseVisualStyleBackColor = true;
            reminderButton.Click += reminderButton_Click;
            // 
            // historyButton
            // 
            historyButton.Font = new Font("Times New Roman", 10F);
            historyButton.Location = new Point(966, 260);
            historyButton.Margin = new Padding(2);
            historyButton.Name = "historyButton";
            historyButton.Size = new Size(148, 48);
            historyButton.TabIndex = 8;
            historyButton.Text = "Riwayat";
            historyButton.UseVisualStyleBackColor = true;
            historyButton.Click += historyButton_Click;
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.Items.AddRange(new object[] { "Incompleted", "Completed", "Overdue" });
            statusComboBox.Location = new Point(736, 200);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(148, 33);
            statusComboBox.TabIndex = 9;
            statusComboBox.SelectedIndexChanged += statusComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(656, 203);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 10;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 891);
            Controls.Add(label1);
            Controls.Add(statusComboBox);
            Controls.Add(deleteTaskButton);
            Controls.Add(markCompletedButton);
            Controls.Add(reminderButton);
            Controls.Add(historyButton);
            Controls.Add(logoPictureBox);
            Controls.Add(welcomeLabel);
            Controls.Add(taskGridView);
            Controls.Add(addTaskButton);
            Controls.Add(editTaskButton);
            Margin = new Padding(2);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
