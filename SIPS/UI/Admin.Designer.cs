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
            dgvMagazines = new DataGridView();
            tpOrders = new TabPage();
            tpUsers = new TabPage();
            tpSales = new TabPage();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            panel1.Size = new Size(172, 744);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(172, 644);
            panel2.Name = "panel2";
            panel2.Size = new Size(1006, 100);
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
            tabControl1.Size = new Size(1006, 644);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tpInventory
            // 
            tpInventory.Controls.Add(button3);
            tpInventory.Controls.Add(button2);
            tpInventory.Controls.Add(button1);
            tpInventory.Controls.Add(textBox4);
            tpInventory.Controls.Add(textBox3);
            tpInventory.Controls.Add(textBox2);
            tpInventory.Controls.Add(textBox1);
            tpInventory.Controls.Add(label4);
            tpInventory.Controls.Add(label3);
            tpInventory.Controls.Add(label2);
            tpInventory.Controls.Add(label1);
            tpInventory.Controls.Add(dgvMagazines);
            tpInventory.Location = new Point(4, 34);
            tpInventory.Name = "tpInventory";
            tpInventory.Padding = new Padding(3);
            tpInventory.Size = new Size(998, 606);
            tpInventory.TabIndex = 0;
            tpInventory.Text = "Magazines";
            tpInventory.UseVisualStyleBackColor = true;
            // 
            // dgvMagazines
            // 
            dgvMagazines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMagazines.Dock = DockStyle.Right;
            dgvMagazines.Location = new Point(546, 3);
            dgvMagazines.Name = "dgvMagazines";
            dgvMagazines.RowHeadersWidth = 62;
            dgvMagazines.Size = new Size(449, 600);
            dgvMagazines.TabIndex = 1;
            // 
            // tpOrders
            // 
            tpOrders.Location = new Point(4, 34);
            tpOrders.Name = "tpOrders";
            tpOrders.Padding = new Padding(3);
            tpOrders.Size = new Size(998, 606);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 77);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 2;
            label1.Text = "Magazine Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 268);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 3;
            label2.Text = "Price";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(140, 165);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 4;
            label3.Text = "Category";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 367);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 5;
            label4.Text = "Stock Quantity";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(436, 31);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 213);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(436, 31);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 313);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(436, 31);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 428);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(436, 31);
            textBox4.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(6, 527);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 10;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(172, 527);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 11;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(330, 527);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 12;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Admin";
            Text = "Admin";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tpInventory.ResumeLayout(false);
            tpInventory.PerformLayout();
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
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
    }
}