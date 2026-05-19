namespace CafeHandler.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesTitle = new System.Windows.Forms.Label();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.panelTotalOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.panelAvgOrder = new System.Windows.Forms.Panel();
            this.lblAvgOrderTitle = new System.Windows.Forms.Label();
            this.lblAvgOrderValue = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBestSelling = new System.Windows.Forms.Panel();
            this.lblBestSellingTitle = new System.Windows.Forms.Label();
            this.dgvBestSelling = new System.Windows.Forms.DataGridView();
            this.panelByCategory = new System.Windows.Forms.Panel();
            this.lblByCategoryTitle = new System.Windows.Forms.Label();
            this.dgvByCategory = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelTotalSales.SuspendLayout();
            this.panelTotalOrders.SuspendLayout();
            this.panelAvgOrder.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelBestSelling.SuspendLayout();
            this.panelByCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByCategory)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 60);

            // lblTitle
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "📊  Sales Reports";
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // panelFilter
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelFilter.Controls.Add(this.lblFrom);
            this.panelFilter.Controls.Add(this.dtpFrom);
            this.panelFilter.Controls.Add(this.lblTo);
            this.panelFilter.Controls.Add(this.dtpTo);
            this.panelFilter.Controls.Add(this.btnGenerateReport);
            this.panelFilter.Controls.Add(this.btnToday);
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Size = new System.Drawing.Size(1100, 55);

            // lblFrom
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblFrom.Text = "From:";
            this.lblFrom.Location = new System.Drawing.Point(15, 15);
            this.lblFrom.Size = new System.Drawing.Size(50, 25);

            // dtpFrom
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(70, 12);
            this.dtpFrom.Size = new System.Drawing.Size(140, 28);

            // lblTo
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTo.Text = "To:";
            this.lblTo.Location = new System.Drawing.Point(225, 15);
            this.lblTo.Size = new System.Drawing.Size(30, 25);

            // dtpTo
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(260, 12);
            this.dtpTo.Size = new System.Drawing.Size(140, 28);

            // btnGenerateReport
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.Location = new System.Drawing.Point(415, 10);
            this.btnGenerateReport.Size = new System.Drawing.Size(150, 32);
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // btnToday
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.Text = "Today";
            this.btnToday.Location = new System.Drawing.Point(575, 10);
            this.btnToday.Size = new System.Drawing.Size(90, 32);
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);

            // panelStats
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelStats.Controls.Add(this.panelTotalSales);
            this.panelStats.Controls.Add(this.panelTotalOrders);
            this.panelStats.Controls.Add(this.panelAvgOrder);
            this.panelStats.Location = new System.Drawing.Point(0, 115);
            this.panelStats.Size = new System.Drawing.Size(1100, 130);

            // panelTotalSales
            this.panelTotalSales.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.panelTotalSales.Controls.Add(this.lblTotalSalesTitle);
            this.panelTotalSales.Controls.Add(this.lblTotalSalesValue);
            this.panelTotalSales.Location = new System.Drawing.Point(20, 15);
            this.panelTotalSales.Size = new System.Drawing.Size(330, 100);

            // lblTotalSalesTitle
            this.lblTotalSalesTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalSalesTitle.Text = "Total Sales";
            this.lblTotalSalesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalSalesTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTotalSalesTitle.Size = new System.Drawing.Size(330, 25);

            // lblTotalSalesValue
            this.lblTotalSalesValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.Text = "$0.00";
            this.lblTotalSalesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalSalesValue.Location = new System.Drawing.Point(0, 45);
            this.lblTotalSalesValue.Size = new System.Drawing.Size(330, 45);

            // panelTotalOrders
            this.panelTotalOrders.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.panelTotalOrders.Controls.Add(this.lblTotalOrdersTitle);
            this.panelTotalOrders.Controls.Add(this.lblTotalOrdersValue);
            this.panelTotalOrders.Location = new System.Drawing.Point(380, 15);
            this.panelTotalOrders.Size = new System.Drawing.Size(330, 100);

            // lblTotalOrdersTitle
            this.lblTotalOrdersTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalOrdersTitle.Text = "Total Orders";
            this.lblTotalOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTotalOrdersTitle.Size = new System.Drawing.Size(330, 25);

            // lblTotalOrdersValue
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.Text = "0";
            this.lblTotalOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(0, 45);
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(330, 45);

            // panelAvgOrder
            this.panelAvgOrder.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.panelAvgOrder.Controls.Add(this.lblAvgOrderTitle);
            this.panelAvgOrder.Controls.Add(this.lblAvgOrderValue);
            this.panelAvgOrder.Location = new System.Drawing.Point(740, 15);
            this.panelAvgOrder.Size = new System.Drawing.Size(330, 100);

            // lblAvgOrderTitle
            this.lblAvgOrderTitle.ForeColor = System.Drawing.Color.White;
            this.lblAvgOrderTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAvgOrderTitle.Text = "Average Order Value";
            this.lblAvgOrderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvgOrderTitle.Location = new System.Drawing.Point(0, 15);
            this.lblAvgOrderTitle.Size = new System.Drawing.Size(330, 25);

            // lblAvgOrderValue
            this.lblAvgOrderValue.ForeColor = System.Drawing.Color.White;
            this.lblAvgOrderValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAvgOrderValue.Text = "$0.00";
            this.lblAvgOrderValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvgOrderValue.Location = new System.Drawing.Point(0, 45);
            this.lblAvgOrderValue.Size = new System.Drawing.Size(330, 45);

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelBottom.Controls.Add(this.panelBestSelling);
            this.panelBottom.Controls.Add(this.panelByCategory);
            this.panelBottom.Location = new System.Drawing.Point(0, 245);
            this.panelBottom.Size = new System.Drawing.Size(1100, 405);

            // panelBestSelling
            this.panelBestSelling.BackColor = System.Drawing.Color.White;
            this.panelBestSelling.Controls.Add(this.lblBestSellingTitle);
            this.panelBestSelling.Controls.Add(this.dgvBestSelling);
            this.panelBestSelling.Location = new System.Drawing.Point(15, 10);
            this.panelBestSelling.Size = new System.Drawing.Size(520, 385);

            // lblBestSellingTitle
            this.lblBestSellingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBestSellingTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblBestSellingTitle.Text = "🏆  Best Selling Items";
            this.lblBestSellingTitle.Location = new System.Drawing.Point(15, 10);
            this.lblBestSellingTitle.Size = new System.Drawing.Size(490, 30);

            // dgvBestSelling
            this.dgvBestSelling.Location = new System.Drawing.Point(10, 48);
            this.dgvBestSelling.Size = new System.Drawing.Size(500, 325);
            this.dgvBestSelling.BackgroundColor = System.Drawing.Color.White;
            this.dgvBestSelling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBestSelling.RowHeadersVisible = false;
            this.dgvBestSelling.AllowUserToAddRows = false;
            this.dgvBestSelling.AllowUserToDeleteRows = false;
            this.dgvBestSelling.ReadOnly = true;
            this.dgvBestSelling.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvBestSelling.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvBestSelling.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvBestSelling.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBestSelling.ColumnHeadersHeight = 40;
            this.dgvBestSelling.RowTemplate.Height = 35;
            this.dgvBestSelling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // panelByCategory
            this.panelByCategory.BackColor = System.Drawing.Color.White;
            this.panelByCategory.Controls.Add(this.lblByCategoryTitle);
            this.panelByCategory.Controls.Add(this.dgvByCategory);
            this.panelByCategory.Location = new System.Drawing.Point(555, 10);
            this.panelByCategory.Size = new System.Drawing.Size(520, 385);

            // lblByCategoryTitle
            this.lblByCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblByCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblByCategoryTitle.Text = "📂  Sales by Category";
            this.lblByCategoryTitle.Location = new System.Drawing.Point(15, 10);
            this.lblByCategoryTitle.Size = new System.Drawing.Size(490, 30);

            // dgvByCategory
            this.dgvByCategory.Location = new System.Drawing.Point(10, 48);
            this.dgvByCategory.Size = new System.Drawing.Size(500, 325);
            this.dgvByCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvByCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvByCategory.RowHeadersVisible = false;
            this.dgvByCategory.AllowUserToAddRows = false;
            this.dgvByCategory.AllowUserToDeleteRows = false;
            this.dgvByCategory.ReadOnly = true;
            this.dgvByCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvByCategory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvByCategory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvByCategory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvByCategory.ColumnHeadersHeight = 40;
            this.dgvByCategory.RowTemplate.Height = 35;
            this.dgvByCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ReportsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Handler - Reports";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelTotalSales.ResumeLayout(false);
            this.panelTotalOrders.ResumeLayout(false);
            this.panelAvgOrder.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBestSelling.ResumeLayout(false);
            this.panelByCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByCategory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelTotalSales;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Panel panelTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersTitle;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.Panel panelAvgOrder;
        private System.Windows.Forms.Label lblAvgOrderTitle;
        private System.Windows.Forms.Label lblAvgOrderValue;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBestSelling;
        private System.Windows.Forms.Label lblBestSellingTitle;
        private System.Windows.Forms.DataGridView dgvBestSelling;
        private System.Windows.Forms.Panel panelByCategory;
        private System.Windows.Forms.Label lblByCategoryTitle;
        private System.Windows.Forms.DataGridView dgvByCategory;
    }
}