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
    public class Card
    {
        private int codecard;
        private int codebusiness;
        private string cpel;
        private int famount;
        private double namount;
        private bool status;
        public DataRow Dr { get; set; }

        public Card()
        {

        }
        public Card(DataRow dr)
        {
            this.Dr = dr;
            this.codecard = Convert.ToInt32(Dr["codecard"]);
            this.famount = Convert.ToInt32(Dr["famount"]);
            this.codebusiness = Convert.ToInt32(Dr["codebusiness"]);
            this.cpel = Dr["cpel"].ToString();
            this.namount = Convert.ToDouble(Dr["namount"]);
            if (Dr["status"].Equals(true))
                this.status = true;
            else
                this.status = false;
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
                    throw new Exception("הקוד אינו תקין");
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
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codebusiness = value;
                else
                    throw new Exception("הקוד אינו תקין");
            }
        }
        public int Famount
        {
            get
            {
                return this.famount;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.famount= value;
                else
                    throw new Exception("המחיר אינו תקין");
            }
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
                    throw new Exception("מספר הפלאפון שגוי");
            }
        }
        public double Namount
        {
            get
            {
                return this.namount;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.namount = value;
                else
                    throw new Exception("הסכום אינו תקין");
            }
        }
        public bool Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        public void PutInto()
        {
            Dr["codecard"] = this.Codecard;
            Dr["cpel"] = this.Cpel;
            Dr["famount"] = this.Famount;
            Dr["namount"] = this.Namount;
            Dr["codebusiness"] = this.Codebusiness;
            Dr["status"] = this.status;
        }
        public override string ToString()
        {
            return codecard + " קוד כרטיס";
        }
        public Client ThisClient()
        {
            ClientDB tblc = new ClientDB();
            return tblc.Find(this.cpel);
        }
        public Business ThisBusiness()
        {
            BusinessDB tblc = new BusinessDB();
            return tblc.Find(this.Codebusiness);
        }
     
    }
}
