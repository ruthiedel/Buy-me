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
using Buy_Me.Gui;




namespace Buy_Me
{
    public partial class Form1 : Form
    {
        private BusinessDB tblb;
      
        public Form1()
        {
            InitializeComponent();
            BusinessStatus();
            CardStatus();
            panel1.Visible = false;
            panel2.Visible = false;
            tblb = new BusinessDB();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            FrmSubject f = new FrmSubject();
            f.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnsort_Click(object sender, EventArgs e)
        {

            FrmSort f = new FrmSort();
            f.Show();
            this.Hide();

        }

        private void btnarea_Click(object sender, EventArgs e)
        {
            FrmArea f = new FrmArea();
            f.Show();
            this.Hide();
        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            FrmSum f = new FrmSum();
            f.Show();
            this.Hide();
        }

        private void btnbusiness_Click(object sender, EventArgs e)
        {
            FrmBusiness f = new FrmBusiness();
            f.Show();
            this.Hide();
        }

        private void btnusing_Click(object sender, EventArgs e)
        {
            FrmUsing f = new FrmUsing();
            f.Show();
            this.Hide();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            FrmClient f = new FrmClient();
            f.Show();
            this.Hide();
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            FrmPurchus1 f = new FrmPurchus1();
            f.Show();
            this.Hide();
        }
        public void BusinessStatus()
        {
            BusinessDB tblbusiness = new BusinessDB();
            for(int i=1; i < tblbusiness.GetList().Count()+1; i++)
                
            {
                Business b = new Business();
                b = tblbusiness.Find(i);
                if (b.ThisRegiatration().Ldate.Date < DateTime.Today.Date)
                {
                    b.status = false;
                    tblbusiness.UpdateRow(b);
                }
            }
        }
        public void CardStatus()
        {
            MailsDB tblmail = new MailsDB();
            CardDB tblcard = new CardDB();
            List<Card> lst = new List<Card>();
            CardpurchaseDB tblcp = new CardpurchaseDB();
            lst = tblcard.GetList().Where(x => x.Status == true).ToList();
            for(int i = 0; i < lst.Count(); i++)
            {
                Cardpurchase cp = new Cardpurchase();
                Card c = new Card();
                c = lst.ElementAt(i);
                cp = tblcp.GetList().First(z => z.Codecard == c.Codecard);
                DateTime s = cp.Pdate.AddYears(5);
                DateTime k=s.AddMonths(11);
                DateTime t = cp.Pdate.AddYears(6);            
                if (k< Convert.ToDateTime(DateTime.Today))
                {
                    c.Status = false;
                    tblcard.UpdateRow(c);
                    Mails m1 = new Mails();
                    m1.Codemailkind = 5;
                    m1.Cpel = c.Cpel;
                    m1.Mdate = DateTime.Today;
                    m1.Mhour = DateTime.Now;
                    m1.Content = " :תאריך התפוגה של הכרטיס " + Convert.ToString(c.Codecard) + "יפוג בעוד חודש";
                    tblmail.AddNew(m1);
                }
                if (t < DateTime.Today)
                {
                    Card c1 = tblcard.Find(c.Codecard);
                    c1.Status = false;
                    tblcard.UpdateRow(c1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmDiagrama f = new FrmDiagrama();
            f.Show();
        }

        private void לקוחותToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void כניסהוצפייהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmClient f = new FrmClient();
            f.Show();
            this.Hide();
        }

        private void קנייהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmPurchus1 f = new FrmPurchus1();
            f.Show();
            this.Hide();
        }

        private void כניסהועדכוןToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmBusiness f = new FrmBusiness();
            f.Show();
            this.Hide();
        }

        private void שימושבכרטיסToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmUsing f = new FrmUsing();
            f.Show();
            this.Hide();
        }

        private void אודותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            FrmAbout f = new FrmAbout();
            f.Show();
            
        }

        private void דוחרכישותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            
        }

        private void כניסתמנהלToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                if (textBox1.Text == "123")
                {
                    Frmmanager f = new Frmmanager();
                    f.Show();
                    panel1.Visible = false;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show(" הסיסמא שהוקשה שגויה");
                }
            }
        }

        private void ביתעסקToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtbcode.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtbcode.Text != null)
            {
                Business b = new Business();
                b = tblb.GetList().Find(x => x.Codebusiness == Convert.ToInt32(txtbcode.Text));
                if (b != null)
                {
                    panel2.Visible = false;
                    FrmbusinessReport f = new FrmbusinessReport(b);
                    f.Show();
                    txtbcode.Text = "";
                }
                else
                {
                    MessageBox.Show(" הקוד שהוקש שגוי");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
