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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }


        
     private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
            MongoCursor<Class2> put = db.GetCollection<Class2>("Transaction").FindAll();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 5;
            foreach (Class2 i in put)
            {
                 dataGridView1.Rows.Add(Convert.ToString(i._id), i.Seller, Convert.ToString(i.Creditcrdno).Trim(), Convert.ToString(i.Totalamount), Convert.ToString(i.Accno));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
