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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            displaycustinfo();
        }
        private void displaycustinfo()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCursor<Class1> put = db.GetCollection<Class1>("Customer").FindAll();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 7;
            foreach (Class1 i in put)
            {
                dataGridView1.Rows.Add(Convert.ToString(i._id).Trim(), i.Name.Trim(), i.Address.Trim(), Convert.ToString(i.Age).Trim(), Convert.ToString(i.Contact).Trim(), Convert.ToString(i.Income).Trim(), i.Password.Trim());
            }
            dataGridView1.Columns[6].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns[6].Visible == false)
            {
                dataGridView1.Columns[6].Visible = true;
                button1.Text = "Hide Passwords";
            }
            else
            {
                dataGridView1.Columns[6].Visible = false;
                button1.Text = "Show Passwords";           
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
