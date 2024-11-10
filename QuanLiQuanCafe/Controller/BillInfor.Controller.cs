using QuanLiQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static List<MenuModel> GetMenuByIdTable (int idTable)
        {
            string sql = "Select idBill ,idTable, name, count, price,status from Bill Inner join BillInfo on Bill.id = BillInfo.idBill inner join Food on BillInfo.idFood = Food.id where idTable = " + idTable + " and Bill.status = 0";
            DataTable data = DataProvider.ExecuteQuery (sql);
            List<MenuModel> listMenu = new List<MenuModel>();
            if(data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    
                    int idBill = (int)row["idBill"];
                    int count = (int)row["count"];
                    double  price = Convert.ToDouble(row["price"]);
                    string name = (string)row["name"];
                    int status = (int)row["status"];
                    MenuModel item = new MenuModel(idBill,idTable, count, price,name,status);
                    listMenu.Add(item);
                }
            }
            return listMenu;
        }

        public static void insertNewBillInfo( int idBill, int idFood, int count)
        {
            String sql = "insert BillInfo values (  @A ,  @b , @c )";
            DataProvider.ExecuteNonquery(sql, new object[] { idBill, idFood, count });
            return;
        }

        public static void InsertBillInfo (int idTable,int idBill, int idFood, int count)
        {
            String getCountFood = "Select * from BillInfo where idFood = @idFood AND idBill = @idBill ";
            String sql = "";
            DataTable dt = DataProvider.ExecuteQuery(getCountFood, new object[] {idFood,idBill});
            if(dt.Rows.Count >0 ) {
                int countFood = (int)dt.Rows[0]["count"];
                int countNew = countFood + count;
                
                if (countNew > 0)
                {
                    sql = "Update BillInfo set count = @countNew where idFood = @idFood AND idBill = @idBill ";
                    DataProvider.ExecuteNonquery(sql, new object[] { countNew, idFood, idBill });
                }
                else
                {
                    sql = "Delete BillInfo where idFood = @idFood AND idBill = @idBill ";
                    DataProvider.ExecuteNonquery(sql, new object[] { idFood, idBill });
                }
            }
            else
            {
                if(count <=0)
                {
                    MessageBox.Show("Vui lòng nhập đúng số lượng !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    insertNewBillInfo( idBill, idFood , count);
                }
                
            }
            
            
        }
    }
}
