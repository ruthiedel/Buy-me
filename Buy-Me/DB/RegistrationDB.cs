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
  public  class RegistrationDB:GeneralDB
    {
        protected List<Registration> list = new List<Registration>();
        public RegistrationDB() : base("registration")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Registration(dr));
            }
        }
        public List<Registration> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Registration Find(int code)
        {
            RegistrationDB tbl = new RegistrationDB();
            Registration r = new Registration();
            r = tbl.GetList().FindLast(z => z.Codebusiness == code);
            return this.GetList().Find(x => x.Codebusiness== code && x.Fdate==r.Fdate);
        }
        public void delelteRow(int code, DateTime hour)
        {
            Registration b = this.Find(code);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Registration c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Registration c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
     
    }
}
