using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftRewards
{
    class Program
    {
        public static List<string> dict = new List<string>();

        static void Main(string[] args)
        {
            LoadDict();
            Console.WriteLine($"Loaded {dict.Count()} words");
            var rng = new Random();
            for (var i=0;i<34; i++)
            {
                var query = GenQuery();
                System.Diagnostics.Process.Start("cmd", $"/C start microsoft-edge:https://www.bing.com/search?q={query}");
                SleepFor(rng.Next(1200, 6000));
            }
        }

        private static void LoadDict()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream resource = assembly.GetManifestResourceStream("MicrosoftRewards.words.txt");
            string line;
            using (StreamReader sr = new StreamReader(resource))
                while ((line = sr.ReadLine()) != null)
                    dict.Add(line);
        }

        private static string GenQuery()
        {
            var rng = new Random();
            var sb = new StringBuilder();
            for (var i=0; i<5; i++)
            {
                if (i > 0 && rng.NextDouble() < 0.5) continue;
                sb.Append(dict.Skip(rng.Next(0, dict.Count()-1)).Take(1).First());
                sb.Append("+");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private static void SleepFor(int v)
        {
            Task.Delay(v).Wait();
        }
    }
}
