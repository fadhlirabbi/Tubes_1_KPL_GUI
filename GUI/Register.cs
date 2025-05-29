using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions; // Required for regex validation
using System.Windows.Forms;
using Tubes_1_KPL.Model; // Make sure this namespace is correct for your User model
using API.Services; // Assuming ToDoListService is in API.Services

namespace GUI
{
    public partial class Register : Form
    {
        private readonly ToDoListService _toDoListService;

        public Register()
        {
            InitializeComponent();
            _toDoListService = ToDoListService.Instance; // Get the singleton instance
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Assuming your username input is named usernameTextBox
            string username = textBox1.Text;
            // Assuming your password input is named passwordTextBox
            string password = textBox2.Text;

            // 1. Validate input fields are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate password complexity
            // At least 8 characters, one uppercase, one lowercase, one digit, one special character
            // Note: The regex ensures characters only from A-Z, a-z, 0-9, and the specified special chars.
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character (e.g., @$!%*?&).",
                    "Password Policy Violation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Attempt to register using ToDoListService
            bool isRegistered = await _toDoListService.RegisterAsync(username, password);

            if (isRegistered)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, navigate to the login form or close the register form
                this.Hide(); // Hide the current form
                Login loginForm = new Login(); // Assuming your Login form class is named Login
                loginForm.Show(); // Show the login form
            }
            else
            {
                // If RegisterAsync returns false, it means the API call failed (e.g., username already exists).
                // The ToDoListService already logs the specific API message to the debug console.
                MessageBox.Show("Registration failed. This might be due to an existing username or a server error.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide(); // Hide the current form
        }
    }
}