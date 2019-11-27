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
    public partial class Discount_for_From_Univesity : Form
    {
        storeddata myobject = new storeddata();
        public Discount_for_From_Univesity()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO precentage (precentage) VALUES ('" + precentage.Text+ "')";
            myobject.insertInTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM precentage", 1, 0, 0);
        }

        private void Discount_for_From_Univesity_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "تحديد النسبة";
            tabPage1.Text = "عرض النسبة";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }
    }
}
