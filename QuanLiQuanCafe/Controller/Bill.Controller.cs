﻿using QuanLiQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    public class BillController
    {
        public static BillModel GetIdBillByIdTable (int idTable){
            String sql = "Select * from Bill where idTable = " + idTable + "and status = 0";
            DataTable dt = new DataTable();
            BillModel bill = null ;
            dt = DataProvider.ExecuteQuery(sql);
            if(dt.Rows.Count == 1){
                int id = (int)dt.Rows[0]["id"];
                int idtable = (int)dt.Rows[0]["idTable"];
                int status = (int)dt.Rows[0]["status"];
                DateTime TimeCheckIn = (DateTime)dt.Rows[0]["DateCheckIn"];
              


                bill = new BillModel(id, idtable, TimeCheckIn, status);
                
            }
            return bill;
        }
    }
}
