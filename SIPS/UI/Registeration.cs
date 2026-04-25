using Npgsql;
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
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace SIPS.UI
{
    public partial class Registeration : Form
    {
        public Registeration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            // 2. Pass the text from your UI directly to the backend
            bool success = userRepo.RegisterUser(

                    textBox1.Text, // Usually the Name box
                    textBox4.Text, // Usually the Email box
                    textBox3.Text, // Usually the Password box
                    textBox2.Text // Usually the Address box
                    //richTextBox1.Text
            );

            // 3. Show the result!
            if (success)
            {
                MessageBox.Show("Registration Successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. That email might already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();

        }

        private void Registeration_Load(object sender, EventArgs e)
        {

        }
    }
}
