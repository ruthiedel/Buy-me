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
     public class AreaDB: GeneralDB
    {
        protected List<Area> list = new List<Area>();
        public AreaDB() : base("area") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Area(dr));
            }
        }
        public List<Area> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Area Find(int code)
        {
            return this.GetList().FirstOrDefault(X => X.Codearea == code);
        }
        public void Updatarow(Area c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Area c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codearea) + 1;
        }

    }
}
