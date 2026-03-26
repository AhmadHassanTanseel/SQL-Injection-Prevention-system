using SIPS.UI;

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

            string username = textBox1.Text;
            string password = textBox2.Text;
            // For right now, we will hardcode the admin password just to test the connection
            if (textBox1.Text == "admin" && textBox2.Text == "admin123")
            {
                // 1. Create a new copy of your Admin form
                Admin adminForm = new Admin();

                // 2. Show the Admin form
                adminForm.Show();

                // 3. Hide this Login form
                this.Hide();
            }
            else
            {
                // If they type the wrong password, show an error!
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
