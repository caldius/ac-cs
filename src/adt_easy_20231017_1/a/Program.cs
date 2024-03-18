using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                023456789
                """;

                sr = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 65536);
            }


            Console.WriteLine(sr.ReadLine() == "Hello,World!" ? "AC" : "WA");
        }
    }

    //よく使うコードなどあれば    
    class Utils
    {
        public static IEnumerable<int> GetDiffs(List<int> li) => li.Zip(li.Skip(1), Tuple.Create).Select(x => x.Item2 - x.Item1);
    }
}