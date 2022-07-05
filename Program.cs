using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextStatistics
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Dictionary<int, double> GetWordLenghtStatistics(string text)
        {
            Dictionary<int, double> statistics = new Dictionary<int, double>();

            string[] words = text.Split(new char[] { ' ', ',', '.', ':', '!', '?', '\t', '\n', '\r' });

            SortedDictionary<int, int> lenghtAndCount = new SortedDictionary<int, int>();

            int countOfNotNullWords = 0;
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    countOfNotNullWords++;

                    if (lenghtAndCount.ContainsKey(word.Length) == true)
                    {
                        lenghtAndCount[word.Length] = lenghtAndCount[word.Length] + 1;
                    }
                    else
                    {
                        lenghtAndCount.Add(word.Length, 1);
                    }
                }
            }

            foreach (int lenght in lenghtAndCount.Keys)
            {
                statistics.Add(lenght, (double)lenghtAndCount[lenght] / countOfNotNullWords * 100);
            }

            return statistics;
        }

        public static Dictionary<string, double> GetCharStatistics(string text)
        {
            text = text.ToLower();

            Dictionary<string, double> statistics = new Dictionary<string, double>();

            SortedDictionary<char, int> charAndCount = new SortedDictionary<char, int>();
            for (char c = 'а'; c <= 'я'; c++)
            {
                charAndCount.Add(c, 0);
            }

            List<char> alphabet = charAndCount.Keys.ToList();
            foreach (char c in alphabet)
            {
                charAndCount[c] = text.Count(f => f == c);
            }

            foreach (char currentChar in charAndCount.Keys)
            {
                if (charAndCount[currentChar] > 0)
                {
                    statistics.Add(currentChar.ToString(), (double)charAndCount[currentChar] / text.Length);
                }
            }

            return statistics;
        }

        public static Dictionary<string, int> GetPunctuationMarksStatistics(string text)
        {
            Dictionary<string, int> statistics = new Dictionary<string, int>();

            SortedDictionary<char, int> markAndCount = new SortedDictionary<char, int>
            {
                { '.', 0 },
                { ',', 0 },
                { '-', 0 },
                { ':', 0 },
                { ';', 0 },
                { '!', 0 },
                { '?', 0 }
            };

            List<char> marks = markAndCount.Keys.ToList();
            foreach(char mark in marks)
            {
                markAndCount[mark] = text.Count(f => f == mark);
            }

            foreach (char mark in markAndCount.Keys)
            {
                if (markAndCount[mark] > 0)
                {
                    statistics.Add(mark.ToString(), markAndCount[mark]);
                }
            }

            return statistics;
        }
    }
}
