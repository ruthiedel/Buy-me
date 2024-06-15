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
   public class Clientsubject
    {
        private int codesubject;
        private string cpel;
     
        public DataRow Dr { get; set; }
        public Clientsubject(DataRow dr)
        {
            this.Dr = dr;
            this.codesubject = Convert.ToInt32(dr["codesubject"]);
            this.cpel = dr["cpel"].ToString();
           
        }
        public Clientsubject()
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
                if (ValidateUtil.IsNum(Convert.ToString(value)))
                    this.codesubject = value;
                else
                    throw new Exception("הקוד שהוקש אינו תקין");
            }
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
                    throw new Exception("הפלאפון שהוקש אינו תקין");

            }
        }
        public void PutInto()
        {
            Dr["codesubject"] = this.Codesubject;
            Dr["cpel"] = this.Cpel;
        }
           
        public override string ToString()
        {
            return cpel + "מספר לקוח" + codesubject + ":קוד תחום";
        }
        public Client ThisClient()
        {
            ClientDB tblc = new ClientDB();
            return tblc.Find(this.cpel);
        }
        public Subject ThisSubject()
        {
            SubjectDB tbla = new SubjectDB();
            return tbla.Find(this.codesubject);
        }
    }
}
