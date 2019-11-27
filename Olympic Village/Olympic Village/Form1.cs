using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace Olympic_Village
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //static string mycon = @"Data Source=DESKTOP-3DNKMVB\SQLEXPRESS;Initial Catalog=olympic_village;Integrated Security=True";

        // SqlConnection con = new SqlConnection(mycon);
        static string mycon = @"Data Source=ASHRAKT-PC\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
        SqlConnection con = new SqlConnection(mycon);
        storeddata myobject = new storeddata();
        bool in_or_out_university = false;
        string employee_username = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            employee_username = f.return_username();
            MessageBox.Show(employee_username);
            settocombox();
            myobject.showdata(dataGridView1, "SELECT * FROM customer where in_or_out_university='" + in_or_out_university + "'", 13, 1, 0);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (nationalid.Text.Length != 14)
            //{
            //    MessageBox.Show("يجيب ان يكون الرقم القومي  14  رقم");
            //    return;
            //}
            bool cardloss = false;
            bool in_or_out_university = false;
            Zen.Barcode.BarcodeDraw barcodee = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            barcodee.Draw(nationalid.Text, 50);
            string query = "INSERT INTO customer (barcode,national_id,numofmember,name,job,birth_day,fathername,fatherjob,phone,adress,card_loss,receipt_number,in_or_out_university,employee_username) VALUES ('" + barcodee.Draw(nationalid.Text, 50) + "','" + nationalid.Text + "','" + numofmember.Text + "',N'" + customername.Text + "',N'" + job.Text + "',N'" + birth.Value + "',N'" + fathername.Text + "',N'" + fatherjob.Text + "','" + phone.Text + "',N'" + adress.Text + "',N'" + cardloss + "','" + receipt_num.Text + "','"+ in_or_out_university+ "',N'" + employee_username + "')";
            myobject.insertInTable(query);
            string query1 = "INSERT INTO custmer_activity (actvity_name,strat_subscripation,end_subscripation,subscription_period,academyorschool,season,recipetnumber) VALUES ('" + activityname.Text + "','" + startsubscription.Value + "','" + endsubscription.Value + "',N'" + numofperiod.Text + "',N'" + academyorschool.Text + "',N'" + season.Text + "',N'" + receipt_num.Text + "')";
            myobject.insertInTable(query1);
            myobject.showdata(dataGridView1, "SELECT * FROM customer where in_or_out_university='" + in_or_out_university + "'", 13, 1, 0);


        }

        public void settocombox()
        {
            string query = "SELECT name FROM activity";
            con.Open();
            SqlDataAdapter sqlcom = new SqlDataAdapter(query, con);
            DataSet dataSet = new DataSet();
            sqlcom.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    activityname.Items.Add(dataSet.Tables[0].Rows[i]["name"]);
                }

            }
            con.Close();
        }


        public void setttextbox(string value,TextBox textbox)
        {
            string query = "SELECT" +value+ " FROM "+season+ " WHERE name='"+activityname+"'";
            con.Open();
            SqlDataAdapter sqlcom = new SqlDataAdapter(query, con);
            DataSet dataSet = new DataSet();
            sqlcom.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count != 0)
            {
                    textbox.Text=dataSet.Tables[0].Rows[0][value]+"";
                

            }
            con.Close();
        }

        private void season_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectSql = "select * from activity where name='" + activityname.Text.Trim() + "'";
            SqlCommand com = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        if (season.Text.Trim() == "صيفي")
                        {
                            string valueodsubstraction1 = (read["priceofwinter"].ToString());
                            valueodsubstraction.Text = valueodsubstraction1;
                            numofperiod.Text = (read["numofperiodS"].ToString());
                        }
                        else
                         if (season.Text.Trim() == "شتاء")
                        {
                            string valueodsubstraction1 = (read["priceofwinter"].ToString());
                            valueodsubstraction.Text = valueodsubstraction1;
                            numofperiod.Text = (read["numofperiodW"].ToString());
                        }


                    }
                }
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           try {


                string query = "SELECT * FROM customer";
                con.Open();
              
                SqlDataAdapter sqldata = new SqlDataAdapter(query, con);
                dataGridView1.Rows.Clear();
                DataTable datable = new DataTable();
                sqldata.Fill(datable);
                foreach (DataRow item in datable.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                    dataGridView1.Rows[n].Cells[10].Value = item[10].ToString();
                    dataGridView1.Rows[n].Cells[12].Value = item[12].ToString();
                    dataGridView1.Rows[n].Cells[13].Value = item[13].ToString();
                    dataGridView1.Rows[n].Cells[14].Value = item[14].ToString();


                }
                 query = "SELECT * FROM activity_customer";
               

                SqlDataAdapter sqldata1 = new SqlDataAdapter(query, con);
                dataGridView1.Rows.Clear();
                DataTable datable1 = new DataTable();
                sqldata.Fill(datable1);
                foreach (DataRow item in datable.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[7].Value = item[5].ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selectSql = "select * from customer where national_id='" + nationalid.Text.Trim() + "'";
            SqlCommand com = new SqlCommand(selectSql, con);

            try
            {
                con.Open();

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        customername.Text = (read["name"].ToString());
                        job.Text = (read["job"].ToString());
                        fathername.Text = (read["fathername"].ToString());
                        fatherjob.Text = (read["fatherjob"].ToString());
                        phone.Text = (read["phone"].ToString());
                        adress.Text = (read["adress"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }
    }


    }

