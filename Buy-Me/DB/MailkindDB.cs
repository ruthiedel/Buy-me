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
  public  class MailkindDB:GeneralDB
    {

        protected List<Mailkind> list = new List<Mailkind>();
        public MailkindDB() : base("mailkind") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Mailkind(dr));
            }
        }
        public List<Mailkind> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Mailkind Find(int code)
        {
            return this.GetList().FirstOrDefault(X => X.Codemailkind == code);
        }
        public void Updatarow(Mailkind c)
        {
            c.Putinto();
            this.Update();
        }
        public void AddNew(Mailkind c)
        {
            c.Dr = table.NewRow();
            c.Putinto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codemailkind) + 1;
        }

    }
}
