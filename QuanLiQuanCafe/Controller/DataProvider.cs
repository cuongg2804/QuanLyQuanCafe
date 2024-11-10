using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    internal class DataProvider
    {
        
        private static String connection = @"Data Source=LAPTOP-M10PEF5O\SQLEXPRESS;Initial Catalog=QuanLiQuanCafe;Integrated Security=True;TrustServerCertificate=True";
        private static SqlConnection Connection;

        public static DataTable ExecuteQuery (String query, object[] parameters = null)
        {
            DataTable dt = new DataTable();
            Connection = new SqlConnection (connection);
            Connection.Open ();
            SqlCommand cmd = new SqlCommand (query, Connection);
            if(parameters != null)
            {
                int i = 0 ;
                String[] listParam = query.Split(' ');
                foreach (String param in listParam)
                {
                    if (param.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(param, parameters[i++]);
                    }
                }
            } 
            

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            Connection.Close ();
            return dt;
        }


        public static void ExecuteNonquery (String query, Object[] parameters = null)
        {
            Connection = new SqlConnection (connection);
            Connection.Open();
            SqlCommand cmd = new SqlCommand(query, Connection);
            String []queryNew = query.Split(' ');
            if(parameters != null)
            {
                int i = 0;
                foreach(String item in queryNew)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue (item, parameters[i++]);
                    }
                }
            }

            cmd.ExecuteNonQuery ();

            Connection.Close();
        }
    }
}
