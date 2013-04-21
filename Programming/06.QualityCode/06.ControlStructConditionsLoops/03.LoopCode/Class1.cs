// Refactor the following loop

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopCode
{
    public class Class1
    {
        int i=0;
for (i = 0; i < 100;) 
{
   if (i % 10 == 0)
   {
   	Console.WriteLine(array[i]);
   	if ( array[i] == expectedValue ) 
   	{
   	   i = 666;
   	}
   	i++;
   }
   else
   {
        Console.WriteLine(array[i]);
   	i++;
   }
}
// More code here
if (i == 666)
{
    Console.WriteLine("Value Found");
}

    }
}
