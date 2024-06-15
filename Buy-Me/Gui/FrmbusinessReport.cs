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
    public partial class FrmbusinessReport : Form
    {
        private BusinessDB tblbusiness;
        private Business thisbusiness;
        private CardpurchaseDB tblcardpurchase;
        private List<Cardpurchase> listc = new List<Cardpurchase>();
        private Panel[] panel;
        private Label[] lbl1;
        private Label[] lbl2;
        private Label[] lbl3;
        private int count;
        List<string> lstmonth;
        public FrmbusinessReport(Business b)
        {
            InitializeComponent();
            thisbusiness = b;
            tblbusiness = new BusinessDB();
            tblcardpurchase = new CardpurchaseDB();
            lstmonth = new List<string>();
            lstmonth.Add("hgd");
            lstmonth.Add("ינואר");
            lstmonth.Add("פברואר");
            lstmonth.Add("מרץ");
            lstmonth.Add("אפריל");
            lstmonth.Add("מאי");
            lstmonth.Add("יוני");
            lstmonth.Add("יולי");
            lstmonth.Add("אוגוסט");
            lstmonth.Add("ספטמבר");
            lstmonth.Add("אוקטובר");
            lstmonth.Add("נובמבר");
            lstmonth.Add("דצמבר");
            label2.Text = thisbusiness.Bname;
            panel = new Panel[13];
            lbl1 = new Label[13 ];
            lbl2 = new Label[13];
            lbl3 = new Label[13];
            Pour();

        }
        private void Pour()
        {
            var list3 = tblcardpurchase.GetList();
            var list2 = tblcardpurchase.GetList(); 
            var list1 = tblcardpurchase.GetList().Where(x => x.Pdate.Year == DateTime.Today.Year && x.ThisCard().Codebusiness == thisbusiness.Codebusiness).Select(x => new { a = x.Pdate.Month, b = list2.Where(t => t.Pdate.Month == x.Pdate.Month && t.Pdate.Year == x.Pdate.Year && t.ThisCard().Codebusiness == x.ThisCard().Codebusiness).Sum(t => t.Amount), c = list3.Where(z => z.Pdate.Month == x.Pdate.Month && z.Pdate.Year == DateTime.Today.Year && z.ThisCard().Codebusiness == thisbusiness.Codebusiness).Count()  }).ToList();
            int f = 0;
            int r = 0;
            double sum;
            int c;
            for (int i = 1; i <= 13; i++)
            {
               
               
                if (list1.Find(x=> x.a==i)!=null)
                {
                    sum = list1.Find(x => x.a == i).b;
                    c = list1.Find(x => x.a == i).c;
                    lbl1[count] = new Label();
                    lbl1[count].AutoSize = true;
                    lbl1[count].Location = new System.Drawing.Point(405, 23);
                    lbl1[count].Name = "label1";
                    lbl1[count].Size = new System.Drawing.Size(70, 24);
                    lbl1[count].TabIndex = 1;
                    lbl1[count].TabStop = false;
                    lbl1[count].Text = Convert.ToString(lstmonth.ElementAt(i));
                    lbl1[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl1[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl1[count]);

                    lbl2[count] = new Label();
                    lbl2[count].AutoSize = true;
                    lbl2[count].Location = new System.Drawing.Point(240, 23);
                    lbl2[count].Name = "label2";
                    lbl2[count].Size = new System.Drawing.Size(70, 24);
                    lbl2[count].TabIndex = 1;
                    lbl2[count].TabStop = false;
                    lbl2[count].Text = Convert.ToString(c);
                    lbl2[count].Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    lbl2[count].ForeColor = System.Drawing.Color.Black;
                    Controls.Add(lbl2[count]);

                    lbl3[count] = new Label();
                    lbl3[count].AutoSize = true;
                    lbl3[count].Location = new System.Drawing.Point(54, 23);
                    lbl3[count].Name = "label1";
                    lbl3[count].Size = new System.Drawing.Size(70, 24);
                    lbl3[count].TabIndex = 1;
                    lbl3[count].TabStop = false;
                    lbl3[count].Text = "₪ " + Convert.ToString(sum);
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
                    panel[count].Size = new System.Drawing.Size(514 , 51);

                    panel[count].TabIndex = 10;
                    panel[count].BorderStyle = BorderStyle.FixedSingle;
                    panel[count].BackColor = System.Drawing.Color.White;
                    Controls.Add(panel[count]);

                    panel1.Controls.Add(panel[count]);
                    f = f + 213;

                    f = 0;
                    r = r + 50;


                    count++;
                }

            }
        }

            private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmbusinessReport_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
