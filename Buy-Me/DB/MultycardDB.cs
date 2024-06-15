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
   public class MultycardDB:GeneralDB
    {
        protected List<Multycard> list = new List<Multycard>();
        public MultycardDB() : base("multycard")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Multycard(dr));
            }
        }
        public List<Multycard> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Multycard Find(int code)
        {
            return this.GetList().Find(x => x.Codecard == code);
        }
        public void delelteRow(int code)
        {
            Multycard b = this.Find(code);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Multycard c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Multycard c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codecard) + 1;
        }
    }
}
