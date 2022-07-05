using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextStatistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Text = $"Количество введённых символов: {textBox1.Text.Length}";

            Dictionary<string, double> charStatistics = Program.GetCharStatistics(textBox1.Text);
            chart1.Series["CharStatistics"].Points.DataBindXY(charStatistics.Keys, charStatistics.Values);

            Dictionary<int, double> wordLenghtStatistics = Program.GetWordLenghtStatistics(textBox1.Text);
            chart2.Series["WordLenghtStatistics"].Points.DataBindXY(wordLenghtStatistics.Keys, wordLenghtStatistics.Values);

            Dictionary<string, int> punktuationMarksStatistics = Program.GetPunctuationMarksStatistics(textBox1.Text);
            chart3.Series["PunktuationMarksStatistics"].Points.DataBindXY(punktuationMarksStatistics.Keys, punktuationMarksStatistics.Values);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SizeF sizeF = new SizeF(1, 1);
            tableLayoutPanel1.Scale(sizeF);
        }
    }
}
