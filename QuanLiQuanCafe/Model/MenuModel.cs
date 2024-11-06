﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.Model
{
    public class MenuModel
    {
        private int idBill, idTable, count;
        private double price;
        private string name;

        public MenuModel (int idBill , int idTable , int count , double price , string name)
        {
            this.idBill = idBill;   
            this.idTable = idTable;
            this.count = count;
            this.price = price;
            this.name = name;
        }
        public double totalPrice()
        {
            return this.price * this.count;
        }
        public int IdBill { get { return idBill; } set { } }
        public int IdTable { get {  return idTable; } set { } }
        public double Price { get { return price; } set { price = value; } }
        public string Name { get { return name; } set { name = value; } }   

        public int Count { get { return count; } set { } }
    }
}