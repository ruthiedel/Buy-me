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
        public FrmSelection()
        {
            InitializeComponent();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            FrmSubject f = new FrmSubject();
            f.Show();
            this.Hide();
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

        private void FrmSelection_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmBusiness f = new FrmBusiness();
            f.Show();
            this.Hide();
        }
    }
}
