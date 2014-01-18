// Task description is in the solution folder
namespace CSharpBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CSharpBracketsExec
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string tab = Console.ReadLine();
            List<string> code = new List<string>();
            int indent = 0;
            for (int index = 0; index < lines; index++)
            {
                string line = Console.ReadLine().Trim();
                if (line.Length > 0)
                {
                    indent = Parse(code, line, tab, indent);
                }
            }

            /// StreamWriter sw = new StreamWriter(new FileStream("../../output.txt", FileMode.Create));
            /// Console.SetOut(sw); 

            Console.WriteLine(string.Join("\n", code));

            /// sw.Close();
        }

        private static int Parse(IList<string> code, string originalLine, string tab, int indent)
        {
            char[] brackets = { '{', '}' };
            string line = originalLine;
            int bracketTabCounter = indent;
            int codeTabCounter = indent;
            bool whitespaceFound = false;
            int index = 0;

            StringBuilder currentLineCode = new StringBuilder();
            StringBuilder currentLineBrackets = new StringBuilder();
            while (index < line.Length)
            {
                // Check for openning bracket
                if (line[index].Equals(brackets[0]))
                {
                    for (int i = 0; i < bracketTabCounter; i++)
                    {
                        currentLineBrackets.Append(tab);
                    }

                    currentLineBrackets.Append(line[index]);
                    code.Add(currentLineBrackets.ToString());
                    codeTabCounter = bracketTabCounter + 1;
                    bracketTabCounter++;
                    currentLineBrackets.Clear();
                    currentLineCode.Clear();
                    index++;
                    continue;
                }

                // Check for closing bracket
                if (line[index].Equals(brackets[1]))
                {
                    codeTabCounter = bracketTabCounter - 1;
                    bracketTabCounter--;
                    for (int i = 0; i < bracketTabCounter; i++)
                    {
                        currentLineBrackets.Append(tab);
                    }

                    currentLineBrackets.Append(line[index]);
                    code.Add(currentLineBrackets.ToString());
                    currentLineBrackets.Clear();
                    currentLineCode.Clear();
                    index++;
                    continue;
                }

                while (index < line.Length && !brackets.Contains(line[index]))
                {
                    if (line[index].Equals(' '))
                    {
                        if (whitespaceFound)
                        {
                            index++;
                            continue;
                        }

                        whitespaceFound = true;
                    }
                    else
                    {
                        whitespaceFound = false;
                    }

                    currentLineCode.Append(line[index]);
                    index++;
                }

                if (currentLineCode.Length == 1 && currentLineCode[0].Equals(' '))
                {
                    currentLineCode.Clear();
                    whitespaceFound = false;
                    continue;
                }

                string result = currentLineCode.ToString().Trim();

                for (int i = 0; i < codeTabCounter; i++)
                {
                    result = result.Insert(0, tab);
                }

                code.Add(result);
            }

            return codeTabCounter;
        }
    }
}