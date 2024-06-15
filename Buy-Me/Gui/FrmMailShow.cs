using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buy_Me.DB;
using Buy_Me.Models;
using Buy_Me.Utilities;
using Buy_Me.Gui;



namespace Buy_Me.Gui
{
    public partial class FrmMailShow : Form
    {
        private Mails thismail;
        private CardpurchaseDB tblcardpurchase;
        private MultycardpurchaseDB tblmultycardpurchase;
        
        public FrmMailShow(Mails m)
        {
            InitializeComponent();
            thismail = new Mails();
            pictureBox1.Visible = false;
            tblcardpurchase = new CardpurchaseDB();
            thismail = m;
            tblmultycardpurchase = new MultycardpurchaseDB();
            lblcontent.Text = thismail.Content;
            lblmailkind.Text = thismail.ThisMailkind().Teur;
            panel2.Visible = false;
            if (thismail.Codemailkind == 3||thismail.Codemailkind==1||thismail.Codemailkind==6)
            {
                Cardpurchase cp = new Cardpurchase();
                int y = m.Content.IndexOf("ממספר הפלפון");
                y += 12;
                string pel = m.Content.Substring(y, 10);
                int t = m.Content.IndexOf("קוד הכרטיס");
                t += 10;
                DateTime l = m.Mhour;
                int z = m.Content.Length - t;
                string code = m.Content.Substring(t, z);
                cp = tblcardpurchase.Find(Convert.ToInt32(code), pel, m.Mdate, m.Mhour);
                if (cp.Congratulation != "")
                {
                    label2.Text = cp.Congratulation;
                    panel2.Visible = true;
                }
                pictureBox1.Visible = true;
            }
            if (thismail.Codemailkind == 4)
            {
                Multycardpurchase cp = new Multycardpurchase();
                int y = m.Content.IndexOf("ממספר הפלפון");
                y += 12;
                string pel = m.Content.Substring(y, 10);
                int t = m.Content.IndexOf("קוד הכרטיס");
                t += 10;
                DateTime l = m.Mhour;
                int z = m.Content.Length - t;
                string code = m.Content.Substring(t, z);
                cp = tblmultycardpurchase.Find(Convert.ToInt32(code), pel,thismail.Mdate,thismail.Mhour);
                if (cp.Congratulation != "")
                {
                    label2.Text = cp.Congratulation;
                    panel2.Visible = true;
                }
            }
        }

        private void FrmMailShow_Load(object sender, EventArgs e)
        {

        }

        private void lblmailkind_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
