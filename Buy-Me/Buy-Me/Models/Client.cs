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
     public class Client
    {
        private string cpel;
        private string lname;
        private string fname;
        private string residence;
        private int codesort;
        private string pincode;
        public DataRow Dr { get; set; }

        public Client(DataRow dr)
        {
            this.Dr = dr;
            this.cpel = dr["cpel"].ToString();
            this.fname = dr["fname"].ToString();
            this.lname = dr["lname"].ToString();
            this.residence = (dr["residence"]).ToString();
            this.codesort = Convert.ToInt32(dr["codesort"]);
            this.pincode = (dr["pincode"]).ToString();

        }
        public Client()
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
                    throw new Exception("מספר הטלפון אינו תקין");
            }
        }
        public string Lname
        {
            get
            {
                return this.lname;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.lname = value;
                else
                    throw new Exception("  השם שהוקש אינו תקין");
            }
        }
        public string Fname
        {
            get
            {
                return this.fname;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.fname = value;
                else
                    throw new Exception("השם אינו תקין");
            }
        }
        public string Residence
        {
            get
            {
                return this.residence;
            }
            set
            {
                if (ValidateUtil.IsHebrew(Convert.ToString(value)))
                    this.residence = value;
                else
                    throw new Exception("הקש  מגורים תקינים");

            }
        }
              public int Codesort
        {
            get
            {
                return this.codesort;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codesort = value;
                else
                    throw new Exception("הקש קוד תקין");

            }
        }
            public string Pincode
        {
            get
            {
                return this.pincode;
            }
            set
            {
                //if (ValidateUtil.IsNum((value)))
                    this.pincode = value;
                //else
                //    throw new Exception("הקש  קוד תקין");

            }
        }
        public void PutInto()
        {
            Dr["cpel"] = this.Cpel;
            Dr["lname"] = this.Lname;
            Dr["fname"] = this.Fname;
            Dr["residence"] = this.residence;
            Dr["codesort"] = this.Codesort;
            Dr["pincode"] = this.Pincode;
        }
        public override string ToString()
        {
            return  lname+ fname + ":שם";
         }
        public Sort ThisSort()
        {
            SortDB tbls = new SortDB();
            return tbls.Find(this.codesort);
        }
      
    }
    }

