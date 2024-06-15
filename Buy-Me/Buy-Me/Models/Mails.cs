using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Buy_Me.Utilities;


namespace Buy_Me.Models
{
  public  class Mails
    {
        private string cpel;
        private DateTime mdate;
        private DateTime mhour;
        private int codemailkind;
        public DataRow Dr { get; set; }
        public Mails(DataRow dr)
        {
            this.Dr = dr;
            this.cpel = dr["cpel"].ToString();
            this.mdate = Convert.ToDateTime(dr["mdate"]);
            this.mhour = Convert.ToDateTime(dr["mhour"]);
            this.codemailkind = Convert.ToInt32(dr["codemailkind"]);
        }
        public Mails()
        {

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
                    throw new Exception("הקש פלאפון תקין");
            }
        }
        public DateTime Mdate
        {
            get
            {
                return this.mdate;
            }
            set
            {
                this.mdate = value;
            }
        }
        public DateTime Mhour
        {
            get
            {
                return this.mhour;
            }
            set
            {
                this.mhour = value;
            }
        }
        public int Codemailkind
        {
            get
            {
                return this.Codemailkind;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codemailkind = value;
                else
                {
                    throw new Exception("הקש קוד תקין ");
                }
            }
        }
        public void PutInto()
        {
            Dr["cpel"] = this.cpel;
            Dr["mdate"] = this.mdate;
            Dr["mhour"] = this.mhour;
            Dr["codemailkind"] = this.codemailkind;
        }

    }
}
