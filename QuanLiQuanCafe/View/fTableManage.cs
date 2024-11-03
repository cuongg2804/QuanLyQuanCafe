using QuanLiQuanCafe.Controller;
using QuanLiQuanCafe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiQuanCafe
{
    public partial class fTableManage : Form
    {
        public fTableManage()
        {
            InitializeComponent();
            LoadTable();

        }
        #region Method
        private void LoadTable()
        {
            List<Table> tables = TableController.LoadTable() ;
            foreach (Table table in tables)
            {
                Button bt = new Button();
               
                bt.Name = table.ID.ToString();
                
                bt.Width = 80;
                bt.Height = 80;
                bt.Text = table.Name + "\n" + table.Status;
                if(table.Status.Equals("Có người"))
                {
                    bt.BackColor = Color.Gray;
                }
                bt.Click += bt_Click;
                flpTable.Controls.Add(bt);
            }
        }


        #endregion
        #region Event
        private void bt_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear();
            int idTable = Convert.ToInt32((sender as Button).Name.ToString());
            int idBill = 0;
            if (BillController.GetIdBillByIdTable(idTable)  !=null )
            {
                idBill = Convert.ToInt32(BillController.GetIdBillByIdTable(idTable).Id);
                List<BillInfoModel> listBillInfo = BillInforController.GetBillInfoByIdBill(idBill);
                foreach (BillInfoModel billInfor in listBillInfo)
                {
                    ListViewItem lvs = new ListViewItem(billInfor.Id.ToString());
                    lvs.SubItems.Add(billInfor.Count.ToString());
                    lsvBill.Items.Add(lvs);
                }
            }
        }
        private void thôngTinTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccountInfo fAccountInfo = new fAccountInfo();
         
            fAccountInfo.ShowDialog();
            this.Show();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();   
            fAdmin.ShowDialog();
            this.Show();
        }
        #endregion

        
    }
}
