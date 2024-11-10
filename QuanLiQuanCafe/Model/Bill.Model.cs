using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Model
{
    public class BillModel
    {
        private int id;
        private int idTable;
        private DateTime? TimeCheckIn;
        private int status;
        private int discount;
        private int totalBill;

        public BillModel(int id, int idTable, DateTime timeCheckIn, int status, int discount = 0, int totalBill = 0)
        {
            this.id = id;
            this.idTable = idTable;
            this.TimeCheckIn = timeCheckIn;
            this.status = status;
            this.discount = discount;
            this.totalBill = totalBill;
        }

        public int Id { get { return id; } set { id = value; } }
        public int IdTable { get { return idTable;  } set { idTable = value; } }
        public int Status { get { return status; } set {  status = value; } }
        public int Discount { get { return discount; } set { discount = value; } }
        public int TotalBill { get {  return totalBill; } set {  totalBill = value; } }
    }
}
