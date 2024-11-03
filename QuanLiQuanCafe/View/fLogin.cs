using QuanLiQuanCafe.Controller;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thóat chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(thoat == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            String username = txtDN.Text;
            String password = txtMK.Text;   
            if (Login(username, password))
            {
                fTableManage f = new fTableManage();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean Login (String username, String password) { 
            return Account.Login(username, password);
        }
    }
}
