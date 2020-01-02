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
    public partial class Form11 : Form
    {
        long accno;
        int totalbalance;
        public Form11(long accountno)
        {
            InitializeComponent();
            accno = accountno;
            displaytransaction();
            label2.Text = Convert.ToString(accno).Trim();
        }
        private void displaytransaction()
        {
            totalbalance = 0;
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
            MongoCursor<Class2> put = db.GetCollection<Class2>("Transaction").FindAll();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 4;
            foreach (Class2 i in put)
            {
                if(i.Accno==accno)
                dataGridView1.Rows.Add(Convert.ToString(i.Creditcrdno).Trim(),Convert.ToString(i._id), i.Seller, Convert.ToString(i.Totalamount));
            }
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            MongoCursor<Class3> put1 = db.GetCollection<Class3>("Creditcrds").FindAll();
            foreach (Class3 j in put1)
            {
                if (j.Accno == accno)
                {
                    totalbalance = totalbalance + j.Balance;
                }
            }
            label4.Text = Convert.ToString(100000-totalbalance).Trim();
            label6.Text= Convert.ToString(totalbalance).Trim();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            MongoCursor<Class3> put = db.GetCollection<Class3>("Creditcrds").FindAll();
            /*foreach (Class3 i in put)
            {
                if (i.Accno == accno)
                {
                    IMongoUpdate update1 = new UpdateDocument();
                    update1 = MongoDB.Driver.Builders.Update.Set("Balance", 0);
                    i.Balance = 0;
                    MessageBox.Show("Thank You for paying the bill!!");
                    Close();
                }
            }*/

            IMongoUpdate update1 = new UpdateDocument();
            update1 = MongoDB.Driver.Builders.Update.Set("Balance", 0);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            Creditcrds.Update(Query.And(Query.EQ("Accno", accno), Query.NE("Balance", 0)), update1);
            MessageBox.Show("Thank You for paying the bill!!");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
