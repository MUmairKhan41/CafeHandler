using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CafeHandler.Database;
using CafeHandler.Models;

namespace CafeHandler.Forms
{
    public partial class ViewOrdersForm : Form
    {
        // ── Repositories ────────────────────────────────────────────
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly OrderItemRepository _orderItemRepo = new OrderItemRepository();

        public ViewOrdersForm()
        {
            InitializeComponent();
        }

        // ── Form Load ────────────────────────────────────────────────
        private void ViewOrdersForm_Load(object sender, EventArgs e)
        {
            // Default date picker to today
            dtpFilter.Value = DateTime.Today;

            // Load today's orders when the form first opens
            LoadOrders("today", DateTime.Today);
        }

        // ── Load Orders ──────────────────────────────────────────────
        // One method handles all three filter types:
        //   "today"  → orders placed today only
        //   "date"   → orders on the selected date
        //   "all"    → all orders ever
        private void LoadOrders(string filterType, DateTime date)
        {
            try
            {
                // Call repository with filter — returns List<Order>
                List<Order> orders = _orderRepo.GetAll(filterType, date);

                // Bind to grid
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;

                // Rename columns for user-friendly display
                if (dgvOrders.Columns.Contains("OrderId"))
                {
                    dgvOrders.Columns["OrderId"].HeaderText = "Order #";
                    dgvOrders.Columns["UserId"].Visible = false;
                    dgvOrders.Columns["CashierName"].HeaderText = "Cashier";
                    dgvOrders.Columns["TableNumber"].HeaderText = "Table";
                    dgvOrders.Columns["TotalAmount"].HeaderText = "Total ($)";
                    dgvOrders.Columns["Status"].HeaderText = "Status";
                    dgvOrders.Columns["OrderDate"].HeaderText = "Date & Time";
                }

                // Update the label to show how many orders found
                lblOrdersTitle.Text = $"Orders  ({orders.Count} found)";

                // Clear the right-side detail panel
                dgvOrderDetails.DataSource = null;
                lblOrderInfo.Text = "Click an order to view details";
                lblOrderTotal.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Order Details ───────────────────────────────────────
        // When a row in the orders grid is clicked, load the
        // detailed items of that order into the right-side panel.
        private void LoadOrderDetails(int orderId)
        {
            try
            {
                // Get items for this specific order from repository
                List<OrderItem> items = _orderItemRepo.GetByOrderId(orderId);

                // Bind to detail grid
                dgvOrderDetails.DataSource = null;
                dgvOrderDetails.DataSource = items;

                // Rename columns
                if (dgvOrderDetails.Columns.Contains("ItemName"))
                {
                    dgvOrderDetails.Columns["OrderItemId"].Visible = false;
                    dgvOrderDetails.Columns["OrderId"].Visible = false;
                    dgvOrderDetails.Columns["ItemId"].Visible = false;
                    dgvOrderDetails.Columns["ItemName"].HeaderText = "Item";
                    dgvOrderDetails.Columns["Quantity"].HeaderText = "Qty";
                    dgvOrderDetails.Columns["UnitPrice"].HeaderText = "Unit Price";
                    dgvOrderDetails.Columns["Subtotal"].HeaderText = "Subtotal";
                }

                // Calculate and display total for this order
                decimal total = 0;
                foreach (OrderItem item in items)
                    total += item.Subtotal;

                lblOrderTotal.Text = $"Order Total:   ${total:0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid Row Click ───────────────────────────────────────────
        // When user clicks an order in the left grid,
        // show that order's items in the right panel.
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the Order object from the clicked row
            Order selected = (Order)dgvOrders.Rows[e.RowIndex].DataBoundItem;

            // Update the info label at the top of the details panel
            lblOrderInfo.Text = $"Order #{selected.OrderId}  " +
                                $"|  Table: {selected.TableNumber}  " +
                                $"|  Cashier: {selected.CashierName}  " +
                                $"|  {selected.OrderDate:dd/MM/yyyy hh:mm tt}";
            lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);

            // Load the detailed items for this order
            LoadOrderDetails(selected.OrderId);
        }

        // ── Filter Buttons ───────────────────────────────────────────

        private void btnFilterToday_Click(object sender, EventArgs e)
        {
            // Show only today's orders
            LoadOrders("today", DateTime.Today);
        }

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            // Show all orders with no date filter
            LoadOrders("all", DateTime.Today);
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            // Show orders for the date selected in the date picker
            LoadOrders("date", dtpFilter.Value);
        }
    }
}