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
                var fuga = """assd""";

                sr = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fuga)));
            }
            else
            {
                sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 65536);
            }


            var S = sr.ReadLine();

            if (!S.Contains('a'))
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(S.LastIndexOf('a') + 1);


        }
    }

    //よく使うコードなどあれば    
    class Utils
    {
    }
}