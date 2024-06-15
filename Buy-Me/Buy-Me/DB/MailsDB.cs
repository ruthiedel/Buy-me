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
  public  class MailsDB:GeneralDB
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
        public Mails Find(string code)
        {
            return this.GetList().Find(x => x.Cpel == code);
        }
     
        public void delelteRow(string code)
        {
            Mails m = this.Find(code);
            if (m != null)
            {
                m.Dr.Delete();
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
