using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buy_Me.Gui
{
    public partial class FrmSelection : Form
    {
        private FrmBusiness frm;
        public FrmSelection()
        {
            InitializeComponent();
        }
        public FrmSelection(FrmBusiness frm)
        {
            InitializeComponent();
            this.frm = frm;

        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            FrmSubject f = new FrmSubject(frm);
            f.Show();
            this.Hide();
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            FrmSort f = new FrmSort(frm);
            f.Show();
            this.Hide();
        }

        private void btnarea_Click(object sender, EventArgs e)
        {
            FrmArea f = new FrmArea(frm);
            f.Show();
            this.Hide();
        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            FrmSum f = new FrmSum(frm);
            f.Show();
            this.Hide();
        }

        private void FrmSelection_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            
        }
    }
}
