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
    public partial class Form17 : Form
    {
        long accno;
        public Form17(long accnumber)
        {
            InitializeComponent();
            accno = accnumber;
            label3.Text = Convert.ToString(accno).Trim();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(accno);
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(accno);
            form11.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18(accno);
            form18.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
