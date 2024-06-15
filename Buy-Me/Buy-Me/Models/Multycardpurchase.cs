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
public class Multycardpurchase
    {
        private string cpel;
        private int codecard;
        private double amount;
        private DateTime pdate;
        private DateTime hour;
        public DataRow Dr { get; set; }
        public Multycardpurchase()
        {

        }
        public Multycardpurchase(DataRow dr)
        {
            this.Dr = dr;
            this.cpel = dr["cpel"].ToString();
            this.codecard = Convert.ToInt32(dr["codecard"]);
            this.amount = Convert.ToDouble(dr["amount"]);
            this.pdate = Convert.ToDateTime(dr["pdate"]);
            this.hour = Convert.ToDateTime(dr["mhour"]);
        }
        public string Cpel
        {
            get
            {
                return this.cpel;
            }
            set
            {
                if (ValidateUtil.IsCellPhone(value))
                    this.cpel = value;
                else
                    throw new Exception("הפלאפון אינו תקין");
            }
        }
        public int Codecard
        {
            get
            {
                return this.codecard;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codecard = value;
                else
                    throw new Exception("מספר הקוד אינו תקין");
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
                    throw new Exception("הקש מספר תקין");
            }
        }
        public DateTime Pdate
        {
            get
            {
                return this.pdate;
            }
            set
            {
                this.pdate = value;
            }
        }
        public DateTime Hour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
            }
        }
     
        public void PutInto()
        {
            Dr["cpel"] = this.Cpel;
            Dr["codecard"] = this.Codecard;
            Dr["amount"] = this.Amount;
            Dr["pdate"] = this.Pdate;
            Dr["mhour"] = this.Hour.ToLongTimeString();
        }
        public override string ToString()
        {
            return this.cpel + ":מספר לקוח" + this.codecard + "מספר כרטיס";

        }
        public Client ThisClient()
        {
            ClientDB tblc = new ClientDB();
            return tblc.Find(this.cpel);
        }
        public Multycard ThisMultycard()
        {
            MultycardDB tblc = new MultycardDB();
            return tblc.Find(this.codecard);
        }
    }
}
