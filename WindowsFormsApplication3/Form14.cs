using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Form16 form16 = new Form16();
                form16.Show();
                Close();
            }
            else
                MessageBox.Show("Wrong username or password!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
