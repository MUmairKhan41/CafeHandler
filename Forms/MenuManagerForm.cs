using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CafeHandler.Database;
using CafeHandler.Models;

namespace CafeHandler.Forms
{
    public partial class MenuManagerForm : Form
    {
        // ── Repositories ────────────────────────────────────────────
        // Each repository handles its own table's operations.
        // No SQL is written in this form — it's all in the repos.
        private readonly MenuItemRepository _menuRepo = new MenuItemRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        // ── State variable ──────────────────────────────────────────
        // Tracks which item is currently selected in the grid.
        // 0 = nothing selected (we are ADDING a new item).
        // >0 = an item is selected (we are EDITING that item).
        // This single variable controls INSERT vs UPDATE in btnSave.
        private int _selectedItemId = 0;

        public MenuManagerForm()
        {
            InitializeComponent();
        }

        // ── Form Load ───────────────────────────────────────────────
        private void MenuManagerForm_Load(object sender, EventArgs e)
        {
            // Load categories into the dropdown
            LoadCategories();

            // Load all menu items into the grid (empty search = all)
            LoadMenuItems("");

            // Set up the search box placeholder behaviour
            txtSearch.Text = "Search by item name...";
            txtSearch.ForeColor = System.Drawing.Color.Gray;
            txtSearch.Enter += (s, ev) =>
            {
                // When user clicks the search box, clear the placeholder
                if (txtSearch.Text == "Search by item name...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = System.Drawing.Color.Black;
                }
            };
            txtSearch.Leave += (s, ev) =>
            {
                // When user leaves the search box empty, restore placeholder
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search by item name...";
                    txtSearch.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        // ── Load Categories into ComboBox ───────────────────────────
        // Calls the CategoryRepository to get all categories from DB.
        // Adds Category objects to the dropdown — not just strings.
        // This way we have both the ID and name available when saving.
        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();

                // Get all categories from the repository
                List<Category> categories = _categoryRepo.GetAll();

                foreach (Category cat in categories)
                {
                    // Category.ToString() returns CategoryName,
                    // so the dropdown displays the name correctly
                    cmbCategory.Items.Add(cat);
                }

                // Select the first category by default
                if (cmbCategory.Items.Count > 0)
                    cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Menu Items into DataGridView ───────────────────────
        // Calls the MenuItemRepository with an optional search string.
        // The search uses SQL LIKE so partial names match too.
        private void LoadMenuItems(string search)
        {
            try
            {
                // Get filtered list from repository
                List<CafeMenuItem> items = _menuRepo.GetAll(search);

                // Clear and rebind the grid
                dgvMenuItems.DataSource = null;
                dgvMenuItems.DataSource = items;

                // Rename columns for user-friendly display
                if (dgvMenuItems.Columns.Contains("ItemId"))
                {
                    dgvMenuItems.Columns["ItemId"].HeaderText = "ID";
                    dgvMenuItems.Columns["ItemId"].Width = 50;
                    dgvMenuItems.Columns["CategoryId"].Visible = false;
                    dgvMenuItems.Columns["CategoryName"].HeaderText = "Category";
                    dgvMenuItems.Columns["ItemName"].HeaderText = "Item Name";
                    dgvMenuItems.Columns["Price"].HeaderText = "Price";
                    dgvMenuItems.Columns["Description"].HeaderText = "Description";
                    dgvMenuItems.Columns["IsAvailable"].HeaderText = "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu items: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid Row Click ──────────────────────────────────────────
        // When user clicks a row in the grid, populate the left form
        // with that item's data for editing.
        private void dgvMenuItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the header row (index -1)
            if (e.RowIndex < 0) return;

            // Get the MenuItem object from the selected row
            CafeMenuItem selected = (CafeMenuItem)dgvMenuItems.Rows[e.RowIndex].DataBoundItem;

            // Store the selected item's ID so Save knows to UPDATE
            _selectedItemId = selected.ItemId;

            // Populate form fields with the item's current values
            txtItemName.Text = selected.ItemName;
            txtPrice.Text = selected.Price.ToString("0.00");
            txtDescription.Text = selected.Description;
            chkAvailable.Checked = selected.IsAvailable;

            // Match the category in the dropdown
            foreach (Category cat in cmbCategory.Items)
            {
                if (cat.CategoryId == selected.CategoryId)
                {
                    cmbCategory.SelectedItem = cat;
                    break;
                }
            }

            // Update form title to show we are editing
            lblFormTitle.Text = "Editing: " + selected.ItemName;
        }

        // ── Save Button ─────────────────────────────────────────────
        // Handles both ADD (INSERT) and EDIT (UPDATE) in one button.
        // Decision is made based on _selectedItemId:
        //   _selectedItemId == 0 → INSERT new item
        //   _selectedItemId >  0 → UPDATE existing item
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ── Validate inputs ──────────────────────────────────────
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter the Item Name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure price is a valid decimal number
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Please enter a valid numeric Price.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected category object (has both ID and Name)
            Category selectedCategory = (Category)cmbCategory.SelectedItem;

            // ── Build MenuItem object ────────────────────────────────
            // We populate a MenuItem model object with the form data
            // and pass it to the repository — no SQL in this form.
            CafeMenuItem item = new CafeMenuItem
            {
                ItemId = _selectedItemId, // 0 for new, >0 for edit
                CategoryId = selectedCategory.CategoryId,
                ItemName = txtItemName.Text.Trim(),
                Price = price,
                Description = txtDescription.Text.Trim(),
                IsAvailable = chkAvailable.Checked
            };

            try
            {
                bool success;

                if (_selectedItemId == 0)
                {
                    // ── INSERT new item ──────────────────────────────
                    success = _menuRepo.Add(item);
                    if (success)
                        MessageBox.Show("Item added successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ── UPDATE existing item ─────────────────────────
                    success = _menuRepo.Update(item);
                    if (success)
                        MessageBox.Show("Item updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refresh the grid and clear the form
                ClearForm();
                LoadMenuItems("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving item: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Button ────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Cannot delete if nothing is selected
            if (_selectedItemId == 0)
            {
                MessageBox.Show("Please select an item from the grid to delete.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ask for confirmation before deleting
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call repository to delete by item ID
                    bool success = _menuRepo.Delete(_selectedItemId);

                    if (success)
                    {
                        MessageBox.Show("Item deleted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear form and refresh grid
                        ClearForm();
                        LoadMenuItems("");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Clear / Reset Button ─────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ── Search Button ────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get search term — ignore placeholder text
            string search = txtSearch.Text == "Search by item name..."
                ? "" : txtSearch.Text.Trim();

            LoadMenuItems(search);
        }

        // ── ClearForm Helper ─────────────────────────────────────────
        // Resets all form fields back to defaults and sets
        // _selectedItemId = 0 so the next Save will INSERT.
        private void ClearForm()
        {
            _selectedItemId = 0;           // Back to "add new" mode
            txtItemName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            chkAvailable.Checked = true;
            lblFormTitle.Text = "Add / Edit Item";

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }
    }
}