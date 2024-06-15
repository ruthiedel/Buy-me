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
using Buy_Me.Utilities;


namespace Buy_Me.Gui
{
    public partial class FrmMultycard : Form
    {
        private Multycard thismultycard;
        private MultycardDB tblmultycard;
        private string cpell;
        public FrmMultycard(Client c)
        {
            InitializeComponent();
            cpell = c.Cpel;
            tblmultycard = new MultycardDB();
            thismultycard = new Multycard();
            thismultycard = tblmultycard.GetList().Find(x => x.Cpel == cpell);
            txtname.Text = thismultycard.ThisClient().Fname + " " + thismultycard.ThisClient().Lname;
            txtsum.Text = Convert.ToString(thismultycard.Amount);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
