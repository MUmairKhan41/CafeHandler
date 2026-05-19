using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CafeHandler.Database;
using CafeHandler.Models;

namespace CafeHandler.Forms
{
    public partial class NewOrderForm : Form
    {
        // ── Repositories ────────────────────────────────────────────
        private readonly MenuItemRepository _menuRepo = new MenuItemRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly OrderItemRepository _orderItemRepo = new OrderItemRepository();

        // ── In-memory order table ────────────────────────────────────
        // This DataTable stores the current order items in memory.
        // Nothing is saved to the database until Place Order is clicked.
        // It is bound to the DataGridView so it updates automatically.
        private DataTable _orderTable = new DataTable();

        public NewOrderForm()
        {
            InitializeComponent();
        }

        // ── Form Load ────────────────────────────────────────────────
        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            // Set up the in-memory order table structure
            SetupOrderTable();

            // Load category filter dropdown
            LoadCategoryFilter();

            // Load all available menu item buttons
            LoadMenuButtons("All");
        }

        // ── Setup Order DataTable ────────────────────────────────────
        // Defines the columns of our in-memory order table.
        // This table is used as the DataSource for the order grid.
        private void SetupOrderTable()
        {
            _orderTable.Columns.Add("item_id", typeof(int));
            _orderTable.Columns.Add("Item Name", typeof(string));
            _orderTable.Columns.Add("Price", typeof(decimal));
            _orderTable.Columns.Add("Quantity", typeof(int));
            _orderTable.Columns.Add("Subtotal", typeof(decimal));

            // Bind to grid — any changes to _orderTable
            // automatically reflect in the DataGridView
            dgvOrderItems.DataSource = _orderTable;

            // Hide the internal item_id column from the user
            dgvOrderItems.Columns["item_id"].Visible = false;
        }

        // ── Load Category Filter Dropdown ────────────────────────────
        private void LoadCategoryFilter()
        {
            try
            {
                cmbCategoryFilter.Items.Clear();
                cmbCategoryFilter.Items.Add("All"); // First option shows everything

                // Get all categories from repository
                List<Category> categories = _categoryRepo.GetAll();
                foreach (Category cat in categories)
                    cmbCategoryFilter.Items.Add(cat.CategoryName);

                cmbCategoryFilter.SelectedIndex = 0; // Default: All
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Menu Buttons Dynamically ────────────────────────────
        // Creates one Button per available menu item fetched from DB.
        // Buttons are added to a FlowLayoutPanel so they wrap neatly.
        // We use the button's Tag property to carry item data
        // so we know what was clicked without extra lookups.
        private void LoadMenuButtons(string category)
        {
            // Clear existing buttons
            panelMenuItems.Controls.Clear();

            try
            {
                // Get available items — optionally filtered by category
                List<CafeMenuItem> items = _menuRepo.GetAvailable(category);

                foreach (CafeMenuItem item in items)
                {
                    // Create a button for each menu item
                    Button btn = new Button
                    {
                        Text = item.ItemName + "\n$" + item.Price.ToString("0.00"),
                        Font = new System.Drawing.Font("Segoe UI", 10F,
                                    System.Drawing.FontStyle.Bold),
                        Size = new System.Drawing.Size(165, 70),
                        BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                        ForeColor = System.Drawing.Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Margin = new System.Windows.Forms.Padding(5),

                        // Tag carries {itemId, itemName, price} as an array.
                        // When this button is clicked, we read Tag to get the data.
                        Tag = new object[] { item.ItemId, item.ItemName, item.Price }
                    };

                    btn.FlatAppearance.BorderSize = 0;

                    // Attach click handler — all buttons share the same handler
                    btn.Click += MenuItemButton_Click;

                    panelMenuItems.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu items: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Menu Item Button Clicked ─────────────────────────────────
        // Fired when any menu item button is clicked.
        // Smart logic: if item already in order → increment qty
        //              if item not in order     → add new row
        private void MenuItemButton_Click(object sender, EventArgs e)
        {
            // Read item data from the button's Tag property
            Button btn = (Button)sender;
            object[] tag = (object[])btn.Tag;
            int itemId = (int)tag[0];
            string name = (string)tag[1];
            decimal price = (decimal)tag[2];

            // Check if this item is already in the order
            foreach (DataRow row in _orderTable.Rows)
            {
                if (Convert.ToInt32(row["item_id"]) == itemId)
                {
                    // ── Item exists — increment quantity ─────────────
                    int newQty = Convert.ToInt32(row["Quantity"]) + 1;
                    row["Quantity"] = newQty;
                    row["Subtotal"] = newQty * price;

                    UpdateTotal();
                    return; // Exit — no need to add a new row
                }
            }

            // ── Item not in order — add new row ──────────────────────
            _orderTable.Rows.Add(itemId, name, price, 1, price);
            UpdateTotal();
        }

        // ── Update Total ─────────────────────────────────────────────
        // Recalculates and displays the total by summing all subtotals.
        // Called every time the order changes.
        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _orderTable.Rows)
                total += Convert.ToDecimal(row["Subtotal"]);

            lblTotal.Text = "Total:  $" + total.ToString("0.00");
        }

        // ── Category Filter Changed ──────────────────────────────────
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuButtons(cmbCategoryFilter.SelectedItem.ToString());
        }

        // ── Remove Selected Item ─────────────────────────────────────
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item in the order list to remove.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the index of the selected row and delete from DataTable
            int index = dgvOrderItems.SelectedRows[0].Index;
            _orderTable.Rows[index].Delete();

            UpdateTotal();
        }

        // ── Clear Entire Order ───────────────────────────────────────
        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            _orderTable.Rows.Clear();
            UpdateTotal();
        }

        // ── Place Order ──────────────────────────────────────────────
        // Saves the complete order to the database using a TRANSACTION.
        // A transaction means: either BOTH inserts succeed together,
        // OR if anything fails, BOTH are rolled back (undone).
        // This prevents partial orders in the database.
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Cannot place an empty order
            if (_orderTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the order.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Calculate the final total
            decimal total = 0;
            foreach (DataRow row in _orderTable.Rows)
                total += Convert.ToDecimal(row["Subtotal"]);

            // Build Order object for the repository
            Order order = new Order
            {
                UserId = LoginForm.LoggedInUserId, // Who placed the order
                TableNumber = (int)nudTableNumber.Value,
                TotalAmount = total
            };

            try
            {
                // ── Open connection for transaction ──────────────────
                // We open the connection manually here because we need
                // to use ONE connection for the entire transaction.
                using (MySqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Step 1: Save the order header to the orders table.
                        // SaveWithTransaction() returns the new order_id.
                        long orderId = _orderRepo.SaveWithTransaction(order, conn, transaction);

                        // Step 2: Build list of OrderItem objects
                        List<OrderItem> orderItems = new List<OrderItem>();
                        foreach (DataRow row in _orderTable.Rows)
                        {
                            orderItems.Add(new OrderItem
                            {
                                ItemId = Convert.ToInt32(row["item_id"]),
                                Quantity = Convert.ToInt32(row["Quantity"]),
                                UnitPrice = Convert.ToDecimal(row["Price"]),
                                Subtotal = Convert.ToDecimal(row["Subtotal"])
                            });
                        }

                        // Step 3: Save all order items to order_items table.
                        // We pass the same connection and transaction so
                        // everything is in the same atomic operation.
                        _orderItemRepo.SaveItems(orderId, orderItems, conn, transaction);

                        // Step 4: Commit — make all changes permanent
                        transaction.Commit();

                        // Step 5: Show receipt
                        ShowReceipt(orderId, total);

                        // Step 6: Clear the order for the next customer
                        _orderTable.Rows.Clear();
                        UpdateTotal();
                    }
                    catch
                    {
                        // Something went wrong — undo ALL changes
                        transaction.Rollback();
                        throw; // Re-throw so outer catch shows the error
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Show Receipt ─────────────────────────────────────────────
        // Generates a simple text receipt and shows it in a MessageBox.
        private void ShowReceipt(long orderId, decimal total)
        {
            string receipt = "=====================================\n";
            receipt += "           CAFE HANDLER\n";
            receipt += "=====================================\n";
            receipt += $"Order #:   {orderId}\n";
            receipt += $"Table:     {nudTableNumber.Value}\n";
            receipt += $"Date:      {DateTime.Now:dd/MM/yyyy hh:mm tt}\n";
            receipt += $"Cashier:   {LoginForm.LoggedInUser}\n";
            receipt += "-------------------------------------\n";

            foreach (DataRow row in _orderTable.Rows)
            {
                string itemLine = row["Item Name"].ToString().PadRight(18);
                itemLine += $"x{row["Quantity"],-3}";
                itemLine += $"  ${Convert.ToDecimal(row["Subtotal"]):0.00}";
                receipt += itemLine + "\n";
            }

            receipt += "-------------------------------------\n";
            receipt += $"{"TOTAL:",-22} ${total:0.00}\n";
            receipt += "=====================================\n";
            receipt += "      Thank you! Come again!\n";
            receipt += "=====================================";

            MessageBox.Show(receipt,
                $"Receipt — Order #{orderId}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}