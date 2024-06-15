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
using System.Media;


namespace Buy_Me.Gui
{
    public partial class FrmClient : Form
    {
        private Client thisclient=new Client();
        private ClientDB tblclient;
        private SortDB tblsort = new SortDB();
        private CardDB tblcard = new CardDB();
        private SubjectDB tblsj = new SubjectDB();
        private BusinessDB tblbusiness ;
        private bool flagAdd;
        private bool flagUpdate;
        private bool delwish;
        private bool delsort;
        private bool cardshow;
        private bool multycardshow;
        private bool flagupdatewish;
        private bool flagupdatesort;
        private bool flagmail;
        private MailsDB tblmail;
        private ClientsubjectDB tblclientsubject = new ClientsubjectDB();
        private ClientwishDB tblclientwish = new ClientwishDB();
        private MultycardDB tblmultycard=new MultycardDB();
        public FrmClient()
        {
            InitializeComponent();
            delwish = false;
            flagmail = false;
            delsort = false;
            flagAdd = false;
            flagUpdate = false;
            flagupdatewish = false;
            flagupdatesort = false;
            multycardshow = false;
            tblmail = new MailsDB();
            tblbusiness = new BusinessDB();
            btnmail.Visible = false;
            btnmultycardshow.Visible = false;
            btncardshow.Visible = false;
            tblclient = new ClientDB();
            cardshow = false;
            cmsort.DataSource = tblsort.GetList();
            lstbusiness.DataSource = tblbusiness.GetList();
            lstsort.DataSource=tblsj.GetList();
            panel3.Visible = false;
            panel4.Visible = false;
          
            possible();
            dgclient.DataSource = tblclient.GetList().Select(x => new { טלפון = x.Cpel, ש = x.Fname+" " + x.Lname, מגורים = x.Residence, כתובת_מייל = x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {

        }
        private void possible()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panelsort.Visible = false;
            panelwish.Visible = false;
            panelchecking.Visible = false; 
            dgsort.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            txtcpel.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtresidence.Text = "";
            txtpincode.Text = "";
            txtemail.Text = "";
            cmsort.Text = "";
            cmsort.SelectedItem = null;
            dgcw.Visible = false; 
            delwish = false;
            delsort = false;

        }
        public void notpossible()
        {
            flagUpdate = false;
            flagAdd = false;
            panel1.Visible = false;
            panel2.Visible = true;
            panelsort.Visible = false;
            panelwish.Visible = false;
            panelchecking.Visible = false;
            dgcw.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dgsort.Visible = false;
            //cmsort.SelectedItem = null;
            delwish = false;
            delsort = false;


        }
        private bool CreateFields(Client b)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                b.Cpel = txtcpel.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtcpel, ex.Message);
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
                if(cmsort.SelectedItem!=null)
                b.Codesort = ((Sort)cmsort.SelectedItem).Codesort;
                else
                {
                    errorProvider1.SetError(cmsort, "בחר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmsort, ex.Message);
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
            if (flagAdd)
            {
                b.Pincode = tblclient.GetPinCode();
            }
            return ok;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           possible();
            errorProvider1.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgclient.DataSource = tblclient.GetList().Select(x => new { טלפון = x.Cpel, ש = x.Fname +" "+ x.Lname, מגורים = x.Residence,כתובת_מייל=x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            //הצגת הרשומה שנבבחרה בטבלה בתיבות הטקסט לצורך צפייה 
            if (dgclient.SelectedRows.Count > 0)
            {
                string st = dgclient.SelectedRows[0].Cells[0].Value.ToString();
                thisclient = tblclient.Find(st);
                Fill(thisclient);
            }
        }
        private void Fill(Client j)
        {
            //מילוי תיבות הטקסט בערכי העצם שנשלח כפרמטר 
            if (tblclient.Size() > 0)
            {
                txtcpel.Text = j.Cpel;
                txtfname.Text = j.Fname;
                //cmsort.SelectedItem = tblsort.Find(j.Codesort).Teur;
                cmsort.Text = j.ThisSort().Teur;
                txtresidence.Text = j.Residence;
                txtlname.Text = j.Lname;
                txtemail.Text = j.Email;
            }
            else
            {
                txtcpel.Text = "";
                txtfname.Text = "";
                txtlname.Text = "";
                txtresidence.Text ="";
                txtemail.Text = "";
                cmsort.Text = "";

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //הוספת עצם חדש
           
            txtcpel.Text = "";
            txtfname.Text = "";
            txtresidence.Text="";
            cmsort.SelectedItem ="";
            txtlname.Text = "";
            cmsort.SelectedItem = null;
            notpossible();
            flagAdd = true;
            multycardshow = false;
            cardshow = false;
        }

        private void txtcpel_TextChanged(object sender, EventArgs e)
        {
            dgclient.DataSource = tblclient.GetList().Where(x => x.Cpel.StartsWith( txtcpel.Text)).Select(x => new { טלפון = x.Cpel, שם = x.Fname +" " +x.Lname, מגורים = x.Residence, כתובת_מייל = x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {
            dgclient.DataSource = tblclient.GetList().Where(x => x.Lname.StartsWith( txtlname.Text)).Select(x => new { טלפון = x.Cpel, שם = x.Fname + " "+ x.Lname, מגורים = x.Residence, כתובת_מייל = x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {
            dgclient.DataSource = tblclient.GetList().Where(x => x.Fname.StartsWith(txtfname.Text)).Select(x => new { טלפון = x.Cpel, שם = x.Fname + " " + x.Lname, מגורים = x.Residence, כתובת_מייל = x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        

        private void cmsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgclient.DataSource = tblclient.GetList().Where(x => x.ThisSort().Teur == cmsort.Text).Select(x => new { טלפון = x.Cpel, שם = x.Fname+" " + x.Lname, מגורים = x.Residence, כתובת_מייל = x.Email, סיווג = x.ThisSort().Teur }).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                Client b = new Client();
                if (this.tblclient.Find(txtcpel.Text) == null)
                {
                    if (CreateFields(b))
                    {
                        DialogResult r = MessageBox.Show("אישור הוספה", "האם להוסיף לקוח זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblclient.AddNew(b);
                            Multycard m = new Multycard();
                            m.Cpel = txtcpel.Text; ;
                            m.Amount = 0;
                            m.Codecard = tblmultycard.GetNextKey();
                            tblmultycard.AddNew(m);
                            MessageBox.Show(":סיסמתך היא" + b.Pincode + "אנא זכור את הסיסמה לצורכי הזדהות");
                            possible();
                        }
                    }
                }
                
            }
           if( flagUpdate)
            {
                if (CreateFields(thisclient))
                {
                    DialogResult r = MessageBox.Show("אישור עידכון", "האם לעדכן לקוח זה ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblclient.UpdateRow(thisclient);
                        possible();
                    }
                }
            }
        }

        private void btnUdapter_Click(object sender, EventArgs e)
        {if (SelectDg(dgclient))
            {
                thisclient = tblclient.GetList().Find(x => x.Cpel.Equals(dgclient.CurrentRow.Cells[0].Value.ToString()));
                multycardshow = false;
                cardshow = false;
                flagUpdate = true;
                btnaddsort.Enabled = false;
                btnaddwish.Enabled = false;
                btnmail.Enabled = false;
                btncardshow.Enabled = false;
                btnmultycardshow.Enabled = false;
                btndelsort.Enabled = false;
                btndelwish.Enabled = false;
                panelchecking.Visible = true;
            }
        }
        private bool SelectDg(DataGridView dg)
        {
            return (dg.SelectedRows.Count >= 1);
        }


        private void btnfine_Click(object sender, EventArgs e)
        {
            if (txtpincode.Text != "")
            {
                if (cardshow)
                {
                    if (tblclient.GetList().Exists(x => x.Pincode == txtpincode.Text))
                    {
                        cardshow = false;
                        Client c = new Client();
                        c = tblclient.GetList().Find(x => x.Pincode == txtpincode.Text);
                        FrmCard f = new FrmCard(c);
                        f.Show();
                        btnaddsort.Enabled = true;
                        btnaddwish.Enabled = true;
                        btnmail.Enabled = true;
                        btncardshow.Enabled = true;
                        btnmultycardshow.Enabled = true;
                        btndelsort.Enabled = true;
                        btndelwish.Enabled = true;
                        btnUdapter.Enabled = true;
                        panelchecking.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("הסיסמה שהוקשה שגויה");
                    }
                }
                if (multycardshow)
                {
                    if (tblclient.GetList().Exists(x => x.Pincode == txtpincode.Text))
                    {
                        multycardshow = false;
                        Client c = new Client();
                        c = tblclient.GetList().Find(x => x.Pincode == txtpincode.Text);
                        FrmMultycard f = new FrmMultycard(c);
                        f.Show();
                        btnaddsort.Enabled = true;
                        btnaddwish.Enabled = true;
                        btnmail.Enabled = true;
                        btncardshow.Enabled = true;
                        btnmultycardshow.Enabled = true;
                        btndelsort.Enabled = true;
                        btndelwish.Enabled = true;
                        panelchecking.Visible = false;
                        btnUdapter.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("הסיסמה שהוקשה שגויה");
                    }
                }
                if (multycardshow == false && cardshow == false)
                {
                    if (thisclient.Pincode.Equals(txtpincode.Text))
                    {

                        flagAdd = false;
                        if (flagupdatesort)
                        {
                            panel4.Visible = true;
                            panelchecking.Visible = false;
                            btnaddsort.Enabled = true;
                            btnaddwish.Enabled = true;
                            btnmail.Enabled = true;
                            btncardshow.Enabled = true;
                            btnmultycardshow.Enabled = true;
                            btndelsort.Enabled = true;
                            btndelwish.Enabled = true;
                            btnUdapter.Enabled = true;
                            flagupdatesort = false;
                        }
                        if (flagupdatewish)
                        {
                            panel3.Visible = true;
                            panelchecking.Visible = false;
                            btnaddsort.Enabled = true;
                            btnaddwish.Enabled = true;
                            btnmail.Enabled = true;
                            btncardshow.Enabled = true;
                            btnmultycardshow.Enabled = true;
                            btndelsort.Enabled = true;
                            btndelwish.Enabled = true;
                            btnUdapter.Enabled = true;
                            flagupdatewish = false;
                        }
                        if (flagUpdate)
                        {
                            string st = dgclient.SelectedRows[0].Cells[0].Value.ToString();
                            thisclient = tblclient.Find(st);
                            Fill(thisclient);
                            thisclient = tblclient.GetList().Find(x => x.Cpel.Equals(txtcpel.Text));
                            notpossible();
                            btnaddsort.Enabled = true;
                            btnaddwish.Enabled = true;
                            btnmail.Enabled = true;
                            btncardshow.Enabled = true;
                            btnmultycardshow.Enabled = true;
                            btndelsort.Enabled = true;
                            btndelwish.Enabled = true;
                            btnUdapter.Enabled = true;
                            panelchecking.Visible = false;
                            flagUpdate = true;
                        }
                        if (delwish)
                        {
                            Clientwish c = new Clientwish();
                            c = tblclientwish.GetList().Find(x => x.Cpel == thisclient.Cpel);
                            tblclientwish.delelteRow(c.Codebusiness, c.Cpel);
                            delwish = false;
                            btnaddsort.Enabled = true;
                            btnaddwish.Enabled = true;
                            btnmail.Enabled = true;
                            btncardshow.Enabled = true;
                            btnmultycardshow.Enabled = true;
                            btndelsort.Enabled = true;
                            btndelwish.Enabled = true;
                            btnUdapter.Enabled = true;
                            panelchecking.Visible = false;
                            dgcw.DataSource = tblclientwish.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname +" " + x.ThisClient().Lname, בית_עסק_מבוקש = x.ThisBusiness().Bname }).ToList();


                        }
                        if (delsort)
                        {
                            Clientsubject s = new Clientsubject();
                            s = tblclientsubject.GetList().Find(x => x.Cpel == thisclient.Cpel);
                            tblclientsubject.delelteRow(s.Codesubject, s.Cpel);
                            delsort = false;
                            btnaddsort.Enabled = true;
                            btnaddwish.Enabled = true;
                            btnmail.Enabled = true;
                            btncardshow.Enabled = true;
                            btnmultycardshow.Enabled = true;
                            btndelsort.Enabled = true;
                            btndelwish.Enabled = true;
                            btnUdapter.Enabled = true;
                            panelchecking.Visible = false;
                            dgsort.DataSource = tblclientsubject.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname+" " + x.ThisClient().Lname, תחום_מבוקש = x.ThisSubject().Teur }).ToList();
                        }
                        if (flagmail)
                        {

                            FrmMails f = new FrmMails(thisclient);
                            f.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("הסיסמה שהוקשה שגויה");
                        SoundPlayer s = new SoundPlayer();
                        s.Play();
                    }
                }

            
            }
            else
            {
                MessageBox.Show("לא הוקשה סיסמה");
                SoundPlayer s = new SoundPlayer();
                s.Play();
            }
            txtpincode.Text = "";
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectDg(dgclient))
            {
                thisclient = tblclient.GetList().Find(x => x.Cpel.Equals(dgclient.CurrentRow.Cells[0].Value.ToString()));
                //dgmultycard.DataSource = tblmultycard.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { קוד_כרטיס = x.Codecard, שם_לקוח = x.ThisClient().Fname + x.ThisClient().Lname, סכום_נוכחי = x.Amount }).ToList();
                //dgcard.DataSource = tblcard.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { קוד_כרטיס = x.Codecard, שם_בית_עסק = x.Codebusiness, סכום_התחלתי = x.Famount, סכום_נוכחי = x.Namount, שם_לקוח = x.ThisClient().Fname + x.ThisClient().Lname }).ToList();
                dgcw.DataSource = tblclientwish.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname + " "  + x.ThisClient().Lname, בית_עסק_מבוקש = x.ThisBusiness().Bname }).ToList();
                dgsort.DataSource=tblclientsubject.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname+" " + x.ThisClient().Lname, תחום_מבוקש = x.ThisSubject().Teur }).ToList();
                dgsort.Visible=true;
                btncardshow.Visible = true;
                btnmultycardshow.Visible = true;
                btnmail.Visible = true;
                panel5.Visible = true;
                dgcw.Visible = true;
                panelsort.Visible = true;
                panelwish.Visible = true;
            }
        }

        private void btnaddwish_Click(object sender, EventArgs e)
        {
            //thisclient= tblclient.GetList().Find(x => x.Cpel.Equals(dgclient.CurrentRow.Cells[0].Value.ToString()));
            flagupdatewish = true;
            multycardshow = false;
            cardshow = false;
            btnaddsort.Enabled = false;
            btnaddwish.Enabled = false;
            btnmail.Enabled = false;
            btncardshow.Enabled = false;
            btnmultycardshow.Enabled = false;
            btndelsort.Enabled = false;
            btnUdapter.Enabled = false;
            btndelwish.Enabled = false;
            panelchecking.Visible = true;
        }

        private void btndelwish_Click(object sender, EventArgs e)
        {
            if (SelectDg(dgcw))
            {
                delwish = true;
                multycardshow = false;
                cardshow = false;
                btnaddsort.Enabled = false;
                btnaddwish.Enabled = false;
                btnUdapter.Enabled = false;
                btnmail.Enabled = false;
                btncardshow.Enabled = false;
                btnmultycardshow.Enabled = false;
                btndelsort.Enabled = false;
                btnUdapter.Enabled = false;
                btndelwish.Enabled = false;
                panelchecking.Visible = true;
            }
        }

        private void btncancelpanel_Click(object sender, EventArgs e)
        {
            flagupdatewish = false;
            flagupdatesort = false;
            flagUpdate = false;
            flagmail = false;
            multycardshow = false;
            cardshow = false;
            txtpincode.Text = "";
            btnaddsort.Enabled = true;
            btnaddwish.Enabled = true;
            btnmail.Enabled = true;
            btncardshow.Enabled = true;
            btnUdapter.Enabled = true;
            btnmultycardshow.Enabled = true;
            btndelsort.Enabled = true;
            btndelwish.Enabled = true;
            panelchecking.Visible = false;
        }

        private void btndelsort_Click(object sender, EventArgs e)
        {
            if (SelectDg(dgsort))
            {
                delsort = true;
                multycardshow = false;
                cardshow = false;
                btnaddsort.Enabled = false;
                btnaddwish.Enabled = false;
                btnmail.Enabled = false;
                btnUdapter.Enabled = false;
                btncardshow.Enabled = false;
                btnmultycardshow.Enabled = false;
                btndelsort.Enabled = false;
                btndelwish.Enabled = false;
                panelchecking.Visible = true;
            }
        }

        private void btnok1_Click(object sender, EventArgs e)                                               
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       if (lstbusiness.SelectedItem!= null)
            {
                Business b = tblbusiness.GetList().Find(x => x.Bname == lstbusiness.SelectedItem.ToString());
                Clientwish cw = new Clientwish();
                cw.Cpel = thisclient.Cpel;
                cw.Codebusiness = b.Codebusiness;
                if (tblclientwish.GetList().Find(x => x.Codebusiness == cw.Codebusiness && x.Cpel == cw.Cpel) == null)
                    tblclientwish.AddNew(cw);
                else
                {
                    MessageBox.Show("הרצון הנבחר כבר קיים במאגר הרצונות של לקוח זה");
                }
                dgcw.DataSource = tblclientwish.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname+" " + x.ThisClient().Lname, בית_עסק_מבוקש = x.ThisBusiness().Bname }).ToList();
                lstbusiness.ClearSelected();
            }
        }

        private void lblpincode_Click(object sender, EventArgs e)
        {

        }

        private void btnaddsort_Click(object sender, EventArgs e)
        {
            thisclient = tblclient.GetList().Find(x => x.Cpel.Equals(dgclient.CurrentRow.Cells[0].Value.ToString()));
            flagupdatesort = true;
            multycardshow = false;
            btnaddsort.Enabled = false;
            btnaddwish.Enabled = false;
            btnmail.Enabled = false;
            btncardshow.Enabled = false;
            btnmultycardshow.Enabled = false;
            btndelsort.Enabled = false;
            btndelwish.Enabled = false;
            cardshow = false;
            panelchecking.Visible = true;
        }

        private void btnok2_Click(object sender, EventArgs e)
        {
            if (lstsort.SelectedItem != null)
            {
                dgsort.DataSource = tblclientsubject.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname + " "+ x.ThisClient().Lname, תחום_מבוקש = x.ThisSubject().Teur }).ToList();
                Subject s = tblsj.GetList().Find(x => x.Teur == lstsort.SelectedItem.ToString());
                Clientsubject cs = new Clientsubject();
                cs.Codesubject =s.Codesubject;
                cs.Cpel = thisclient.Cpel;
                if(tblclientsubject.GetList().Find(x=> x.Codesubject==cs.Codesubject&&x.Cpel==cs.Cpel)==null)
                tblclientsubject.AddNew(cs);
                else
                {
                    MessageBox.Show("התחום הנבחר כבר קיים במאגר התחומים של לקוח זה");
                }
                dgsort.DataSource = tblclientsubject.GetList().Where(x => x.Cpel.Equals(Convert.ToString(dgclient.CurrentRow.Cells[0].Value))).Select(x => new { שם_לקוח = x.ThisClient().Fname+" " + x.ThisClient().Lname, תחום_מבוקש = x.ThisSubject().Teur }).ToList();
                lstsort.ClearSelected();
            }

        }

        private void btnforget_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" נשלחה תזכורת סיסמה ללקוח ");
            Mails m = new Mails();
            m.Cpel = thisclient.Cpel;
            m.Codemailkind = 2;
            m.Mdate = DateTime.Today;
            m.Mhour = DateTime.Now;
            m.Content = ":סיסמתך היא" + Convert.ToString(thisclient.Pincode);
            tblmail.AddNew(m);
        }

        private void btncardshow_Click(object sender, EventArgs e)
        {
            cardshow = true;
            multycardshow = false;
            panelchecking.Show();
            btnaddsort.Enabled = false;
            btnaddwish.Enabled = false;
            btnmail.Enabled = false;
            btncardshow.Enabled = false;
            btnUdapter.Enabled = false;
            btnmultycardshow.Enabled = false;
            btndelsort.Enabled = false;
            btndelwish.Enabled = false;
        }

        private void btnmultycardshow_Click(object sender, EventArgs e)
        {
            multycardshow = true;
            cardshow = false;
            panelchecking.Show();
            btnaddsort.Enabled = false;
            btnaddwish.Enabled = false;
            btnmail.Enabled = false;
            btncardshow.Enabled = false;
            btnUdapter.Enabled = false;
            btnmultycardshow.Enabled = false;
            btndelsort.Enabled = false;
            btndelwish.Enabled = false;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void btndone2_Click(object sender, EventArgs e)
        {
            possible();
        }

        private void btndone1_Click(object sender, EventArgs e)
        {
            possible();
        }

        private void btnmail_Click(object sender, EventArgs e)
        {
            panelchecking.Show();
            btnaddsort.Enabled = false;
            btnaddwish.Enabled = false;
            btnmail.Enabled = false;
            btncardshow.Enabled = false;
            btnmultycardshow.Enabled = false;
            btndelsort.Enabled = false;
            btndelwish.Enabled = false;
            btnUdapter.Enabled = false;
            flagmail = true;
        }

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void panelchecking_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
