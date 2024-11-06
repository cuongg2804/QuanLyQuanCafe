using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLiQuanCafe.Model
{
    public class Food
    {
        private int id;
        private string name;
        private double price;

        public Food(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int Id () { return id; }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
    }
}
