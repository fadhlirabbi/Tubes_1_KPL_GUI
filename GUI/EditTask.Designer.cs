namespace GUI
{
    partial class EditTask
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label deadlineLabel;
        private System.Windows.Forms.DateTimePicker deadlinePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

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
            nameLabel = new Label();
            nameTextBox = new TextBox();
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            deadlineLabel = new Label();
            deadlinePicker = new DateTimePicker();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 41);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(63, 25);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Nama:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(147, 41);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(273, 31);
            nameTextBox.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(12, 81);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(88, 25);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Deskripsi:";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(147, 78);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(273, 31);
            descriptionTextBox.TabIndex = 3;
            // 
            // deadlineLabel
            // 
            deadlineLabel.AutoSize = true;
            deadlineLabel.Location = new Point(12, 121);
            deadlineLabel.Name = "deadlineLabel";
            deadlineLabel.Size = new Size(85, 25);
            deadlineLabel.TabIndex = 4;
            deadlineLabel.Text = "Deadline:";
            // 
            // deadlinePicker
            // 
            deadlinePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            deadlinePicker.Format = DateTimePickerFormat.Custom;
            deadlinePicker.Location = new Point(147, 116);
            deadlinePicker.Name = "deadlinePicker";
            deadlinePicker.Size = new Size(273, 31);
            deadlinePicker.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(130, 190);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 30);
            saveButton.TabIndex = 6;
            saveButton.Text = "Simpan";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(232, 190);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 30);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Batal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EditTask
            // 
            ClientSize = new Size(477, 251);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(deadlinePicker);
            Controls.Add(deadlineLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(descriptionLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Name = "EditTask";
            Text = "Edit Task";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
