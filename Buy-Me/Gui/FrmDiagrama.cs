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
    public partial class FrmDiagrama : Form
    {
        private BusinessDB tblbussines;
        private CardpurchaseDB tblcardpurchase;
        private CardDB tblcard;
         private  int count;
        private int t;
        List<Business> listb;
        public FrmDiagrama()
        {
            InitializeComponent();
            tblbussines = new BusinessDB();
            tblcardpurchase = new CardpurchaseDB();
            tblcard = new CardDB();
            t = 0;
            listb = new List<Business>();
            var list = tblbussines.GetList().Select(x => new { a = x.Bname, b = tblcard.GetList().Where(t => t.Codebusiness == x.Codebusiness).Count(), c = x.Codebusiness }).OrderBy(x => x.b).ToList();
            int max = list.Max(x => x.b);
            int m = list.Count();
            for (int i = 0; i < m; i++)
            {
                if (list.ElementAt(0).b < max)
                {
                    list.RemoveAt(0);
                }
            }
            count = list.Count();
            for (int i = 0; i < list.Count(); i++)
            {
                Business b = new Business();
                b = tblbussines.Find(list.ElementAt(i).c);
                listb.Add(b);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDiagrama_Load(object sender, EventArgs e)
        {
           var list= tblbussines.GetList().Select(x => new { a = x.Bname, b = tblcard.GetList().Where(t => t.Codebusiness == x.Codebusiness).Count(),c=x.Codebusiness }).OrderBy(x=> x.b).ToList();
            int count = list.Count();
            for (int i=0;i< count-7; i++)
            {
                
                list.RemoveAt(0);
            }
            chart1.DataSource = list;
            chart1.Series["bussines"].XValueMember = "a";
            chart1.Series["bussines"].YValueMembers = "b";
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Business b = new Business();
            b = listb.ElementAt(t);
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                int x = path.IndexOf("\\bin");
                path = path.Substring(0, x) + b.Picture;
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            catch { }
            if (t == count-1)
                t = -1;
            t++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
