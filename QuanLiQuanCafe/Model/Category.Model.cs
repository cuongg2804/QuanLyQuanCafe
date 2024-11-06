using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Model
{
    public class CategoryModel
    {
        private int _id;
        private string _name;

        public CategoryModel (int id, string name)
        {
            this._id = id;
            this._name = name;  
        }
        public int Id { get { return _id; }  set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } } 
    }
}
