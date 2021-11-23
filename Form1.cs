using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.DataSource = db.Product.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            productBindingSource.DataSource = db.Product.Where(a => a.Title.Contains(textBox1.Text) || a.Description.Contains(textBox1.Text)).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "По возрастанию")
            {
                productBindingSource.DataSource = db.Product.OrderBy(a => a.Cost).ToList();
            }
            if (comboBox1.Text == "По убыванию")
            {
                productBindingSource.DataSource = db.Product.OrderByDescending(a => a.Cost).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productBindingSource.DataSource = null;
            productBindingSource.DataSource = db.Product.ToList();
        }
    }
}
