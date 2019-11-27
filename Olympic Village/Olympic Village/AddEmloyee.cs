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
    public partial class AddEmloyee : Form
    {
        static string mycon = @"Data Source=ASHRAKT-PC\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
        SqlConnection con = new SqlConnection(mycon);
        storeddata myobject = new storeddata();
        public AddEmloyee()
        {
            InitializeComponent();
        }
        string query;
        storeddata storeobj = new storeddata();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(textBox2.Text))
            {
                MessageBox.Show("يوجد مشكلة في كتابة صيغة الايميل");
                return;
            }
            if (textBox4.Text.Length < 5)
            {
                MessageBox.Show("يجيب ان يكون الباسورد اكبر من 5 حروف او ارقام");
                return;
            }
            if (textBox6.Text.Length < 5)
            {
                MessageBox.Show("يجيب ان يكون رقم الموبيل 11 حروف او ارقام");
                return;
            }
            Random random = new Random();
           // long ran= random.Next(1, 10000000);
            query = "INSERT INTO employee (name,email,username,password,adress,phone) VALUES (N'" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "',N'" + textBox3.Text.Trim() +"',N'" + textBox4.Text.Trim() +"',N'" + textBox5.Text.Trim() + "',N'" + textBox6.Text.Trim() + "')";
            storeobj.insertInTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM employee", 7,0,0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrmMain = new Form4();
            this.Hide();
            objFrmMain.Show();
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   tabPage1.Show();
        }

        private void AddEmloyee_Load(object sender, EventArgs e)
        {
            myobject.showdata(dataGridView1, "SELECT * FROM employee", 7, 1,0);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabPage1.Show();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "UPDATE employee set name=N'" + textBox1.Text + "',email=N'" + textBox2.Text + "',username=N'" + textBox3.Text + "',password=N'" + textBox4.Text + "',adress=N'" + textBox5.Text + "',phone=N'" + textBox6.Text +"' where id='"+ dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
            myobject.updateinTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM employee", 7, 0,0);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query= "DELETE FROM employee WHERE id ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
            storeobj.insertInTable(query);
            myobject.showdata(dataGridView1, "SELECT * FROM employee", 7, 0,0);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
   }

