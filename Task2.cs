using System;
using System.Linq;

class Program
{
    class JumpData
    {
        private string surname;
        private double[] jumps;
        private double result;
        private string title;

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

        public double getResult()
        {
            return result;
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
        var query_forward = data_forward.OrderBy(x => x.getResult());
        var query_up = data_up.OrderBy(x => x.getResult());
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
