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
                10
                22 75 26 45 72 81 47 29 97 2
               """;

                sr = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 65536);
            }

            var N = int.Parse(sr.ReadLine().Trim());

            var Hs = sr.ReadLine().Trim().Split().Select(x => int.Parse(x)).ToList();

            Console.WriteLine(Hs.IndexOf(Hs.Max()) + 1);
        }
    }

    //よく使うコードなどあれば    
    class Utils
    {
    }
}