using SIPS.UI;
using SIPS.DAL;
using System.Data; // <--- THIS MUST BE HERE
namespace SIPS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registeration regForm = new Registeration();
            regForm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //// 1. Ask the backend to check the email and password
            //SIPS.DAL.UserRepository userRepo = new SIPS.DAL.UserRepository();

            //// We use .Trim() and .ToLower() to prevent invisible spaces and capitalization errors!
            //string role = userRepo.AuthenticateUser(textBox1.Text.Trim().ToLower(), textBox2.Text);

            //// 2. Strict Routing Logic (It will ONLY do one of these three things)
            //// Change your if statements in Login.cs to this:
            //if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            //{
            //    Admin adminForm = new Admin();
            //    adminForm.Show();
            //    this.Hide();
            //}
            //else if (string.Equals(role, "Customer", StringComparison.OrdinalIgnoreCase))
            //{
            //    // Inside your Login Form's "Login" button:
            //    int loggedInId = 5; // (You'll get this from your database login query)
            //    Customers customerWin = new Customers(loggedInId);
            //    customerWin.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    // If it gets here, it shows the error and STOPS. It will not open a dashboard.
            //    MessageBox.Show("Invalid Email or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            string email = textBox1.Text.Trim().ToLower();
            string password = textBox2.Text;

            SIPS.DAL.UserRepository userRepo = new SIPS.DAL.UserRepository();

            // 1. Change the variable type from 'string' to 'DataTable'
            System.Data.DataTable dt = userRepo.AuthenticateUser(email, password);

            // 2. Check if the table actually found a user
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    // 3. Extract the Role and the UserID from the first row
            //    string role = dt.Rows["role"].ToString();
            //    int userId = Convert.ToInt32(dt.Rows["userid"]);

            //    if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            //    {
            //        Admin adminForm = new Admin();
            //        adminForm.Show();
            //        this.Hide();
            //    }
            //    else if (string.Equals(role, "Customer", StringComparison.OrdinalIgnoreCase))
            //    {
            //        // Now we can pass the REAL ID from the database!
            //        Customers customerWin = new Customers(userId);
            //        customerWin.Show();
            //        this.Hide();
            //    }
            //}

         

            if (dt != null && dt.Rows.Count > 0)
            {
                // Accessing the FIRST row then the column name
                //string role = dt.Rows["role"].ToString();
                //int userId = Convert.ToInt32(dt.Rows["userid"]);

                // Accessing the FIRST row then the column name
                string role = dt.Rows[0]["role"].ToString();
                int userId = Convert.ToInt32(dt.Rows[0]["userid"]);


                if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    Admin adminForm = new Admin();
                    adminForm.Show();
                    this.Hide();
                }
                else if (string.Equals(role, "Customer", StringComparison.OrdinalIgnoreCase))
                {
                    Customers customerWin = new Customers(userId);
                    customerWin.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid Email or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
