using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static char Task1(string read_s)
    {
        string s = read_s.ToLower();
        int[] stat = new int[256 * 256];
        for (int i = 0; i < stat.Length; i++)
        {
            stat[i] = 0;
        }
        for (int i = 0; i < s.Length; i++)
        {
            stat[(int)s[i]] += 1;
        }
        char max_c = s[0];
        int max_val = stat[max_c];
        for (int i = 1; i < s.Length; i++)
        {
            if (max_val < stat[(int)s[i]])
            {
                max_val = stat[(int)s[i]];
                max_c = s[i];
            }
        }

        Console.WriteLine("В слове '{0}' самая частая буква '{1}'. Кол-во повторений: {2}", read_s, max_c, max_val);
        return max_c;
    }

    static string Task2(string s)
    {
       
        string res = "";
        int diff = 1071 - 1040 + 1;
        for (int i = 0; i < s.Length; i++)
        {
            int code = (int)s[i];
            if ((code < 1040) || (code > 1103))
            {
                res += s[i];
                continue;
            }
            if (code >= 1072) 
            {
                code += 10;
                if (code > 1103)
                {
                    code -= diff;
                }
            } else { 
                code += 10;
                if (code > 1071)
                {
                    code -= diff;
                }
            }
            res += (char)code;
        }
        Console.WriteLine(res);
        return res;
    }

    static void Task3()
    {
        string dirName = "R:\\Solution"; 
            Directory.CreateDirectory(dirName);

        if (!File.Exists(dirName + "\\cw2_1.json")) 
            File.Create(dirName + "\\cw2_1.json");

        if (!File.Exists(dirName + "\\cw2_2.json"))
            File.Create(dirName + "\\cw2_2.json");
    }


    static void Task4()
    {
        string dirName = "R:\\Solution"; 
        if (!Directory.Exists(dirName))
            Directory.CreateDirectory(dirName);
        if (!File.Exists(dirName + "\\cw2_1.json"))
        {
            string s = "Hello, world!";
            char res = Task1(s);

            string json = $" {{ \"input\" : \"{s}\", \"output\" : \"{res}\" }}";
            Console.WriteLine($"JSON 1: {json}");

            File.WriteAllText(dirName + "\\cw2_1.json", json);


        } else
        {
            FileStream fstream = new FileStream(dirName + "\\cw2_1.json", FileMode.Open);
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string json = Encoding.Default.GetString(buffer);
            Console.WriteLine($"JSON 1: {json}");
        }

        if (!File.Exists(dirName + "\\cw2_2.json"))
        {
            string s = "Алфавит Цезаря!";
            string res = Task2(s);

            string json = $" {{ \"input\" : \"{s}\", \"output\" : \"{res}\" }}";
            Console.WriteLine($"JSON 2: {json}");

            File.WriteAllText(dirName + "\\cw2_2.json", json);
        }
        else
        {
            FileStream fstream = new FileStream(dirName + "\\cw2_2.json", FileMode.Open);
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string json = Encoding.Default.GetString(buffer);
            Console.WriteLine($"JSON 2: {json}");
        }

    }

    static void Main(string[] args)
    {
        Task4();
    }
}