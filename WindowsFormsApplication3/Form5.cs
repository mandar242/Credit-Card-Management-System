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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            MongoCursor<Class3> put = db.GetCollection<Class3>("Creditcrds").FindAll();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 7;
            foreach (Class3 i in put)
            {
                dataGridView1.Rows.Add(Convert.ToString(i._id).Trim(), Convert.ToString(i.Accno).Trim(), i.CardType.Trim(), i.Issueddt.Trim(), i.Expdt.Trim(), Convert.ToString(i.Balance).Trim(), Convert.ToString(i.Pin).Trim());
            }

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

     
}
