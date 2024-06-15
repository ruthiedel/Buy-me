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
            dg.DataSource = tblcard.GetList().Where(x => x.Cpel == cpell&&x.Status).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.ThisBusiness().Bname, טלפון_לקוח = x.ThisClient().Cpel, סכום_ראשוני = x.Famount, סכום_נוכחי = x.Namount }).OrderBy(x=> x.סכום_נוכחי).ToList();
            dgopencard.DataSource=tblcard.GetList().Where(x => x.Cpel == cpell && x.Namount > 0 && x.Famount < Convert.ToInt32(x.ThisBusiness().ThisSum().Teur)).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.ThisBusiness().Bname, טלפון_לקוח = x.ThisClient().Cpel, סכום_סופי = x.ThisBusiness().ThisSum().Teur, סכום_נוכחי = x.Namount }).ToList();
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

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            if(dg.SelectedRows.Count > 0)
            {
                Card c = new Card();
                c = tblcard.GetList().Find(x => x.Codecard == Convert.ToInt32(dg.CurrentRow.Cells[0].Value));
                FrmReport f = new FrmReport(c);
                f.Show();
            }
            else
            {
                MessageBox.Show("בחר כרטיס לצפייה");
            }
        }
    }
}
