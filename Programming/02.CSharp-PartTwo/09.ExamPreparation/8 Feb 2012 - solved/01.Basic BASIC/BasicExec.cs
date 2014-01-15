namespace BasicBASIC
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public static class BasicExec
    {
        private static readonly StringBuilder Output = new StringBuilder();
        private static long v = 0;
        private static long w = 0;
        private static long x = 0;
        private static long y = 0;
        private static long z = 0;
        private static char[] variables = { 'V', 'W', 'X', 'Y', 'Z' };

        public static void Main()
        {
            List<short> lineNumbers = new List<short>();
            List<string> lineCode = new List<string>();

            while (true)
            {
                var codeLine = Console.ReadLine();

                // RUN command issued
                if (codeLine != null && codeLine[0] == 'R')
                {
                    if (lineCode.Count == 0)
                    {
                        return;
                    }

                    break;
                }

                if (codeLine != null)
                {
                    int endOfLineNumber = codeLine.IndexOf(' ');
                    lineNumbers.Add(short.Parse(codeLine.Substring(0, endOfLineNumber)));
                    lineCode.Add(codeLine.Substring(endOfLineNumber + 1).Replace(" ", string.Empty));
                }
            }

            int index = 0;
            string currentLine = lineCode[index];

            // While STOP command not issued continue interpret code
            while (currentLine[0] != 'S')
            {
                switch (currentLine[0])
                {
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                        long operandOne;
                        long operandTwo;
                        if (char.IsLetter(currentLine[2]))
                        {
                            operandOne = GetValue(currentLine[2]);
                            if (currentLine.Length == 3)
                            {
                                // X=Y
                                AssignValue(currentLine, operandOne);
                            }
                            else
                            {
                                if (char.IsLetter(currentLine[4]))
                                {
                                    // W=X-Y
                                    operandTwo = GetValue(currentLine[4]);
                                    Calculate(currentLine, operandOne, operandTwo);
                                }
                                else
                                {
                                    // Z=Z+1
                                    operandTwo = int.Parse(currentLine.Substring(4));
                                    Calculate(currentLine, operandOne, operandTwo);
                                }
                            }
                        }
                        else if (variables.Contains(currentLine[currentLine.Length - 1]))
                        {
                            // X=3+X
                            operandTwo = GetValue(currentLine[currentLine.Length - 1]);
                            operandOne = int.Parse(currentLine.Substring(2, currentLine.Length - 4));
                            if (currentLine[currentLine.Length - 2] == '+')
                            {
                                AssignValue(currentLine, operandOne + operandTwo);
                            }
                            else
                            {
                                AssignValue(currentLine, operandOne - operandTwo);
                            }
                        }
                        else
                        {
                            // V=-5,
                            operandOne = int.Parse(currentLine.Substring(2));
                            AssignValue(currentLine, operandOne);
                        }

                        index++;
                        break;
                    case 'I':
                        int startOfThen = currentLine.IndexOf('T');
                        bool isTrue = false;
                        long condOperandOne;
                        long condOperandTwo;

                        if (char.IsLetter(currentLine[2]))
                        {
                            condOperandOne = GetValue(currentLine[2]);
                            if (char.IsLetter(currentLine[4]))
                            {
                                // X>Y
                                condOperandTwo = GetValue(currentLine[4]);
                                isTrue = Compare(currentLine, condOperandOne, condOperandTwo);
                            }
                            else
                            {
                                // X>2
                                condOperandTwo = int.Parse(currentLine.Substring(4, startOfThen - 4));
                                isTrue = Compare(currentLine, condOperandOne, condOperandTwo);
                            }
                        }
                        else
                        {
                            // 3>4
                            int signIndex = currentLine.IndexOf('>', 3, startOfThen);
                            if (signIndex != '>')
                            {
                                signIndex = currentLine.IndexOf('<', 3, startOfThen);
                            }
                            else if (signIndex != '<')
                            {
                                signIndex = currentLine.IndexOf('=', 3, startOfThen);
                            }

                            condOperandOne = int.Parse(currentLine.Substring(2, signIndex - 2));
                            condOperandTwo = int.Parse(currentLine.Substring(signIndex + 1, startOfThen - signIndex));
                            isTrue = Compare(currentLine, condOperandOne, condOperandTwo);
                        }

                        // Execute command after THEN
                        if (isTrue)
                        {
                            var currentCommand = currentLine.Substring(startOfThen + 4);
                            switch (currentCommand[0])
                            {
                                case 'V':
                                case 'W':
                                case 'X':
                                case 'Y':
                                case 'Z':
                                    long cmdOperandOne;
                                    if (char.IsLetter(currentCommand[2]))
                                    {
                                        cmdOperandOne = GetValue(currentCommand[2]);
                                        if (currentCommand.Length == 3)
                                        {
                                            // X=Y
                                            AssignValue(currentCommand, cmdOperandOne);
                                        }
                                        else
                                        {
                                            long cmdOperandTwo;
                                            if (char.IsLetter(currentCommand[4]))
                                            {
                                                // W=X-Y
                                                cmdOperandTwo = GetValue(currentCommand[4]);
                                                Calculate(currentCommand, cmdOperandOne, cmdOperandTwo);
                                            }
                                            else
                                            {
                                                // Z=Z+1
                                                cmdOperandTwo = int.Parse(currentCommand.Substring(4));
                                                Calculate(currentCommand, cmdOperandOne, cmdOperandTwo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // V=-5,
                                        cmdOperandOne = int.Parse(currentCommand.Substring(2));
                                        AssignValue(currentCommand, cmdOperandOne);
                                    }

                                    index++;
                                    break;
                                case 'C':
                                    Output.Clear();
                                    index++;
                                    break;
                                case 'P':
                                    Output.AppendLine(GetValue(currentCommand[5]).ToString(CultureInfo.InvariantCulture));
                                    index++;
                                    break;
                                case 'G':
                                    index = lineNumbers.IndexOf(short.Parse(currentCommand.Substring(4)));
                                    break;
                            }
                        }
                        else
                        {
                            index++;
                        }

                        break;
                    case 'C':
                        Output.Clear();
                        index++;
                        break;
                    case 'P':
                        Output.AppendLine(GetValue(currentLine[5]).ToString(CultureInfo.InvariantCulture));
                        index++;
                        break;
                    case 'G':
                        index = lineNumbers.IndexOf(short.Parse(currentLine.Substring(4)));
                        break;
                }

                if (index == lineCode.Count)
                {
                    break;
                }

                currentLine = lineCode[index];
            }

            Console.WriteLine(Output.ToString());
        }

        private static void Calculate(string currentLine, long operandOne, long operandTwo)
        {
            if (currentLine[3] == '+')
            {
                AssignValue(currentLine, operandOne + operandTwo);
            }
            else
            {
                AssignValue(currentLine, operandOne - operandTwo);
            }
        }

        private static bool Compare(string currentLine, long operandOne, long operandTwo)
        {
            if (currentLine[3] == '>')
            {
                return operandOne > operandTwo;
            }

            if (currentLine[3] == '<')
            {
                return operandOne < operandTwo;
            }

            return operandOne == operandTwo;
        }

        private static void AssignValue(string currentLine, long operandOne)
        {
            switch (currentLine[0])
            {
                case 'V':
                    v = operandOne;
                    break;
                case 'W':
                    w = operandOne;
                    break;
                case 'X':
                    x = operandOne;
                    break;
                case 'Y':
                    y = operandOne;
                    break;
                case 'Z':
                    z = operandOne;
                    break;
            }
        }

        private static long GetValue(char variable)
        {
            long value = 0;
            switch (variable)
            {
                case 'V':
                    value = v;
                    break;
                case 'W':
                    value = w;
                    break;
                case 'X':
                    value = x;
                    break;
                case 'Y':
                    value = y;
                    break;
                case 'Z':
                    value = z;
                    break;
            }

            return value;
        }
    }
}
