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
 public   class UsingMultycardDB:GeneralDB
    {
        protected List<UsingMultycard> list = new List<UsingMultycard>();
        public UsingMultycardDB() : base("usingmultycard")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new UsingMultycard(dr));
            }
        }
        public List<UsingMultycard> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public UsingMultycard Find(int code, DateTime hour, DateTime k)
        {
            return this.GetList().Find(x => x.Codecard == code && x.Uhour == hour && x.Udate == k);
        }
        public void delelteRow(int code, DateTime hour, DateTime k)
        {
            UsingMultycard b = this.Find(code, hour, k);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(UsingMultycard c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(UsingMultycard c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }

    }
}
