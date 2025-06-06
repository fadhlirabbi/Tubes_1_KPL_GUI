using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

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
            ((System.ComponentModel.ISupportInitialize)(taskGridView)).BeginInit();
            SuspendLayout();
            //
            // welcomeLabel
            //
            welcomeLabel.Font = new System.Drawing.Font("Times New Roman", 18F, FontStyle.Bold);
            welcomeLabel.Location = new Point(40, 20);
            welcomeLabel.Size = new Size(700, 40);
            welcomeLabel.Text = "Selamat datang, [nama user]";
            //
            // motivationLabel
            //
            motivationLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            motivationLabel.Location = new Point(40, 60);
            motivationLabel.Size = new Size(700, 30);
            motivationLabel.Text = "Setiap langkah kecil adalah kemajuan besar.";
            //
            // taskGridView
            //
            taskGridView.Location = new Point(40, 100);
            taskGridView.Size = new Size(720, 350);
            taskGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskGridView.ReadOnly = true;
            taskGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taskGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            taskGridView.RowHeadersVisible = false;
            //
            // FormBeranda
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 480);
            Controls.Add(taskGridView);
            Controls.Add(motivationLabel);
            Controls.Add(welcomeLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBeranda";
            Text = "FormBeranda";
            Load += FormBeranda_Load;

            ((System.ComponentModel.ISupportInitialize)(taskGridView)).EndInit();
            ResumeLayout(false);
        }
    }
}
