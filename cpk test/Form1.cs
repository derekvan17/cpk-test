using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace cpk_test
{
    public partial class Form1 : MetroForm
    {
        List<double> data = new List<double> {};

        public Form1()
        {
            InitializeComponent();
        }

        public string[] Assign()
        {
            double mean = data.Mean();
            double variance = data.Variance();
            double sd = data.StandardDeviation();
            double cpk = data.CpkPullTest();

            string[] var = new string[5];
            var[0] = Convert.ToString(mean);
            var[1] = Convert.ToString(variance);
            var[2] = Convert.ToString(sd);
            var[3] = Convert.ToString(cpk);

            return var;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.Add(Convert.ToDouble(textBox1.Text));

            string[] var = Assign();
            label1.Text = var[0];
            label2.Text = var[1];
            label3.Text = var[2];
            label8.Text = var[3];
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
