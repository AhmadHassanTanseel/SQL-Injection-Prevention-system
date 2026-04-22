using SIPS.UI;
using SIPS.DAL;
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
          
            // 1. Ask the backend to check the email and password
            SIPS.DAL.UserRepository userRepo = new SIPS.DAL.UserRepository();

            // We use .Trim() and .ToLower() to prevent invisible spaces and capitalization errors!
            string role = userRepo.AuthenticateUser(textBox1.Text.Trim().ToLower(), textBox2.Text);

            // 2. Strict Routing Logic (It will ONLY do one of these three things)
            // Change your if statements in Login.cs to this:
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                Admin adminForm = new Admin();
                adminForm.Show();
                this.Hide();
            }
            else if (string.Equals(role, "Customer", StringComparison.OrdinalIgnoreCase))
            {
                Customers customerForm = new Customers();
                customerForm.Show();
                this.Hide();
            }
            else
            {
                // If it gets here, it shows the error and STOPS. It will not open a dashboard.
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
