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
        public Form1()
        {
            InitializeComponent();
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

    }
}
