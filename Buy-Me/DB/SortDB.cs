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
   public class SortDB:GeneralDB
    {
        protected List<Sort> list = new List<Sort>();
        public SortDB() : base("sorts") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Sort(dr));
            }
        }
        public List<Sort> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Sort Find(int code)
        {
            return this.GetList().FirstOrDefault(X => X.Codesort == code);
        }
        public void Updatarow(Sort c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Sort c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codesort) + 1;
        }
    }
}
