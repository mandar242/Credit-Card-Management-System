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
    public partial class Form7 : Form
    {
        int pin4;
        string cardtype4;
        long cardnol1, cardnol2, cardnol3, cardnol14;
        long accno;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Form7(long accno2,long cardno2, string cardtype, int pin2)
        {
            InitializeComponent();
            cardnol1 = cardno2 / 1000000000000;
            cardnol2 = (cardno2 / 100000000) - (cardnol1*10000);
            cardnol3 = (cardno2 / 10000) - (cardnol1*100000000) - (cardnol2*10000);
            cardnol14 = (cardno2) - (cardnol1 * 1000000000000) - (cardnol2 * 100000000) - (cardnol3 * 10000);
            cardtype4 = cardtype;
            pin4 = pin2;
            accno = accno2;
            label1.Text = Convert.ToString(cardnol1);
            label2.Text = Convert.ToString(cardnol2);
            label3.Text = Convert.ToString(cardnol3);
            label14.Text = Convert.ToString(cardnol14);
            label6.Text = Convert.ToString(pin4);
            label16.Text = Convert.ToString(accno);
            accno = accno2;
                if (cardtype4 == "Visa")
                    pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/visa.jpg");
                else if (cardtype4 == "MasterCard")
                    pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/mastercard.png");
        }
    }
}
