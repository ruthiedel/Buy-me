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
    public partial class FrmMultycardpurchase : Form
    {
        private Multycard thismultycard;
        private MultycardDB tblmultycard;
        private MultycardpurchaseDB tblmutlycardpurchase;
        private Client thisclient;
        private Client thisbuyer;
        public FrmMultycardpurchase(Client buyer, Client client)
        {
            InitializeComponent();
            tblmultycard = new MultycardDB();
            thismultycard = new Multycard();
            tblmutlycardpurchase = new MultycardpurchaseDB();
            thismultycard = tblmultycard.GetList().First(x => x.Cpel == client.Cpel);
            thisclient = new Client();
            thisbuyer = new Client();
            thisclient = client;
            thisbuyer = buyer;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsum.Text != "")
            {
                DialogResult r = MessageBox.Show("אישור קנייה", "האם לאשר קנייה זו", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    thismultycard.Amount += Convert.ToDouble(txtsum.Text);
                    tblmultycard.UpdateRow(thismultycard);
                    Multycardpurchase p = new Multycardpurchase();
                    p.Amount = Convert.ToDouble(txtsum.Text);
                    p.Codecard = thismultycard.Codecard;
                    p.Cpel = thisbuyer.Cpel;
                    p.Pdate = DateTime.Today;
                    p.Hour = DateTime.Now;
                    tblmutlycardpurchase.AddNew(p);
                    if (thisclient.Pincode == "")
                    {
                        MessageBox.Show(" המתנה תשלח לפלפון של הנמען בצרוף ההקדשה וכןישלח לנמען קןד שימוש לאתר זה ");
                    }
                    else
                    {
                        MessageBox.Show("  המתנה תשלח לפלפון של הנמען בצרוף ההקדשה  ");
                    }
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsum.Text = "";
            this.Hide();
        }
    }
}
