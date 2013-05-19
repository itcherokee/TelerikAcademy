namespace KpkPracticalExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CatalogOfFreeContent
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog cat = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();
            foreach (ICommand item in Parse())
            {
                commandExecutor.ExecuteCommand(cat, item, output); //this is how we do


            }

            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output); //printing the output
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> ins = new List<ICommand>();
            bool end = false;

            do
            {
                string l = Console.ReadLine();
                end = (l.Trim() == "End");
                if (!end)
                {
                    ins.Add(new Command(l));
                }
            }
            while (!end);

            return ins;
        }
    }
}
