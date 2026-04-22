using SIPS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPS.UI
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpUsers;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpInventory;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpOrders;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpSales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. We must convert the Price and Stock from Text into real Numbers for the database
                decimal price = Convert.ToDecimal(textBox3.Text);
                int stock = Convert.ToInt32(textBox4.Text);

                // 2. Create the connection to your Magazine backend
                MagazineRepository magRepo = new MagazineRepository();

                // 3. Pass the data to the backend!
                bool success = magRepo.AddMagazine(textBox1.Text, textBox2.Text, price, stock);

                // 4. Show the result
                if (success)
                {
                    MessageBox.Show("Magazine added to inventory successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optional: Clear the textboxes so they can quickly type the next one
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Database Error: Could not save the magazine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                // Layer 1 Security: If they type "Five" instead of "5" in the price box, this catches it!
                MessageBox.Show("Please enter valid numbers for Price and Stock.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
