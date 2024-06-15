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


namespace Buy_Me.Gui
{
    public partial class FrmSubject : Form
    {
        private Subject thissubject;
        private SubjectDB tbls;
        FrmBusiness frm;
        public FrmSubject()
        {
            InitializeComponent();
            tbls = new SubjectDB();
            dg.DataSource = tbls.GetList().Select(x => new { קוד_סכום = x.Codesubject, תאור = x.Teur }).ToList();
            panel1.Visible = false;
        }
        public FrmSubject(FrmBusiness frm)
        {
            InitializeComponent();
            tbls = new SubjectDB();
            dg.DataSource = tbls.GetList().Select(x => new { קוד_סכום = x.Codesubject, תאור = x.Teur }).ToList();
            panel1.Visible = false;
            this.frm = frm;
        }

        private void FrmSubject_Load(object sender, EventArgs e)
        {

        }
        private void Possible()
        {
            panel1.Visible = true;
            btnnew.Visible = false;
        }
        private void notPossible()
        {
            btnnew.Visible = true;
            panel1.Visible = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Subject a = new Subject();
            if (tbls.GetList().Exists(x => x.Teur == this.txtteur.Text))
            {
                MessageBox.Show("שגיאת הוספה", "סכום זה כבר קיים", MessageBoxButtons.OK);
                txtteur.Text = "";
            }
            else
                if (CreatFields(a))
            {
                DialogResult r = MessageBox.Show(" אישור הוספה", "?האם להוסיף סכום זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tbls.AddNew(a);
                    notPossible();
                    dg.DataSource = tbls.GetList().Select(x => new { קוד_קהל_יעד = x.Codesubject, תאור = x.Teur }).ToList();
                   
                }
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtsubject.Text = tbls.GetNextKey().ToString();
            txtteur.Text = "";
            Possible();
            txtteur.Select();
        }
        private bool CreatFields(Subject a)
        {
            bool ok = true;
            errorProvider1.Clear();
            a.Codesubject = Convert.ToInt32(txtsubject.Text);
            try
            {
                a.Teur = txtteur.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtteur, ex.Message);
                ok = false;
            }
            return ok; ;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            notPossible();
            errorProvider1.Clear();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            frm.miluysubject();
               
        }

        private void FrmSubject_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm.miluysubject();
        }
    }
}
