using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Olympic_Village
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        static public string username { get; set; }
        public string return_username()
        {
            return username;
        }
        //static  string mycon = @"Data Source=DESKTOP-3DNKMVB\SQLEXPRESS;Initial Catalog=olympic_village;Integrated Security=True";
        //  SqlConnection sql = new SqlConnection(mycon);
        static string mycon = @"Data Source=ASHRAKT-PC\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
        SqlConnection con = new SqlConnection(mycon);
        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            string query = "Select Count(*) FROM  employee WHERE username = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlCommand sCommand = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            int UserExist1 = (int)sCommand.ExecuteScalar();
            // MessageBox.Show(UserExist1.ToString() + " "/*+reader.HasRows.ToString()*/ + " " + textBox1.Text.Trim() + textBox2.Text.Trim());
            if (UserExist1 != 0)
            {
                username = textBox1.Text.Trim();
                con.Close();
                Form5 objFrmMain = new Form5();
                this.Hide();
                objFrmMain.Show();
                return;

            }
            string query1 = "Select  Count(*) FROM  Admin WHERE  username = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlCommand sCommand1 = new SqlCommand(query1, con);
            int UserExist2 = (int)sCommand1.ExecuteScalar();
            //   MessageBox.Show(UserExist2.ToString()+" "/*+reader.HasRows.ToString()*/ +" "+ textBox1.Text.Trim()+ textBox2.Text.Trim());
            if (UserExist2 != 0)
            {
                username ="Admin "+textBox1.Text.Trim();
                con.Close();
                Form4 objFrmMain = new Form4();
                this.Hide();
                objFrmMain.Show();
                return;
            }
            MessageBox.Show("Check Your username and password correctly");
        }
    }
}
