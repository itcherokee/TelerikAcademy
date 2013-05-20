namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Phonebook
    {
        private static IPhonebookRepository bookOfPhones = new PhonebookRepository();
        private static readonly StringBuilder output = new StringBuilder();

        public static void Main()
        {
            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "End" || inputData == null)
                {
                    break;
                }

                int openingBracketIndex = inputData.IndexOf('(');
                string command = inputData.Substring(0, openingBracketIndex);
                if ((openingBracketIndex == -1) || (!inputData.EndsWith(")")))
                {
                    Log("Invalid formated parameters in the entry found.");
                    break;
                }

                string inputCommandParameters = inputData.Substring(openingBracketIndex + 1, inputData.Length - openingBracketIndex - 2);
                string[] parameters = inputCommandParameters.Split(',');
                for (int index = 0; index < parameters.Length; index++)
                {
                    parameters[index] = parameters[index].Trim();
                }

                if ((command == "AddPhone") && (parameters.Length >= 2))
                {
                    CommandInterpretator("AddPhone", parameters);
                }
                else if ((command == "ChangePhone") && (parameters.Length == 2))
                {
                    CommandInterpretator("ChangePhone", parameters);
                }
                else if ((command == "List") && (parameters.Length == 2))
                {
                    CommandInterpretator("List", parameters);
                }
                else
                {
                    throw new InvalidOperationException("Not a valid cammand provided in input stream: " + command);
                }
            }

            Console.Write(output);
        }

        private static void CommandInterpretator(string command, string[] commandParameteres)
        {
            if (command == "AddPhone")
            {
                string personName = commandParameteres[0];
                var phoneNumbers = commandParameteres.Skip(1).ToList();

                bool flag = bookOfPhones.AddPhone(personName, phoneNumbers);
                if (flag)
                {
                    Log("Phone entry created");
                }
                else
                {
                    Log("Phone entry merged");
                }
            }

            if (command == "ChangePhone")
            {
                int numberOfChanges = bookOfPhones.ChangePhone(commandParameteres[0], commandParameteres[1]);
                Log(numberOfChanges + " numbers changed");
            }

            if (command == "List")
            {
                int startIndex = int.Parse(commandParameteres[0]);
                int count = int.Parse(commandParameteres[1]);
                IEnumerable<Record> entries = bookOfPhones.ListEntries(startIndex, count);
                if (entries != null)
                {
                    foreach (var entry in entries)
                    {
                        Log(entry.ToString());
                    }
                }
                else
                {
                    Log("Invalid range");
                }
            }
        }

        private static void Log(string text)
        {
            output.AppendLine(text);
        }
    }
}
