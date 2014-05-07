namespace CSharpCode
{
    using System;

    /// <summary>
    /// Task 1: Format correctly the following source code:
    ///         - C# code given in the file events.cs.
    ///
    /// Notes: You can use the "input.txt" file in order to test the operation of the code.
    /// </summary>
    public class Events
    {
        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            bool isRunning = true;
            while (isRunning)
            {
                isRunning = ExecuteNextCommand();
            }

            Console.WriteLine(Messages.Output);
        }

        private static bool ExecuteNextCommand()
        {
            bool exitCode = false;
            string commandToExecute = Console.ReadLine();
            if (commandToExecute != null)
            {
                switch (commandToExecute[0])
                {
                    case 'A':
                        AddEvent(commandToExecute);
                        exitCode = true;
                        break;
                    case 'D':
                        DeleteEvents(commandToExecute);
                        exitCode = true;
                        break;
                    case 'L':
                        ListEvents(commandToExecute);
                        exitCode = true;
                        break;
                    default:
                        exitCode = false;
                        break;
                }
            }

            return exitCode;
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);
            events.AddEvent(date, title, location);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.DeleteEvents(title);
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            events.ListEvents(date, count);
        }

        private static void GetParameters(
            string command,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(command, commandType);
            int firstPipeIndex = command.IndexOf('|');
            int lastPipeIndex = command.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = command.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = command.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = command.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}