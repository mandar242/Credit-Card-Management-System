using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace WindowsFormsApplication3
{
    public partial class Form6 : Form
    {
        long accno;
        int totalprice;
        int seller;
        int price1, price2, price3, price4, price5, price6, price7, price8, price9;
        int quantity1, quantity2, quantity3, quantity4, quantity5, quantity6, quantity7, quantity8, quantity9;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != "0"&&textBox3.Text.Trim()!="")
                pictureBox4.Image = System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
            else
                pictureBox4.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            if (textBox3.Text != "")
            {
                if (seller == 1)
                    label13.Text = Convert.ToString((50 * Convert.ToInt16(textBox3.Text.Trim())));
                if (seller == 2)
                    label13.Text = Convert.ToString((15 * Convert.ToInt16(textBox3.Text.Trim())));
                if (seller == 3)
                    label13.Text = Convert.ToString((10 * Convert.ToInt16(textBox3.Text.Trim())));
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if(textBox3.Text.Trim()=="")
            {
                textBox3.Text = "0";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.Text = "0";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.Text = "0";
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (seller == 1)
                    label14.Text = Convert.ToString((30 * Convert.ToInt16(textBox4.Text.Trim())));
                if (seller == 2)
                    label14.Text = Convert.ToString((40 * Convert.ToInt16(textBox4.Text.Trim())));
                if (seller == 3)
                    label14.Text = Convert.ToString((120 * Convert.ToInt16(textBox4.Text.Trim())));
            }
            if (textBox4.Text.Trim() != "0"&&textBox4.Text.Trim()!="")
                pictureBox5.Image = System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
            else
                pictureBox5.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (seller == 1)
                    label15.Text = Convert.ToString((10 * Convert.ToInt16(textBox5.Text.Trim())));
                if (seller == 2)
                    label15.Text = Convert.ToString((240 * Convert.ToInt16(textBox5.Text.Trim())));
                if (seller == 3)
                    label15.Text = Convert.ToString((130 * Convert.ToInt16(textBox5.Text.Trim())));
            }
            if (textBox5.Text.Trim() != "0"&&textBox5.Text.Trim()!="")
                pictureBox6.Image = System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
            else
                pictureBox6.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (totalprice == 0)
                MessageBox.Show("Select atleast 1 product!!");
            else
            {
                Close();
                Form8 form8 = new Form8(accno, totalprice, quantity1, quantity2, quantity3, quantity4, quantity5, quantity6, quantity7, quantity8, quantity9);
                form8.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label23.Visible = true;
            if(seller==1)
            {
                price1 = Convert.ToInt16(label13.Text.Trim());
                price2 = Convert.ToInt16(label14.Text.Trim());
                price3 = Convert.ToInt16(label15.Text.Trim());
                quantity1 = Convert.ToInt16(textBox3.Text.Trim());
                quantity2 = Convert.ToInt16(textBox4.Text.Trim());
                quantity3 = Convert.ToInt16(textBox5.Text.Trim());
            }
            if (seller == 2)
            {
                price4 = Convert.ToInt16(label13.Text.Trim());
                price5 = Convert.ToInt16(label14.Text.Trim());
                price6 = Convert.ToInt16(label15.Text.Trim());
                quantity4 = Convert.ToInt16(textBox3.Text.Trim());
                quantity5 = Convert.ToInt16(textBox4.Text.Trim());
                quantity6 = Convert.ToInt16(textBox5.Text.Trim());
            }
            if (seller == 3)
            {
                price7 = Convert.ToInt16(label13.Text.Trim());
                price8 = Convert.ToInt16(label14.Text.Trim());
                price9 = Convert.ToInt16(label15.Text.Trim());
                quantity7 = Convert.ToInt16(textBox3.Text.Trim());
                quantity8 = Convert.ToInt16(textBox4.Text.Trim());
                quantity9 = Convert.ToInt16(textBox5.Text.Trim());
            }
            totalprice = price1 + price2 + price3 + price4 + price5 + price6 + price7 + price8 + price9;
            label23.Text = Convert.ToString(totalprice);
        }

        public Form6(long accountno)
        {
            InitializeComponent();
            label23.Visible = false;
            accno = accountno;
            label2.Text = Convert.ToString(accno).Trim();
            label7.Text = "Please Select Seller.";
            //label6.Text="";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            totalprice = 0;
            price1 = 0;
            price2 = 0;
            price3 = 0;
            price4 = 0;
            price5 = 0;
            price6 = 0;
            price7 = 0;
            price8 = 0;
            price9 = 0;
            seller = 0;
            quantity1 = 0;
            quantity2 = 0;
            quantity3 = 0;
            quantity4 = 0;
            quantity5 = 0;
            quantity6 = 0;
            quantity7 = 0;
            quantity8 = 0;
            quantity9 = 0;
        }           

        private void button5_Click(object sender, EventArgs e)
        {
            if(seller==1)
            {
                if(textBox3.Text=="0")
                {
                    textBox3.Text = "1";
                    label13.Text = "50";
                }
            }
            if (seller == 2)
            {
                if (textBox3.Text == "0")
                {
                    textBox3.Text = "1";
                    label13.Text = "15";
                }
            }
            if (seller == 3)
            {
                if (textBox3.Text == "0")
                {
                    textBox3.Text = "1";
                    label13.Text = "10";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (seller == 1)
            {
                if (textBox4.Text == "0")
                {
                    textBox4.Text = "1";
                    label14.Text = "30";
                }
            }
            if (seller == 2)
            {
                if (textBox4.Text == "0")
                {
                    textBox4.Text = "1";
                    label14.Text = "40";
                }
            }
            if (seller == 3)
            {
                if (textBox4.Text == "0")
                {
                    textBox4.Text = "1";
                    label14.Text = "120";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (seller == 1)
            {
                if (textBox5.Text == "0")
                {
                    textBox5.Text = "1";
                    label15.Text = "10";
                }
            }
            if (seller == 2)
            {
                if (textBox5.Text == "0")
                {
                    textBox5.Text = "1";
                    label15.Text = "240";
                }
            }
            if (seller == 3)
            {
                if (textBox5.Text == "0")
                {
                    textBox5.Text = "1";
                    label15.Text = "130";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
            label24.Text = "Venus Traders";
            label7.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            seller = 1;
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            textBox3.Text = quantity1.ToString();
            textBox4.Text = quantity2.ToString();
            textBox5.Text = quantity3.ToString();
            label13.Text = price1.ToString();
            label14.Text = price2.ToString();
            label15.Text = price3.ToString();
            button5.Image= System.Drawing.Image.FromFile(@"d://projectimages/notebook.png");
            label8.Text = "200 pgs A4 Size Navneet Notebook.";
            label17.Text = "Rs. 50/-";
            pictureBox1.Image= System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
            button6.Image = System.Drawing.Image.FromFile(@"d://projectimages/pencils.png");
            label9.Text = "Natraj Pencils 10 pieces.";
            label18.Text = "Rs. 30/-";
            button7.Image = System.Drawing.Image.FromFile(@"d://projectimages/pen.png");
            label10.Text = "Reynolds Ball Pen.";
            label19.Text = "Rs. 10";
            pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            pictureBox3.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
        }

        private void txtbox3click()
        {
            label24.Visible = true;
            label24.Text = "Food Mart";
            label7.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            seller = 2;
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            textBox3.Text = quantity4.ToString();
            textBox4.Text = quantity5.ToString();
            textBox5.Text = quantity6.ToString();
            label13.Text = price4.ToString();
            label14.Text = price5.ToString();
            label15.Text = price6.ToString();
            button5.Image = System.Drawing.Image.FromFile(@"d://projectimages/biscuit.png");
            label8.Text = "Marie Bisucuits.";
            label17.Text = "Rs. 15/-";
            pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
            pictureBox1.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            pictureBox3.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            button6.Image = System.Drawing.Image.FromFile(@"d://projectimages/capsicum.png");
            label9.Text = "1 kg Capsicum.";
            label18.Text = "Rs. 40/-";
            button7.Image = System.Drawing.Image.FromFile(@"d://projectimages/wheat.png");
            label10.Text = "1 kg Wheat.";
            label19.Text = "Rs. 240/-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtbox3click();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
            label24.Text = "Abhishek Restaurant";
            label7.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            seller = 3;
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            textBox3.Text = quantity7.ToString();
            textBox4.Text = quantity8.ToString();
            textBox5.Text = quantity9.ToString();
            label13.Text = price7.ToString();
            label14.Text = price8.ToString();
            label15.Text = price9.ToString();
            button5.Image = System.Drawing.Image.FromFile(@"d://projectimages/roti.jpg");
            label8.Text = "Wheat Roti.";
            label17.Text = "Rs. 10/-";
            pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            pictureBox1.Image = System.Drawing.Image.FromFile(@"d://projectimages/cleartick.png");
            button6.Image = System.Drawing.Image.FromFile(@"d://projectimages/paneer.png");
            label9.Text = "Paneer Tikka Masala.";
            label18.Text = "Rs. 120/-";
            button7.Image = System.Drawing.Image.FromFile(@"d://projectimages/jeerarice.jpg");
            label10.Text = "Jeera Rice.";
            label19.Text = "Rs. 130";
            pictureBox3.Image = System.Drawing.Image.FromFile(@"d://projectimages/tick.png");
        }
    }
}
