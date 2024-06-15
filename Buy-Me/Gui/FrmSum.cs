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
    public partial class FrmSum : Form
    {
        private Sum thissum;
        private SumDB tbls;
        private FrmBusiness frm;
        public FrmSum()
        {
            InitializeComponent();
            tbls = new SumDB();
            dg.DataSource = tbls.GetList().Select(x => new {קוד_סכום = x.Codesum, תאור = x.Teur }).ToList();
            panel1.Visible = false;
        }
        public FrmSum(FrmBusiness frm)
        {
            InitializeComponent();
            tbls = new SumDB();
            dg.DataSource = tbls.GetList().Select(x => new { קוד_סכום = x.Codesum, תאור = x.Teur }).ToList();
            panel1.Visible = false;
            this.frm = frm;
        }

        private void FrmSum_Load(object sender, EventArgs e)
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
            txtsum.Text = tbls.GetNextKey().ToString();
            txtteur.Text = "";
            Possible();
            txtteur.Select();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Sum a = new Sum();
            if (tbls.GetList().Exists(x => x.Teur == this.txtteur.Text))
            {
                MessageBox.Show("שגיאת הוספה", "סכום זה כבר קיים", MessageBoxButtons.OK);
                txtteur.Text = "";
            }
            else
                if ( CreatFields(a)&&Convert.ToInt32(txtteur.Text) > 0 )
            {
                DialogResult r = MessageBox.Show(" אישור הוספה", "?האם להוסיף סכום זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tbls.AddNew(a);
                    notPossible();
                    dg.DataSource = tbls.GetList().Select(x => new { קוד_קהל_יעד = x.Codesum, תאור = x.Teur }).ToList();
                  
                }
            }
        }
        private bool CreatFields(Sum a)
        {
            bool ok = true;
            errorProvider1.Clear();
            a.Codesum = Convert.ToInt32(txtsum.Text);
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
            frm.miluysum();
        }

        private void FrmSum_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm.miluysum();
        }
    }
}
