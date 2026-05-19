namespace CafeHandler.Forms
{
    partial class NewOrderForm
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
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.nudTableNumber = new System.Windows.Forms.NumericUpDown();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.panelMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblOrderTitle = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearOrder = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTableNumber)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblTableNumber);
            this.panelTop.Controls.Add(this.nudTableNumber);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 60);

            // lblTitle
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "🛒  New Order";
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);

            // lblTableNumber
            this.lblTableNumber.ForeColor = System.Drawing.Color.White;
            this.lblTableNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTableNumber.Text = "Table Number:";
            this.lblTableNumber.Location = new System.Drawing.Point(700, 17);
            this.lblTableNumber.Size = new System.Drawing.Size(130, 28);

            // nudTableNumber
            this.nudTableNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudTableNumber.Minimum = 1;
            this.nudTableNumber.Maximum = 50;
            this.nudTableNumber.Value = 1;
            this.nudTableNumber.Location = new System.Drawing.Point(840, 15);
            this.nudTableNumber.Size = new System.Drawing.Size(80, 28);

            // panelLeft
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelLeft.Controls.Add(this.lblMenuTitle);
            this.panelLeft.Controls.Add(this.cmbCategoryFilter);
            this.panelLeft.Controls.Add(this.panelMenuItems);
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Size = new System.Drawing.Size(580, 590);

            // lblMenuTitle
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblMenuTitle.Text = "Menu Items";
            this.lblMenuTitle.Location = new System.Drawing.Point(15, 12);
            this.lblMenuTitle.Size = new System.Drawing.Size(200, 30);

            // cmbCategoryFilter
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(350, 12);
            this.cmbCategoryFilter.Size = new System.Drawing.Size(210, 30);
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);

            // panelMenuItems
            this.panelMenuItems.AutoScroll = true;
            this.panelMenuItems.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelMenuItems.Location = new System.Drawing.Point(10, 55);
            this.panelMenuItems.Size = new System.Drawing.Size(560, 525);

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblOrderTitle);
            this.panelRight.Controls.Add(this.dgvOrderItems);
            this.panelRight.Controls.Add(this.panelBottom);
            this.panelRight.Location = new System.Drawing.Point(580, 60);
            this.panelRight.Size = new System.Drawing.Size(520, 590);

            // lblOrderTitle
            this.lblOrderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblOrderTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblOrderTitle.Text = "Current Order";
            this.lblOrderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblOrderTitle.Size = new System.Drawing.Size(490, 30);

            // dgvOrderItems
            this.dgvOrderItems.Location = new System.Drawing.Point(10, 50);
            this.dgvOrderItems.Size = new System.Drawing.Size(500, 380);
            this.dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderItems.RowHeadersVisible = false;
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrderItems.ColumnHeadersHeight = 40;
            this.dgvOrderItems.RowTemplate.Height = 35;
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Controls.Add(this.btnRemoveItem);
            this.panelBottom.Controls.Add(this.btnClearOrder);
            this.panelBottom.Controls.Add(this.btnPlaceOrder);
            this.panelBottom.Location = new System.Drawing.Point(0, 440);
            this.panelBottom.Size = new System.Drawing.Size(520, 150);

            // lblTotal
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Text = "Total:  $0.00";
            this.lblTotal.Location = new System.Drawing.Point(15, 10);
            this.lblTotal.Size = new System.Drawing.Size(490, 40);
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnRemoveItem
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.Location = new System.Drawing.Point(15, 60);
            this.btnRemoveItem.Size = new System.Drawing.Size(150, 40);
            this.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);

            // btnClearOrder
            this.btnClearOrder.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClearOrder.ForeColor = System.Drawing.Color.White;
            this.btnClearOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOrder.FlatAppearance.BorderSize = 0;
            this.btnClearOrder.Text = "Clear Order";
            this.btnClearOrder.Location = new System.Drawing.Point(175, 60);
            this.btnClearOrder.Size = new System.Drawing.Size(150, 40);
            this.btnClearOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);

            // btnPlaceOrder
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.Text = "✔  Place Order";
            this.btnPlaceOrder.Location = new System.Drawing.Point(335, 55);
            this.btnPlaceOrder.Size = new System.Drawing.Size(170, 50);
            this.btnPlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

            // NewOrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Handler - New Order";
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTableNumber)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.NumericUpDown nudTableNumber;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.FlowLayoutPanel panelMenuItems;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblOrderTitle;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearOrder;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}