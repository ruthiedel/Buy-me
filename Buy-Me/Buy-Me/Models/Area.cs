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
   public class Area
    {
        private int codearea;
        private string teur;

        public DataRow Dr { get; set; }
        public Area(DataRow dr) 
        { this.Dr = dr;
            this.codearea = Convert.ToInt32(Dr["codearea"]);
            this.teur = Dr["teur"].ToString(); 
        }
        public Area()
        {

        }
        public  int Codearea
        {
            get
            {
                return this.codearea;
            }
            set
            {
                this.codearea = value;
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
                    throw new Exception("הקש אזור תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codearea"] = this.Codearea;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }
          private int codearea;
        private string teur;

        public DataRow Dr { get; set; }
        public Area(DataRow dr) 
        { this.Dr = dr;
            this.codearea = Convert.ToInt32(Dr["codearea"]);
            this.teur = Dr["teur"].ToString(); 
        }
        public Area()
        {

        }
        public  int Codearea
        {
            get
            {
                return this.codearea;
            }
            set
            {
                this.codearea = value;
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
                    throw new Exception("הקש אזור תקין");
                }
            }
        }
        public void PutInto()
        {
            Dr["codearea"] = this.Codearea;
            Dr["teur"] = this.Teur;
        }
        public override string ToString()
        {
            return teur;
        }
        

    }
}
