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

        private void LoadUsers()
        {
            try
            {
                UserRepository repo = new UserRepository();
                DataTable dt = repo.GetAllUsers();

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                    // This ensures the grid actually draws the columns
                    dataGridView2.AutoGenerateColumns = true;
                }
                else
                {
                    MessageBox.Show("Database connected, but the Users table is empty!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void LoadBookings()
        {
            DAL.BookingRepository repo = new DAL.BookingRepository();
            dataGridView1.DataSource = repo.GetBookings();

            if (dataGridView1.Columns.Count > 0)
            {
                // These MUST match the "AS" names in your SQL query
                if (dataGridView1.Columns["ID"] != null)
                    dataGridView1.Columns["ID"].Width = 50;

                if (dataGridView1.Columns["Customer"] != null)
                    dataGridView1.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            LoadUsers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpInventory;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpOrders;
            LoadBookings();
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserEmail.Text)) return;

            var confirm = MessageBox.Show($"Delete {txtUserName.Text}?", "SIPS Security", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                UserRepository repo = new UserRepository();
                if (repo.DeleteUser(txtUserEmail.Text))
                {
                    MessageBox.Show("User deleted.");
                    LoadUsers();
                    // Clear the boxes
                    txtUserName.Clear();
                    txtUserEmail.Clear();
                    txtUserAddress.Clear();
                    txtUserPass.Clear();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.CurrentRow == null) return;

            //string email = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
            //// Assuming you have a txtNewName and txtNewRole textbox
            //string name = txtUserName.Text;
            //string role = cmbRole.Text;

            //UserRepository repo = new UserRepository();
            //if (repo.UpdateUser(email, name, role))
            //{
            //    MessageBox.Show("User updated!");
            //    LoadUsers();
            //}

            if (string.IsNullOrWhiteSpace(txtUserEmail.Text))
            {
                MessageBox.Show("Please select a user from the grid first.");
                return;
            }

            UserRepository repo = new UserRepository();
            // Updating based on the Email (ID)
            if (repo.UpdateUser(txtUserEmail.Text, txtUserName.Text, cmbUserRole.Text, txtUserAddress.Text))
            {
                MessageBox.Show("Update successful!");
                LoadUsers();
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Safety check: RowIndex 0 or higher means it's a data row, not the header
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dataGridView2.Rows[e.RowIndex];

                    // 1. Extract the values from the grid row
                    // Note: Ensure these "ColumnNames" match your pgAdmin columns exactly!
                    string email = row.Cells["Email"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string role = row.Cells["Role"].Value.ToString();

                    // 2. Push to Database via Repository
                    UserRepository repo = new UserRepository();
                    if (repo.UpdateUser(txtUserEmail.Text, txtUserName.Text, cmbUserRole.Text, txtUserAddress.Text))
                    {
                        MessageBox.Show("Update successful!");
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    // If the user types something invalid, we catch it here
                    MessageBox.Show("Update failed. Please ensure Email, Name, and Role are filled.");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //UserRepository repo = new UserRepository();
            //// We send Name, Email, Password, Role, "N/A" for Signature, and Address
            //if (repo.AddUser(txtUserName.Text, txtUserEmail.Text, txtUserPass.Text, cmbUserRole.Text, "N/A", txtUserAddress.Text))
            //{
            //    MessageBox.Show("User added successfully!");
            //    LoadUsers();
            //}

            // 1. Validation: Don't let them add someone without an email
            if (string.IsNullOrWhiteSpace(txtUserEmail.Text))
            {
                MessageBox.Show("Email is required!");
                return;
            }

            UserRepository repo = new UserRepository();

            // 2. Calling the method with 6 arguments in this EXACT order:
            // (name, email, password, role, signature, address)
            if (repo.AddUser(txtUserName.Text,
                             txtUserEmail.Text,
                             txtUserPass.Text,
                             cmbUserRole.Text,
                             "N/A",
                             txtUserAddress.Text))
            {
                MessageBox.Show("User added successfully!");
                LoadUsers(); // Refresh the grid
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null && e.RowIndex >= 0)
            {
                // Use the Column Names we defined in the GetAllUsers() query
                txtUserName.Text = dataGridView2.CurrentRow.Cells["Name"].Value.ToString();
                txtUserEmail.Text = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
                txtUserAddress.Text = dataGridView2.CurrentRow.Cells["Address"].Value.ToString();
                cmbUserRole.Text = dataGridView2.CurrentRow.Cells["Role"].Value.ToString();

                // Clear password for security
                txtUserPass.Clear();
            }
        }

        private void tpUsers_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                // Change 'DAL' to 'Repositories'
                if (new SIPS.DAL.BookingRepository().ApproveBooking(id))
                {
                    MessageBox.Show("Booking Approved!");
                    LoadBookings();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 1. Get the Booking ID
                // 1. Changed "BookingID" to "ID" to match our SQL alias
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                // 2. Get the Magazine ID (so we can restore stock)
                int magId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MagazineID"].Value);

                // 3. Call the new method with BOTH IDs
                if (new SIPS.DAL.BookingRepository().CancelBooking(id, magId))
                {
                    MessageBox.Show("Booking Cancelled and Stock Restored.");
                    LoadBookings();
                }
            }
        }
    }
}
