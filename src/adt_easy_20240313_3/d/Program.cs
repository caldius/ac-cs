using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr;

            if (args.Length > 0 && args[0] == "DEBUGGING")
            {
                //F5実行時
                var fuga = """
                assd
                    fsd

                fsafas
                """;

                sr = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 65536);
            }

            var N = int.Parse(sr.ReadLine().Trim());

            var As = sr.ReadLine().Trim().Split().Select(x => int.Parse(x)).ToList();

            // var curr = 0;

            var cutts = new List<int> { 0 };

            As.ForEach((x) => { cutts.Add((cutts.Last() + x) % 360); });

            cutts.Add(360);

            cutts.Sort();

            var diffs = cutts.Zip(cutts.Skip(1), Tuple.Create).Select(x => x.Item2 - x.Item1);

            Console.WriteLine(diffs.Max());

        }
    }

    //よく使うコードなどあれば    
    class Utils
    {
    }
}