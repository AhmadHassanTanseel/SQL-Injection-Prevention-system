using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIPS.DAL;

namespace SIPS.UI
{
    public partial class Customers : Form
    {
        private int currentUserId; // To store the logged-in user's ID
        private DAL.BookingRepository bookingRepo = new DAL.BookingRepository();
        private DAL.MagazineRepository magRepo = new DAL.MagazineRepository();
        public Customers(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId; // Catch the ID from Login

            // CALL THE LOAD METHOD HERE
            LoadAvailableMagazines();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadAvailableMagazines();
        }
        private void LoadAvailableMagazines()
        {
            //try
            //{
            //    // 1. Get the latest data from your repository
            //    DAL.MagazineRepository magRepo = new DAL.MagazineRepository();
            //    DataTable dt = magRepo.GetAllMagazines();

            //    // 2. Refresh the DataGridView
            //    // (Make sure 'dataGridView1' is the correct name of your grid)
            //    dataGridView1.DataSource = dt;

            //    // 3. UI Cleanup: Hide ID if you want, and format the price
            //    if (dataGridView1.Columns["magazineid"] != null)
            //        dataGridView1.Columns["magazineid"].Visible = false;

            //    if (dataGridView1.Columns["price"] != null)
            //        dataGridView1.Columns["price"].DefaultCellStyle.Format = "N2";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Refresh Error: " + ex.Message);
            //}

            DAL.MagazineRepository repo = new DAL.MagazineRepository();
            DataTable data = repo.GetAllMagazines();

            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                // If this pops up, the Repo is returning an empty table
                MessageBox.Show("Database connected, but no magazines found.");
            }
        }
        //private void LoadMagazines()
        //{
        //    try
        //    {
        //        // 1. Create an instance of the Magazine Repository
        //        DAL.MagazineRepository magRepo = new DAL.MagazineRepository();

        //        // 2. Fetch the data (using the method you built earlier)
        //        DataTable dt = magRepo.GetAllMagazines();

        //        // 3. Bind it to the grid in your Customer UI
        //        // Change 'dataGridView1' if your grid has a different name
        //        dataGridView1.DataSource = dt;

        //        // 4. UI Polish: Hide the raw ID from the customer (optional)
        //        if (dataGridView1.Columns["magazineid"] != null)
        //            dataGridView1.Columns["magazineid"].Visible = false;

        //        // Make the grid look full and professional
        //        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error refreshing magazines: " + ex.Message);
        //    }
        //}

        private void LoadMyBookings()
        {
            try
            {
                // We already have the currentUserId from the Constructor!
                DAL.BookingRepository repo = new DAL.BookingRepository();

                // This uses the method we wrote earlier that takes a userId as a filter
                DataTable dt = repo.GetBookings(this.currentUserId);

                // Change 'dataGridView2' to match your second grid's name
                dataGridView2.DataSource = dt;

                // UI Polish
                if (dataGridView2.Columns["ID"] != null) dataGridView2.Columns["ID"].Width = 50;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading your history: " + ex.Message);
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            // tabControl1.SelectedTab = tpBrowse; // Change to your tab name
            LoadAvailableMagazines();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            // 1. Move the user to the History tab
            // tabControl1.SelectedTab = tpHistory;

            // 2. Fetch the latest data from the database
            LoadMyBookings();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //// 1. Safety Check: Make sure a row is actually selected
            //if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            //{
            //    MessageBox.Show("Please select a magazine from the list first!");
            //    return;
            //}

            //try
            //{
            //    // 2. Extract Data from the Grid
            //    // These names MUST match the column names in your PostgreSQL table
            //    int magId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["magazineid"].Value);
            //    decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["price"].Value);
            //    int currentStock = Convert.ToInt32(dataGridView1.CurrentRow.Cells["stock"].Value);

            //    // 3. Logic Check: Don't let them book if it's out of stock
            //    if (currentStock <= 0)
            //    {
            //        MessageBox.Show("This magazine is currently out of stock!", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // 4. Send to Backend
            //    // We use 'this.currentUserId' which we passed from the Login form
            //    DAL.BookingRepository repo = new DAL.BookingRepository();

            //    if (repo.BookMagazine(this.currentUserId, magId, price))
            //    {
            //        MessageBox.Show("Booking successful! Admin will review your request.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // 5. Refresh the UI so the stock number drops immediately
            //        LoadAvailableMagazines();              
            //    }
            //    else
            //    {
            //        MessageBox.Show("Something went wrong with the database. Please try again.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            if (dataGridView1.CurrentRow == null) return;

            try
            {
                // Extract data - Column names must be EXACTLY as they appear in the grid
                int magId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["magazineid"].Value);
                decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["price"].Value);

                DAL.BookingRepository repo = new DAL.BookingRepository();

                // This calls the method we wrote in Step 6
                if (repo.BookMagazine(this.currentUserId, magId, price))
                {
                    MessageBox.Show("Success!");
                    LoadAvailableMagazines(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Button Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;

            int bId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
            int mId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MagazineID"].Value);
            string status = dataGridView2.CurrentRow.Cells["Status"].Value.ToString();

            // SECURITY CHECK: Don't let them cancel if it's already Approved
            if (status == "Approved")
            {
                MessageBox.Show("This booking is already approved and cannot be cancelled.");
                return;
            }

            if (new DAL.BookingRepository().CancelBooking(bId, mId))
            {
                MessageBox.Show("Booking Cancelled.");
                LoadMyBookings(); // Refresh the list
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. Ask the user for confirmation (prevents accidental logouts)
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Create a new instance of your Login form
                // Note: Make sure 'Login' is the exact name of your login form class
                Login login = new Login();

                // 3. Show the login screen
                login.Show();

                // 4. Close the current dashboard (Admin or Customer)
                this.Close();
            }
        }
    }
}
