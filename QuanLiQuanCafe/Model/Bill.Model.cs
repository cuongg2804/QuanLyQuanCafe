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

        public BillModel(int id, int idTable, DateTime timeCheckIn, int status)
         {
            this.id= id;
            this.idTable = idTable;
            this.TimeCheckIn = timeCheckIn;
            this.status = status;
        }

       public int Id { get { return id; } set { id = value; } }
        public int IdTable { get { return idTable;  } set { idTable = value; } }
        public int Status { get { return status; } set {  status = value; } }
    }
}
