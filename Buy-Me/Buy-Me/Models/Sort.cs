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
   public class Sort
    {
        private int codesort;
        private string teur;
        public DataRow Dr { get; set; }
        public Sort(DataRow dr)
        {
            this.Dr = dr;
            this.codesort = Convert.ToInt32(Dr["codesort"]);
            this.teur = Dr["teur"].ToString();
        }
        public Sort()
        {

        }
        public int Codesort
        {
            get
            {
                return this.codesort;
            }
            set
            {
                this.codesort = value;
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
                if (ValidateUtil.IsHebrew(value))
                    this.teur = value;
                else
                {
                    throw new Exception("הקש קהל יעד תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codesort"] = this.Codesort;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }
    }
}
