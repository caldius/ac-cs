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
                abcccaa
                """;

                sr = new Scanner(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new Scanner(Console.OpenStandardInput(), bufferSize: 65536);
            }

            var S = sr.S().ToList();

            S.Sort();

            Console.WriteLine(string.Join("", S));


        }
    }

    class Scanner : StreamReader
    {

        Stream stream;

        int bufferSize;

        public Scanner(Stream stream) : base(stream)
        { this.stream = stream; }

        public Scanner(Stream stream, int bufferSize) : base(stream, bufferSize: bufferSize)
        { this.stream = stream; this.bufferSize = bufferSize; }

        public string S() => this.ReadLine();


    }

    //よく使うコードなどあれば    
    class Utils
    {
        public static IEnumerable<int> GetDiffs(List<int> li) => li.Zip(li.Skip(1), Tuple.Create).Select(x => x.Item2 - x.Item1);
    }
}