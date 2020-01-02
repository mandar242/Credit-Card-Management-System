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
    public partial class Form18 : Form
    {
        long accno;
        public Form18(long accountno)
        {
            InitializeComponent();
            accno = accountno;
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCursor<Class1> put = db.GetCollection<Class1>("Customer").FindAll();

            foreach (Class1 i in put)
            {
                if (i._id == accno)
                {
                    label4.Text = Convert.ToString(i._id).Trim();
                    label5.Text = i.Name.Trim();
                    label6.Text = i.Address.Trim();
                    label7.Text = Convert.ToString(i.Age).Trim();
                    label8.Text = Convert.ToString(i.Contact).Trim();
                    label9.Text = Convert.ToString(i.Income).Trim();
                    label10.Text = i.Password.Trim();
                }
            }
            label10.Visible = false;
            label3.Text = Convert.ToString(accno).Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label10.Visible == false)
                label10.Visible = true;
            else
                label10.Visible = false;
        }
    }
}
