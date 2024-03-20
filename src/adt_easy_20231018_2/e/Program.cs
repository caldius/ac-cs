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
                php
                """;

                sr = new Scanner(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new Scanner(Console.OpenStandardInput(), bufferSize: 65536);
            }

            var S = sr.S();

            if (S.Replace("a", "").Length == 0)
            {
                Console.WriteLine("Yes");
                return;
            }

            var leftACountXX = 0;
            var rightACountXX = 0;

            foreach (var c in S)
            {
                if (c != 'a') { break; }
                leftACountXX++;
            }

            foreach (var c in S.Reverse())
            {
                if (c != 'a') { break; }
                rightACountXX++;
            }

            if (leftACountXX > rightACountXX)
            {
                Console.WriteLine("No");
                return;
            }

            var maybeKaibun = new String('a', (rightACountXX - leftACountXX)) + S;

            if (maybeKaibun == new string(maybeKaibun.Reverse().ToArray()))
            {
                Console.WriteLine("Yes");
                return;
            }
            else
            {
                Console.WriteLine("No");
                return;
            }

        }
    }

    class Scanner : StreamReader
    {
        public Scanner(Stream stream) : base(stream) { }
        public Scanner(Stream stream, int bufferSize) : base(stream, bufferSize: bufferSize) { }

        public string S() => this.ReadLine();

        public (string, string) SS()
        {
            var hoge = this.ReadLine().Split(" ");
            return (hoge[0], hoge[1]);
        }
        public int I() => int.Parse(this.ReadLine());


        public (int, int) II()
        {
            var hoge = this.ReadLine().Split(" ").Select(int.Parse).ToArray();
            return (hoge[0], hoge[1]);
        }

        public (int, int, int) III()
        {
            var hoge = this.ReadLine().Split(" ").Select(int.Parse).ToArray();
            return (hoge[0], hoge[1], hoge[2]);
        }


        public int[] IALL() => this.ReadLine().Split(" ").Select(int.Parse).ToArray();

        public (int, int[]) IIALL()
        {
            var hoge = this.ReadLine().Split(" ").Select(int.Parse).ToArray();
            return (hoge[0], hoge.Skip(1).ToArray());
        }

    }

    //よく使うコードなどあれば    
    class Utils
    {
        public static IEnumerable<int> GetDiffs(List<int> li) => li.Zip(li.Skip(1), Tuple.Create).Select(x => x.Item2 - x.Item1);
    }
}