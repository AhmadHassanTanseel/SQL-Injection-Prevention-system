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
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            panel2 = new Panel();
            richTextBox1 = new RichTextBox();
            tabControl1 = new TabControl();
            tpInventory = new TabPage();
            label8 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvMagazines = new DataGridView();
            tpOrders = new TabPage();
            label7 = new Label();
            button9 = new Button();
            button8 = new Button();
            dataGridView1 = new DataGridView();
            tpUsers = new TabPage();
            label6 = new Label();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            dataGridView2 = new DataGridView();
            tpSales = new TabPage();
            button13 = new Button();
            label5 = new Label();
            dataGridView3 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tpInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMagazines).BeginInit();
            tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tpSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(269, 744);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button7
            // 
            button7.Location = new Point(30, 244);
            button7.Name = "button7";
            button7.Size = new Size(208, 34);
            button7.TabIndex = 3;
            button7.Text = "Bookings";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(30, 315);
            button6.Name = "button6";
            button6.Size = new Size(198, 34);
            button6.TabIndex = 2;
            button6.Text = "User Info";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(30, 381);
            button5.Name = "button5";
            button5.Size = new Size(198, 34);
            button5.TabIndex = 1;
            button5.Text = "Revenue";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(30, 174);
            button4.Name = "button4";
            button4.Size = new Size(208, 34);
            button4.TabIndex = 0;
            button4.Text = "Magazines";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(richTextBox1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(269, 644);
            panel2.Name = "panel2";
            panel2.Size = new Size(909, 100);
            panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = SystemColors.InfoText;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1006, 100);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tpInventory);
            tabControl1.Controls.Add(tpOrders);
            tabControl1.Controls.Add(tpUsers);
            tabControl1.Controls.Add(tpSales);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Location = new Point(269, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(909, 644);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tpInventory
            // 
            tpInventory.Controls.Add(label8);
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
            tpInventory.Location = new Point(4, 5);
            tpInventory.Name = "tpInventory";
            tpInventory.Padding = new Padding(3);
            tpInventory.Size = new Size(901, 635);
            tpInventory.TabIndex = 0;
            tpInventory.Text = "Magazines";
            tpInventory.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label8.Location = new Point(330, 17);
            label8.Name = "label8";
            label8.Size = new Size(156, 38);
            label8.TabIndex = 13;
            label8.Text = "Magazines";
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
            // button2
            // 
            button2.Location = new Point(172, 527);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 11;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 527);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 10;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(49, 428);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(342, 31);
            textBox4.TabIndex = 9;
           // textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(49, 313);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(342, 31);
            textBox3.TabIndex = 8;
           // textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(49, 213);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(342, 31);
            textBox2.TabIndex = 7;
          //  textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(49, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 31);
            textBox1.TabIndex = 6;
            //textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 366);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 5;
            label4.Text = "Stock Quantity";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 165);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 4;
            label3.Text = "Category";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 268);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 3;
            label2.Text = "Price";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 78);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 2;
            label1.Text = "Magazine Title";
            label1.Click += label1_Click;
            // 
            // dgvMagazines
            // 
            dgvMagazines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMagazines.Location = new Point(449, 78);
            dgvMagazines.Name = "dgvMagazines";
            dgvMagazines.RowHeadersWidth = 62;
            dgvMagazines.Size = new Size(449, 525);
            dgvMagazines.TabIndex = 1;
            // 
            // tpOrders
            // 
            tpOrders.Controls.Add(label7);
            tpOrders.Controls.Add(button9);
            tpOrders.Controls.Add(button8);
            tpOrders.Controls.Add(dataGridView1);
            tpOrders.Location = new Point(4, 5);
            tpOrders.Name = "tpOrders";
            tpOrders.Padding = new Padding(3);
            tpOrders.Size = new Size(901, 635);
            tpOrders.TabIndex = 1;
            tpOrders.Text = "Bookings";
            tpOrders.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label7.Location = new Point(341, 3);
            label7.Name = "label7";
            label7.Size = new Size(139, 38);
            label7.TabIndex = 8;
            label7.Text = "Bookings";
            // 
            // button9
            // 
            button9.Location = new Point(506, 539);
            button9.Name = "button9";
            button9.Size = new Size(208, 34);
            button9.TabIndex = 4;
            button9.Text = "Approve Bookings";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(127, 539);
            button8.Name = "button8";
            button8.Size = new Size(208, 34);
            button8.TabIndex = 3;
            button8.Text = "Cancel Bookings";
            button8.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(896, 466);
            dataGridView1.TabIndex = 2;
            // 
            // tpUsers
            // 
            tpUsers.Controls.Add(label6);
            tpUsers.Controls.Add(button10);
            tpUsers.Controls.Add(button11);
            tpUsers.Controls.Add(button12);
            tpUsers.Controls.Add(dataGridView2);
            tpUsers.Location = new Point(4, 5);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(901, 635);
            tpUsers.TabIndex = 2;
            tpUsers.Text = "Users Info";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(341, 17);
            label6.Name = "label6";
            label6.Size = new Size(149, 38);
            label6.TabIndex = 7;
            label6.Text = "Users Info";
            // 
            // button10
            // 
            button10.Location = new Point(23, 547);
            button10.Name = "button10";
            button10.Size = new Size(253, 34);
            button10.TabIndex = 6;
            button10.Text = "Add User";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(332, 547);
            button11.Name = "button11";
            button11.Size = new Size(253, 34);
            button11.TabIndex = 5;
            button11.Text = "Update Info";
            button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Location = new Point(640, 547);
            button12.Name = "button12";
            button12.Size = new Size(253, 34);
            button12.TabIndex = 4;
            button12.Text = "Delete";
            button12.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(0, 73);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(898, 446);
            dataGridView2.TabIndex = 3;
            // 
            // tpSales
            // 
            tpSales.Controls.Add(button13);
            tpSales.Controls.Add(label5);
            tpSales.Controls.Add(dataGridView3);
            tpSales.Location = new Point(4, 5);
            tpSales.Name = "tpSales";
            tpSales.Padding = new Padding(3);
            tpSales.Size = new Size(901, 635);
            tpSales.TabIndex = 3;
            tpSales.Text = "Revenue";
            tpSales.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(786, 47);
            button13.Name = "button13";
            button13.Size = new Size(112, 34);
            button13.TabIndex = 4;
            button13.Text = "Refresh";
            button13.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label5.Location = new Point(337, 26);
            label5.Name = "label5";
            label5.Size = new Size(200, 38);
            label5.TabIndex = 5;
            label5.Text = "Total Revenue";
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Bottom;
            dataGridView3.Location = new Point(3, 116);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.Size = new Size(895, 516);
            dataGridView3.TabIndex = 4;
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
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tpInventory.ResumeLayout(false);
            tpInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMagazines).EndInit();
            tpOrders.ResumeLayout(false);
            tpOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tpUsers.ResumeLayout(false);
            tpUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tpSales.ResumeLayout(false);
            tpSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
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
        private RichTextBox richTextBox1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button8;
        private DataGridView dataGridView1;
        private Button button11;
        private Button button12;
        private DataGridView dataGridView2;
        private Button button10;
        private DataGridView dataGridView3;
        private Label label5;
        private Button button13;
        private Label label8;
        private Label label7;
        private Label label6;
    }
}