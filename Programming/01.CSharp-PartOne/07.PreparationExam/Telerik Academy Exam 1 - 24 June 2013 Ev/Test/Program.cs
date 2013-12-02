using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 39; i++)
            {
                Console.WriteLine("{0} % 3 = {1}",i,i%3);
            }
        }
    }
}
