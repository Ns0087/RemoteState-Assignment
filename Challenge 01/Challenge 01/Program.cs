using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Console.WriteLine("Hello World");
            //    Console.ReadKey();

            var arr = new int[5];
            arr[2] = 12;
            arr[3] = 12;
            arr[4] = 12;
            arr[5] = 12;


            for (int i = 0; i < arr.Length; i++ >{
                Console.WriteLine(arr[i]);
            }

                Console.ReadKey());
        }
    }
}
