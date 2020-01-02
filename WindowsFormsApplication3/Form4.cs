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

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        private int pin3;
        private long cardno3;
        int balance=0;
        string cardtype3;
        public Form4(long cardno1, int pin1)
        {
            InitializeComponent();
            cardno3 = cardno1;
            pin3 = pin1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            long userCount = db.GetCollection("Customer").Count(Query.EQ("_id", Convert.ToInt64(textBox1.Text.Trim())));
            long accno2 = Convert.ToInt64(textBox1.Text.Trim());
            if (userCount < 1)
            {
                MessageBox.Show("Not Found");
            }
            else
            {
                long userCount3 = 1;
                while (userCount3 > 0)
                {
                    userCount3 = db.GetCollection("Creditcrds").Count(Query.EQ("_id", cardno3));
                    if (userCount3 > 0)
                    {
                        cardno3++;
                    }
                }
                long userCount4 = 1;
                while (userCount4 > 0)
                {
                    userCount4 = db.GetCollection("Creditcrds").Count(Query.EQ("Pin", pin3));
                    if (userCount4 > 0)
                    {
                        pin3++;
                    }
                }

                balance = 0;

                BsonDocument cred = new BsonDocument
            {
                { "_id",cardno3 },
                { "Accno", Convert.ToInt16(textBox1.Text.Trim()) },
                { "CardType",comboBox1.Text.Trim()},
                { "Issueddt", "09-2016" },
                { "Expdt", "08-2021" },
                {"Balance", balance },
                { "Pin", pin3 }
            };
                Creditcrds.Insert(cred);
                cardtype3 = comboBox1.Text.Trim();
                Form7 form7 = new Form7(accno2, cardno3, cardtype3, pin3);
                form7.Show();
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Visa")
                pictureBox1.Image = System.Drawing.Image.FromFile(@"d://projectimages/visa.jpg");
            else if(comboBox1.Text=="MasterCard")
                pictureBox1.Image = System.Drawing.Image.FromFile(@"d://projectimages/mastercard2.jpg");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
