using System;
using System.Linq;

class Program
{
    class JumpData
    {
        private string surname;
        private double[] jumps;
        public double result { get; set; }

        protected string title;

        public JumpData(string surname, string title)
        {
            this.surname = surname;
            this.title = title;
            jumps = new double[3];
            Random rand = new Random();
            result = 100;
            for (int i = 0; i < 3; i++)
            {
                jumps[i] = rand.NextDouble() * 20 + 50;
                result = Math.Min(result, jumps[i]);
            }
        }

        public void show()
        {
            Console.WriteLine("{0, 10}, {1, -10}: {2:f3} | {3:f3} | {4:f3} | BEST: {5:f3}", title, surname, jumps[0], jumps[1], jumps[2], result);
        }
    }

    class JumpForward : JumpData
    {
        public JumpForward(string surname) : base(surname, "В длину") { }
    }

    class JumpUp : JumpData
    {
        public JumpUp(string surname) : base(surname, "В высоту") { }
    }


    static void Main(string[] args)
    {
        int N = 10;
        Random rand = new Random();
        JumpData[] data_forward = new JumpData[N];
        JumpData[] data_up = new JumpData[N];
        string[] surnames =
        {
            "Trushina",
            "Agieva",
            "Klochay",
            "Bugaeva",
            "Kamishova",
            "Romanova",
            "Ivanova",
            "Smirnova",
        };
        for (int i = 0; i < N; i++)
        {
            int surname = rand.Next(surnames.Length - 1);
            data_forward[i] = new JumpForward(surnames[surname]);
        }

        for (int i = 0; i < N; i++)
        {
            int surname = rand.Next(surnames.Length);
            data_up[i] = new JumpUp(surnames[surname]);
        }
        var query_forward = data_forward.OrderBy(x => x.result);
        var query_up = data_up.OrderBy(x => x.result);
        Console.WriteLine("Прыжки в длину");
        foreach (JumpData item in query_forward)
        {
            item.show();
        }
        Console.WriteLine("Прыжки в высоту");
        foreach (JumpData item in query_up)
        {
            item.show();
        }
    }
}



    static void Main(string[] args)
    {
        int N = 5;
        double p_answer = 0.80;  // Вероятность ответа на каждый вопрос
        Quest quest = new Quest("Общее", N * 2);
        Quest questRussia = new QuestRussia(N * 2);
        Quest questJapan = new QuestJapan(N);
        string[] q1 =
        {
            "Панда",
            "Карп",
            "Жираф",
            "Аист",
            "Кот",
            "Волк",
            "Заяц",
            "Медведь",
        };
        string[] q2 =
        {
            "Терпеливость",
            "Ум",
            "Дисциплинарность",
            "Традиции",
        };
        string[] q3 =
        {
            "Катана",
            "Аниме",
            "Суши",
            "Горы",
            "Сакура",
        };
        Random rand = new Random();
        for (int i = 0; i < N; i++)
        {
            string[] answers = { q1[rand.Next(q1.Length)], q2[rand.Next(q2.Length)], q3[rand.Next(q3.Length)] };
            for (int j = 0; j < 3; j++)
            {
                double p = rand.NextDouble();
                if (p > p_answer)
                {
                    answers[j] = "";
                }
            }
            questRussia.append(answers);
            quest.append(answers);
        }
        for (int i = 0; i < N; i++)
        {
            string[] answers = { q1[rand.Next(q1.Length)], q2[rand.Next(q2.Length)], q3[rand.Next(q3.Length)] };
            for (int j = 0; j < 3; j++)
            {
                double p = rand.NextDouble();
                if (p > p_answer)
                {
                    answers[j] = "";
                }
            }
            questJapan.append(answers);
            quest.append(answers);
        }

        quest.show();
        questRussia.show();
        questJapan.show();
    }
}
