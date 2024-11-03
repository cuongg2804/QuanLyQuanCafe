using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Model
{
    public class Table
    {
        private int iD;
        private String name;
        private String status;

        public Table (int id, String name, String status) {
            this.iD = id;
            this.name = name;
            this.status = status;   
        }
        public int ID { get { return iD; } set { iD = iD; } }
        public String Name { get { return name; } set { name = value; } }
        public String Status { get { return status; } set { status = value; } }
    }
}
