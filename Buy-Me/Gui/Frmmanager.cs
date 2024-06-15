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
    public partial class Frmmanager : Form
    {
        private BusinessDB tblbusiness;
        private RegistrationDB tblregistration;
        private List<Registration> lst;
        private Registration rg;
        private int count;
        private Label[] lbl1;
        private Label[] lbl2;
        private Label[] lbl3;
        private Panel[] panel;
        public Frmmanager()
        {
            InitializeComponent();
            lst = new List<Registration>();
            tblbusiness = new BusinessDB();
            tblregistration = new RegistrationDB();
            lst = tblregistration.GetList().Where(x => x.Fdate.Year == DateTime.Today.Year).ToList();
            rg = new Registration();
            lbl1 = new Label[lst.Count - 1];
            lbl2 = new Label[lst.Count - 1];
            lbl3 = new Label[lst.Count - 1];
            panel = new Panel[lst.Count - 1];
            Pour(lst);
        }
        private void Pour(List<Registration> lstk)
        {

            int f = 0;
            int r = 0;
            int x = lstk.Count() - 1;
            for (int i = (x); i > 0; i--)
            {
                 rg= lstk.ElementAt(i);
                if (rg != null)
                {
                  

                    lbl1[count] = new Label();
                    lbl1[count].AutoSize = true;
                    lbl1[count].Location = new System.Drawing.Point(361,23);
                    lbl1[count].Name = "label1";
                    lbl1[count].Size = new System.Drawing.Size(70, 24);
                    lbl1[count].TabIndex = 1;
                    lbl1[count].TabStop = false;
                    lbl1[count].Text = Convert.ToString(rg.ThisBusiness().Bname);
                    lbl1[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl1[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl1[count]);

                    lbl2[count] = new Label();
                    lbl2[count].AutoSize = true;
                    lbl2[count].Location = new System.Drawing.Point(195,23);
                    lbl2[count].Name = "label2";
                    lbl2[count].Size = new System.Drawing.Size(70, 24);
                    lbl2[count].TabIndex = 1;
                    lbl2[count].TabStop = false;
                    lbl2[count].Text = Convert.ToString(rg.Fdate.ToShortDateString());
                    lbl2[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl2[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl2[count]);

                    lbl3[count] = new Label();
                    lbl3[count].AutoSize = true;
                    lbl3[count].Location = new System.Drawing.Point(63, 23);
                    lbl3[count].Name = "label1";
                    lbl3[count].Size = new System.Drawing.Size(70, 24);
                    lbl3[count].TabIndex = 1;
                    lbl3[count].TabStop = false;
                    lbl3[count].Text = "₪ " + Convert.ToString((rg.Ldate.Year-rg.Fdate.Year)*2000)  ;
                    lbl3[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl3[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl3[count]);

                    panel[count] = new Panel();
                    panel[count].Controls.Add(lbl1[count]);
                    panel[count].Controls.Add(lbl2[count]);
                    panel[count].Controls.Add(lbl3[count]);
                    panel[count].Location = new System.Drawing.Point(f, r);
                    panel[count].Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                    panel[count].Name = "panel";
                    panel[count].Size = new System.Drawing.Size(481, 51);
                    panel[count].Tag = rg;
                    panel[count].TabIndex = 10;
                    panel[count].BorderStyle = BorderStyle.FixedSingle;
                    panel[count].BackColor = System.Drawing.Color.White;
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
        private void Frmmanager_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
