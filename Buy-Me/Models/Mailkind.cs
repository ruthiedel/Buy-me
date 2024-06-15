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
 public   class Mailkind
    {
        private int codemailkind;
        private string teur;
        public DataRow Dr { get; set; }
        public Mailkind(DataRow dr)
        {
            this.Dr = dr;
            this.codemailkind = Convert.ToInt32(dr["codemailkind"]);
            this.teur = dr["teur"].ToString();
        }
        public Mailkind()
        {

        }
        public int Codemailkind
        {
            get
            {
                return this.codemailkind;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codemailkind = value;
                else
                {
                    throw new Exception("הקש קוד תקין");
                }
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
                    throw new Exception("הקש סוג בעברית");
                }
            }
        }
        public void Putinto()
        {
            Dr["codemailkind"] = this.codemailkind;
            Dr["teur"] = this.teur;
        }
        public override string ToString()
        {
            return teur;
        }
    }
}
