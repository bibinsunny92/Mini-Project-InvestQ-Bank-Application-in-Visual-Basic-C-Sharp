/* Student Name: Bibin Sunny Sebastian
 * Student ID: 18230329
 * Date: 14/11/2018
 * Assignment: 4
 * Task: Create a banking application which displays the interest for different amounts and stores details of client.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment04_Sebastian_BibinSunny
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "InvestQ Login";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.passwordTextbox.Text == "investq")           //password is Investq and username can be your name
            {
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();

            }
            else
            {
                MessageBox.Show("You have entered the wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                passwordTextbox.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
