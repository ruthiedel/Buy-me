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
   public  class Clientwish
    {
        private int codebusiness;
        private string cpel;
     
        public DataRow Dr { get; set; }
      
        public Clientwish(DataRow dr)
        
        {
            
            this.Dr = dr;
            this.codebusiness = Convert.ToInt32(dr["codebusiness"]);
            
            this.cpel = dr["cpel"].ToString();
           
        
        }
        public Clientwish()
        {

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
            Dr["codebusiness"] = this.Codebusiness;
            Dr["cpel"] = this.Cpel;
          
        }
        public override string ToString()
        {
            return cpel+"מספר לקוח"+codebusiness+":קוד בית עסק";
        }
        public Client ThisClient()
        {
            ClientDB tblc = new ClientDB();
            return tblc.Find(this.cpel);
        }
        public Business ThisBusiness()
        {
            BusinessDB tblc = new BusinessDB();
            return tblc.Find(this.Codebusiness);
        }
    }
}
