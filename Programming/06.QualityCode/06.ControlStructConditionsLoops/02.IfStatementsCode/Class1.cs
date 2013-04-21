// Refactor the following if statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStatementsCode
{
    public class Class1
    {
        Potato potato;
//... 
if (potato != null)
   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
	Cook(potato);

    }
}
