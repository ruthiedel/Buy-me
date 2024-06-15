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
   public class SumDB:GeneralDB
    {
        protected List<Sum> list = new List<Sum>();
        public SumDB() : base("amount") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Sum(dr));
            }
        }
        public List<Sum> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Sum Find(int code)
        {
            return this.GetList().FirstOrDefault(X => X.Codesum == code);
        }
        public void Updatarow(Sum c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Sum c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codesum) + 1;
        }

    }
}
