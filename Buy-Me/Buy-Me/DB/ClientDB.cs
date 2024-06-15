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
    public class ClientDB : GeneralDB
    {
        protected List<Client> list = new List<Client>();
        public ClientDB() : base("client")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Client(dr));
            }
        }
        public List<Client> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Client Find(string code)
        {
            return this.GetList().Find(x => x.Cpel == code);
        }
        public void delelteRow(string code)
        {
            Client client = this.Find(code);
            if (client != null)
            {
                client.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Client c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Client c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public string GetPinCode()
        {
            
            int count = 0,num=0;
            count = list.Count();
            while (count % 10 != 0)
            {
                num++;
                count = count / 10;
            }
            if (num <= 4)
                num = 4;
           
            Random rnd = new Random();
            string st="";
            for (int i = 0; i < num; i++)
            {
               
                int x = rnd.Next(0,9);
                st += x.ToString();
            }
            if(list.Find(x=> x.Pincode.Equals(st))==null)
            {
                return st;
            }
            else
            {
               return GetPinCode();
            }
           
        }

    }
}
