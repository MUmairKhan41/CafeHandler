using System;
using System.Windows.Forms;
using CafeHandler.Database;
using CafeHandler.Models;

namespace CafeHandler.Forms
{
    public partial class LoginForm : Form
    {
        // ── Static session variables ────────────────────────────────
        // These are static so ANY form in the project can read them
        // without needing a LoginForm object.
        // They store who is currently logged in for the whole session.
        public static string LoggedInUser = "";
        public static string LoggedInRole = "";
        public static int LoggedInUserId = 0;

        // ── Repository ──────────────────────────────────────────────
        // UserRepository handles all user-related database operations.
        // We create one instance and reuse it in this form.
        private readonly UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        // ── Form Load ───────────────────────────────────────────────
        // Runs automatically when the form opens.
        // We move the cursor to the username field for convenience.
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        // ── Exit Button ─────────────────────────────────────────────
        // Closes the entire application when clicked.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── Login Button ────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Step 1: Read and trim input
            // .Trim() removes any accidental leading/trailing spaces
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Step 2: Input validation — check for empty fields
            // We validate BEFORE touching the database
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both username and password.";
                lblError.ForeColor = System.Drawing.Color.Red;
                return; // Stop here — do not proceed to database
            }

            try
            {
                // Step 3: Call repository to authenticate
                // GetByCredentials() runs the SELECT query with
                // parameterized inputs to prevent SQL injection.
                // It returns a User object if found, or null if not.
                User loggedInUser = _userRepo.GetByCredentials(username, password);

                // Step 4: Check result
                if (loggedInUser != null)
                {
                    // ── Login SUCCESS ────────────────────────────────
                    // Store the logged-in user's info in static variables.
                    // These will be accessible from every other form.
                    LoggedInUserId = loggedInUser.UserId;
                    LoggedInUser = loggedInUser.FullName;
                    LoggedInRole = loggedInUser.Role;

                    // Show welcome message
                    MessageBox.Show(
                        $"Welcome, {LoggedInUser}!",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Open the dashboard and hide the login form
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    // ── Login FAILED ─────────────────────────────────
                    // No matching user found in the database.
                    lblError.Text = "Invalid username or password.";
                    lblError.ForeColor = System.Drawing.Color.Red;

                    // Clear password and focus it for retry
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors (e.g. database connection issue)
                lblError.Text = "Error: " + ex.Message;
            }
        }
    }
}