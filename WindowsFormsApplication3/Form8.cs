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
    public partial class Form8 : Form
    {
        long accno;
        int qnt1, qnt2, qnt3, qnt4, qnt5, qnt6, qnt7, qnt8, qnt9;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        int totalamount;

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        int transid = 1;
     
        int sellerid=0;
        int seller1, seller2, seller3;

        long temp_id, tempAccno;
        string tempCardType, tempIssueddt, tempExpdt;
        int tempBalance, tempPin;

        public Form8(long accountno, int totalprice, int quantity1, int quantity2, int quantity3, int quantity4, int quantity5, int quantity6, int quantity7, int quantity8, int quantity9)
        {
            InitializeComponent();
            accno = accountno;
            qnt1 = quantity1;
            qnt2 = quantity2;
            qnt3 = quantity3;
            qnt4 = quantity4;
            qnt5 = quantity5;
            qnt6 = quantity6;
            qnt7 = quantity7;
            qnt8 = quantity8;
            qnt9=quantity9;
            totalamount = totalprice;
            label4.Text = Convert.ToString(totalamount).Trim();
            label7.Text = Convert.ToString(accno).Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transid++;
            sellerid = 0;


            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("projecttest");
        again: long userCount1 = db.GetCollection("Transaction").Count(Query.EQ("_id", transid));
            if (userCount1 > 0)
            {
                transid++;
                goto again;
            }

            MongoCollection<BsonDocument> Customer = db.GetCollection<BsonDocument>("Customer");
            MongoCollection<BsonDocument> Creditcrds = db.GetCollection<BsonDocument>("Creditcrds");
            var query1 = Query.And(Query.EQ("_id", Convert.ToInt64(textBox1.Text.Trim())), Query.EQ("Accno", accno));
            long userCount2 = db.GetCollection("Creditcrds").Count(query1);
            if (userCount2 < 1)
            {
                MessageBox.Show("The Credit Card you entered does not belong to your account!!");

            }
            else
            {
                goto ahead;
            ahead: var query = Query.And(Query.EQ("_id", Convert.ToInt64(textBox1.Text.Trim())), Query.EQ("Pin", Convert.ToInt32(textBox2.Text.Trim())));
                long userCount = db.GetCollection("Creditcrds").Count(query);
                if (userCount < 1)
                {
                    MessageBox.Show("Incorrect pin!! Please Enter the correct CC no. and Pin!!");
                }
                else
                {
                    var query3 = Query.And(Query.EQ("_id", Convert.ToInt64(textBox1.Text.Trim())), Query.GTE("balance", 100000 - totalamount));
                    long userCount3 = db.GetCollection("Creditcrds").Count(query3);
                    if (userCount3 > 0)
                    {
                        MessageBox.Show("You don't have enough balance to purchase this item!!");
                    }
                    else {
                        if ((qnt1 + qnt2 + qnt3) > 0)
                            seller1 = 1;
                        if ((qnt4 + qnt5 + qnt6) > 0)
                            seller2 = 1;
                        if ((qnt7 + qnt8 + qnt9) > 0)
                            seller3 = 1;
                        if (seller1 == 1)
                            sellerid = sellerid + 100;
                        if (seller2 == 1)
                            sellerid = sellerid + 10;
                        if (seller3 == 1)
                            sellerid = sellerid + 1;













                        if (sellerid == 100)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Venus Traders"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                    };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 010)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Food Mart"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 001)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Abhishek Restaurant"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 110)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Venus Traders, Food Mart"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 011)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Food Mart, Abhishek Restaurant"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 101)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Venus Traders, Abhishek Restauarnt"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }
                        else if (sellerid == 111)
                        {
                            BsonDocument Trans = new BsonDocument
                        {
                        {"_id", transid },
                        { "Seller","Venus Traders, Food Mart, Abhishek Restaurant"},
                        { "Creditcrdno", textBox1.Text.Trim()},
                        {"Totalamount", totalamount},
                        {"Accno", accno }
                        };
                            MongoCollection<BsonDocument> Transaction = db.GetCollection<BsonDocument>("Transaction");
                            Transaction.Insert(Trans);
                        }

                        
                        MongoCursor<Class3> put = db.GetCollection<Class3>("Creditcrds").FindAll();
                        foreach (Class3 i in put)
                        {
                            if (i._id == Convert.ToInt64(textBox1.Text.Trim()))
                            {
                                temp_id = i._id;
                                tempAccno = i.Accno;
                                tempBalance = i.Balance;
                                tempCardType = i.CardType;
                                tempIssueddt = i.Issueddt;
                                tempExpdt = i.Expdt;
                                tempPin = i.Pin;
                            }
                        }
                        tempBalance = tempBalance+totalamount;

                        IMongoUpdate update1 = new UpdateDocument();
                        update1 = MongoDB.Driver.Builders.Update.Set("Balance", Convert.ToString(tempBalance).Trim());
                        Creditcrds.Update(Query.EQ("_id", Convert.ToInt64(textBox1.Text)), update1);


                        MessageBox.Show("**Thank You for Shopping at us. Please visit Again!!**");
                        Close();
                    }
                }

            }
        }
    }
}
