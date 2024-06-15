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
    public class Business
    {
        private int codebusiness;
        private string bname;
        private int codearea;
        private int codesort;
        private int codesubject;
        private int codesum;
        private string residence;
        private string picture;
        public bool status { get; set; }
        public DataRow Dr { get; set; }

        public Business(DataRow dr)
        {
            this.Dr = dr;
            this.bname = Dr["bname"].ToString();
            this.codesort = Convert.ToInt32(Dr["codesort"]);
            this.codesubject = Convert.ToInt32(Dr["codesubject"]);
            this.codearea = Convert.ToInt32(Dr["codearea"]);
            this.codebusiness = Convert.ToInt32(Dr["codebusiness"]);
            this.codesum = Convert.ToInt32(Dr["codeamount"]);
            this.residence = Dr["residence"].ToString();
            this.picture = Dr["picture"].ToString();
            if (Dr["status"].Equals(true))
                this.status = true;
            else
                this.status = false;
        }
        
        public Business()
        
        
        {

        }
        public string Bname
        {
            get 
            {
                return this.bname;
            }
            set
            {
                if (value != null)
                    this.bname = value;
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
        public string Picture
        {
            get
            {
                return this.picture;
            }
            set
            {
                this.picture = value;
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
                    throw new Exception("הקוד אינו תקין");
            }
        }
        public int Codearea
        {
            get
            {
                return this.codearea;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codearea = value;
                else
                    throw new Exception("הקוד אינו תקין");
            }
        }
        public int Codesubject
        {
            get
            {
                return this.codesubject;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codesubject = value;
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
        public int Codesum
        {
            get
            {
                return this.codesum;
            }
            set
            {
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codesum = value;
                else
                    throw new Exception("הקוד אינו תקין");
            }
        }
        public void PutInto()
        {
            Dr["codesubject"] = this.Codesubject;
            Dr["codesort"] = this.Codesort;
            Dr["codearea"] = this.Codearea;
            Dr["codeamount"] = this.Codesum;
            Dr["codebusiness"] = this.Codebusiness;
            Dr["bname"] = this.Bname;
            Dr["status"] = this.status;
            Dr["residence"] = this.residence;
            Dr["picture"] = this.picture;
        }
        public override string ToString()
        {
            return bname;

        }
        public Sort ThisSort()
        {
            SortDB tbls = new SortDB();
            return tbls.Find(this.codesort);
        }
     public Sum ThisSum()
        {
            SumDB tbls = new SumDB();
            return tbls.Find(this.codesum);
        }
        public Area ThisArea()
        {
            AreaDB tbla = new AreaDB();
            return tbla.Find(this.codearea);
        }
        public Subject ThisSubject()
        {
            SubjectDB tbla = new SubjectDB();
            return tbla.Find(this.codesubject);
        }
    }
}
