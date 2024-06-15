using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Buy_Me.Utilities;
using Buy_Me.DB;


namespace Buy_Me.Models
{
   public class Using
    {
        private int codecard;
        private DateTime udate;
        private DateTime uhour;

        private double amount;
        public DataRow Dr { get; set; }
        public Using(DataRow dr)
        {
            this.Dr = dr;
            this.codecard = Convert.ToInt32(Dr["codecard"]);
            this.udate = Convert.ToDateTime(Dr["udate"]);
            this.uhour = Convert.ToDateTime(Dr["uhour"]);
            this.amount = Convert.ToDouble(Dr["amount"]);
        }
        public Using()
        {

        }
        public int Codecard
        {
            get
            {
                return this.codecard;
            }
            set
            {
                this.codecard = value;
            }
        }
      
        public DateTime Uhour
        {
            get
            {
                return this.uhour;
            }
            set
            {
                this.uhour = value;
            }
        }
        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.amount = value;
                else
                    throw new Exception("הסכום שהוקש שגוי");
            }
        }
        public DateTime Udate
        {
            get
            {
                return this.udate;
            }
            set
            {
                this.udate = value;
            }
        }
        public void PutInto()
        {
            Dr["codecard"] = this.Codecard;
            Dr["amount"] = this.Amount;
            Dr["udate"] = this.Udate;
            Dr["uhour"] = this.Uhour.ToLongTimeString();

        }
        public override string ToString()
        {
            return codecard+":קוד כרטיס" ;
        }

        public Card ThisCard()
        {
            CardDB tblc = new CardDB();
            return tblc.Find(this.codecard);
        }
    }
}
