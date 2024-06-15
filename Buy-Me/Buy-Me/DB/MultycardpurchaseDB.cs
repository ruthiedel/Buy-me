using System;
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
   public class MultycardpurchaseDB:GeneralDB
    {
        protected List<Multycardpurchase> list = new List<Multycardpurchase>();
        public MultycardpurchaseDB() : base("multycardpurchase")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Multycardpurchase(dr));
            }
        }
        public List<Multycardpurchase> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Multycardpurchase Find(int code, string cpel)
        {
            return this.GetList().Find(x => x.Codecard == code && x.Cpel == cpel);
        }
        public void delelteRow(int code, string cpel)
        {
            Multycardpurchase b = this.Find(code, cpel);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Multycardpurchase c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Multycardpurchase c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
    }
}
