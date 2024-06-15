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
   public class ClientwishDB:GeneralDB
    {

        protected List<Clientwish> list = new List<Clientwish>();
        public ClientwishDB() : base("clientwish") { }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Clientwish(dr));
            }
        }
        public List<Clientwish> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Clientwish Find(int codeb,string codec)
        {
            return this.GetList().FirstOrDefault(X => X.Codebusiness == codeb&&X.Cpel==codec);
        }
        public void Updatarow(Clientwish c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Clientwish c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
     
        public void delelteRow(int code, string codec)
        {
            Clientwish client = this.Find(code, codec);
            if (client != null)
            {
                client.Dr.Delete();
                this.Update();
            }
        }

    }
}
