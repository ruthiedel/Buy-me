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
     public class BusinessDB: GeneralDB
    {  
        protected List<Business> list = new List<Business>();
    public BusinessDB() : base("Business")
    {

    }
    private void DataTableToList()
    {
        foreach (DataRow dr in table.Rows)
        {
            list.Add(new Business(dr));
        }
    }
    public List<Business> GetList()
    {
        list.Clear();
        DataTableToList();
        return list;
    }
    public Business Find(int code)
    {
        return this.GetList().Find(x => x.Codebusiness == code);
    }
    public void delelteRow(int code)
    {
        Business b = this.Find(code);
        if (b != null)
        {
            b.Dr.Delete();
            this.Update();
        }
    }
    public void UpdateRow(Business c)
    {
        c.PutInto();
        this.Update();
    }
    public void AddNew(Business c)
    {
        c.Dr = table.NewRow();
        c.PutInto();
        this.Add(c.Dr);
    }
        public void DeleteStatus(int code)
        {
            Business b = this.Find(code);
            if (b != null)
            {
                b.status = false;
                this.UpdateRow(b);
            }
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Codebusiness) + 1;
        }
    }
}
