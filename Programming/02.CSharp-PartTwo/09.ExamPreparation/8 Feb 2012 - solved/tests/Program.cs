using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.MaxValue;
            int b = a - 2 + int.Parse(Console.ReadLine());
            Console.WriteLine(Calc(b*b, int.MaxValue));

        }

        static int Calc(int number1, int number2)
        {
            return checked(number1 - number2);
        }
    }
}
