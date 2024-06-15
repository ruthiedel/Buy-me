using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buy_Me.DB;
using Buy_Me.Models;
using Buy_Me.Utilities;
using System.IO;
using System.Runtime.Serialization;

namespace Buy_Me.Gui
{
    public partial class FrmReport : Form
    {
        private Card thiscard;
        private UsingDB tblusing;

        public FrmReport(Card c)
        {
            InitializeComponent();
            thiscard = c;
            tblusing = new UsingDB();
            if (c.Namount != c.Famount)
            {
                dataGridView1.DataSource = tblusing.GetList().Where(x => x.Codecard == thiscard.Codecard).Select(x => new { בית_עסק = x.ThisCard().ThisBusiness().Bname, תאריך = x.Udate, שעה = x.Uhour.ToShortTimeString(), סכום_קנייה = x.Amount }).ToList();
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
