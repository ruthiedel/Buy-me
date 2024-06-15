﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Buy_Me.Utilities;
using Buy_Me.Models;



namespace Buy_Me.DB
{
   public class CardpurchaseDB:GeneralDB
    {
        protected List<Cardpurchase> list = new List<Cardpurchase>();
        public CardpurchaseDB() : base("cardpurchase")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Cardpurchase(dr));
            }
        }
        public List<Cardpurchase> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Cardpurchase Find(int code,string cpel)
        {
            return this.GetList().Find(x => x.Codecard == code&&x.Cpel==cpel);
        }
        public void delelteRow(int code, string cpel)
        {
            Cardpurchase b = this.Find(code,cpel);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Cardpurchase c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Cardpurchase c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
       
    }
}
