using System;
using System.Linq;

class Program
{
    class AnswerData
    {
        protected string answer;
        protected double percentage;

        public string getAnswer()
        {
            return answer;
        }

        public double getPercentage()
        {
            return percentage;
        }

        public AnswerData(string answer, double percentage = 0)
        {
            this.answer = answer;
            this.percentage = percentage;
        }
    }

    class Quest
    {
        private string[][] questions;
        private int currIndex;
        protected string country;

        public Quest(string country, int max_questions = 100)
        {
            this.country = country;
            questions = new string[3][];
            for (int i = 0; i < 3; i++)
            {
                questions[i] = new string[max_questions];
            }
            currIndex = 0;

        }

        public void append(string[] answers)
        {
            if (answers.Length != 3)
            {
                Console.WriteLine("Должно быть 3 ответа");
                return;
            }
            for (int i = 0; i < answers.Length; i++)
            {
                questions[i][currIndex] = answers[i];
            }
            currIndex++;
        }

        AnswerData[] get_top(int i_question)
        {
            AnswerData[] data = new AnswerData[questions[i_question].Length];
            int dataIndex = 0;
            string[] currQuestions = questions[i_question];
            var query = currQuestions.OrderBy(x => x);

            string currQuestion = query.First();
            int currCnt = 0; // Нуль, т.к. в цикле он все равно прибавится
            int nullCnt = 0;
            foreach (string item in query)
            {

                if (item == "")
                {
                    nullCnt++;
                }

                if (item == currQuestion)
                {
                    currCnt++;
                }
                else
                {
                    if (currQuestion != "")
                    {
                        data[dataIndex] = new AnswerData(currQuestion, currCnt / (double)(currQuestions.Length - nullCnt) * 100);
                        dataIndex++;
                    }

                    currCnt = 1;
                    currQuestion = item;
                }
            }

            data[dataIndex] = new AnswerData(currQuestion, currCnt / (double)(currQuestions.Length - nullCnt) * 100);
            dataIndex++;

            return data;
        }

        public void show()
        {
            Console.WriteLine("Вопросы по стране: {0}", country);
            for (int i = 0; i < 3; i++)
            {
                AnswerData[] data = get_top(i);
                Console.WriteLine("Вопрос #{0}\n---", i + 1);
                int cnt = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    if (data[j] != null)
                    {
                        Console.WriteLine("{0, 4:f1}% : {1}", data[j].getPercentage(), data[j].getAnswer());
                        cnt++;
                        if (cnt >= 5)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("-----", i + 1);
            }
        }
    }

    class QuestRussia : Quest
    {
        public QuestRussia(int n) : base("Россия", n) { }
    }

    class QuestJapan : Quest
    {
        public QuestJapan(int n) : base("Япония", n) { }
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