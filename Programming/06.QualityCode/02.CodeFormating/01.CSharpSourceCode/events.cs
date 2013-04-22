namespace CSharpEvents
{
    using System;

    public class Events
    {
        private static EventHolder eventsInput = new EventHolder();

        public static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                isRunning = ExecuteNextCommand();
            }

            Console.WriteLine(Messages.MessageOutput);
        }

        private static bool ExecuteNextCommand()
        {
            string commandToExecute = Console.ReadLine();
            char commandFirstLetter = commandToExecute[0];
            if (commandFirstLetter == 'A')
            {
                AddEvent(commandToExecute);
                return true;
            }

            if (commandFirstLetter == 'D')
            {
                DeleteEvents(commandToExecute);
                return true;
            }

            if (commandFirstLetter == 'L')
            {
                ListEvents(commandToExecute);
                return true;
            }

            return false;
        }

        private static void AddEvent(string commandForExecution)
        {
            DateTime eventDate;
            string eventTitle;
            string eventLocation;
            GetParameters(commandForExecution, "AddEvent", out eventDate, out eventTitle, out eventLocation);
            eventsInput.AddEvent(eventDate, eventTitle, eventLocation);
        }

        private static void DeleteEvents(string commandForExecution)
        {
            string title = commandForExecution.Substring("DeleteEvents".Length + 1);
            eventsInput.DeleteEvents(title);
        }

        private static void ListEvents(string commandForExecution)
        {
            int pipeIndex = commandForExecution.IndexOf('|');
            DateTime date = GetDate(commandForExecution, "ListEvents");
            string countString = commandForExecution.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            eventsInput.ListEvents(date, count);
        }

        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string commandForExecution, string commandType)
        {
            DateTime date = DateTime.Parse(commandForExecution.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}