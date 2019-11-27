using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olympic_Village
{
    public partial class Activity : Form
    {
        static string mycon = @"Data Source=ASHRAKT-PC\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
        SqlConnection con = new SqlConnection(mycon);
        storeddata myobject = new storeddata();
        public Activity()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Activity_Load(object sender, EventArgs e)
        {
            myobject.showdata(dataGridView1, "SELECT * FROM activity", 6,0,0);   
        }
        storeddata storeobj = new storeddata();
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query;
            if (priceofsummer.Text != "" && periodofsummer.Text == "")
            {
              query  = "INSERT INTO activity (name,price,numofperiod) VALUES ('" + comboBox2.Text + "',N'" + priceofsummer.Text + "',N'" + periodofsummer.Text + "',N'" + "'";
            }
            else
            {
                query = "INSERT INTO activity (name,price,numofperiod) VALUES ('" + comboBox2.Text + "',N'" + priceofwinter.Text + "',N'" + periodofwinter.Text + "',N'" + "'";
            }

            storeobj.insertInTable(query);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string  query = "INSERT INTO activity (name,priceofsummer,numofperiodS,priceofwinter,numofperiodW) VALUES (N'" + comboBox2.Text.Trim() + "',N'" + priceofsummer.Text.Trim() + "',N'" + periodofsummer.Text.Trim() + "',N'" + priceofwinter.Text.Trim() + "',N'" + periodofwinter.Text.Trim() + "')";
            storeobj.insertInTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM activity", 6,0,0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tabPage1.Show();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            priceofsummer.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            periodofsummer.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            priceofwinter.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            periodofwinter.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           // string query = "INSERT INTO activity (name,priceofsummer,numofperiodS,priceofwinter,numofperiodW) VALUES (N'" + comboBox2.Text.Trim() + "',N'" + priceofsummer.Text.Trim() + "',N'" + periodofsummer.Text.Trim() + "',N'" + priceofwinter.Text.Trim() + "',N'" + periodofwinter.Text.Trim() + "')";
            string query1 = "UPDATE activity set name=N'" + comboBox2.Text.Trim() + "',priceofsummer=N'" + priceofsummer.Text.Trim() + "',numofperiodS=N'" + periodofsummer.Text.Trim() + "',priceofwinter=N'" + priceofwinter.Text.Trim() + "',numofperiodW=N'" + periodofwinter.Text  + "' where id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
            myobject.updateinTable(query1);
            myobject.showdata(dataGridView1, "SELECT * FROM activity", 6, 0,0);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string query = "DELETE FROM activity WHERE id ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
            storeobj.insertInTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM activity", 6, 0,0);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
