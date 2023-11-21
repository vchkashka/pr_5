using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_5
{
    public partial class Form3 : Form
    {
        Syllabus syllabus;
        public Form3(Syllabus syllabus)
        {
            InitializeComponent();
            this.syllabus = syllabus;
            label1.Text += $" {syllabus.NumSemesters}):";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k, d;
            //номер семестра
            k = Convert.ToInt32(textBox1.Text);
            k--;
            //номер дисциплины
            d = Convert.ToInt32(textBox2.Text);
            d--;
            //удаление дисциплины
            syllabus.Udalite(d, k);
            Close();
        }
    }
}
