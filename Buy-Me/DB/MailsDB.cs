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
    class MailsDB:GeneralDB
    {
        protected List<Mails> list = new List<Mails>();
        public MailsDB() : base("mails")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Mails(dr));
            }
        }
        public List<Mails> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Mails Find(string code, DateTime mdate,DateTime mhour)
        {
            return this.GetList().Find(x => x.Cpel == code && x.Mdate==mdate&&x.Mhour==mhour);
        }
        public void delelteRow(string code, DateTime mdate, DateTime mhour)
        {
            Mails b = this.Find(code,mdate,mhour);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Mails c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Mails c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
    }
}
