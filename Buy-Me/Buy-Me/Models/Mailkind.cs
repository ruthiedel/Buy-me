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
  public  class Mailkind
    {
        private int codemailkind;
        private string teur;

        public DataRow Dr { get; set; }
        public Mailkind(DataRow dr)
        {
            this.Dr = dr;
            this.codemailkind = Convert.ToInt32(Dr["codemailkind"]);
            this.teur = Dr["teur"].ToString();
        }
        public Mailkind()
        {

        }
        public int Codemailkind
        {
            get
            {
                return this.codemailkind ;
            }
            set
            {
                this.codemailkind = value;
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
                    throw new Exception("הקש סוג הודעה תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codemailkind"] = this.codemailkind;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }

    }
}
