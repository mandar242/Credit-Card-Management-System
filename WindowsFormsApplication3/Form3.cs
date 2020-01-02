using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        private int flag1, flag2, flag3, flag4, flag5, flag6, flag7, pin2;
        string cardtype;
        long accno2, cardno2;
        int balance = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
            Form2 form2 = new Form2(accno2, cardno2, pin2);
            form2.Show();
        }

        public Form3(long accno1, long cardno1, int pin1)
        {
            InitializeComponent();
            flag1 = 0;
            flag2 = 0;
            flag3 = 0;
            flag4 = 0;
            flag5 = 0;
            flag6 = 0;
            flag7 = 0;
            accno2 = accno1;
            cardno2 = cardno1;
            pin2 = pin1;
            textBox6.PasswordChar = '*';
            textBox7.PasswordChar = '*';
            label15.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label14.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label9.Visible = false;
            CancelButton = button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox7.Text)
            {
                errorProvider1.SetError(textBox7, "Password does not match!");
                label15.Text = "Password does not match!";
                errorProvider2.SetError(textBox7, "");
                flag7 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                label15.Text = "Correct";
                errorProvider2.SetError(textBox7, "correct");
                flag7 = 1;
            }
            if (flag1 == 0 || flag2 == 0 || flag3 == 0 || flag4 == 0 || flag5 == 0 || flag6 == 0 || flag7 == 0)
            {
                MessageBox.Show("Incomplete form!!");
                return;
            }
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            long userCount1 = 1;
            while (userCount1 > 0)
            {
                userCount1 = db.GetCollection("Customer").Count(Query.EQ("_id", accno2));
                if (userCount1 > 0)
                {
                    accno2++;
                }
            }
            long userCount2 = 1;
            while (userCount2 > 0)
            {
                userCount2 = db.GetCollection("Creditcrds").Count(Query.EQ("Accno", accno2));
                if (userCount2 > 0)
                {
                    accno2++;
                }
            }
            long userCount3 = 1;
            while (userCount3 > 0)
            {
                userCount3 = db.GetCollection("Creditcrds").Count(Query.EQ("_id", cardno2));
                if (userCount3 > 0)
                {
                    cardno2++;
                }
            }
            long userCount4 = 1;
            while (userCount4 > 0)
            {
                userCount4 = db.GetCollection("Creditcrds").Count(Query.EQ("Pin", pin2));
                if (userCount4 > 0)
                {
                    pin2++;
                }
            }
            balance = 0;
            BsonDocument cust = new BsonDocument
            {
                {"_id", accno2 },
                { "Name",textBox1.Text.Trim()},
                { "Address",textBox2.Text.Trim()},
                { "Age",Convert.ToInt16(textBox3.Text.Trim()) },
                {"Contact",Convert.ToInt64(textBox4.Text.Trim()) },
                {"Income",Convert.ToInt32(textBox5.Text.Trim()) },
                {"Password",textBox6.Text.Trim() }
            };
            BsonDocument cred = new BsonDocument
            {
                {"_id",cardno2 },
                { "Accno",accno2 },
                {"CardType",comboBox1.Text.Trim()},
                {"Issueddt", "09-2016" },
                {"Expdt", "08-2021" },
                {"Balance", balance },
                {"Pin", pin2 }
            };
            //Creditcrds.Insert(cred);
            Customer.Insert(cust);
            Creditcrds.Insert(cred);
            MessageBox.Show("Thank You.",
        "User registered!!");
            cardtype = comboBox1.Text.Trim();
            
            Form7 form7 = new Form7(accno2,cardno2, cardtype, pin2);
            form7.Show();
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label10.Visible = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Name required!");
                label10.Text = "Name Required!";
                errorProvider2.SetError(textBox1, "");
                flag1 = 0;
            }
            else
            {
                Regex CharOnly;
                CharOnly = new Regex(@"^[a-zA-Z_]+( [a-zA-Z_]+)*$");
                if (CharOnly.IsMatch(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "");
                    label10.Text = "Correct!";
                    errorProvider2.SetError(textBox1, "correct");
                    flag1 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Please Enter only Characters");
                    label10.Text = "Please Enter only Characters";
                    errorProvider2.SetError(textBox1, "");
                    flag1 = 0;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Name required!");
                label10.Text = "Name Required!";
               
                errorProvider2.SetError(textBox1, "");
                flag1 = 0;
            }
            else
            {
                Regex CharOnly;
                CharOnly = new Regex(@"^[a-zA-Z_]+( [a-zA-Z_]+)*$");
                if (CharOnly.IsMatch(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "");
                    label10.Text = "Correct!";
                    errorProvider2.SetError(textBox1, "correct");
                    flag1 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Please Enter only Characters");
                    label10.Text = "Please Enter only Characters";
                    errorProvider2.SetError(textBox1, "");
                    flag1 = 0;
                }
            }
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Name required!");
                label10.Text = "Name Required!";
                errorProvider2.SetError(textBox1, "");
                flag1 = 0;
                e.Cancel = true;
            }
            else
            {
                Regex CharOnly;
                CharOnly = new Regex(@"^[a-zA-Z_]+( [a-zA-Z_]+)*$");
                if (CharOnly.IsMatch(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "");
                    label10.Text = "Correct!";
                    errorProvider2.SetError(textBox1, "correct");
                    flag1 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Please Enter only Characters");
                    label10.Text = "Please Enter only Characters";
                    errorProvider2.SetError(textBox1, "");
                    flag1 = 0;
                    e.Cancel = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = true;
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Address required!");
                label11.Text = "Address Required!";
                errorProvider2.SetError(textBox2, "");
                flag2 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                label11.Text = "Correct";
                errorProvider2.SetError(textBox2, "correct");
                flag2 = 1;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Address required!");
                label11.Text = "Address Required!";
                errorProvider2.SetError(textBox2, "");
                flag2 = 0;
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                label11.Text = "Correct";
                errorProvider2.SetError(textBox2, "correct");
                flag2 = 1;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label11.Visible = true;
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Address required!");
                label11.Text = "Address Required!";
                errorProvider2.SetError(textBox2, "");
                flag2 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                label11.Text = "Correct";
                errorProvider2.SetError(textBox2, "correct");
                flag2 = 1;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            label12.Visible = true;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Age required!");
                label12.Text = "Age Required!";
                errorProvider2.SetError(textBox3, "");
                flag3 = 0;
            }
            else
            {
                int age;
                age = int.Parse(textBox3.Text);
                if (age > 17 && age < 61)
                {
                    errorProvider1.SetError(textBox3, "");
                    label12.Text = "Correct";
                    errorProvider2.SetError(textBox3, "correct");
                    flag3 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Age Range must be [18-60].");
                    label12.Text = "Age Range must be [18-60].";
                    errorProvider2.SetError(textBox3, "");
                    flag3 = 0;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Age required!");
                label12.Text = "Age Required!";
                errorProvider2.SetError(textBox3, "");
                flag3 = 0;
            }
            else
            {
                int age;
                age = int.Parse(textBox3.Text);
                if (age > 17 && age < 61)
                {
                    errorProvider1.SetError(textBox3, "");
                    label12.Text = "Correct";
                    errorProvider2.SetError(textBox3, "correct");
                    flag3 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Age Range must be [18-60].");
                    label12.Text = "Age Range must be [18-60].";
                    errorProvider2.SetError(textBox3, "");
                    flag3 = 0;
                }
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Age required!");
                label12.Text = "Age Required!";
                errorProvider2.SetError(textBox3, "");
                flag3 = 0;
                e.Cancel = true;
            }
            else
            {
                int age;
                age = int.Parse(textBox3.Text);
                if (age > 17 && age < 61)
                {
                    errorProvider1.SetError(textBox3, "");
                    label12.Text = "Correct";
                    errorProvider2.SetError(textBox3, "correct");
                    flag3 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Age Range must be [18-60].");
                    label12.Text = "Age Range must be [18-60].";
                    errorProvider2.SetError(textBox3, "");
                    flag3 = 0;
                    e.Cancel = true;
                }
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            label13.Visible = true;
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Ph no required!");
                label13.Text = "Ph no required!!";
                errorProvider2.SetError(textBox4, "");
                flag4 = 0;
            }
            else
            {
                Regex MobOnly;
                MobOnly = new Regex(@"[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
                if (MobOnly.IsMatch(textBox4.Text))
                {
                    errorProvider1.SetError(textBox4, "");
                    label13.Text = "Correct";
                    errorProvider2.SetError(textBox4, "correct");
                    flag4 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Ph no should be 10 digits");
                    label13.Text = "Ph no should be 10 digits";
                    errorProvider2.SetError(textBox4, "");
                    flag4 = 0;
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Ph no required!");
                label13.Text = "Ph no required!!";
                errorProvider2.SetError(textBox4, "");
                flag4 = 0;
            }
            else
            {
                Regex MobOnly;
                MobOnly = new Regex(@"[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
                if (MobOnly.IsMatch(textBox4.Text))
                {
                    errorProvider1.SetError(textBox4, "");
                    label13.Text = "Correct";
                    errorProvider2.SetError(textBox4, "correct");
                    flag4 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Ph no should be 10 digits");
                    label13.Text = "Ph no should be 10 digits";
                    errorProvider2.SetError(textBox4, "");
                    flag4 = 0;
                }
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Ph no required!");
                label13.Text = "Ph no required!!";
                errorProvider2.SetError(textBox4, "");
                flag4 = 0;
                e.Cancel = true;
            }
            else
            {
                Regex MobOnly;
                MobOnly = new Regex(@"[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
                if (MobOnly.IsMatch(textBox4.Text))
                {
                    errorProvider1.SetError(textBox4, "");
                    label13.Text = "Correct";
                    errorProvider2.SetError(textBox4, "correct");
                    flag4 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Ph no should be 10 digits");
                    label13.Text = "Ph no should be 10 digits";
                    errorProvider2.SetError(textBox4, "");
                    flag4 = 0;
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            label9.Visible = true;
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "Income required!");
                label9.Text = "Income Required!";
                errorProvider2.SetError(textBox5, "");
                flag5 = 0;
            }
            else
            {
                Regex NumOnly;
                NumOnly = new Regex(@"^([0-9]*|\d*)$");
                if (NumOnly.IsMatch(textBox5.Text))
                {
                    errorProvider1.SetError(textBox5, "");
                    errorProvider2.SetError(textBox5, "correct");
                    label9.Text = "Correct";
                    flag5 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Please Enter only Numbers");
                    label9.Text = "Please Enter only Numbers";
                    errorProvider2.SetError(textBox5, "");
                    flag5 = 0;
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Visa")
                pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/visa.jpg");
            else if (comboBox1.Text == "MasterCard")
                pictureBox2.Image = System.Drawing.Image.FromFile(@"d://projectimages/mastercard2.jpg");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "Income required!");
                label9.Text = "Income Required!";
                errorProvider2.SetError(textBox5, "");
                flag5 = 0;
            }
            else
            {
                Regex NumOnly;
                NumOnly = new Regex(@"^([0-9]*|\d*)$");
                if (NumOnly.IsMatch(textBox5.Text))
                {
                    errorProvider1.SetError(textBox5, "");
                    errorProvider2.SetError(textBox5, "correct");
                    label9.Text = "Correct";
                    flag5 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Please Enter only Numbers");
                    label9.Text = "Please Enter only Numbers";
                    errorProvider2.SetError(textBox5, "");
                    flag5 = 0;
                }
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "Income required!");
                label9.Text = "Income Required!";
                errorProvider2.SetError(textBox5, "");
                flag5 = 0;
                e.Cancel = true;
            }
            else
            {
                Regex NumOnly;
                NumOnly = new Regex(@"^([0-9]*|\d*)$");
                if (NumOnly.IsMatch(textBox5.Text))
                {
                    errorProvider1.SetError(textBox5, "");
                    label9.Text = "Correct";
                    errorProvider2.SetError(textBox5, "correct");
                    flag5 = 1;
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Please Enter only Numbers");
                    label9.Text = "Please Enter only Numbers";
                    errorProvider2.SetError(textBox5, "");
                    flag5 = 0;
                    e.Cancel = true;
                }
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            label14.Visible = true;
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                errorProvider1.SetError(textBox6, "Password Required!");
                label14.Text = "Password Required!";
                errorProvider2.SetError(textBox6, "");
                flag6 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
                label14.Text = "Correct";
                errorProvider2.SetError(textBox6, "correct");
                flag6 = 1;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                errorProvider1.SetError(textBox6, "Password Required!");
                label14.Text = "Password Required!";
                errorProvider2.SetError(textBox6, "");
                flag6 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
                label14.Text = "Correct";
                errorProvider2.SetError(textBox6, "correct");
                flag6 = 1;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                errorProvider1.SetError(textBox6, "Password Required!");
                label14.Text = "Password Required!";
                errorProvider2.SetError(textBox6, "");
                flag6 = 0;
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
                label14.Text = "Correct";
                errorProvider2.SetError(textBox6, "correct");
                flag6 = 1;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            label15.Visible = true;
            if (textBox6.Text != textBox7.Text)
            {
                errorProvider1.SetError(textBox7, "Password does not match!");
                label15.Text = "Password does not match!";
                errorProvider2.SetError(textBox7, "");
                flag7 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                label15.Text = "Correct";
                errorProvider2.SetError(textBox7, "correct");
                flag7 = 1;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox7.Text)
            {
                errorProvider1.SetError(textBox7, "Password does not match!");
                label15.Text = "Password does not match!";
                errorProvider2.SetError(textBox7, "");
                flag7 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                label15.Text = "Correct";
                errorProvider2.SetError(textBox7, "correct");
                flag7 = 1;
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text != textBox7.Text)
            {
                errorProvider1.SetError(textBox7, "Password does not match!");
                label15.Text = "Password does not match!";
                errorProvider2.SetError(textBox7, "");
                flag7 = 0;
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                label15.Text = "Correct";
                errorProvider2.SetError(textBox7, "correct");
                flag7 = 1;
            }
        }
    }
}
