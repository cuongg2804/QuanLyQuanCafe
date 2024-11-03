using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLiQuanCafe.Model;
namespace QuanLiQuanCafe.Controller
{
    public class TableController
    {
        public static List<Table> LoadTable  ()
        {
            String query = "exec SelectAllTable";
            DataTable dataTable = new DataTable ();
			dataTable = DataProvider.ExecuteQuery (query);  
            List<Table> list = new List<Table> ();
            foreach (DataRow row in dataTable.Rows)
            {
                
                int id = (int)row["id"];
                String name =row["name"].ToString();
                String status = row["status"].ToString();

				Table table = new Table(id,name,status);
                list.Add(table);
			}
            return list;
		}
    }
}
