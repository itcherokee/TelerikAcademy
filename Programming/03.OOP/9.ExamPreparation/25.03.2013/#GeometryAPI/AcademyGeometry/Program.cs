using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryAPI;
using System.IO;

namespace GeometryAPI
{
}

namespace GeometryAPI
{
    class Program
    {
        private static FigureController GetFigureController()
        {
            return new ExtendedFigureController();
        }

        static void Main(string[] args)
        {
            var sw = new StreamWriter(new FileStream("../../../output.txt", FileMode.Create));
            Console.SetOut(sw);


            var figController = GetFigureController();

            int figCreationsCount = int.Parse(Console.ReadLine());
            int endCommandsCount = 0;

            while (endCommandsCount < figCreationsCount)
            {
                figController.ExecuteCommand(Console.ReadLine());
                if (figController.EndCommandExecuted)
                {
                    endCommandsCount++;
                }
            }


            sw.Close();
        }
    }
}
