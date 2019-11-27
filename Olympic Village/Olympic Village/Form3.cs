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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        storeddata myobject = new storeddata();
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }
        static string mycon = @"Data Source=ASHRAKT-PC\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
        SqlConnection con = new SqlConnection(mycon);

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
        private void recipt_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool in_or_out_university = true;
        string employee_username="";
        private void Form3_Load(object sender, EventArgs e)
        {
            settocombox();
            Form2 f = new Form2();
            employee_username = f.return_username();
            //    MessageBox.Show(employee_username);
            if (employee_username == "")
                employee_username = "Admin";
            myobject.showdata(dataGridView1, "SELECT * FROM customer where in_or_out_university='" + in_or_out_university + "'", 13, 1, 0);

            //   myobject.showdata(dataGridView1, "SELECT * FROM custmer_activity ", 11, 4, 11);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (nationalId.Text.Length != 14)
            //{
            //    MessageBox.Show("يجيب ان يكون الرقم القومي  14  رقم");
            //    return;
            //}
            int cardloss = 0;

            Zen.Barcode.BarcodeDraw barcodee = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            barcodee.Draw(nationalid.Text, 50);
            string query = "INSERT INTO customer (barcode,national_id,numofmember,name,job,birth_day,fathername,fatherjob,phone,adress,card_loss,receipt_number,in_or_out_university,employee_username) VALUES ('" + barcodee.Draw(nationalid.Text, 50) + "','" + nationalid.Text + "','" + numofmember.Text + "',N'" + customername.Text + "',N'" + job.Text + "',N'" + birth.Value + "',N'" +fathername.Text + "',N'"+fatherjob.Text + "','" + phone.Text+ "',N'" + adress.Text+ "',N'" + cardloss + "','" + receipt_num.Text + "',N'" +employee_username+ "')";
            myobject.insertInTable(query);
            string query1 = "INSERT INTO custmer_activity (actvity_name,strat_subscripation,end_subscripation,subscription_period,academyorschool,season,recipetnumber) VALUES ('" + activityname.Text + "','" + startsubscription.Value + "','" + endsubscription.Value + "',N'" + numofperiod.Text + "',N'" + academyorschool.Text + "',N'" + season.Text + "',N'"+receipt_num.Text+ "')";
            myobject.insertInTable(query1);
            myobject.showdata(dataGridView1, "SELECT * FROM customer where in_or_out_university='" + in_or_out_university + "'", 13, 1, 0);
        }

        private void activityname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void season_SelectedIndexChanged(object sender, EventArgs e)
        {
            double precent = 1;
            double discount = 0;
            string selectSql1 = "select * from precentage ";
            SqlCommand com1 = new SqlCommand(selectSql1, con);
            try
            {
                con.Open();

                using (SqlDataReader read2 = com1.ExecuteReader())
                {
                    while (read2.Read())
                    {                   
                            string temp = (read2["precentage"].ToString());
                            precent = double.Parse(temp);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            string selectSql = "select * from activity where name='" + activityname.Text.Trim() + "'";
            double precent2 = precent;
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
                            discount = precent * (double.Parse(valueodsubstraction1) / 100);
                            MessageBox.Show(precent.ToString() + " " + (double.Parse(valueodsubstraction1) / 100).ToString() + " " + discount.ToString());
                            double res = (double.Parse(valueodsubstraction1) - discount);
                            valueodsubstraction.Text = res.ToString();
                            numofperiod.Text = (read["numofperiodS"].ToString());
                        }
                        else
                         if (season.Text.Trim() == "شتاء")
                        {
                            string valueodsubstraction1 = (read["priceofwinter"].ToString());
                            discount = precent * (double.Parse(valueodsubstraction1) / 100);
                            MessageBox.Show(precent.ToString() + " " + (double.Parse(valueodsubstraction1) / 100).ToString() + " " + discount.ToString());
                            double res = (double.Parse(valueodsubstraction1) - discount);
                            valueodsubstraction.Text = res.ToString();
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
