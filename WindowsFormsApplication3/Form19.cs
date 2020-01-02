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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            var query = Query.EQ("_id", Convert.ToInt64(textBox1.Text));
            long userCount = Creditcrds.Count(query);
            if (userCount < 1)
            {
                MessageBox.Show("Enter Valid Credit Card no.!!");
            }
            else
            {
                var query1 = Query.And(Query.EQ("_id", Convert.ToInt64(textBox1.Text)), Query.NE("Balance", 0));
                long userCount1 = Creditcrds.Count(query1);
                MessageBox.Show("userCount1");
                if (userCount1 > 0)
                    MessageBox.Show("Please first pay the bill and then close the card!!");
                else if (Creditcrds.Remove((Query.EQ("_id", Convert.ToInt64(textBox1.Text)))).Ok == true)
                {
                    MessageBox.Show("Card closed Successfully");
                    Close();
                }
                else
                    MessageBox.Show("Couldn't close the card!!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
