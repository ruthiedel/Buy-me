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
    public partial class FrmBusiness : Form
    {
        private Business thisbusiness;
        private BusinessDB tblbusiness;
        private SortDB tblsort=new SortDB();
        private SubjectDB tblsubject=new SubjectDB();
        private SumDB tblsum=new SumDB();
        private AreaDB tblarea=new AreaDB();
        private Registration thisregistration;
        private RegistrationDB tblregistration = new RegistrationDB();
        private bool flagr;
        private bool flagAdd;
        private bool flagUpdate;
        private int code;
        public FrmBusiness()
        {
            InitializeComponent();
            tblbusiness = new BusinessDB();
            flagAdd = false;
            flagUpdate = false;
            flagr = false;
            cmbarea.DataSource = tblarea.GetList();
            cmbarea.SelectedItem = null;
            cmbsort.DataSource = tblsort.GetList();
            cmbsort.SelectedItem = null;
            cmbsubject.DataSource = tblsubject.GetList();
            cmbsubject.SelectedItem = null;
            cmbsum.DataSource = tblsum.GetList();
            cmbsum.SelectedItem=null;
            txtsum.ReadOnly = true;
            textBox1.Visible = false;
            btnfrm.Visible = false;
            possible();
            dgb.DataSource = tblbusiness.GetList().Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
           
        }
        private void possible()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            dgr.Visible = false;
            gbr.Visible = false;
            btncreateregistration.Visible = false;
            btnregistration.Visible = false;
            txtcode.Text = "";
            txtname.Text = "";
            txtresidence.Text = "";
            cmbarea.Text = "";
            cmbsort.Text = "";
            cmbsubject.Text = "";
            cmbsum.Text = "";
            pictureBox1.Image = null;
        }
        public void notpossible()
        {
            flagUpdate = false;
            flagAdd = false;
            panel1.Visible = false;
            panel2.Visible = true;
            dgr.Visible = false;
            gbr.Visible = false;
            btnregistration.Visible = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //הפיכת בית עסק לבלתי פעיל
            if (dgb.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("אישור מחיקה", "האם למחוק בית עסק  זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dgb.SelectedRows[0].Cells[0].Value.ToString();
                    tblbusiness.DeleteStatus(Convert.ToInt32(st));
                }
            }
        }
        private bool CreateFields(Business b)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                b.Codebusiness = Convert.ToInt32(txtcode.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtcode, ex.Message);
                ok = false;
            }
            try
            {
                if (txtname.Text != "")
                    b.Bname = txtname.Text;
                else
                {
                    errorProvider1.SetError(txtname, "הקש שם בית עסק");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtname, ex.Message);
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
            try
            {
                if(cmbarea.SelectedItem!=null)
                b.Codearea = ((Area)cmbarea.SelectedItem).Codearea;
            else
                {
                    errorProvider1.SetError(cmbarea, "בחר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbarea, ex.Message);
                ok = false;
            }
            try
            {
                if(cmbsum.SelectedItem != null)
                   b.Codesum = ((Sum)cmbsum.SelectedItem).Codesum;
                else
                {
                    errorProvider1.SetError(cmbsum, "בחר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbsort, ex.Message);
                ok = false;
            }
            try
            {
                if(cmbsort.SelectedItem!=null)
                b.Codesort = ((Sort)cmbsort.SelectedItem).Codesort;
                else 
                {
                    errorProvider1.SetError(cmbsort, "בחר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbsort, ex.Message);
                ok = false;
            }
            try
            {
                if(cmbsubject.SelectedItem!=null)
                b.Codesubject = ((Subject)cmbsubject.SelectedItem).Codesubject;
                else
                {
                    errorProvider1.SetError(cmbsubject, "בחר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbsubject, ex.Message);
                ok = false;
            }
            if (textBox1.Text != "")
            {

               
                b.Picture = textBox1.Text;
            }
            else
            {
                errorProvider1.SetError(pictureBox1, "הוסף תמונה");
                ok = false;
            }
            b.status = (chb.Checked == true);
            return ok;

        }

        private void FrmBusiness_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {   //רענן טבלת הצפיה בכל רשומות הטבלה 
            dgb.DataSource = tblbusiness.GetList().Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            //הצגת הרשומה שנבבחרה בטבלה בתיבות הטקסט לצורך צפייה 
            if (dgb.SelectedRows.Count > 0)
            {
                string st = dgb.SelectedRows[0].Cells[0].Value.ToString();
                thisbusiness = tblbusiness.Find(Convert.ToInt32(st));
                Fill(thisbusiness);
            }
        }
        private void Fill(Business j)
        {
            //מילוי תיבות הטקסט בערכי העצם שנשלח כפרמטר 
            if (tblbusiness.Size() > 0)
            {
                txtcode.Text = j.Codebusiness.ToString();
                txtname.Text = j.Bname.ToString();
                txtresidence.Text = j.Residence;
                cmbsort.SelectedItem = tblsort.Find(j.Codesort).Teur;
                //cmbsort.Text = cmbsort.SelectedItem.ToString();
                chb.Checked = (j.status.Equals(true));
                cmbarea.SelectedItem = tblarea.GetList().Where(x => x.Codearea == j.Codearea).ToString();
                cmbsubject.SelectedItem = tblsubject.GetList().Where(x => x.Codesubject == j.Codesubject).ToString();
                cmbsum.SelectedItem = tblsum.GetList().Where(x => x.Codesum == j.Codesum).ToString();
                cmbsum.Text = j.ThisSum().Teur;
                cmbarea.Text = j.ThisArea().Teur;
                cmbsort.Text = j.ThisSort().Teur;
                cmbsubject.Text = j.ThisSubject().Teur;
                //cmbsum.Text = cmbsum.SelectedItem.ToString();
                //cmbarea.Text = cmbarea.SelectedItem.ToString();
                //cmbsubject.Text = cmbsubject.SelectedItem.ToString();

                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory();
                    int x = path.IndexOf("\\bin");
                    path = path.Substring(0, x) + j.Picture;
                    pictureBox1.Image = Image.FromFile(path);
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
            else
            {
                txtcode.Text = "";
                txtname.Text = "";
                txtresidence.Text = "";
                cmbarea.Text = null;
                cmbsort.Text = null;
                cmbsubject.Text = null;
                cmbsum.Text = null;
                chb.Checked = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //הוספת עצם חדש

            txtcode.Text ="";
            txtname.Text = "";
            txtresidence.Text = "";
            cmbarea.SelectedItem = "";
            cmbsort.SelectedItem ="";
            cmbsum.SelectedItem ="";
            cmbsubject.SelectedItem ="";
            chb.Checked = true;
            txtcode.Text = tblbusiness.GetNextKey().ToString();
            txtcode.ReadOnly = true;
            gbr.Visible = false;
            flagAdd = true;
            panel2.Visible = true;
            btnSave.Visible = false;
            btncreateregistration.Visible = true;
            btnfrm.Visible = true;
        }

        private void btnUdapter_Click(object sender, EventArgs e)
        {
            //עדכון הרשומה שניבחרה בטבלה- שפיכת נתוני העצם לתיבות הטקסט לצורך עדכון
            if (dgb.SelectedRows.Count > 0)
            {
                string st = dgb.SelectedRows[0].Cells[0].Value.ToString();
                thisbusiness = tblbusiness.Find(Convert.ToInt32(st));
                Fill(thisbusiness);
                flagAdd = false;
                flagUpdate = true;
                txtcode.ReadOnly = true;
                panel1.Visible = false;
                panel2.Visible = true;
                btnfrm.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                //יצירת עצם על פי הקלטים והןספתו כשורה חדשה בטבלה
            if (flagUpdate)
                if (CreateFields(thisbusiness))
                {
                    DialogResult r = MessageBox.Show("אישור עידכון", "האם לעדכן בית עסק זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblbusiness.UpdateRow(thisbusiness);
                        possible();
                    }
                }
            if (flagAdd)
            {
                Business b = new Business();
                if (this.tblbusiness.Find(Convert.ToInt32(txtcode.Text)) == null)
                {
                    if (CreateFields(b))
                    {
                        DialogResult r = MessageBox.Show("אישור הוספה", "האם להוסיף בית עסק זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblbusiness.AddNew(b);
                            tblregistration.AddNew(thisregistration);
                            possible();
                            dgb.DataSource = tblbusiness.GetList().Where(x => x.Codebusiness == b.Codebusiness).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
                        }
                    }
                }
                else
                    MessageBox.Show("בית עסק זה כבר נמצא במאגר");
        }
            btnfrm.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           possible();
            errorProvider1.Clear();
            btnfrm.Visible = false;
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            //חיפוש על פי קוד בית עסק
            dgb.DataSource = tblbusiness.GetList().Where(x => x.Codebusiness.ToString().StartsWith(txtcode.Text)).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            //חיפוש על פי שם בית עסק
            dgb.DataSource = tblbusiness.GetList().Where(x => x.Bname.StartsWith(txtname.Text)).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void cmbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //חיפוש על פי אזור נבחר
          dgb.DataSource=tblbusiness.GetList().Where(x=> x.ThisArea().Teur==((Area)cmbarea.SelectedItem).Teur).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void cmbsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //חיפוש על פי תחום נבחר
            dgb.DataSource = tblbusiness.GetList().Where(x => x.ThisSubject().Teur == ((Subject)cmbsubject.SelectedItem).Teur).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void cmbsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //חיפוש על פי קהל יעד נבחר 
            dgb.DataSource = tblbusiness.GetList().Where(x => x.ThisSort().Teur == ((Sort)cmbsort.SelectedItem).Teur).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname, עיר = x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void cmbsum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //חיפוש על פי סכום נבחר
            dgb.DataSource = tblbusiness.GetList().Where(x => x.ThisSum().Teur == ((Sum)cmbsum.SelectedItem).Teur).Select(x => new { קוד_בית_עסק = x.Codebusiness,עיר=x.Residence, שם = x.Bname, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void bcolculate_Click(object sender, EventArgs e)
        {
            if (txtyears.Text != "" && ValidateUtil.IsNum(txtyears.Text)&&Convert.ToInt32(txtyears.Text)>0)
            {
                int x = Convert.ToInt32(txtyears.Text);
                txtsum.Text = (x * 2000).ToString();
                errorProvider1.Clear();

            }
            else
                errorProvider1.SetError(txtyears, "הקש מספר שנים");
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtsum.Text != "")
            {
                if (flagAdd)
                {
                    Registration r = new Registration();
                    r.Codebusiness = Convert.ToInt32(txtcode.Text);
                    r.Fdate = DateTime.Today;
                    r.Ldate = DateTime.Today.AddYears(Convert.ToInt32(txtsum.Text) / 2000);
                    thisregistration = r;
                    panel2.Visible = true;
                    btnSave.Visible = true;
                    gbr.Visible = false;
                }
                if (flagr)
                {
                    Registration r = new Registration();
                    r.Codebusiness = code;
                    r.Fdate = DateTime.Today;
                    r.Ldate = DateTime.Today.AddYears(Convert.ToInt32(txtsum.Text) / 2000);
                    DialogResult re = MessageBox.Show("אישור הוספה", "האם להוסיף מנוי זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (re == DialogResult.Yes)
                    {
                        tblregistration.AddNew(r);
                        flagr = false;
                    }
                    gbr.Visible = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtyears, "מלא את פרטי המנוי");
            }
        }

        private void btncreateregistration_Click(object sender, EventArgs e)
        {
            Business b = new Business();
            if (CreateFields(b))
            {
                gbr.Visible = true;
                btncreateregistration.Visible = false;
            }

        }
        private bool SelectDg(DataGridView dg)
        {
            return (dg.SelectedRows.Count >= 1);
        }

        private void dgb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectDg(dgb))
            {
                dgr.DataSource = tblregistration.GetList().Where(x => x.Codebusiness == Convert.ToInt32(dgb.CurrentRow.Cells[0].Value)).Select(x => new { קוד_בית_עסק = x.Codebusiness, תאריך_התחלה = x.Fdate, תאריך_סיום = x.Ldate }).ToList();
                dgr.Visible = true;
               btnregistration.Visible = true;
            }
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            if (SelectDg(dgb))
            {
                var list = tblregistration.GetList().Where(x => x.Codebusiness == Convert.ToInt32(dgb.CurrentRow.Cells[0].Value)).Select(x => new { a = x.Codebusiness, b = x.Ldate }).ToList();
                DateTime d = list.Min(x => x.b);
                if (d < DateTime.Today)
                {
                    gbr.Visible = true;
                    flagr = true;
                    code = Convert.ToInt32(dgb.CurrentRow.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("אין אפשרות לעדכן מנוי כל עוד ישנו מנוי פעיל");
                }
            }
            else
            {
                MessageBox.Show("בחר ערך בחלונית בתי העסק");
            }
        }

        private void btnfrm_Click(object sender, EventArgs e)
        {
            FrmSelection f = new FrmSelection(this);
            f.Show();
          
        }
        public void miluycity()
        {
            tblarea = new AreaDB();
            cmbarea.DataSource = tblarea.GetList();
            cmbarea.SelectedItem = null;
        }
        public void miluysort()
        {
            tblsort = new SortDB();
            cmbsort.DataSource = tblsort.GetList();
            cmbsort.SelectedItem = null;
        }
        public void miluysubject()
        {
            tblsubject = new SubjectDB();
            cmbsubject.DataSource = tblsubject.GetList();
            cmbsubject.SelectedItem = null;
        }
        public void miluysum()
        {
            tblsum = new SumDB();
            cmbsum.DataSource = tblsum.GetList();
            cmbsum.SelectedItem = null;
        }
        private void txtresidence_TextChanged(object sender, EventArgs e)
        {
            dgb.DataSource = tblbusiness.GetList().Where(x => x.Residence.StartsWith(txtresidence.Text)).Select(x => new { קוד_בית_עסק = x.Codebusiness, שם = x.Bname,עיר=x.Residence, אזור = x.ThisArea().Teur, סכום_משוער = x.ThisSum().Teur, תחום = x.ThisSubject().Teur, קהל_יעד = x.ThisSort().Teur, פעיל = x.status }).ToList();
        }

        private void btnpicture_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg";
                openFileDialog1.ShowDialog();
                string r = openFileDialog1.FileName;

                string mikum;
                int x = r.IndexOf("\\pictures");
                int y = r.Length - x;
                mikum = r.Substring(x, y);
                pictureBox1.Image = Image.FromFile(r);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                textBox1.Text = mikum;
            }
            catch
            {
                MessageBox.Show(" pictures לא ניתן לפתוח קובץ זה עליך לבחור תמונה מתיקיה ");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void FrmBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    } 
}
