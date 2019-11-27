using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olympic_Village
{
    public partial class CheckFromUniversity : Form
    {
        public CheckFromUniversity()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 objFrmMain = new Form3();
            this.Hide();
            objFrmMain.Show();
            //في اتنين اتشيك هيبقا هنا تشيك هل هو من الجامعة ولا لا وهل سجل قبل كده وبيناته موجوده ولا لا

        }

        private void CheckFromUniversity_Load(object sender, EventArgs e)
        {

        }
    }
}
