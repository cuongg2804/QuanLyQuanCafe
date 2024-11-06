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
            LoadCategoryFood();
        }
        private int idTable = -1;

        #region Method

        private void LoadTable()
        {
            List<Table> tables = TableController.LoadTable();
            foreach (Table table in tables)
            {
                Button bt = new Button();

                bt.Name = table.ID.ToString();

                bt.Width = 80;
                bt.Height = 80;
                bt.Text = table.Name + "\n" + table.Status;
                if (table.Status.Equals("Có người"))
                {
                    bt.BackColor = Color.Gray;
                }
                bt.Click += bt_Click;
                flpTable.Controls.Add(bt);
            }
        }

        private void LoadCategoryFood ()
        {
           List<CategoryModel> listCategory = CategoryController.LoadCategory();
            cmbFoodCategory.DisplayMember = "name";
            cmbFoodCategory.ValueMember = "id";
            cmbFoodCategory.DataSource = listCategory;
        }

        private void LoadFood (int idCategory)
        {
            DataTable tb = FoodController.LoadFoodByIdCategory(idCategory);
            cmbFood.DisplayMember = "name";
            cmbFood.ValueMember = "id"; 
            cmbFood.DataSource = tb;

        }

        private void LoadBill()
        {
            lsvBill.Items.Clear();
            List<MenuModel> list = new List<MenuModel>();
            double totalBill = 0;

            foreach (MenuModel model in BillInforController.GetMenuByIdTable(idTable))
            {
                ListViewItem lvs = new ListViewItem(model.Name.ToString());
                lvs.SubItems.Add(model.Count.ToString());
                lvs.SubItems.Add(model.Price.ToString("#,0 đ"));
                lvs.SubItems.Add(model.totalPrice().ToString("#,0 đ"));
                lsvBill.Items.Add(lvs);
                totalBill += Convert.ToDouble(model.totalPrice());
            }
            txtTotalPrice.Text = totalBill.ToString("#,0 đ");
        }

        #endregion
        #region Event
        private void cmbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategory = cmbFoodCategory.SelectedIndex + 1;
            LoadFood (idCategory);
        }
        private void bt_Click(object sender, EventArgs e)
        {
            
            idTable = Convert.ToInt32((sender as Button).Name.ToString());
            LoadBill();


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

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            int idFood = (int)cmbFood.SelectedValue;
            int count = (int)numCount.Value;
            if (idTable != -1)
            {
                var bill = BillController.GetIdBillByIdTable(idTable);
                int idBillExist = bill != null ? bill.Id : -1;
                if (idBillExist != -1)
                { 

                    BillInforController.InsertBillInfo(idTable, idBillExist, idFood, count);
                }
                else
                {
                    int idBill = BillController.getIdMax() + 1;
                    BillController.InsertBill(idTable);
                    BillInforController.insertNewBillInfo(idBill, idFood, count);
                    TableController.UpdateStatusTable("Có người", idTable);
                    flpTable.Controls.Clear();
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadBill();
        }

        #endregion


    }
}
