namespace GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lnkRegister = new LinkLabel();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(40, 30);
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            this.txtUsername.PlaceholderText = "Username";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(40, 70);
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Password";

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(40, 110);
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // lnkRegister
            this.lnkRegister.Location = new System.Drawing.Point(140, 118);
            this.lnkRegister.Text = "Register disini";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(40, 150);
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.AutoSize = true;

            // Form1
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lnkRegister);
            this.Controls.Add(this.lblStatus);
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
