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
   public class Sum
    {
        private int codesum;
        private string teur;
        public DataRow Dr { get; set; }
        public Sum(DataRow dr)
        {
            this.Dr = dr;
            this.codesum = Convert.ToInt32(Dr["codeamount"]);
            this.teur = Dr["teur"].ToString();
        }
        public Sum()
        {

        }
        public int Codesum
        {
            get
            {
                return this.codesum;
            }
            set
            {
                this.codesum = value;
            }
        }
        public string Teur
        {
            get
            {
                return this.teur;
            }
            set
            {
                if (ValidateUtil.IsNum(value))
                    this.teur = value;
                else
                {
                    throw new Exception("הקש סכום תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codeamount"] = this.Codesum;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }
    }
}
