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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            var query = Query.And(Query.EQ("_id", Convert.ToInt64(textBox1.Text.Trim())), Query.EQ("Password", Convert.ToString(textBox2.Text.Trim())));
            long userCount = db.GetCollection("Customer").Count(query);
            if (userCount < 1)
            {
                MessageBox.Show("Not Found");
            }
            else
            {
                Form17 form17 = new Form17(Convert.ToInt64(textBox1.Text.Trim()));
                form17.Show();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
