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
   public class Subject
    {
        private int codesubject;
        private string teur;
        public DataRow Dr { get; set; }
        public Subject(DataRow dr)
        {
            this.Dr = dr;
            this.codesubject = Convert.ToInt32(Dr["codesubject"]);
            this.teur = Dr["teur"].ToString();
        }
        public Subject()
        {

        }
        public int Codesubject
        {
            get
            {
                return this.codesubject;
            }
            set
            {
                this.codesubject = value;
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
                    throw new Exception("הקש תחום תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codesubject"] = this.Codesubject;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }
    }
}
