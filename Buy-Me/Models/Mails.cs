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
    public class Mails
    {
        private string cpel;
        private DateTime mdate;
        private DateTime mhour;
        private int codemailkind;
        private string content;
     
        public DataRow Dr { get; set; }
        public Mails(DataRow dr)
        {
            this.Dr = dr;
            this.cpel = dr["cpel"].ToString();
            this.content = dr["content"].ToString();
            this.mdate = Convert.ToDateTime(dr["mdate"]);
            this.mhour = Convert.ToDateTime(dr["mhour"]);
            this.codemailkind = Convert.ToInt32(dr["codemailkind"]);
        }
        public Mails()
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
                {
                    throw new Exception("הקש מספר פלפון תקין");
                }
            }
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
                    throw new Exception("הקש קוד תקין");
            }
        }
        public DateTime Mdate
        {
            get
            {
                return this.mdate;
            }
            set
            {
                this.mdate = value;
            }
        }
        public DateTime Mhour
        {
            get
            {
                return this.mhour;
            }
            set
            {
                this.mhour = value;
            }
        }
        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
        public void PutInto()
        {
            Dr["cpel"] = this.cpel;
            Dr["codemailkind"] = this.codemailkind;
            Dr["mdate"] = this.mdate.ToLongDateString();
            Dr["mhour"] = this.mhour.ToLongTimeString();
            Dr["content"] = this.Content;
        }
        public override string ToString()
        {
            return cpel;

        }
        public Mailkind ThisMailkind()
        {
            MailkindDB tbls = new MailkindDB();
            return tbls.Find(this.codemailkind);
        }
        public Client ThisClient()
        {
            ClientDB tblc = new ClientDB();
            return tblc.Find(this.cpel);
        }
    }

}
