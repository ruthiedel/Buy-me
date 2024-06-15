using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buy_Me.DB;
using Buy_Me.Models;
using Buy_Me.Utilities;
using System.IO;
using System.Runtime.Serialization;


namespace Buy_Me.Gui
{
    public partial class FrmMultycardpurchase : Form
    {
        private Multycard thismultycard;
        private MultycardDB tblmultycard;
        private MultycardpurchaseDB tblmutlycardpurchase;
        private Client thisclient;
        private Client thisbuyer;
        private MailsDB tblmail;
        SoundPlayer s = new SoundPlayer();

        public FrmMultycardpurchase(Client buyer, Client client)
        {
            InitializeComponent();
            tblmultycard = new MultycardDB();
            thismultycard = new Multycard();
            tblmutlycardpurchase = new MultycardpurchaseDB();
            thismultycard = tblmultycard.GetList().First(x => x.Cpel == client.Cpel);
            thisclient = new Client();
            thisbuyer = new Client();
            tblmail = new MailsDB();
            thisclient = client;
            thisbuyer = buyer;
            SoundPlayer s = new SoundPlayer();
            s.Play();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsum.Text != ""&&Convert.ToInt32(txtsum.Text)>0)
            {
                DialogResult r = MessageBox.Show("אישור קנייה", "האם לאשר קנייה זו", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    thismultycard.Amount += Convert.ToDouble(txtsum.Text);
                    tblmultycard.UpdateRow(thismultycard);
                    Multycardpurchase p = new Multycardpurchase();
                    p.Amount = Convert.ToDouble(txtsum.Text);
                    p.Codecard = thismultycard.Codecard;
                    p.Cpel = thisbuyer.Cpel;
                    p.Pdate = DateTime.Today;
                    p.Hour = DateTime.Now;
                    if (txtcongratulation.Text != "")
                        p.Congratulation = txtcongratulation.Text;
                    else
                        p.Congratulation = "";
                    if (txtcongratulation.Text != "")
                    {
                        p.Congratulation = txtcongratulation.Text;
                    }
                    else
                    {
                        p.Congratulation = " ";
                    }
                    tblmutlycardpurchase.AddNew(p);
                    Mails m = new Mails();
                    m.Cpel = thisclient.Cpel;
                    m.Codemailkind = 4;
                    m.Mdate= DateTime.Today;
                    m.Mhour = p.Hour;
                    m.Content= ": התווסף סכום לחשבון הלמולטיקרד" + ":מהלקוח" + Convert.ToString(thisbuyer.Lname + thisbuyer.Fname) +""+"\n"+""+ "ממספר הפלפון" + thisbuyer.Cpel + "קוד הכרטיס" + Convert.ToString(p.Codecard);
                    tblmail.AddNew(m);
                    if (thisclient.Pincode == "")
                    {
                        MessageBox.Show(" המתנה תשלח לפלפון של הנמען בצרוף ההקדשה וכןישלח לנמען קןד שימוש לאתר זה ");
                    }
                    else
                    {
                        MessageBox.Show("  המתנה תשלח לפלפון של הנמען בצרוף ההקדשה  ");
                    }
                    this.Hide();
                }
            }
            else
            {
                s.Play();
                MessageBox.Show("הקש את סכום הקניה");
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsum.Text = "";
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
