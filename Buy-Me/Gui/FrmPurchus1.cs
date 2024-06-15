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
using Buy_Me.Gui;




namespace Buy_Me.Gui
{
    public partial class FrmPurchus1 : Form
    {
        private ClientDB tblclient ;
        private Client thisclient ;
        private Client thisbuyer ;
        private SortDB tblsort ;
        private MultycardDB tblmultycard;
        private bool flagbuyer;
        private bool flagclient;
        public FrmPurchus1()
        {
            InitializeComponent();
            panel2.Visible = false;
            flagbuyer = false;
            flagclient = false;
            panel3.Visible = false;
            tblmultycard = new MultycardDB();
            tblclient = new ClientDB();
            tblsort = new SortDB();
            thisbuyer = new Client();
            thisclient = new Client();
            cmbsort.DataSource = tblsort.GetList();
            txtbuyerpel.Select();
            cmbsort.SelectedItem = null;

        }

        public void Possible()
        {
            txtcpel.Text = "";
            txtbuyerpel.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtresidence.Text = "";
            txtemail.Text = "";
            cmbsort.SelectedItem = null;
          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPurchus1_Load(object sender, EventArgs e)
        {

        }

        private void btnok1_Click(object sender, EventArgs e)
        {
            
            if (ValidateUtil.IsCellPhone(txtbuyerpel.Text))
            {  
                if (tblclient.GetList().Find(x => x.Cpel == txtbuyerpel.Text)!=null)
                {
                    thisbuyer = tblclient.GetList().Find(x => x.Cpel == txtbuyerpel.Text);
                    panel2.Visible = true;
                    panel1.Visible = false;
                    txtcpel.Select();
                }
                else
                {
                    panel1.Visible = false;
                    panel3.Visible = true;
                    flagbuyer = true;
                }
            }
            else
            {
                errorProvider1.SetError(txtbuyerpel,"הקש מספר תקין" );
                
            }
        }
        private bool CreateFields(Client b,Multycard m)
        {
            bool ok = true;
            errorProvider1.Clear();
            if (flagclient)
            {
                try
                {
                    b.Cpel = txtcpel.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtcpel, ex.Message);
                    ok = false;
                }
            }
            if (flagbuyer)
            {
                try
                {
                    b.Cpel = txtbuyerpel.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtbuyerpel, ex.Message);
                    ok = false;
                }
            }
            try
            {
                b.Fname = txtfname.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtfname, ex.Message);
                ok = false;
            }
            try
            {
                b.Lname = txtlname.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtlname, ex.Message);
                ok = false;
            }
            try
            {
                b.Email = txtemail.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtemail, ex.Message);
                ok = false;
            }
            try
            {
                b.Codesort = ((Sort)cmbsort.SelectedItem).Codesort;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbsort, ex.Message);
                ok = false;
            }
            try
            {
                b.Residence = txtresidence.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtresidence, ex.Message);
                ok = false;
            }
            
           
                b.Pincode = tblclient.GetPinCode();
            
            
           
            return ok;

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (flagbuyer)
            {
                Multycard m = new Multycard();
                Client c = new Client();
                if (CreateFields(c,m))
                {
                    DialogResult r = MessageBox.Show("אישור הוספה", "האם להוסיף לקוח", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        m.Amount = 0;
                        m.Codecard = tblmultycard.GetNextKey();
                        m.Cpel = txtbuyerpel.Text ;
                        tblclient.AddNew(c);
                        tblmultycard.AddNew(m);
                        MessageBox.Show("אנא זכור סיסמתך לאצרכי הזדהות " + c.Pincode + " :סיסמתך היא");
                        flagbuyer = false;
                        thisbuyer = tblclient.GetList().Find(x => x.Cpel == c.Cpel);
                        panel3.Visible = false;
                        Possible();
                        panel2.Visible = true;
                    }

                }
            }
            if (flagclient)
            {
                Multycard m = new Multycard();
                Client c = new Client();
                if (CreateFields(c,m))
                {
                    DialogResult r = MessageBox.Show("אישור הוספה", "האם להוסיף לקוח", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        m.Cpel = txtcpel.Text; ;
                        m.Amount = 0;
                        m.Codecard = tblmultycard.GetNextKey();
                    
                        tblclient.AddNew(c);
                       
                        tblmultycard.AddNew(m);
                        flagclient = false;
                        thisclient= tblclient.GetList().Find(x => x.Cpel == c.Cpel);
                        panel3.Visible = false;
                        Possible();
                        FrmPurchase2 f = new FrmPurchase2(thisbuyer, thisclient);
                        f.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (flagbuyer)
            {
                panel1.Visible = true;
                panel3.Visible = false;
                flagbuyer = false;
                Possible();
            }
            if (flagclient)
            {
                panel2.Visible = true;
                panel3.Visible = false;
                flagclient = false;
                Possible();
            }
        }

        private void btnok2_Click(object sender, EventArgs e)
        {
            if (ValidateUtil.IsCellPhone(txtcpel.Text))
            {
                if (tblclient.GetList().Find(x => x.Cpel == txtcpel.Text) != null)
                {
                    thisclient = tblclient.GetList().Find(x => x.Cpel == txtcpel.Text);
                    FrmPurchase2 f = new FrmPurchase2(thisbuyer, thisclient);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    panel2.Visible = false;
                    panel3.Visible = true;
                    flagclient = true;
                }
            }
            else
            {
                errorProvider1.SetError(txtcpel, "הקש מספר תקין");

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void FrmPurchus1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
}
