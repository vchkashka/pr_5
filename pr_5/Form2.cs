using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pr_5
{
    public partial class Form2 : Form
    {
        Syllabus syllabus;
        public Form2(Syllabus syllabus)
        {
            InitializeComponent();
            this.syllabus = syllabus;
            label1.Text += $" {syllabus.NumSemesters}):";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Заполняем информацию о дисциплине и добавляем ее в учебный план
        private void button1_Click(object sender, EventArgs e)
        {
            int k; EL el = EL.EMPTY;
            k = Convert.ToInt32(textBox1.Text);
            k--;
            switch (comboBox1.Text)
            {
                case "Бакалавриат": el = EL.bakalavriat; break;
                case "Магистратура": el = EL.magistratura; break;
                case "Аспирантура": el = EL.aspirantura; break;
                
            }
            Discipline newDiscipline = new Discipline(textBox2.Text, Convert.ToInt32(textBox3.Text), el);
            syllabus.Dobavite(newDiscipline, k);
            Close();
        }
    }
}
