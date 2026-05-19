using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CafeHandler.Database;

namespace CafeHandler.Forms
{
    public partial class ReportsForm : Form
    {
        // ── Repositories ────────────────────────────────────────────
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly OrderItemRepository _orderItemRepo = new OrderItemRepository();

        public ReportsForm()
        {
            InitializeComponent();
        }

        // ── Form Load ────────────────────────────────────────────────
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Set both date pickers to today by default
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            // Auto-generate today's report when form opens
            GenerateReport(DateTime.Today, DateTime.Today);
        }

        // ── Generate Report ──────────────────────────────────────────
        // Master method that calls all three report sections.
        // Called whenever the user changes the date range.
        private void GenerateReport(DateTime from, DateTime to)
        {
            LoadSummaryStats(from, to);
            LoadBestSellingItems(from, to);
            LoadSalesByCategory(from, to);
        }

        // ── Summary Statistics ───────────────────────────────────────
        // Loads Total Sales, Total Orders, and Average Order Value
        // using SQL aggregate functions: COUNT, SUM, AVG.
        private void LoadSummaryStats(DateTime from, DateTime to)
        {
            try
            {
                // Repository returns a tuple with 3 values
                var (totalSales, totalOrders, avgOrder) =
                    _orderRepo.GetSummaryStats(from, to);

                // Display in the coloured stat panels
                lblTotalSalesValue.Text = "$" + totalSales.ToString("0.00");
                lblTotalOrdersValue.Text = totalOrders.ToString();
                lblAvgOrderValue.Text = "$" + avgOrder.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Best Selling Items ───────────────────────────────────────
        // Loads top 10 items ranked by total quantity sold.
        // Uses GROUP BY item, ORDER BY qty DESC, LIMIT 10.
        private void LoadBestSellingItems(DateTime from, DateTime to)
        {
            try
            {
                // Returns list of (itemName, totalQty, totalRevenue) tuples
                var items = _orderItemRepo.GetBestSelling(from, to);

                // Convert to a bindable list of anonymous objects for the grid
                var display = new System.Collections.Generic.List<object>();
                foreach (var (itemName, totalQty, totalRevenue) in items)
                {
                    display.Add(new
                    {
                        Item = itemName,
                        Qty_Sold = totalQty,
                        Revenue = "$" + totalRevenue.ToString("0.00")
                    });
                }

                dgvBestSelling.DataSource = null;
                dgvBestSelling.DataSource = display;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading best sellers: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Sales by Category ────────────────────────────────────────
        // Loads revenue breakdown by category.
        // Uses GROUP BY category, showing orders, items, and revenue.
        private void LoadSalesByCategory(DateTime from, DateTime to)
        {
            try
            {
                // Returns list of (category, totalOrders, totalItems, revenue) tuples
                var categories = _orderItemRepo.GetByCategory(from, to);

                var display = new System.Collections.Generic.List<object>();
                foreach (var (cat, totalOrders, totalItems, revenue) in categories)
                {
                    display.Add(new
                    {
                        Category = cat,
                        Orders = totalOrders,
                        Items = totalItems,
                        Revenue = "$" + revenue.ToString("0.00")
                    });
                }

                dgvByCategory.DataSource = null;
                dgvByCategory.DataSource = display;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading category sales: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Generate Button ──────────────────────────────────────────
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Validate date range — From cannot be after To
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show(
                    "The From date cannot be later than the To date.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            GenerateReport(dtpFrom.Value, dtpTo.Value);
        }

        // ── Today Button ─────────────────────────────────────────────
        private void btnToday_Click(object sender, EventArgs e)
        {
            // Reset both pickers to today and regenerate
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            GenerateReport(DateTime.Today, DateTime.Today);
        }
    }
}