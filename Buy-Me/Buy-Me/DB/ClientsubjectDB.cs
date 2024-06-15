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
    class ClientsubjectDB:GeneralDB
    {
        protected List<Clientsubject> list = new List<Clientsubject>();
        public ClientsubjectDB() : base("clientsubject") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Clientsubject(dr));
            }
        }
        public List<Clientsubject> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Clientsubject Find(int codeb, string codec)
        {
            return this.GetList().FirstOrDefault(X => X.Codesubject == codeb && X.Cpel == codec);
        }
        public void Updatarow(Clientsubject c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Clientsubject c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public void delelteRow(int code,string codec)
        {
            Clientsubject client = this.Find(code,codec);
            if (client != null)
            {
                client.Dr.Delete();
                this.Update();
            }
        }
    }
}
