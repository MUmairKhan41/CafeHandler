using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CafeHandler.Database;
using CafeHandler.Models;

namespace CafeHandler.Forms
{
    public partial class ManageUsersForm : Form
    {
        // ── Repository ──────────────────────────────────────────────
        private readonly UserRepository _userRepo = new UserRepository();

        // ── State variable ──────────────────────────────────────────
        // Same pattern as MenuManagerForm:
        // 0 = no user selected → Save will INSERT
        // >0 = user selected   → Save will UPDATE
        private int _selectedUserId = 0;

        public ManageUsersForm()
        {
            InitializeComponent();
        }

        // ── Form Load ────────────────────────────────────────────────
        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // ── Load Users into Grid ─────────────────────────────────────
        private void LoadUsers()
        {
            try
            {
                // Get all users from repository
                List<User> users = _userRepo.GetAll();

                // Bind to grid
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;

                // Rename and configure columns
                if (dgvUsers.Columns.Contains("UserId"))
                {
                    dgvUsers.Columns["UserId"].HeaderText = "ID";
                    dgvUsers.Columns["UserId"].Width = 50;
                    dgvUsers.Columns["FullName"].HeaderText = "Full Name";
                    dgvUsers.Columns["Username"].HeaderText = "Username";
                    dgvUsers.Columns["Password"].Visible = false; // Never show password
                    dgvUsers.Columns["Role"].HeaderText = "Role";
                    dgvUsers.Columns["IsActive"].HeaderText = "Active";
                }

                lblUsersTitle.Text = $"All Users  ({users.Count} total)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid Row Click ───────────────────────────────────────────
        // Populate the form fields when a user row is clicked.
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the User object from the clicked row
            User selected = (User)dgvUsers.Rows[e.RowIndex].DataBoundItem;

            // Store the selected user ID for the Save button
            _selectedUserId = selected.UserId;

            // Populate form fields
            txtFullName.Text = selected.FullName;
            txtUsername.Text = selected.Username;
            txtPassword.Text = ""; // Always leave password blank for security
            chkActive.Checked = selected.IsActive;
            cmbRole.SelectedItem = selected.Role;

            lblFormTitle.Text = "Editing: " + selected.FullName;
        }

        // ── Save Button ──────────────────────────────────────────────
        // Handles both ADD (INSERT) and EDIT (UPDATE).
        // Special logic: if editing and password field is blank,
        // we call UpdateWithoutPassword() to keep the existing password.
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ── Validate required fields ──────────────────────────────
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Full Name and Username are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password is required only when adding a new user
            if (_selectedUserId == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for a new user.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Build User object ────────────────────────────────────
            User user = new User
            {
                UserId = _selectedUserId,
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Role = cmbRole.SelectedItem.ToString(),
                IsActive = chkActive.Checked
            };

            try
            {
                bool success;

                if (_selectedUserId == 0)
                {
                    // ── INSERT new user ──────────────────────────────
                    success = _userRepo.Add(user);
                    if (success)
                        MessageBox.Show("User added successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    // ── UPDATE with new password ─────────────────────
                    success = _userRepo.Update(user);
                    if (success)
                        MessageBox.Show("User updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ── UPDATE without changing password ─────────────
                    // Admin left password blank — keep existing password
                    success = _userRepo.UpdateWithoutPassword(user);
                    if (success)
                        MessageBox.Show("User updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Button ────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please select a user to delete.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ── Self-delete protection ────────────────────────────────
            // Prevent admin from deleting their own account.
            // Compare selected user ID with the logged-in user's ID.
            if (_selectedUserId == LoginForm.LoggedInUserId)
            {
                MessageBox.Show(
                    "You cannot delete your own account!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Confirm before deleting
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _userRepo.Delete(_selectedUserId);

                    if (success)
                    {
                        MessageBox.Show("User deleted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearForm();
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Clear Button ─────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ── ClearForm Helper ─────────────────────────────────────────
        private void ClearForm()
        {
            _selectedUserId = 0;       // Back to "add new" mode
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 1;    // Default: cashier
            chkActive.Checked = true;
            lblFormTitle.Text = "Add / Edit User";
        }
    }
}