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
    class CardDB:GeneralDB
    {
        protected List<Card> list = new List<Card>();
        public CardDB() : base("card")
        {

        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Card(dr));
            }
        }
        public List<Card> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Card Find(int code)
        {
            return this.GetList().Find(x => x.Codecard == code);
        }
        public void delelteRow(int code)
        {
            Card b = this.Find(code);
            if (b != null)
            {
                b.Dr.Delete();
                this.Update();
            }
        }
        public void UpdateRow(Card c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Card c)
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
