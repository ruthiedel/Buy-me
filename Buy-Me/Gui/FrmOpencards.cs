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


namespace Buy_Me.Gui
{
    public partial class FrmOpencards : Form
    {
        private CardDB tblcard;
        private Client thisclient;
        private Client thisbuyer;
        private Business business;
        private BusinessDB tblbusiness;
        private CardpurchaseDB tblcardpurchase;
        private MailsDB tblmail;
        public FrmOpencards(Client buyer,Client client)
        {
            InitializeComponent();
            thisbuyer = new Client();
            thisbuyer = buyer;
            thisclient = new Client();
            thisclient = client;
            tblcard = new CardDB();
            business = new Business();
            tblcardpurchase = new CardpurchaseDB();
            tblbusiness = new BusinessDB();
            tblmail = new MailsDB();
            dgcards.DataSource = tblcard.GetList().Where(x => x.Cpel == thisclient.Cpel && x.Famount<Convert.ToInt32(x.ThisBusiness().ThisSum().Teur)).Select(x => new { קוד_כרטיס=x.Codecard,בית_עסק = x.ThisBusiness().Bname,תחום=x.ThisBusiness().ThisSubject().Teur, סכום_נוכחי = x.Namount, סכום_להשלמה = Convert.ToInt32(x.ThisBusiness().ThisSum().Teur) - (x.Namount) }).ToList();
            panel1.Visible = false;
        }

        private void FrmOpencards_Load(object sender, EventArgs e)
        {

        }
        private bool SelectDg(DataGridView dg)
        {
            return (dg.SelectedRows.Count >= 1);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (SelectDg(dgcards))
            {
                business = (Business)tblbusiness.GetList().Find(z => z.Bname == Convert.ToString(dgcards.CurrentRow.Cells[1].Value) && z.ThisSubject().Teur == Convert.ToString(dgcards.CurrentRow.Cells[2].Value));
                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory();
                    int x = path.IndexOf("\\bin");
                    path = path.Substring(0, x) + business.Picture;
                    pictureBox1.Image = Image.FromFile(path);
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                catch { }
                panel1.Visible = true;
                lblname.Text = business.Bname;
                lblresidence.Text = business.Residence;
            }
            else
            {
                MessageBox.Show(" בחר כרטיס בחלונית שאליו תרצה להוסיף");
            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            txtsum.Text = "";
            panel1.Visible = false;
            business = new Business();
        }

        private void btndone_Click(object sender, EventArgs e)
        {
            if (txtsum.Text != ""&&Convert.ToInt32(txtsum.Text) > 0)
            {
                Card c = new Card();
                c = tblcard.Find(Convert.ToInt32(dgcards.CurrentRow.Cells[0].Value));
                c.Namount += Convert.ToDouble(txtsum.Text);
                c.Famount += Convert.ToInt32(txtsum.Text);
                tblcard.UpdateRow(c);
                Cardpurchase p = new Cardpurchase();
                p.Amount = Convert.ToDouble(txtsum.Text);
                p.Codecard = c.Codecard;
                p.Cpel = thisbuyer.Cpel;
                p.Pdate = DateTime.Today.Date;
                p.Phour = DateTime.Now;
                if (txtcongratulation.Text != "")
                    p.Congratulation = txtcongratulation.Text;
                else
                    p.Congratulation = "";
                p.Buyerpel=thisbuyer.Cpel;
                tblcardpurchase.AddNew(p);
                MessageBox.Show(" נשלחה הודעה ללקוח על מתנתך");
                panel1.Visible = false;
                dgcards.DataSource = tblcard.GetList().Where(x => x.Cpel == thisclient.Cpel && x.Famount < Convert.ToInt32(x.ThisBusiness().ThisSum().Teur)).Select(x => new { קוד_קורס = x.Codecard, בית_עסק = x.ThisBusiness().Bname, תחום = x.ThisBusiness().ThisSubject().Teur, סכום_נוכחי = x.Namount, סכום_להשלמה = Convert.ToInt32(x.ThisBusiness().ThisSum().Teur) - (x.Namount) }).ToList();
             
                if (c.Famount >= Convert.ToInt32(business.ThisSum().Teur))
                {
                    Mails m1 = new Mails();
                    m1.Codemailkind = 3;
                    m1.Cpel = thisclient.Cpel;
                    m1.Mdate = DateTime.Today;
                    m1.Mhour = p.Phour;
                    m1.Content = " :נסגר כרטיס  לבית העסק " + Convert.ToString(c.ThisBusiness().Bname) + " :מהלקוח " + Convert.ToString(p.ThisBuyer().Lname + p.ThisBuyer().Fname)+""+"\n"+""+"ממספר הפלפון"+thisbuyer.Cpel+" קוד הכרטיס" + p.Codecard;
                    tblmail.AddNew(m1);
                }
                else
                {
                    Mails m = new Mails();
                    m.Codemailkind = 6;
                    m.Cpel = thisclient.Cpel;
                    m.Mdate = DateTime.Today;
                    m.Mhour = p.Phour;
                    m.Content = ": התווסף כסף לכרטיס  לבית העסק" + Convert.ToString(c.ThisBusiness().Bname) + " :מהלקוח" + Convert.ToString(p.ThisBuyer().Lname) + " "+ Convert.ToString(p.ThisBuyer().Fname)+""+"\n"+""+"ממספר הפלפון"+thisbuyer.Cpel+"קוד הכרטיס"+p.Codecard; 
                    tblmail.AddNew(m);
                }
                business = new Business();
                txtsum.Text = "";
            }
            else
            {
                MessageBox.Show(" הקש סכום קנייה");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
