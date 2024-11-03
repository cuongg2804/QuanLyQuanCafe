using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Model
{
    public class BillInfoModel
    {
        private int id, idFood, idBill, count;
        public BillInfoModel(int id, int idFood, int idBill, int count) {
            
            this.id = id;
            this.idBill = idBill;
            this.idFood = idFood;   
            this.count = count;
        }
        public int Id { get { return id; }  }
        public int IdFood { get {  return idFood; } }
        public int IdBill { get {  return idBill; } }   
        public int Count { get { return count; } set { count = value; } }
    }
}
