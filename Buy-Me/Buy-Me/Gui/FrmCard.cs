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
    public partial class FrmCard : Form
    {
        private CardDB tblcard;
        private Card thiscard;
        private string cpell;
        private Client thisclient=new Client();
   
        public FrmCard(Client c)
        {
            InitializeComponent();
            tblcard = new CardDB();
            thiscard = new Card();
            thisclient = c;
            cpell = c.Cpel;
            dg.DataSource = tblcard.GetList().Where(x => x.Cpel == cpell&&x.Namount>0&&x.Status).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.ThisBusiness().Bname, טלפון_לקוח = x.ThisClient().Cpel, סכום_ראשוני = x.Famount, סכום_נוכחי = x.Namount }).ToList();
            dgopencard.DataSource=tblcard.GetList().Where(x => x.Cpel == cpell && x.Namount > 0 && x.Status==false).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.ThisBusiness().Bname, טלפון_לקוח = x.ThisClient().Cpel, סכום_ראשוני = x.Famount, סכום_נוכחי = x.Namount }).ToList();
        }

        private void FrmCard_Load(object sender, EventArgs e)
        {

        }

        //private void btnrefresh_Click(object sender, EventArgs e)
        //{
        //    dg.DataSource = tblcard.GetList().Where(x => x.Cpel == cpell).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.ThisBusiness().Bname, טלפון_לקוח = x.ThisClient().Cpel, סכום_ראשוני = x.Famount, סכום_נוכחי = x.Namount }).ToList();
        //}

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            FrmOpencards f = new FrmOpencards(thisclient, thisclient);
            f.Show();
            this.Hide();
        }
    }
}
