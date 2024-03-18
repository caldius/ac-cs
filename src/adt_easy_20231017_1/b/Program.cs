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

            Scanner sr;

            if (args.Length > 0 && args[0] == "DEBUGGING")
            {
                //F5実行時
                var fuga = """
                023456789
                """;

                sr = new Scanner(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new Scanner(Console.OpenStandardInput(), bufferSize: 65536);
            }


            var hs = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            // var S = sr.ReadLine().ToArray();
            var S = sr.S();

            Console.WriteLine(hs.Where(x => !S.Contains(x)).First());


        }
    }

    class Scanner : StreamReader
    {

        Stream stream;

        int bufferSize;

        public Scanner(Stream stream) : base(stream)
        {
            this.stream = stream;
        }

        public Scanner(Stream stream, int bufferSize) : base(stream, bufferSize: bufferSize)
        {
            this.stream = stream;
            this.bufferSize = bufferSize;
        }

        public string S() => this.ReadLine();


    }

    //よく使うコードなどあれば    
    class Utils
    {
        public static IEnumerable<int> GetDiffs(List<int> li) => li.Zip(li.Skip(1), Tuple.Create).Select(x => x.Item2 - x.Item1);
    }
}