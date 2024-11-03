using QuanLiQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Controller
{
    internal class BillInforController
    {
        public static List<BillInfoModel> GetBillInfoByIdBill (int idBill)
        {
            string sql = "select * from BillInfo where idBill = " + idBill;
            DataTable data = DataProvider.ExecuteQuery (sql);
            List<BillInfoModel> listBillInfo = new List<BillInfoModel>();

            if (data.Rows.Count > 0)
            {
            
                foreach (DataRow row in data.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    int idbill = (int)row["idBill"];
                    int idfood = (int)row["idFood"];
                    int count = (int)row["count"];
                    BillInfoModel billinfor = new BillInfoModel(id,idbill,idfood,count);
                    listBillInfo.Add(billinfor);
                }
              
            }
            return listBillInfo;
        }
    }
}
