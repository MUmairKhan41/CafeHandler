using System;
using System.Windows.Forms;

namespace CafeHandler.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        // ── Form Load ───────────────────────────────────────────────
        // Runs when the dashboard opens after login.
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Display logged-in user name and role in the top bar.
            // We read from LoginForm's static session variables.
            lblWelcome.Text = $"Welcome,  {LoginForm.LoggedInUser}" +
                              $"   |   Role: {LoginForm.LoggedInRole}";

            // ── Role-based access control ────────────────────────────
            // If the user is a Cashier (not admin), hide the
            // Manage Users button completely so they cannot access it.
            if (LoginForm.LoggedInRole != "admin")
                btnUsers.Visible = false;

            // Start the live clock timer.
            // The timer fires every 1000ms (1 second).
            timerClock.Start();
        }

        // ── Live Clock ──────────────────────────────────────────────
        // This method fires every 1 second (Interval = 1000ms).
        // It updates the date/time label with the current time.
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMM yyyy   hh:mm:ss tt");
        }

        // ── Logout Button ───────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before logging out
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // ── Clear session variables ──────────────────────────
                // Reset all static session data back to empty/zero.
                // This is important for security — the next user
                // logging in should not see the previous user's data.
                LoginForm.LoggedInUser = "";
                LoginForm.LoggedInRole = "";
                LoginForm.LoggedInUserId = 0;

                // Stop the clock timer before closing
                timerClock.Stop();

                // Open a fresh login form and close the dashboard
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        // ── Sidebar Navigation ──────────────────────────────────────
        // Each button opens its corresponding form using ShowDialog().
        // ShowDialog() is used instead of Show() so the dashboard
        // is locked behind the opened form — the user cannot
        // accidentally open multiple copies of the same form.

        private void btnMenuManager_Click(object sender, EventArgs e)
        {
            // Open Menu Manager — Admin only
            MenuManagerForm menuForm = new MenuManagerForm();
            menuForm.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            // Open POS New Order screen — Admin and Cashier
            NewOrderForm orderForm = new NewOrderForm();
            orderForm.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            // Open View Orders screen — Admin and Cashier
            ViewOrdersForm ordersForm = new ViewOrdersForm();
            ordersForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Open Reports screen — Admin only
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Open Manage Users screen — Admin only
            // (This button is already hidden for cashier role
            //  so only admins can reach this point)
            ManageUsersForm usersForm = new ManageUsersForm();
            usersForm.ShowDialog();
        }
    }
}