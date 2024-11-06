using QuanLiQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    internal class CategoryController
    {
        public static List<CategoryModel> LoadCategory ()
        {
            string sql = "select * from FoodCategory";
            DataTable dataTable = new DataTable();

            dataTable = DataProvider.ExecuteQuery (sql, null);
            List<CategoryModel > list = new List<CategoryModel> ();
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                CategoryModel ct = new CategoryModel(id, name) ;
                list.Add(ct);
            }
            return list;
        }
    }
}
