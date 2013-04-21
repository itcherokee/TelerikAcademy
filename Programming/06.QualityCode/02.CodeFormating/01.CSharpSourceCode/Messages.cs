namespace CSharpEvents
{
    using System;
    using System.Text;

    internal static class Messages
    {
        private static StringBuilder messageOutput = new StringBuilder();

        public static string MessageOutput
        {
            get
            {
                return messageOutput.ToString();
            }
        }

        public static void EventAdded()
        {
            messageOutput.Append("Event added");
            messageOutput.Append(Environment.NewLine);
        }

        public static void EventDeleted(int eventNumber)
        {
            if (eventNumber == 0)
            {
                NoEventsFound();
            }
            else
            {
                messageOutput.AppendFormat("{0} event deleted", eventNumber);
                messageOutput.Append(Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            messageOutput.Append("No events found");
            messageOutput.Append(Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                messageOutput.Append(eventToPrint);
                messageOutput.Append(Environment.NewLine);
            }
        }
    }
}
