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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEmloyee objFrmMain = new AddEmloyee();
            this.Hide();
            objFrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Activity objFrmMain = new Activity();
            this.Hide();
            objFrmMain.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckFromUniversity objFrmMain = new CheckFromUniversity();
            this.Hide();
            objFrmMain.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          //  Is_From_University
          
            Form1 objFrmMain = new Form1();
            this.Hide();
            objFrmMain.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            Discount_for_From_Univesity objFrmMain = new Discount_for_From_Univesity();
            this.Hide();
            objFrmMain.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
