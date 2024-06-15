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
    public partial class FrmPurchase2 : Form
    {
        private BusinessDB tblbusiness;
        private Business business;
        private CardDB tblcard;
        private Cardpurchase cardpurchase;
        private Card card;
        private CardpurchaseDB tblcardpurchase;
        private List<Business> lst = new List<Business>();
        private List<Business> lst2 = new List<Business>();
        private List<Business> lstkategory = new List<Business>();
        private AreaDB tblarea;
        private SortDB tblsort;
        private SubjectDB tblsubject;
        private ClientwishDB tblclientwish;
        private SumDB tblsum;
        private ClientDB tblclient;
        private Client thisclien;
        private Client thisbuyer;
        private Panel[] panel;
        private PictureBox[] p;
        private Label[] lbl;
        private Label[] lbl2;
        private int count;
        private int kodb = 0;
        private int count2;
        private ClientsubjectDB tblclientsubject;
        public FrmPurchase2(Client buyer, Client client)
        {
            InitializeComponent();
            tblbusiness = new BusinessDB();
            business = new Business();
            card = new Card();
            tblclientwish = new ClientwishDB();
            thisclien = new Client();
            thisclien = client;
            cardpurchase = new Cardpurchase();
            tblcard = new CardDB();
            tblarea = new AreaDB();
            tblsort = new SortDB();
            tblsubject = new SubjectDB();
            tblclient = new ClientDB();
            tblsum = new SumDB();
            tblcardpurchase = new CardpurchaseDB();
            thisbuyer = new Client();
            thisbuyer = buyer;
            tblclientsubject = new ClientsubjectDB();
            panel2.Visible = false;
            cmbarea.DataSource = tblarea.GetList();
            cmbarea.SelectedItem = null;
            cmbsort.DataSource = tblsort.GetList();
            cmbsort.SelectedItem = null;
            cmbsubject.DataSource = tblsubject.GetList();
            cmbsubject.SelectedItem = null;
            cmbsum.DataSource = tblsum.GetList();
            cmbsum.SelectedItem = null;
            panel = new Panel[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            p = new PictureBox[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            lbl = new Label[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            lbl2 = new Label[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            button1.Visible = false;
            button2.Visible = false;
            count = 1;
            count2 = 1;
            Pour();
        }
        public void Pour()
        {
            int f = 39;
            int r = 46;
            panel1.Controls.Add(panel2);

            for (int i = 1; i < p.Length; i++)
            {
                business = tblbusiness.GetList().Find(x => x.Codebusiness == i);
                if (business != null && business.status)
                {
                    p[count] = new PictureBox();
                    try
                    {
                        string path = System.IO.Directory.GetCurrentDirectory();
                        int x = path.IndexOf("\\bin");
                        path = path.Substring(0, x) + business.Picture;
                        p[count].Image = Image.FromFile(path);
                    }
                    catch
                    {
                    }
                    p[count].Location = new System.Drawing.Point(3, 3);
                    p[count].Name = "pictureBox1";
                    p[count].Size = new System.Drawing.Size(139, 130);
                    p[count].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    p[count].TabIndex = 1;
                    p[count].TabStop = false;
                    p[count].Tag = business.Codebusiness;
                    p[count].Click += new System.EventHandler(button2_Click);
                    //Controls.Add(p[count]);

                    lbl[count] = new Label();
                    lbl[count].AutoSize = true;
                    lbl[count].Location = new System.Drawing.Point(19, 136);
                    lbl[count].Name = "label1";
                    lbl[count].Size = new System.Drawing.Size(125, 24);
                    lbl[count].TabIndex = 1;
                    lbl[count].TabStop = false;
                    lbl[count].Text = business.Bname.ToString();
                    lbl[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl[count]);

                    lbl2[count] = new Label();
                    lbl2[count].AutoSize = true;
                    lbl2[count].Location = new System.Drawing.Point(45, 166);
                    lbl2[count].Name = "label2";
                    lbl2[count].Size = new System.Drawing.Size(125, 24);
                    lbl2[count].TabIndex = 1;
                    lbl2[count].TabStop = false;
                    lbl2[count].Text = "₪ " + business.ThisSum().ToString();
                    lbl2[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl2[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl2[count]);

                    panel[count] = new Panel();
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl[count]);
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl2[count]);
                    panel[count].Location = new System.Drawing.Point(f, r);
                    panel[count].Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                    panel[count].Name = "panel";
                    panel[count].Size = new System.Drawing.Size(145, 199);
                    panel[count].Tag = business.Codebusiness;
                    panel[count].TabIndex = 10;
                    panel[count].BackColor = System.Drawing.Color.White;
                    panel[count].Click += new System.EventHandler(button1_Click);
                    Controls.Add(panel[count]);

                    panel1.Controls.Add(panel[count]);
                    f = f + 213;

                    if (count2 >= 4)
                    {

                        count2 = 0;
                        f = 39;
                        r = r + 247;

                    }
                    count2++;
                   
                }

            }
            count = 1;
            count2 = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void FrmPurchase2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnwish_Click(object sender, EventArgs e)
        {
            lstkategory = new List<Business>();
            panel1.Controls.Clear();
            for (int i = 1; i < tblbusiness.GetList().Count+1; i++)
            {
                Clientwish c = new Clientwish();
                Business b = new Business();
                c = (Clientwish)tblclientwish.GetList().Find(x => x.Cpel == thisclien.Cpel && x.Codebusiness == i);//לא מתמלא c
                if (c != null)
                {
                    b = tblbusiness.Find(i);
                    lstkategory.Add(b);
                    count2 = 1;
                    count = 1;
                }
            }
            panel = new Panel[lstkategory.Count + 1];
            p = new PictureBox[lstkategory.Count + 1];
            lbl = new Label[lstkategory.Count + 1];
            lbl2 = new Label[lstkategory.Count + 1];
           
            Pourkategory(lstkategory);
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            List<Subject> lsts = new List<Subject>();
            lsts = tblclientsubject.GetList().Where(x => x.Cpel == thisclien.Cpel).Select(x => new Subject { Codesubject = x.Codesubject, Teur = x.ThisSubject().Teur }).ToList();
            lstkategory = new List<Business>();
            //panel1.Controls.Clear();
            //panel = new Panel[lsts.Count() + 1];
            //p = new PictureBox[lsts.Count() + 1];
            //lbl = new Label[lsts.Count() + 1];
            //lbl2 = new Label[lsts.Count() + 1];
            Subject c = new Subject();
            for (int j = 0; j < lsts.Count(); j++)
            {
                c = lsts.ElementAt(j);

                for (int i = 1; i < tblbusiness.GetList().Count+1; i++)
                {

                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.Codesubject == c.Codesubject)
                    {

                        lstkategory.Add(b);
                        count2 = 1;
                        count = 1;
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2 = new Label[lstkategory.Count + 1];

            }
            Pourkategory(lstkategory);
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (dgcard.SelectedRows.Count >= 1)
            {
                business = lst.Find(x => x.Codebusiness == Convert.ToInt32(dgcard.CurrentRow.Cells[0].Value));
                lst.Remove(business);
                dgcard.DataSource = lst.Select(x => new { קוד_בית_עסק = x.Codebusiness, סכום = x.Codesum, בית_עסק = x.Bname, סניפים = x.Residence }).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            Panel g = (Panel)sender;
            kodb = Convert.ToInt32(g.Tag);
            business = tblbusiness.Find(kodb);
            string path = System.IO.Directory.GetCurrentDirectory();
            int x = path.IndexOf("\\bin");
            path = path.Substring(0, x) + business.Picture;
            pictureBox2.Image = Image.FromFile(path);
            lblname.Text = business.Bname;
            lblsniph.Text = business.Residence;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            PictureBox g = (PictureBox)sender;
            kodb = Convert.ToInt32(g.Tag);
            business = tblbusiness.Find(kodb);
            string path = System.IO.Directory.GetCurrentDirectory();
            int x = path.IndexOf("\\bin");
            path = path.Substring(0, x) + business.Picture;
            pictureBox2.Image = Image.FromFile(path);
            lblname.Text = business.Bname;
            lblsniph.Text = business.Residence;
            txtsum.Text = business.ThisSum().Teur;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
           
            if (txtsum.Text != "")
            {
               
                if (Convert.ToInt32(txtsum.Text) >= Convert.ToInt32(business.ThisSum().Teur))
                {
                    business.Codesum = Convert.ToInt32(txtsum.Text);
                    lst.Add(business);
                    dgcard.DataSource = lst.Select(x => new { קוד_בית_עסק = x.Codebusiness, סכום = x.Codesum, בית_עסק = x.Bname, סניפים = x.Residence }).ToList();
                    panel2.Visible = false;
                    txtsum.Text = "";
                }
                else
                {
                    DialogResult r = MessageBox.Show("אישור פתיחה", "?האם תרצה לפתוח כרטיס שיסגר במידה ולקוח נוסף יוסיף את הסכום הנדרש להשלמת הסכום המנימלי לביתעסק זה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        business.Codesum = Convert.ToInt32(txtsum.Text);
                        lst2.Add(business);
                        dgopencard.DataSource = lst2.Select(x => new {  קוד_בית_עסק = x.Codebusiness, סכום = x.Codesum, בית_עסק = x.Bname, סניפים = x.Residence }).ToList();
                        panel2.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא הקש את הסכום בו תרצה לרכוש את הכרטיס");
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            business = new Business();
            panel2.Visible = false;
            pictureBox2.Image = null;
            lblname.Text = "";
            lblsniph.Text = "";
            txtsum.Text = "";
        }

        private void cmbsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstkategory = new List<Business>();
            panel1.Controls.Clear();
            if (cmbsubject.SelectedItem != null)
            {
                String s = cmbsubject.SelectedItem.ToString();

                for (int i = 1; i < tblbusiness.GetList().Count+1; i++)
                {
                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.ThisSubject().Teur == s)
                    {
                        lstkategory.Add(b);
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2= new Label[lstkategory.Count + 1];
                count2 = 1;
                count = 1;
            }
            if (lstkategory.Count > 0)
            {
                Pourkategory(lstkategory);
            }
        }
        private void Pourkategory(List<Business> lstk)
        {
          
            int f = 39;
            int r = 46;
            panel1.Controls.Add(panel2);
            for (int i = 0; i < lstk.Count(); i++)
            {
                business = lstk.ElementAt(i);
                if (business != null && business.status)
                {
                    p[count] = new PictureBox();
                    try
                    {
                        string path = System.IO.Directory.GetCurrentDirectory();
                        int x = path.IndexOf("\\bin");
                        path = path.Substring(0, x) + business.Picture;
                        p[count].Image = Image.FromFile(path);
                    }
                    catch
                    {
                    }
                    p[count].Location = new System.Drawing.Point(3, 3);
                    p[count].Name = "pictureBox1";
                    p[count].Size = new System.Drawing.Size(139, 130);
                    p[count].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    p[count].TabIndex = 1;
                    p[count].TabStop = false;
                    p[count].Tag = business.Codebusiness;
                    p[count].Click += new System.EventHandler(button2_Click);
                    //Controls.Add(p[count]);

                    lbl[count] = new Label();
                    lbl[count].AutoSize = true;
                    lbl[count].Location = new System.Drawing.Point(19, 136);
                    lbl[count].Name = "label1";
                    lbl[count].Size = new System.Drawing.Size(125, 24);
                    lbl[count].TabIndex = 1;
                    lbl[count].TabStop = false;
                    lbl[count].Text = business.Bname.ToString();
                    lbl[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl[count]);

                    lbl2[count] = new Label();
                    lbl2[count].AutoSize = true;
                    lbl2[count].Location = new System.Drawing.Point(45, 166);
                    lbl2[count].Name = "label2";
                    lbl2[count].Size = new System.Drawing.Size(125, 24);
                    lbl2[count].TabIndex = 1;
                    lbl2[count].TabStop = false;
                    lbl2[count].Text = "₪ " + business.ThisSum().ToString();
                    lbl2[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl2[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl2[count]);

                    panel[count] = new Panel();
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl[count]);
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl2[count]);
                    panel[count].Location = new System.Drawing.Point(f, r);
                    panel[count].Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                    panel[count].Name = "panel";
                    panel[count].Size = new System.Drawing.Size(145, 199);
                    panel[count].Tag = business.Codebusiness;
                    panel[count].TabIndex = 10;
                    panel[count].BackColor = System.Drawing.Color.White;
                    panel[count].Click += new System.EventHandler(button1_Click);
                    Controls.Add(panel[count]);

                    panel1.Controls.Add(panel[count]);
                    f = f + 213;
                    ;

                    if (count2 >= 4)
                    {

                        count2 = 0;
                        f = 39;
                        r = r + 247;

                    }
                    count2++;
                    count++;
                }

            }

            business = new Business();
            lstkategory = new List<Business>();
        }

        private void cmbsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstkategory = new List<Business>();
            panel1.Controls.Clear();
            if (cmbsort.SelectedItem != null)
            {
                String s = cmbsort.SelectedItem.ToString();

                for (int i = 1; i < tblbusiness.GetList().Count; i++)
                {
                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.ThisSort().Teur == s)
                    {
                        lstkategory.Add(b);
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2 = new Label[lstkategory.Count + 1];
                count2 = 1;
                count = 1;
            }
            if (lstkategory.Count > 0)
            {
                Pourkategory(lstkategory);
            }
        }

        private void btnmultycard_Click(object sender, EventArgs e)
        {
            FrmMultycardpurchase f = new FrmMultycardpurchase(thisbuyer, thisclien);
            f.Show();
        }

        private void btndone_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("אישור קנייה", "האם לאשר קנייה זו", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                for (int i = 0; i < lst.Count(); i++)
                {
                    Card c = new Card();
                    c.Cpel = thisclien.Cpel;
                    c.Codebusiness = lst.ElementAt(i).Codebusiness;
                    c.Codecard = tblcard.GetNextKey();
                    c.Namount = lst.ElementAt(i).Codesum;
                    c.Famount = lst.ElementAt(i).Codesum;
                    c.Status = true;
                    tblcard.AddNew(c);
                    Cardpurchase cp = new Cardpurchase();
                    cp.Cpel = thisbuyer.Cpel;
                    cp.Codecard = c.Codecard;
                    cp.Amount = lst.ElementAt(i).Codesum;
                    tblcardpurchase.AddNew(cp);
                    if (thisclien.Pincode == "")
                    {
                        MessageBox.Show(" המתנה תשלח לפלפון של הנמען בצרוף ההקדשה וכןישלח לנמען קןד שימוש לאתר זה");
                    }
                    else
                    {
                        MessageBox.Show("  המתנה תשלח לפלפון של הנמען בצרוף ההקדשה  ");
                    }
                }
                FrmPurchus1 f = new FrmPurchus1();
                f.Show();
                this.Hide();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmPurchus1 f = new FrmPurchus1();
            f.Show();
            this.Hide();
        }

        private void cmbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstkategory = new List<Business>();
            panel1.Controls.Clear();
            if (cmbarea.SelectedItem != null)
            {
                String s = cmbarea.SelectedItem.ToString();

                for (int i = 1; i < tblbusiness.GetList().Count+1; i++)
                {
                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.ThisArea().Teur == s)
                    {
                        lstkategory.Add(b);
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2 = new Label[lstkategory.Count + 1];
                count2 = 1;
                count = 1;
            }
            if (lstkategory.Count > 0)
            {
                Pourkategory(lstkategory);
            }
        }

        private void cmbsum_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstkategory = new List<Business>();
            panel1.Controls.Clear();
            if (cmbsum.SelectedItem != null)
            {
                String s = cmbsum.SelectedItem.ToString();

                for (int i = 1; i < tblbusiness.GetList().Count+1; i++)
                {
                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.ThisSum().Teur == s)
                    {
                        lstkategory.Add(b);
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2 = new Label[lstkategory.Count + 1];
                count2 = 1;
                count = 1;
            }
            if (lstkategory.Count > 0)
            {
                Pourkategory(lstkategory);
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            panel = new Panel[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            p = new PictureBox[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            lbl = new Label[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            lbl2 = new Label[tblbusiness.GetList().Where(x => x.status == true).Count() + 1];
            button1.Visible = false;
            button2.Visible = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(panel2);
            count2 = 1;
            count = 1;
            Pour();
        }

        private void btnopencardone_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("אישור קנייה", "האם לאשר קנייה זו", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                for (int i = 0; i < lst2.Count(); i++)
                {
                    Card c = new Card();
                    c.Cpel = thisclien.Cpel;
                    c.Codebusiness = lst2.ElementAt(i).Codebusiness;
                    c.Codecard = tblcard.GetNextKey();
                    c.Namount = lst2.ElementAt(i).Codesum;
                    c.Famount = lst2.ElementAt(i).Codesum;
                    c.Status = true;
                    tblcard.AddNew(c);
                    Cardpurchase cp = new Cardpurchase();
                    cp.Cpel = thisbuyer.Cpel;
                    cp.Codecard = c.Codecard;
                    cp.Amount = lst2.ElementAt(i).Codesum;
                    tblcardpurchase.AddNew(cp);
                    if (thisclien.Pincode == "")
                    {
                        MessageBox.Show(" המתנה תשלח לפלפון של הנמען בצרוף ההקדשה לאחר שיסגר הכרטיס וכןישלח לנמען קןד שימוש לאתר זה");
                    }
                    else
                    {
                        MessageBox.Show(" לאחר שיסגר הכרטיס המתנה תשלח לפלפון של הנמען בצרוף ההקדשה  ");
                    }
                }
            }
        }

        private void btndelopencard_Click(object sender, EventArgs e)
        {
            if (dgopencard.SelectedRows.Count >= 1)
            {  {
                    business = lst2.Find(x => x.Codebusiness == Convert.ToInt32(dgopencard.CurrentRow.Cells[0].Value));
                    lst2.Remove(business);
                    dgcard.DataSource = lst2.Select(x => new { קוד_בית_עסק = x.Codebusiness, סכום = x.Codesum, בית_עסק = x.Bname, סניפים = x.Residence }).ToList();
                }
               
            }
        }

        private void btnaddopencard_Click(object sender, EventArgs e)
        {
            if (dgopencard.SelectedRows.Count >= 1)
            {
                if (tblcard.Find(Convert.ToInt32(dgopencard.CurrentRow.Cells[0].Value)) == null)
                {
                    business = tblbusiness.Find(Convert.ToInt32(dgopencard.CurrentRow.Cells[1].Value));
                    string path = System.IO.Directory.GetCurrentDirectory();
                    int x = path.IndexOf("\\bin");
                    path = path.Substring(0, x) + business.Picture;
                    pictureBox2.Image = Image.FromFile(path);
                    lblname.Text = business.Bname;
                    lblsniph.Text = business.Residence;
                    panel2.Visible = true;
                  
                }
                else
                {
                    MessageBox.Show("לא ניתן להוסיף לכרטיס שאינו קנוי");
                }
            }
        }

        private void btnopencards_Click(object sender, EventArgs e)
        {
            FrmOpencards f = new FrmOpencards(thisbuyer,thisclien);
            f.Show();

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtbname.Text != "")
            {
                string st = txtbname.Text;
                lstkategory = new List<Business>();
                panel1.Controls.Clear();
                for (int i = 1; i < tblbusiness.GetList().Count + 1; i++)
                {
                    Business b = new Business();
                    b = tblbusiness.Find(i);
                    if (b.Bname == st)
                    {
                        lstkategory.Add(b);
                    }
                }
                panel = new Panel[lstkategory.Count + 1];
                p = new PictureBox[lstkategory.Count + 1];
                lbl = new Label[lstkategory.Count + 1];
                lbl2 = new Label[lstkategory.Count + 1];
                count2 = 1;
                count = 1;

                if (lstkategory.Count > 0)
                {
                    Pourkategory(lstkategory);
                }
                else
                {
                    MessageBox.Show("לא נמצא בית עסק העונה לשם שהקשת");
                }
            }
            else
            {
                MessageBox.Show("הקש את שם בית העסק הרצוי בתיבת הטקסט");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
    
}

