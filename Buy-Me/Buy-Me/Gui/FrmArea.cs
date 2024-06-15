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
    public partial class FrmArea : Form
    {
        
        private AreaDB tbla;
        public FrmArea()
        {
            InitializeComponent();
            tbla = new AreaDB();
            dg.DataSource = tbla.GetList().Select(x => new { קוד_אזור = x.Codearea, תאור = x.Teur }).ToList();
            panel1.Visible = false;
        }

        private void FrmArea_Load(object sender, EventArgs e)
        {

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtarea.Text = tbla.GetNextKey().ToString();
            txtteur.Text = "";
            Possible();
            txtteur.Select();
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
            Area a = new Area();
            if (tbla.GetList().Exists(x => x.Teur == this.txtteur.Text))
            {
                MessageBox.Show("שגיאת הוספה", "אזור זה כבר קיים", MessageBoxButtons.OK);
                txtteur.Text = "";
            }
            else
                if (CreatFields(a))
            {
                DialogResult r = MessageBox.Show(" אישור הוספה", "?האם להוסיף אזור זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tbla.AddNew(a);
                    dg.DataSource = tbla.GetList().Select(x => new { קוד_אזור = x.Codearea, תאור = x.Teur });
                    notPossible();
                }
            }
        }
        private bool CreatFields(Area a)
        {
            bool ok = true;
            errorProvider1.Clear();
            a.Codearea = Convert.ToInt32(txtarea.Text);
            try
            {
                a.Teur = txtteur.Text;
            }
            catch(Exception ex)
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
            FrmSelection f = new FrmSelection();
            f.Show();
            this.Hide();
        }
    }
}
