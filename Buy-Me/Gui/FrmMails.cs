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
    public partial class FrmMails : Form
    {
        private Mails mail;
        private Client thisclient;
        private MailsDB tblmail;
        List<Mails> lst;
        private Panel[] panel;
        private Label[] lbl;
        private Label[] lbl2;
        private Label[] lbl3;
        private PictureBox[] p;
        int count;
        


        public FrmMails(Client c)
        {
            InitializeComponent();
            thisclient = new Client();
            thisclient = c;
            tblmail = new MailsDB();
            lst = new List<Mails>();
            lst = tblmail.GetList().Where(x => x.Cpel == thisclient.Cpel).OrderBy(x=> x.Mdate).ToList();
            count = 1;
            button2.Visible = false;
            button1.Visible = false;
            string name = thisclient.Fname + " " + thisclient.Lname;
            lbl1.Text = "  תיבת ההודעות של " + name;
            mail = new Mails();
            panel = new Panel[lst.Count + 1];
            lbl = new Label[lst.Count + 1];
            lbl3 = new Label[lst.Count + 1];
            lbl2 = new Label[lst.Count + 1];
            p = new PictureBox[lst.Count + 1];
           
            Pour(lst);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Pour(List<Mails> lstk)
        {

            int f = 0;
            int r = 50;
            int x = lstk.Count()-1;
            for (int i =(x); i > -1; i--)
            {
                mail = lstk.ElementAt(i);
                if (mail != null)
                {
                    p[count] = new PictureBox();
                    try
                    {

                        p[count].Image = Buy_Me.Properties.Resources.הורדה__2_;
                    }
                    catch
                    {
                    }
                    p[count].Location = new System.Drawing.Point(726, 16);
                    p[count].Name = "pictureBox1";
                    p[count].Size = new System.Drawing.Size(37, 26);
                    p[count].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    p[count].TabIndex = 1;
                    p[count].TabStop = false;
                    p[count].Tag = mail;
                    p[count].Click += new System.EventHandler(button2_Click);
                    Controls.Add(p[count]);

                    lbl[count] = new Label();
                    lbl[count].AutoSize = true;
                    lbl[count].Location = new System.Drawing.Point(466, 16);
                    lbl[count].Name = "label1";
                    lbl[count].Size = new System.Drawing.Size(70, 24);
                    lbl[count].TabIndex = 1;
                    lbl[count].TabStop = false;
                    lbl[count].Text = Convert.ToString(mail.Mdate.ToShortDateString());
                    lbl[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl[count]);

                    lbl2[count] = new Label();
                    lbl2[count].AutoSize = true;
                    lbl2[count].Location = new System.Drawing.Point(284, 16);
                    lbl2[count].Name = "label2";
                    lbl2[count].Size = new System.Drawing.Size(70, 24);
                    lbl2[count].TabIndex = 1;
                    lbl2[count].TabStop = false;
                    lbl2[count].Text = Convert.ToString(mail.Mhour.ToShortTimeString());
                    lbl2[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl2[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl2[count]);

                    lbl3[count] = new Label();
                    lbl3[count].AutoSize = true;
                    lbl3[count].Location = new System.Drawing.Point(20, 16);
                    lbl3[count].Name = "label3";
                    lbl3[count].Size = new System.Drawing.Size(70, 24);
                    lbl3[count].TabIndex = 1;
                    lbl3[count].TabStop = false;
                    lbl3[count].Text = mail.ThisMailkind().Teur;
                    lbl3[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl3[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl3[count]);

                    panel[count] = new Panel();
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl[count]);
                    panel[count].Controls.Add(p[count]);
                    panel[count].Controls.Add(lbl2[count]);
                    panel[count].Controls.Add(lbl3[count]);
                    panel[count].Location = new System.Drawing.Point(f, r);
                    panel[count].Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                    panel[count].Name = "panel";
                    panel[count].Size = new System.Drawing.Size(798, 51);
                    panel[count].Tag = mail;
                    panel[count].TabIndex = 10;
                    panel[count].BorderStyle = BorderStyle.FixedSingle;
                    panel[count].BackColor = System.Drawing.Color.White;
                    panel[count].Click += new System.EventHandler(button1_Click);
                    Controls.Add(panel[count]);

                    panel1.Controls.Add(panel[count]);
                    f = f + 213;
                    ;




                    f = 0;
                    r = r + 50;


                    count++;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel g = (Panel)sender;
            Mails m = new Mails();           
            m = tblmail.Find(thisclient.Cpel, ((Mails)(g.Tag)).Mdate,((Mails)(g.Tag)).Mhour);
            FrmMailShow f = new FrmMailShow(m);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureBox g = (PictureBox)sender;
            Mails m = new Mails();
            m = tblmail.Find(thisclient.Cpel, ((Mails)(g.Tag)).Mdate, ((Mails)(g.Tag)).Mhour);
            FrmMailShow f = new FrmMailShow(m);
            f.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmClient f = new FrmClient();
            f.Show();
            this.Hide();
        }

        private void FrmMails_Load(object sender, EventArgs e)
        {

        }

        private void FrmMails_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmClient f = new FrmClient();
            f.Show();
        }
    }
}

