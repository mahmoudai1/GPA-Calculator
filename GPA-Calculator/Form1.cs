using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        class CNode
        {
            public float grade;
            public string letter;
        }

        float savedTotal = 0;
        float savedAcheivedCR = 0;
        private ComboBox[] comboBoxes;
        List<CNode> L = new List<CNode>();

        public Form1()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.Text = " GPA-Calculator";
            comboBoxes = new ComboBox[] {
               comboBox1, comboBox2, comboBox3, comboBox4, comboBox5
            , comboBox6, comboBox7, comboBox8, comboBox9
            , comboBox10, comboBox11, comboBox12, comboBox13
            , comboBox14, comboBox15, comboBox16, comboBox17
            , comboBox18};
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Height = SystemInformation.VirtualScreen.Height / 2 + 400;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CNode pnn = new CNode();
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 0:
                        pnn = new CNode();
                        pnn.letter = "A+";
                        pnn.grade = 4.33f;
                        L.Add(pnn);
                        break;
                    case 1:
                        pnn = new CNode();
                        pnn.letter = "A";
                        pnn.grade = 4f;
                        L.Add(pnn);
                        break;
                    case 2:
                        pnn = new CNode();
                        pnn.letter = "A-";
                        pnn.grade = 3.67f;
                        L.Add(pnn);
                        break;
                    case 3:
                        pnn = new CNode();
                        pnn.letter = "B+";
                        pnn.grade = 3.33f;
                        L.Add(pnn);
                        break;
                    case 4:
                        pnn = new CNode();
                        pnn.letter = "B";
                        pnn.grade = 3f;
                        L.Add(pnn);
                        break;
                    case 5:
                        pnn = new CNode();
                        pnn.letter = "B-";
                        pnn.grade = 2.67f;
                        L.Add(pnn);
                        break;
                    case 6:
                        pnn = new CNode();
                        pnn.letter = "C+";
                        pnn.grade = 2.33f;
                        L.Add(pnn);
                        break;
                    case 7:
                        pnn = new CNode();
                        pnn.letter = "C";
                        pnn.grade = 2f;
                        L.Add(pnn);
                        break;
                    case 8:
                        pnn = new CNode();
                        pnn.letter = "C-";
                        pnn.grade = 1.67f;
                        L.Add(pnn);
                        break;
                    case 9:
                        pnn = new CNode();
                        pnn.letter = "D+";
                        pnn.grade = 1.33f;
                        L.Add(pnn);
                        break;
                    case 10:
                        pnn = new CNode();
                        pnn.letter = "D";
                        pnn.grade = 1f;
                        L.Add(pnn);
                        break;
                    case 11:
                        pnn = new CNode();
                        pnn.letter = "D-";
                        pnn.grade = 0.67f;
                        L.Add(pnn);
                        break;
                    case 12:
                        pnn = new CNode();
                        pnn.letter = "F";
                        pnn.grade = 0f;
                        L.Add(pnn);
                        break;
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = -255; i < 255; i++)
            {
                if ((i < 48 || i > 57) && i != 46 && textBox1.Text != "")
                {
                    try
                    {
                        if (textBox1.Text[textBox1.TextLength - 1] == (char)i)
                        {
                            textBox1.Text = "";
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please enter a valid number.", "Input not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = -255; i < 255; i++)
            {
                if ((i < 48 || i > 57) && i != 46 && textBox2.Text != "")
                {
                    try
                    {
                        if (textBox2.Text[textBox2.TextLength - 1] == (char)i)
                        {
                            textBox2.Text = "";
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please enter a valid number.", "Input not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float AcheivedCR = 0;
                for (int i = 0; i < comboBoxes.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (comboBoxes[i].Text != "")
                        {
                            AcheivedCR += int.Parse(comboBoxes[i - 1].Text);
                        }
                    }
                }

                float Total = 0;
                for (int i = 0; i < comboBoxes.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (comboBoxes[i].Text != "" && int.Parse(comboBoxes[i - 1].Text) != 0)
                        {
                            for (int j = 0; j < L.Count; j++)
                            {
                                if (comboBoxes[i].Text == L[j].letter)
                                {
                                    Total += L[j].grade * int.Parse(comboBoxes[i - 1].Text);
                                    break;
                                }
                            }
                        }
                    }
                }


                if (Total != 0 && AcheivedCR != 0)
                {
                    label27.Text = "Acheived Credit Hours: " + AcheivedCR;
                    label27.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    label25.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    label25.Text = "Semester GPA: " + Math.Round(Total / AcheivedCR, 2); ;
                    savedTotal = Total;
                    savedAcheivedCR = AcheivedCR;
                    if (Total / AcheivedCR >= 2.8)
                    {
                        label25.ForeColor = Color.Green;

                    }
                    else if (Total / AcheivedCR < 2.8 && Total / AcheivedCR >= 2)
                    {
                        label25.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label25.ForeColor = Color.Red;
                    }
                }


                try
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        float multiplePrevCRwithPrevGPA = float.Parse(textBox1.Text) * float.Parse(textBox2.Text);
                        float addResultwithTotal = multiplePrevCRwithPrevGPA + savedTotal;
                        float cumGPA = addResultwithTotal / (float.Parse(textBox1.Text) + savedAcheivedCR);
                        label26.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        label28.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        label26.Text = "Cumulative GPA: " + Math.Round(cumGPA, 2);

                        label28.Text = "Total Credit Hours: " + (float.Parse(textBox1.Text) + savedAcheivedCR);

                        if (cumGPA >= 2.8)
                        {
                            label26.ForeColor = Color.Green;

                        }
                        else if (cumGPA < 2.8 && cumGPA >= 2)
                        {
                            label26.ForeColor = Color.Orange;
                        }
                        else
                        {
                            label26.ForeColor = Color.Red;
                        }
                    }
                }
                catch (Exception)
                {


                }


            }
            catch (Exception)
            {

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                for (int i = L.Count - 1; i >= 0; i--)
                {
                    L.Remove(L[i]);
                }
                CNode pnn = new CNode();
                for (int i = 0; i < 13; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pnn = new CNode();
                            pnn.letter = "A+";
                            pnn.grade = 4.3f;
                            L.Add(pnn);
                            break;
                        case 1:
                            pnn = new CNode();
                            pnn.letter = "A";
                            pnn.grade = 4f;
                            L.Add(pnn);
                            break;
                        case 2:
                            pnn = new CNode();
                            pnn.letter = "A-";
                            pnn.grade = 3.7f;
                            L.Add(pnn);
                            break;
                        case 3:
                            pnn = new CNode();
                            pnn.letter = "B+";
                            pnn.grade = 3.3f;
                            L.Add(pnn);
                            break;
                        case 4:
                            pnn = new CNode();
                            pnn.letter = "B";
                            pnn.grade = 3f;
                            L.Add(pnn);
                            break;
                        case 5:
                            pnn = new CNode();
                            pnn.letter = "B-";
                            pnn.grade = 2.7f;
                            L.Add(pnn);
                            break;
                        case 6:
                            pnn = new CNode();
                            pnn.letter = "C+";
                            pnn.grade = 2.3f;
                            L.Add(pnn);
                            break;
                        case 7:
                            pnn = new CNode();
                            pnn.letter = "C";
                            pnn.grade = 2f;
                            L.Add(pnn);
                            break;
                        case 8:
                            pnn = new CNode();
                            pnn.letter = "C-";
                            pnn.grade = 1.7f;
                            L.Add(pnn);
                            break;
                        case 9:
                            pnn = new CNode();
                            pnn.letter = "D+";
                            pnn.grade = 1.3f;
                            L.Add(pnn);
                            break;
                        case 10:
                            pnn = new CNode();
                            pnn.letter = "D";
                            pnn.grade = 1f;
                            L.Add(pnn);
                            break;
                        case 11:
                            pnn = new CNode();
                            pnn.letter = "D-";
                            pnn.grade = 0.7f;
                            L.Add(pnn);
                            break;
                        case 12:
                            pnn = new CNode();
                            pnn.letter = "F";
                            pnn.grade = 0f;
                            L.Add(pnn);
                            break;
                    }

                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                for (int i = L.Count - 1; i >= 0; i--)
                {
                    L.Remove(L[i]);
                }
                CNode pnn = new CNode();
                for (int i = 0; i < 13; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pnn = new CNode();
                            pnn.letter = "A+";
                            pnn.grade = 4.33f;
                            L.Add(pnn);
                            break;
                        case 1:
                            pnn = new CNode();
                            pnn.letter = "A";
                            pnn.grade = 4f;
                            L.Add(pnn);
                            break;
                        case 2:
                            pnn = new CNode();
                            pnn.letter = "A-";
                            pnn.grade = 3.67f;
                            L.Add(pnn);
                            break;
                        case 3:
                            pnn = new CNode();
                            pnn.letter = "B+";
                            pnn.grade = 3.33f;
                            L.Add(pnn);
                            break;
                        case 4:
                            pnn = new CNode();
                            pnn.letter = "B";
                            pnn.grade = 3f;
                            L.Add(pnn);
                            break;
                        case 5:
                            pnn = new CNode();
                            pnn.letter = "B-";
                            pnn.grade = 2.67f;
                            L.Add(pnn);
                            break;
                        case 6:
                            pnn = new CNode();
                            pnn.letter = "C+";
                            pnn.grade = 2.33f;
                            L.Add(pnn);
                            break;
                        case 7:
                            pnn = new CNode();
                            pnn.letter = "C";
                            pnn.grade = 2f;
                            L.Add(pnn);
                            break;
                        case 8:
                            pnn = new CNode();
                            pnn.letter = "C-";
                            pnn.grade = 1.67f;
                            L.Add(pnn);
                            break;
                        case 9:
                            pnn = new CNode();
                            pnn.letter = "D+";
                            pnn.grade = 1.33f;
                            L.Add(pnn);
                            break;
                        case 10:
                            pnn = new CNode();
                            pnn.letter = "D";
                            pnn.grade = 1f;
                            L.Add(pnn);
                            break;
                        case 11:
                            pnn = new CNode();
                            pnn.letter = "D-";
                            pnn.grade = 0.67f;
                            L.Add(pnn);
                            break;
                        case 12:
                            pnn = new CNode();
                            pnn.letter = "F";
                            pnn.grade = 0f;
                            L.Add(pnn);
                            break;
                    }

                }
            }
        }
    }


}
