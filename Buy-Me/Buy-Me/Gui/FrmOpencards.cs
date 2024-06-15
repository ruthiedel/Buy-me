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
            dgcards.DataSource = tblcard.GetList().Where(x => x.Cpel == thisclient.Cpel && x.Famount< Convert.ToInt32(x.ThisBusiness().ThisSum().Teur)).Select(x => new { קוד_כרטיס=x.Codecard,בית_עסק = x.ThisBusiness().Bname,תחום=x.ThisBusiness().ThisSubject().Teur, סכום_נוכחי = x.Namount, סכום_להשלמה = Convert.ToInt32(x.ThisBusiness().ThisSum().Teur) - (x.Namount) }).ToList();
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
                string path = System.IO.Directory.GetCurrentDirectory();
                int x = path.IndexOf("\\bin");
                path = path.Substring(0, x) + business.Picture;
                pictureBox1.Image = Image.FromFile(path);
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
            if (txtsum.Text != "")
            {
                DialogResult r = MessageBox.Show("אישור קנייה", "האם לאשר קנייה זו", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    Card c = new Card();
                    c = tblcard.Find(Convert.ToInt32(dgcards.CurrentRow.Cells[0].Value));
                    c.Namount += Convert.ToDouble(txtsum.Text);
                    c.Famount += Convert.ToInt32(txtsum.Text);
                    if (c.Famount >= Convert.ToInt32(business.ThisSum().Teur))
                    {
                        c.Status = true;
                    }
                    tblcard.UpdateRow(c);
                    Cardpurchase p = new Cardpurchase();
                    p.Amount = Convert.ToDouble(txtsum.Text);
                    p.Codecard = c.Codecard;
                    p.Cpel = thisbuyer.Cpel;
                    p.Pdate = DateTime.Today.Date;
                    p.Phour = DateTime.Now;
                    tblcardpurchase.AddNew(p);
                    panel1.Visible = false;
                    dgcards.DataSource = tblcard.GetList().Where(x => x.Cpel == thisclient.Cpel && x.Status == false).Select(x => new { קוד_קורס = x.Codecard, בית_עסק = x.ThisBusiness().Bname, תחום = x.ThisBusiness().ThisSubject().Teur, סכום_נוכחי = x.Namount, סכום_להשלמה = Convert.ToInt32(x.ThisBusiness().ThisSum().Teur) - (x.Namount) }).ToList();
                    business = new Business();
                    txtsum.Text = "";
                }
            }
            else
            {
                MessageBox.Show("הקש סכום קנייה");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
