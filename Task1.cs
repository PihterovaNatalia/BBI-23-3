using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        abstract class BaseData
        {
            protected string name;
            public double time;

            protected int distance;

            protected BaseData(string name, double time, int distance)
            {
                this.name = name;
                this.time = time;
                this.distance = distance;
            }

            public void show()
            {
                Console.WriteLine("{0} метров {1, 10}: {2:f1} сек.", distance, name, time);
            }

        }

        class Run100 : BaseData
        {
            public Run100(string name, double time) : base(name, time, 100) { }
        }

        class Run500 : BaseData
        {
            public Run500(string name, double time) : base(name, time, 500) { }
        }

        static void Main(string[] args)
        {
            const int N = 10;
            string[] surnames = {
                "Kuznetsova",
                "Sokolova",
                "Popova",
                "Volkova",
                "Kovalenko",
                "Zaitseva",
                "Golubeva",
                "Bogdanova",
                "Mironova",
            };
            Random rand = new Random();
            Run100[] rd100 = new Run100[N];
            for (int i = 0; i < N; i++)
            {
                string surname = surnames[rand.Next(surnames.Length - 1)];
                rd100[i] = new Run100(surname, rand.NextDouble() * 10 + 12);
            }
            Run500[] rd500 = new Run500[N];
            for (int i = 0; i < N; i++)
            {
                string surname = surnames[rand.Next(surnames.Length - 1)];
                rd500[i] = new Run500(surname, rand.NextDouble() * 10 + 70);
            }
            var query1 = rd100.OrderBy(x => x.time);
            var query2 = rd500.OrderBy(x => x.time);
            Console.WriteLine("Бег 100м.");
            foreach (BaseData item in query1) item.show();
            Console.WriteLine("Бег 500м.");
            foreach (BaseData item in query2) item.show();
        }
    }
}
