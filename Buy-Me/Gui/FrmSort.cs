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
    public partial class FrmSort : Form
    {
        private Sort thissort;
        private SortDB tbls;
        private FrmBusiness frm;
        public FrmSort()
        {
            InitializeComponent();
            tbls = new SortDB();
            dg.DataSource = tbls.GetList().Select(x => new { קוד_קהל_יעד = x.Codesort, תאור = x.Teur }).ToList();
            panel1.Visible = false;
        }
        public FrmSort(FrmBusiness frm)
        {
            InitializeComponent();
            tbls = new SortDB();
            dg.DataSource = tbls.GetList().Select(x => new { קוד_קהל_יעד = x.Codesort, תאור = x.Teur }).ToList();
            panel1.Visible = false;
            this.frm = frm;
        }

        private void FrmSort_Load(object sender, EventArgs e)
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

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtsort.Text = tbls.GetNextKey().ToString();
            txtteur.Text = "";
            Possible();
            txtteur.Select();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Sort a = new Sort();
            if (tbls.GetList().Exists(x => x.Teur == this.txtteur.Text))
            {
                MessageBox.Show("שגיאת הוספה", "קהל יעד זה כבר קיים", MessageBoxButtons.OK);
                txtteur.Text = "";
            }
            else
                if (CreatFields(a))
            {
                DialogResult r = MessageBox.Show(" אישור הוספה", "?האם להוסיף אזור זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tbls.AddNew(a);
                    notPossible();
                    tbls = new SortDB();
                    dg.DataSource = tbls.GetList().Select(x => new { קוד_קהל_יעד = x.Codesort, תאור = x.Teur }).ToList();
                  
                }
            }
        }
        private bool CreatFields(Sort a)
        {
            bool ok = true;
            errorProvider1.Clear();
            a.Codesort = Convert.ToInt32(txtsort.Text);
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
            frm.miluysort();
        }

        private void FrmSort_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm.miluysort();
        }
    }
}
