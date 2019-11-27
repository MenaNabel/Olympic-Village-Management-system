using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace olympic
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void back_to_home(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void go_to_edit_employee(object sender, EventArgs e)
        {
            new Form7().Show();
            this.Hide();
        }
    }
}
