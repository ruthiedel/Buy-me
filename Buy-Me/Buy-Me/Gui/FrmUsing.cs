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
    public partial class FrmUsing : Form
    {
     
        private UsingDB tblu;
        private CardDB tblcard;
        private Card c;
        private UsingMultycardDB tblusingmultycard;
        private MultycardDB tblmultycard;
        private Multycard m;
        private BusinessDB tblbusiness;
        public FrmUsing()
        {
            InitializeComponent();
            tblusingmultycard = new UsingMultycardDB();
            tblmultycard = new MultycardDB();
            tblu = new UsingDB();
            tblbusiness = new BusinessDB();
            tblcard = new CardDB();
            panel1.Visible = false;
            panel2.Visible = false;
            txtcodeb.Text = "";
            txtcodecard.Text = "";
            txtsum.Text = "";
        }

        private void FrmUsing_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                if (txtsum.Text != "")
                {
                    if (c.Namount - Convert.ToInt32(txtsum.Text) > 0)
                    {
                        Using u = new Using();
                        u.Codecard = c.Codecard;
                        u.Amount = Convert.ToInt32(txtsum.Text);
                        u.Udate = DateTime.Today.Date;
                        u.Uhour = DateTime.Now ;
                        tblu.AddNew(u);
                        c.Namount -= Convert.ToInt32(txtsum.Text);
                        tblcard.UpdateRow(c);
                        panel1.Visible = false;
                        panel2.Visible = false;
                        panelkindofcard.Visible = true;
                        c = null;
                    }
                    else
                    {
                        MessageBox.Show(" סכום הקנייה גדול מהסכום הנוכחי בכרטיס, הסכום הנוכחי הוא"+c.Namount);
                    }
                }
                else
                {
                    MessageBox.Show("הקש סכום קנייה");
                }
            }
            if (m != null)
            {
                if (txtsum.Text != "" && txtcodeb.Text != "" && ValidateUtil.IsNum(txtcodeb.Text))
                {
                    if (tblbusiness.Find(Convert.ToInt32(txtcodeb.Text)) != null|| tblbusiness.Find(Convert.ToInt32(txtcodeb.Text)).status==false)
                    {
                        if (m.Amount - Convert.ToInt32(txtsum.Text) > 0)
                        {
                            UsingMultycard u = new UsingMultycard();
                            u.Codecard = m.Codecard;
                            u.Codebusiness = Convert.ToInt32(txtcodeb.Text);
                            u.Amount = Convert.ToInt32(txtsum.Text);
                            u.Udate = DateTime.Today.Date;
                            u.Uhour = Convert.ToDateTime(DateTime.Now);
                            tblusingmultycard.AddNew(u);
                            m.Amount -= Convert.ToInt32(txtsum.Text);
                            tblmultycard.UpdateRow(m);
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panelkindofcard.Visible = true;
                            txtcodeb.Text = "";
                            txtcodecard.Text = "";
                            txtsum.Text = "";
                            m = null;
                        }
                        else
                        {
                            MessageBox.Show(" סכום הקנייה גדול מהסכום הנוכחי בכרטיס, הסכום הנוכחי הוא" + m.Amount);
                        }
                    }
                    else
                    {
                        MessageBox.Show("לא ניתן להשתמש בכרטיס כיוון שבית העסק אינו רשום באתר");
                    }
                    
                }
                else
                {
                    MessageBox.Show(" הקש סכום קנייה וקוד בית עסק תקין ");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c = tblcard.GetList().Find(x => x.Codecard == Convert.ToInt32(txtcodecard.Text));
                if (c !=null)
                {
                    //c = tblcard.GetList().Find(x => x.Codecard == Convert.ToInt32(txtcodecard.Text));
                    txtcodeb.Visible = false;
                    label2.Visible = false;
                    panel2.Visible = true;
                    panel1.Visible = false;
                }
                else
                {
                    MessageBox.Show("לא נמצא כרטיס במערכת");
                    c = new Card();
                    txtcodecard.Text = "";
                }
            }
            if (m != null)
            {
                m = tblmultycard.GetList().Find(x => x.Codecard == Convert.ToInt32(txtcodecard.Text));
                if (m != null)
                {
                    //m = tblmultycard.GetList().Find(x => x.Codecard == Convert.ToInt32(txtcodecard.Text));
                    txtcodeb.Visible = true;
                    label2.Visible = true;
                    panel2.Visible = true;
                    panel1.Visible = false;
                }
                else
                {
                    MessageBox.Show("לא נמצא כרטיס במערכת");
                    m = new Multycard();
                    txtcodecard.Text = "";
                }
            }
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            c = new Card();
            panelkindofcard.Visible = false;
            panel1.Visible = true;
        }

        private void btnmultycard_Click(object sender, EventArgs e)
        {
            m = new Multycard();
            panelkindofcard.Visible = false;
            panel1.Visible = true;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }

}
