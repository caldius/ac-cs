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
                3 3
                2 1 2
                2 2 3
                2 1 3
                """;

                sr = new Scanner(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new Scanner(Console.OpenStandardInput(), bufferSize: 65536);
            }

            var (N, M) = sr.II();

            var sankaDict = new Dictionary<int, HashSet<int>>();

            for (int i = 1; i < N + 1; i++)
            {
                sankaDict.Add(i, new HashSet<int>() { i });
            }


            for (int i = 0; i < M; i++)
            {
                var (k, Xs) = sr.IIALL();

                foreach (var x in Xs)
                {
                    sankaDict[x].UnionWith(Xs.ToHashSet());
                }

            }

            foreach (var sd in sankaDict)
            {
                if (sd.Value.Count != N)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");

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


        public (int, int) II()
        {
            var hoge = this.ReadLine().Split(" ").Select(int.Parse).ToArray();
            return (hoge[0], hoge[1]);
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