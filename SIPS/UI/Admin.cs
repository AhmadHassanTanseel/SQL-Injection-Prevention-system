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

        private void LoadMagazines()
        {
            try
            {
                MagazineRepository repo = new MagazineRepository();
                // This gets the DataTable from your repository and shows it in the grid
                dgvMagazines.DataSource = repo.GetAllMagazines();
            }
            catch (Exception ex)
            {
                // For now, keep it simple while debugging
                MessageBox.Show("Error loading magazines: " + ex.Message);
            }
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
                // 1. Layer 1 Validation: Convert Text to Numbers
                decimal price = Convert.ToDecimal(textBox3.Text);
                int stock = Convert.ToInt32(textBox4.Text);

                // 2. Connect to the Backend
                MagazineRepository magRepo = new MagazineRepository();

                // 3. Send data (Layer 2 Parameters are handled inside this method!)
                bool success = magRepo.AddMagazine(textBox1.Text, textBox2.Text, price, stock);

                if (success)
                {
                    MessageBox.Show("Magazine added successfully!", "Success");

                    // 4. IMPORTANT: Refresh the grid so the new row appears immediately
                    LoadMagazines();

                    // 5. Clear the UI
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Error: Database could not save the record.");
                }
            }
            catch (FormatException)
            {
                // This is your Layer 1 defense in action
                MessageBox.Show("Please enter valid numbers for Price and Stock.", "Input Error");
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadMagazines(); // Now the error should be gone!
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvMagazines.CurrentRow == null)
            {
                MessageBox.Show("Please select a magazine from the list first.");
                return;
            }

            try
            {
                /// You MUST have ["magazineid"] between Cells and Value
                int id = Convert.ToInt32(dgvMagazines.CurrentRow.Cells["magazineid"].Value);

                if (MessageBox.Show("Delete this magazine?", "SIPS Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MagazineRepository repo = new MagazineRepository();
                    if (repo.DeleteMagazine(id))
                    {
                        MessageBox.Show("Deleted Successfully!");
                        LoadMagazines();
                    }
                }
            }
            catch (Exception ex)
            {
                // This will show the REAL error if it happens again
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvMagazines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMagazines.CurrentRow != null)
            {
                // This fills your textboxes automatically when you click a row
                textBox1.Text = dgvMagazines.CurrentRow.Cells["Title"].Value.ToString();
                textBox2.Text = dgvMagazines.CurrentRow.Cells["Category"].Value.ToString();
                textBox3.Text = dgvMagazines.CurrentRow.Cells["Price"].Value.ToString();
                textBox4.Text = dgvMagazines.CurrentRow.Cells["Stock"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMagazines.CurrentRow != null)
            {
                try
                {
                    // Added here as well!
                    int id = Convert.ToInt32(dgvMagazines.CurrentRow.Cells["magazineid"].Value);

                    string title = textBox1.Text;
                    string category = textBox2.Text;
                    decimal price = Convert.ToDecimal(textBox3.Text);
                    int stock = Convert.ToInt32(textBox4.Text);

                    MagazineRepository repo = new MagazineRepository();
                    if (repo.UpdateMagazine(id, title, category, price, stock))
                    {
                        MessageBox.Show("Updated!");
                        LoadMagazines();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Error: " + ex.Message);
                }
            }
        }
    }
}
