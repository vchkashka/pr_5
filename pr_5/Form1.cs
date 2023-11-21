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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Syllabus syllabus = new Syllabus("12345654", "Учебный план", "Иванов Иван Иванович", 20, EL.bakalavriat, 2);

        
        //Добавление дисциплины в учебный план
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                //Переходим в другую форму, в которой заполняем информацию о дисциплине
                using (Form2 f2 = new Form2(syllabus))
                {
                    f2.ShowDialog(this);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"\nОшибка: {exception.Message} \n");
            }
        }
        //Удаление дисциплины из учебного плана
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                //Переходим в другую форму, в которой выбираем дисциплину для удаления
                using (Form3 f3 = new Form3(syllabus))
                {
                    f3.ShowDialog(this);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"\nОшибка: {exception.Message} \n");
            }
        }
        //Введение плана в действие
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                syllabus.Put_the_plan();
                richTextBox1.Text = "План введен в действие.";
            }
            catch (Exception exception)
            {
                MessageBox.Show($"\nОшибка: {exception.Message} \n");
            }
        }
        //Вывод информации о плане 
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = syllabus.Print();
        }
        //Вывод информации о семестрах
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = syllabus.Print_dis();
        }
    }
}
