using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mynotepad
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format("Developed by: {0}", Application.CompanyName);
            label2.Text = string.Format("Product name: {0}", Application.ProductName);
            label3.Text = string.Format("Product Version: {0}", Application.ProductVersion);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = Application.ProductName;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
