namespace CafeHandler.Forms
{
    partial class MenuManagerForm
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 60);

            // lblTitle
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "🍽  Menu Manager";
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // panelLeft
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.lblFormTitle);
            this.panelLeft.Controls.Add(this.lblCategory);
            this.panelLeft.Controls.Add(this.cmbCategory);
            this.panelLeft.Controls.Add(this.lblItemName);
            this.panelLeft.Controls.Add(this.txtItemName);
            this.panelLeft.Controls.Add(this.lblPrice);
            this.panelLeft.Controls.Add(this.txtPrice);
            this.panelLeft.Controls.Add(this.lblDescription);
            this.panelLeft.Controls.Add(this.txtDescription);
            this.panelLeft.Controls.Add(this.chkAvailable);
            this.panelLeft.Controls.Add(this.btnSave);
            this.panelLeft.Controls.Add(this.btnClear);
            this.panelLeft.Controls.Add(this.btnDelete);
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Size = new System.Drawing.Size(340, 590);

            // lblFormTitle
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblFormTitle.Text = "Add / Edit Item";
            this.lblFormTitle.Location = new System.Drawing.Point(20, 15);
            this.lblFormTitle.Size = new System.Drawing.Size(300, 30);

            // lblCategory
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblCategory.Text = "Category";
            this.lblCategory.Location = new System.Drawing.Point(20, 60);
            this.lblCategory.Size = new System.Drawing.Size(300, 25);

            // cmbCategory
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(20, 88);
            this.cmbCategory.Size = new System.Drawing.Size(300, 30);

            // lblItemName
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblItemName.Text = "Item Name";
            this.lblItemName.Location = new System.Drawing.Point(20, 130);
            this.lblItemName.Size = new System.Drawing.Size(300, 25);

            // txtItemName
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtItemName.Location = new System.Drawing.Point(20, 158);
            this.txtItemName.Size = new System.Drawing.Size(300, 28);
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblPrice
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblPrice.Text = "Price ($)";
            this.lblPrice.Location = new System.Drawing.Point(20, 200);
            this.lblPrice.Size = new System.Drawing.Size(300, 25);

            // txtPrice
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location = new System.Drawing.Point(20, 228);
            this.txtPrice.Size = new System.Drawing.Size(300, 28);
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblDescription
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblDescription.Text = "Description";
            this.lblDescription.Location = new System.Drawing.Point(20, 270);
            this.lblDescription.Size = new System.Drawing.Size(300, 25);

            // txtDescription
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(20, 298);
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Multiline = true;

            // chkAvailable
            this.chkAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkAvailable.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.chkAvailable.Text = "Available";
            this.chkAvailable.Checked = true;
            this.chkAvailable.Location = new System.Drawing.Point(20, 392);
            this.chkAvailable.Size = new System.Drawing.Size(300, 25);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Text = "💾  Save";
            this.btnSave.Location = new System.Drawing.Point(20, 430);
            this.btnSave.Size = new System.Drawing.Size(300, 42);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Text = "🔄  Clear";
            this.btnClear.Location = new System.Drawing.Point(20, 482);
            this.btnClear.Size = new System.Drawing.Size(300, 42);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Text = "🗑  Delete";
            this.btnDelete.Location = new System.Drawing.Point(20, 534);
            this.btnDelete.Size = new System.Drawing.Size(300, 42);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelRight.Controls.Add(this.txtSearch);
            this.panelRight.Controls.Add(this.btnSearch);
            this.panelRight.Controls.Add(this.dgvMenuItems);
            this.panelRight.Location = new System.Drawing.Point(340, 60);
            this.panelRight.Size = new System.Drawing.Size(760, 590);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 15);
            this.txtSearch.Size = new System.Drawing.Size(580, 28);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(608, 15);
            this.btnSearch.Size = new System.Drawing.Size(130, 28);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dgvMenuItems
            this.dgvMenuItems.Location = new System.Drawing.Point(15, 55);
            this.dgvMenuItems.Size = new System.Drawing.Size(723, 520);
            this.dgvMenuItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMenuItems.RowHeadersVisible = false;
            this.dgvMenuItems.AllowUserToAddRows = false;
            this.dgvMenuItems.AllowUserToDeleteRows = false;
            this.dgvMenuItems.ReadOnly = true;
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMenuItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMenuItems.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvMenuItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMenuItems.ColumnHeadersHeight = 40;
            this.dgvMenuItems.RowTemplate.Height = 35;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuItems_CellClick);

            // MenuManagerForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Handler - Menu Manager";
            this.Load += new System.EventHandler(this.MenuManagerForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvMenuItems;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}