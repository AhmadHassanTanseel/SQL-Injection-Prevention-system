namespace SIPS.UI
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tpInventory = new TabPage();
            tpOrders = new TabPage();
            tpUsers = new TabPage();
            tpSales = new TabPage();
            dgvMagazines = new DataGridView();
            tabControl1.SuspendLayout();
            tpInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMagazines).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 450);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(172, 350);
            panel2.Name = "panel2";
            panel2.Size = new Size(628, 100);
            panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpInventory);
            tabControl1.Controls.Add(tpOrders);
            tabControl1.Controls.Add(tpUsers);
            tabControl1.Controls.Add(tpSales);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(172, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(628, 350);
            tabControl1.TabIndex = 0;
            // 
            // tpInventory
            // 
            tpInventory.Controls.Add(dgvMagazines);
            tpInventory.Location = new Point(4, 34);
            tpInventory.Name = "tpInventory";
            tpInventory.Padding = new Padding(3);
            tpInventory.Size = new Size(620, 312);
            tpInventory.TabIndex = 0;
            tpInventory.Text = "Magazines";
            tpInventory.UseVisualStyleBackColor = true;
            // 
            // tpOrders
            // 
            tpOrders.Location = new Point(4, 34);
            tpOrders.Name = "tpOrders";
            tpOrders.Padding = new Padding(3);
            tpOrders.Size = new Size(620, 312);
            tpOrders.TabIndex = 1;
            tpOrders.Text = "Bookings";
            tpOrders.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            tpUsers.Location = new Point(4, 34);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(620, 312);
            tpUsers.TabIndex = 2;
            tpUsers.Text = "Users Info";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // tpSales
            // 
            tpSales.Location = new Point(4, 34);
            tpSales.Name = "tpSales";
            tpSales.Padding = new Padding(3);
            tpSales.Size = new Size(620, 312);
            tpSales.TabIndex = 3;
            tpSales.Text = "Revenue";
            tpSales.UseVisualStyleBackColor = true;
            // 
            // dgvMagazines
            // 
            dgvMagazines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMagazines.Dock = DockStyle.Right;
            dgvMagazines.Location = new Point(-3, 3);
            dgvMagazines.Name = "dgvMagazines";
            dgvMagazines.RowHeadersWidth = 62;
            dgvMagazines.Size = new Size(620, 306);
            dgvMagazines.TabIndex = 1;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Admin";
            Text = "Admin";
            tabControl1.ResumeLayout(false);
            tpInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMagazines).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tpInventory;
        private TabPage tpOrders;
        private TabPage tpUsers;
        private TabPage tpSales;
        private DataGridView dgvMagazines;
    }
}