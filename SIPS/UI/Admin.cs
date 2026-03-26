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
    }
}
