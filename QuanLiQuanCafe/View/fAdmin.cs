﻿using QuanLiQuanCafe.Controller;
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
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }


        void load_dgvAccount()
        {
            string query = "exec SelectAccount @name ";
            dgvAccount.DataSource = DataProvider.ExecuteQuery(query,new  object[] {"Vũ Văn Cường"});

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            load_dgvAccount();
        }
    }
}
