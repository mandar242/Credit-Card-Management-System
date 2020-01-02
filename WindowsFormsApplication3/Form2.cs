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
    public partial class Form2 : Form
    {
        private int pin1;
        private long accno1, cardno1;

    public Form2(long accno, long cardno, int pin)
        {
            InitializeComponent();
            accno1 = accno;
            cardno1 = cardno;
            pin1 = pin;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            Form3 form3 = new Form3(accno1, cardno1, pin1);
            form3.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Form4 form4 = new Form4(cardno1+100, pin1+100);
          form4.Show();
          Close();
        }
    }
}
