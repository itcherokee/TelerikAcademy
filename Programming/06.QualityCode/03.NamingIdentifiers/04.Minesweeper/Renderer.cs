using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines
{
    public class Renderer : IRenderer

    {

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message, params string[] arguments)
        {
            Console.WriteLine(message);

        }
    }
}
