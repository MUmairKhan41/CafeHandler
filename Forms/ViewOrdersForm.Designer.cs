namespace CafeHandler.Forms
{
    partial class ViewOrdersForm
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
            this.lblDateFilter = new System.Windows.Forms.Label();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.btnFilterToday = new System.Windows.Forms.Button();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterDate = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 60);

            // lblTitle
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "📋  View Orders";
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // panelFilter
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelFilter.Controls.Add(this.lblDateFilter);
            this.panelFilter.Controls.Add(this.dtpFilter);
            this.panelFilter.Controls.Add(this.btnFilterToday);
            this.panelFilter.Controls.Add(this.btnFilterAll);
            this.panelFilter.Controls.Add(this.btnFilterDate);
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Size = new System.Drawing.Size(1100, 55);

            // lblDateFilter
            this.lblDateFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateFilter.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblDateFilter.Text = "Filter by Date:";
            this.lblDateFilter.Location = new System.Drawing.Point(15, 15);
            this.lblDateFilter.Size = new System.Drawing.Size(120, 25);

            // dtpFilter
            this.dtpFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(140, 12);
            this.dtpFilter.Size = new System.Drawing.Size(150, 28);

            // btnFilterDate
            this.btnFilterDate.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnFilterDate.ForeColor = System.Drawing.Color.White;
            this.btnFilterDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilterDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterDate.FlatAppearance.BorderSize = 0;
            this.btnFilterDate.Text = "Filter";
            this.btnFilterDate.Location = new System.Drawing.Point(300, 10);
            this.btnFilterDate.Size = new System.Drawing.Size(90, 32);
            this.btnFilterDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterDate.Click += new System.EventHandler(this.btnFilterDate_Click);

            // btnFilterToday
            this.btnFilterToday.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnFilterToday.ForeColor = System.Drawing.Color.White;
            this.btnFilterToday.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilterToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterToday.FlatAppearance.BorderSize = 0;
            this.btnFilterToday.Text = "Today";
            this.btnFilterToday.Location = new System.Drawing.Point(400, 10);
            this.btnFilterToday.Size = new System.Drawing.Size(90, 32);
            this.btnFilterToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterToday.Click += new System.EventHandler(this.btnFilterToday_Click);

            // btnFilterAll
            this.btnFilterAll.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnFilterAll.ForeColor = System.Drawing.Color.White;
            this.btnFilterAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterAll.FlatAppearance.BorderSize = 0;
            this.btnFilterAll.Text = "All Orders";
            this.btnFilterAll.Location = new System.Drawing.Point(500, 10);
            this.btnFilterAll.Size = new System.Drawing.Size(110, 32);
            this.btnFilterAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilterAll_Click);

            // panelLeft
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelLeft.Controls.Add(this.lblOrdersTitle);
            this.panelLeft.Controls.Add(this.dgvOrders);
            this.panelLeft.Location = new System.Drawing.Point(0, 115);
            this.panelLeft.Size = new System.Drawing.Size(560, 535);

            // lblOrdersTitle
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblOrdersTitle.Text = "Orders";
            this.lblOrdersTitle.Location = new System.Drawing.Point(15, 10);
            this.lblOrdersTitle.Size = new System.Drawing.Size(530, 30);

            // dgvOrders
            this.dgvOrders.Location = new System.Drawing.Point(10, 48);
            this.dgvOrders.Size = new System.Drawing.Size(540, 477);
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvOrders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.RowTemplate.Height = 35;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblDetailsTitle);
            this.panelRight.Controls.Add(this.lblOrderInfo);
            this.panelRight.Controls.Add(this.dgvOrderDetails);
            this.panelRight.Controls.Add(this.lblOrderTotal);
            this.panelRight.Location = new System.Drawing.Point(560, 115);
            this.panelRight.Size = new System.Drawing.Size(540, 535);

            // lblDetailsTitle
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblDetailsTitle.Text = "Order Details";
            this.lblDetailsTitle.Location = new System.Drawing.Point(15, 10);
            this.lblDetailsTitle.Size = new System.Drawing.Size(510, 30);

            // lblOrderInfo
            this.lblOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblOrderInfo.Text = "Click an order to view details";
            this.lblOrderInfo.Location = new System.Drawing.Point(15, 45);
            this.lblOrderInfo.Size = new System.Drawing.Size(510, 25);

            // dgvOrderDetails
            this.dgvOrderDetails.Location = new System.Drawing.Point(10, 78);
            this.dgvOrderDetails.Size = new System.Drawing.Size(520, 390);
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderDetails.RowHeadersVisible = false;
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvOrderDetails.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvOrderDetails.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvOrderDetails.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrderDetails.ColumnHeadersHeight = 40;
            this.dgvOrderDetails.RowTemplate.Height = 35;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // lblOrderTotal
            this.lblOrderTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrderTotal.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblOrderTotal.Text = "";
            this.lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOrderTotal.Location = new System.Drawing.Point(15, 478);
            this.lblOrderTotal.Size = new System.Drawing.Size(510, 40);

            // ViewOrdersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Handler - View Orders";
            this.Load += new System.EventHandler(this.ViewOrdersForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblDateFilter;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.Button btnFilterDate;
        private System.Windows.Forms.Button btnFilterToday;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblOrderTotal;
    }
}