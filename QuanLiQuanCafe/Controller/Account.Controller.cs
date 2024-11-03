using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    internal class Account
    {
        public static Boolean Login (string username, string password)
        {
            String query = "Select * from Account where username = @username and password = @password";
            DataTable tb = new DataTable();
            tb =  DataProvider.ExecuteQuery(query, new object[] { username, password });
            return tb.Rows.Count == 1 ;
            
        }
    }
}
