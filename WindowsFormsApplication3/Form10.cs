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
    public partial class Form10 : Form
    {
        long accno;
        public Form10(long acno)
        {
            InitializeComponent();
            accno = acno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(accno);
            form11.Show();
        }
    }
}
