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
                bt.Width = 80;
                bt.Height = 80;
                bt.Text = table.Name + "\n" + table.Status;
                flpTable.Controls.Add(bt);
            }
        }
        #endregion
        #region Event
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
