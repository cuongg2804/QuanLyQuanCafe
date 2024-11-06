using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    internal class FoodController
    {
        public static DataTable LoadFoodByIdCategory(int idCategory)
        {
            string sql = "Select * from Food where idCategory = " + idCategory;
            DataTable tb = DataProvider.ExecuteQuery(sql);

            return tb;
        }
    }
}
