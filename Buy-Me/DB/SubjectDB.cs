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
   public class SubjectDB: GeneralDB
    {
        protected List<Subject> list = new List<Subject>();
        public SubjectDB() : base("subjects") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Subject(dr));
            }
        }
        public List<Subject> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Subject Find(int code)
        {
            return this.GetList().FirstOrDefault(X => X.Codesubject == code);
        }
        public void Updatarow(Subject c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Subject c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codesubject) + 1;
        }
    }
}
