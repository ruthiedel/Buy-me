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
  public  class UsingMultycard
    {
        private int codecard;
        private int codebusiness;
        private DateTime udate;
        private DateTime uhour;

        private double amount;
        public DataRow Dr { get; set; }
        public UsingMultycard(DataRow dr)
        {
            this.Dr = dr;
            this.codecard = Convert.ToInt32(Dr["codecard"]);
            this.codebusiness = Convert.ToInt32(Dr["codebusiness"]);
            this.udate = Convert.ToDateTime(Dr["udate"]);
            this.uhour = Convert.ToDateTime(Dr["uhour"]);
            this.amount = Convert.ToDouble(Dr["amount"]);
        }
        public UsingMultycard()
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
        public int Codebusiness
        {
            get
            {
                return this.codebusiness;
            }
            set
            {
                this.codebusiness = value;
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
            Dr["codebusiness"] = this.Codebusiness;
            Dr["amount"] = this.Amount;
            Dr["udate"] = this.Udate;
            Dr["uhour"] = this.Uhour.ToLongTimeString();

        }
        public override string ToString()
        {
            return codebusiness + ":בית עסק" + codecard + ":קוד כרטיס";
        }
        public Business ThisBusiness()
        {
            BusinessDB tblc = new BusinessDB();
            return tblc.Find(this.Codebusiness);
        }
        public Card ThisCard()
        {
            CardDB tblc = new CardDB();
            return tblc.Find(this.codecard);
        }
    }
}

