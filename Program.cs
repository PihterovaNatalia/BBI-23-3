using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

class Program
{

    abstract class StringTask
    {
        protected string text;

        protected StringTask(string text)
        {
            this.text = text;
        }

        protected IEnumerable<string> getWords()
        {
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuation));
            return words;
        }
    }

    class StatisticTask : StringTask
    {
        private int[] data = new int[256 * 256];
        public StatisticTask(string text) : base(text) {
            string new_text = text.ToLower();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            for (int i = 0; i < text.Length; i++)
            {
                data[new_text[i]] += 1;
            }
        }
        public override string ToString()
        {
            string res = "Частотный анализ букв русского алфавита:\n";
            for (char c = 'а'; c <= 'я'; c++)
            {
                if (data[(int)c] == 0)
                {
                    res += c + ": Нет\n";
                } else
                {
                    res += c + ": " + data[(int)c] + " раз(а) - " + ((float)data[(int)c]/text.Length * 100).ToString() + "%\n";
                }
                
            }
            return res;
        }
    }

    class SplitTask : StringTask
    {
        private string res;
        public SplitTask(string text) : base(text)
        {
            res = "";
            var words = getWords();

            int free_space = 50;
            int row_i = 0;
            bool is_new_row = true;
            foreach (string word in words)
            {
                if (!is_new_row)
                {
                    if (free_space - word.Length - 1 >= 0)
                    {
                        res += " " + word;
                        free_space -= word.Length - 1;
                    } else
                    {
                        res += "\n" + word;
                        free_space = 50 - word.Length;
                    }
                } else {
                    res = word;
                    free_space -= word.Length;
                    is_new_row = false;
                }
            }

        }

        public override string ToString()
        {
            return res;
        }
    }

    class StatFirstTask : StringTask
    {
        private int[] data;
        public StatFirstTask(string text) : base(text)
        {
            data = new int[5000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            var words = getWords();
            foreach (string word in words)
            {
                if (word.Length == 0)
                {
                    continue;
                }
                data[(int)word[0]]++;
            }
        }

        public override string ToString()
        {
            string res = "Частотный анализ:\n";
            string used = "";
            int max_val = 0;
            char max_c = ' ';

            var words = getWords();

            while (max_val != -1)
            {
                max_val = -1;
                max_c = ' ';
                foreach (string word in words)
                {
                    if (word.Length == 0)
                    {
                        continue;
                    }
                    char symbol = word[0];
                    if ((!used.Contains(symbol)) && (max_val < data[(int)symbol]))
                    {
                        max_val = data[(int)symbol];
                        max_c = symbol;
                    }
                }
                if (max_val != -1) {
                    used += max_c;
                    res += $"-> {max_c} - {max_val} раз(а)\n";
                }
            }
            return res;
        }

    }

    class SubStringTask : StringTask
    {
        private string res;
        public SubStringTask(string text, string sub) : base(text)
        {
            res = "";
            var words = getWords();
            foreach (var word in words)
            {
                if (words.Contains(sub))
                {
                    res += " " + word;
                }
            }
        }
        public override string ToString()
        {
            return res;
        }
    }

    class SurnameTask : StringTask
    {
        private IEnumerable<string> words;
        public SurnameTask(string text) : base(text)
        {
            words = getWords();
        }
        public override string ToString()
        {
            string res = "Фамилии:\n";
            foreach (var surname in words.OrderBy(x => x))
            {
                res += $"{surname}, ";
            }
            return res;
        }
    }

    class NumberTask : StringTask
    {
        private int cnt;
        public NumberTask(string text) : base(text)
        {
            var words = getWords();
            foreach (var word in words)
            {
                int n;
                bool isNumeric = int.TryParse(word, out n);
                if (isNumeric)
                {
                    cnt += n;
                }
            }
        }
        public override string ToString()
        {
            string res = "Сумма чисел: " + cnt.ToString();
            return res;
        }
    }

    static void Main(string[] args)
    {
        string s = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.!";
        string surnames = "Иванов\nПетров\nСмирнов\nСоколов\nКузнецов\nПопов\nЛебедев\nВолков\nКозлов\nНовиков\nИванова\nПетрова\nСмирнова";

        // StatisticTask stat = new StatisticTask(s);
        // Console.WriteLine(stat.ToString());

        // SurnameTask sp = new SurnameTask(surnames);
        // Console.WriteLine(sp.ToString());

        StatFirstTask nt = new StatFirstTask(s);
        Console.WriteLine(nt.ToString());
    }
}