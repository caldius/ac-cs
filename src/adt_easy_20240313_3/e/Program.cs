using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {


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

        }
    }

    //よく使うコードなどあれば    
    class Utils
    {
    }
}