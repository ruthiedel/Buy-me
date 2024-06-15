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
using Buy_Me.DB;


namespace Buy_Me.Models
{
  public  class Registration
    {
        private int codebusiness;
        private DateTime ldate;
        private DateTime fdate;
        public DataRow Dr { get; set; }
        public Registration(DataRow dr)
        {
            this.Dr = dr;
            this.codebusiness = Convert.ToInt32(dr["codebusiness"]);
            this.ldate = Convert.ToDateTime(dr["ldate"]);
            this.fdate = Convert.ToDateTime(dr["fdate"]);
        }
        public Registration()
        {

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
                    throw new Exception("הקוד שהוקש אינו תקין");
            }
        }
        public DateTime Fdate
        {
            get
            {
                return this.fdate;
            }
            set
            {
                this.fdate = value;
            }
        }
        public DateTime Ldate
        {
            get
            {
                return this.ldate;
            }
            set
            {
                this.ldate = value;
            }
        }
        public void PutInto()
        {
            Dr["codebusiness"] = this.codebusiness;
            Dr["ldate"] = this.ldate;
            Dr["fdate"] = this.fdate;
        }
        public override string ToString()
        {
            return fdate + ":תאריך תחילת המנוי" + codebusiness + ":בית עסק";
        }



    }
}
