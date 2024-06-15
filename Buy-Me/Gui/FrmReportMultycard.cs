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
    public partial class FrmReportMultycard : Form
    {
        private Multycard mc;
        private UsingMultycardDB tblu;
        public FrmReportMultycard(Multycard m)
        {
            InitializeComponent();
            mc = new Multycard();
            mc = m;
            tblu = new UsingMultycardDB();
            dataGridView1.DataSource = tblu.GetList().Where(x => x.Codecard == mc.Codecard).Select(x => new { בית_עסק = x.ThisBusiness().Bname, תאריך = x.Udate, שעה = x.Uhour.ToShortTimeString(), סכום = x.Amount }).ToList();
            if (tblu.GetList().Where(x => x.Codecard == mc.Codecard).Count() > 0)
                label1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmReportMultycard_Load(object sender, EventArgs e)
        {

        }
    }
}
