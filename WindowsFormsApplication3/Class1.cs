using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WindowsFormsApplication3
{
    class Class1
    {
        public long _id {get; set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public long Contact { get; set; }
        public int Income { get; set; }
        public string Password { get; set; }
    }
}
