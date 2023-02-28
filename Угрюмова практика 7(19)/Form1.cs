using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Угрюмова_практика_7_19_
{
    public partial class Form1 : Form
    {
        private int Mmm()
        {
            StreamReader sr2 = new StreamReader("test.txt");
            int a = File.ReadAllLines("test.txt").Count();
            a = a/11;
            sr2.Close();
            return a;
        }
        string[,] qetions;
        int curr_numb = 0; double answer = 0;
        public Form1()
        {
            InitializeComponent();
            int longQetions = Mmm();
            qetions = new string[longQetions, 11];
            StreamReader sr = File.OpenText("test.txt");
            int i = 0, j;
            while (!sr.EndOfStream)
            {
                for (j = 0; j < longQetions; j++)
                {
                    qetions[i, j] = sr.ReadLine();
                }
                i++;
            }
            sr.Close();
            
            this.Text = "Вопрос " + (curr_numb + 1);
            label1.Text = qetions[0, 0];
            radioButton1.Text = qetions[0, 1];
            radioButton2.Text = qetions[0, 2];
            radioButton3.Text = qetions[0, 3];
            if (qetions[0, 5] == "")
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
            }
            if (qetions[0, 7] != "")
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(qetions[curr_numb, 7]);
            }
            else
            {
                pictureBox1.Visible = false;
            }
            if (qetions[0, 8] != "")
            {
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(qetions[curr_numb, 8]);
            }
            else
            {
                pictureBox2.Visible = false;
            }
            if (qetions[0, 9] != "")
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile(qetions[curr_numb, 9]);
            }
            else
            {
                pictureBox3.Visible = false;
            }
            if (qetions[0, 10] != "")
            {
                pictureBox4.Visible = true;
                pictureBox4.Image = Image.FromFile(qetions[curr_numb, 10]);
            }
            else
            {
                pictureBox4.Visible = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int longQetions = Mmm();
            qetions = new string[longQetions, 11];
            if (qetions[curr_numb, 5] == "")
            {
                Chek1();
            }
            else
            {
                Chek2();
            }
            if (curr_numb < longQetions-1 && qetions[curr_numb + 1, 5] == "")
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
            }
            else
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
            }
            if (curr_numb < qetions.GetLength(0)-1)
            {
                curr_numb++;
                this.Text = "Вопрос " + (curr_numb + 1);
                label1.Text = qetions[curr_numb, 0];
                radioButton1.Text = qetions[curr_numb, 1];
                radioButton2.Text = qetions[curr_numb, 2];
                radioButton3.Text = qetions[curr_numb, 3];
                checkBox1.Text = qetions[curr_numb, 1];
                checkBox2.Text = qetions[curr_numb, 2];
                checkBox3.Text = qetions[curr_numb, 3];
                if (qetions[curr_numb, 7] != "")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(qetions[curr_numb, 7]);
                }
                else
                {
                    pictureBox1.Visible = false;
                }
                if (qetions[curr_numb, 8] != "")
                {
                    pictureBox2.Visible = true;
                    pictureBox2.Image = Image.FromFile(qetions[curr_numb, 8]);
                }
                else
                {
                    pictureBox2.Visible = false;
                }
                if (qetions[curr_numb, 9] != "")
                {
                    pictureBox3.Visible = true;
                    pictureBox3.Image = Image.FromFile(qetions[curr_numb, 9]);
                }
                else
                {
                    pictureBox3.Visible = false;
                }
                if (qetions[curr_numb, 10] != "")
                {
                    pictureBox4.Visible = true;
                    pictureBox4.Image = Image.FromFile(qetions[curr_numb, 10]);
                }
                else
                {
                    pictureBox4.Visible = false;
                }
            }
            else
            {
                button1.Enabled = false;
                if(curr_numb+1 == answer)
                {
                    MessageBox.Show("Вы ответили верно на все " +answer +" вопросов", "Результаты");
                }
                else
                {
                    MessageBox.Show($"вы ответили верно лишь на {answer} вопросов","Результаты");
                }
            }
        }
        private void Chek1()
        {
            if (radioButton1.Checked)
            {
                if (radioButton1.Text == qetions[curr_numb, 4])
                {
                    answer++;
                }
            }
            if (radioButton2.Checked)
            {
                if (radioButton2.Text == qetions[curr_numb, 4])
                {
                    answer++;
                }
            }
            if (radioButton3.Checked)
            {
                if (radioButton3.Text == qetions[curr_numb, 4])
                {
                    answer++;
                }
            }
        }
        private void Chek2()
        {
            if (checkBox1.Checked)
            {
                if (checkBox1.Text == qetions[curr_numb, 4]|| checkBox1.Text == qetions[curr_numb, 5] || checkBox1.Text == qetions[curr_numb, 6])
                {
                    answer+=0.5;
                }
            }
            if (checkBox2.Checked)
            {
                if (checkBox2.Text == qetions[curr_numb, 4] || checkBox2.Text == qetions[curr_numb, 5] || checkBox2.Text == qetions[curr_numb, 6])
                {
                    answer+=0.5;
                }
            }
            if (checkBox3.Checked)
            {
                if (checkBox3.Text == qetions[curr_numb, 4] || checkBox3.Text == qetions[curr_numb, 5] || checkBox3.Text == qetions[curr_numb, 6])
                {
                    answer+=0.5;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
