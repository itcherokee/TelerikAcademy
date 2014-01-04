namespace CalculateExpression.ReversePolishNotation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class ReversePolishNotation
    {
        private const char FunctionArgumentSeparator = ',';
        private static readonly string[] AllowedTokens =
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            ".", ",", "+", "-", "*", "/", "(", ")",
            "ln", "sqrt", "pow"
        };

        private static readonly char[] Operators = { '+', '-', '*', '/' };
        private static readonly byte[] OperatorsPrecedence = { 1, 1, 2, 2 };
        private static readonly string[] Functions = { "ln", "sqrt", "pow" };
        private static readonly char[] Numbers = { '0', '1', '2', '3', '4', '4', '5', '6', '7', '8', '9', '.' };
        private static readonly char[] Parenthesis = { '(', ')' };

        // Handles user input of expression in one line 
        // Checks does expression is valid (including numbers)
        public static string[] EnterExpression(string infixExpression = null)
        {
            bool isValidInput = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (string.IsNullOrEmpty(infixExpression))
                {
                    Console.WriteLine("Enter the expression on one line (space is ommited).\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Expression: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                string[] tokens = Parse(string.IsNullOrEmpty(infixExpression) ? Console.ReadLine() : infixExpression);
                try
                {
                    if (tokens.Length == 0)
                    {
                        throw new FormatException("No any expression entered!");
                    }

                    if (tokens.Where(token => !AllowedTokens.Contains(token)).Any(token => token.Any(symbol => !Numbers.Contains(symbol))))
                    {
                        throw new FormatException("There is invalid number/symbol/function!");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    return tokens;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return new string[0];
        }

        // Read expression from Console, clears empty spaces and split by tokens
        public static string[] Parse(string input)
        {
            List<string> result = new List<string>();
            if (input != null)
            {
                // removes empty spaces from input string
                string cleanInput = string.Join(string.Empty, input.Split(null as string[], StringSplitOptions.RemoveEmptyEntries));
                int startIndex = 0;
                int currentIndex = 0;
                while (currentIndex <= cleanInput.Length - 1)
                {
                    if (Numbers.Contains(cleanInput[currentIndex]))
                    {
                        // number
                        bool isNumberStarted = true;
                        int numberDigitsCounter = 0;
                        while (isNumberStarted && currentIndex + numberDigitsCounter < cleanInput.Length)
                        {
                            if (!Numbers.Contains(cleanInput[currentIndex + numberDigitsCounter]))
                            {
                                isNumberStarted = false;
                            }
                            else
                            {
                                numberDigitsCounter++;
                            }
                        }

                        result.Add(cleanInput.Substring(startIndex, currentIndex + numberDigitsCounter - startIndex));
                        startIndex = currentIndex + numberDigitsCounter;
                        currentIndex = startIndex - 1;
                    }
                    else
                    {
                        // operator, parenthesis or function
                        switch (cleanInput[currentIndex])
                        {
                            case 'l':
                                result.Add(cleanInput.Substring(startIndex, 2));
                                currentIndex++;
                                startIndex = currentIndex + 1;
                                break;
                            case 's':
                                result.Add(cleanInput.Substring(startIndex, 4));
                                currentIndex += 3;
                                startIndex = currentIndex + 1;
                                break;
                            case 'p':
                                result.Add(cleanInput.Substring(startIndex, 3));
                                currentIndex += 2;
                                startIndex = currentIndex + 1;
                                break;
                            default:
                                result.Add(cleanInput.Substring(startIndex, 1));
                                startIndex = currentIndex + 1;
                                break;
                        }
                    }

                    currentIndex++;
                }
            }

            FixOperators(result);
            return result.ToArray<string>();
        }

        // Converts expression to Postfix using Shunting-Yard algorythm
        public static string[] ConvertToPostfix(string[] infixExpression)
        {
            Stack<string> operations = new Stack<string>();
            Queue<string> output = new Queue<string>();
            for (int index = 0; index < infixExpression.Length; index++)
            {
                if (IsNumber(infixExpression[index]))
                {
                    // token is a number
                    output.Enqueue(infixExpression[index]);
                }

                if (IsFunction(infixExpression[index]))
                {
                    // token is a function
                    operations.Push(infixExpression[index]);
                }

                if (IsFunctionArgumentSeparator(infixExpression[index]))
                {
                    // token is a ","
                    bool leftParenthesisFound = false;
                    while (operations.Count > 0)
                    {
                        if (operations.Peek()[0] != Parenthesis[0])
                        {
                            output.Enqueue(operations.Pop());
                        }
                        else
                        {
                            leftParenthesisFound = true;
                            break;
                        }
                    }

                    if (!leftParenthesisFound)
                    {
                        throw new ArgumentException("There is misplaced separator or parentheses were mismatched!");
                    }
                }

                if (IsOperator(infixExpression[index]))
                {
                    // token is operator o1 
                    int indexO1 = Array.IndexOf(Operators, infixExpression[index][0]);
                    byte precedenceO1 = OperatorsPrecedence[indexO1];

                    while (operations.Count > 0 && Operators.Contains(operations.Peek()[0]))
                    {
                        int indexO2 = Array.IndexOf(Operators, operations.Peek()[0]);
                        byte precedenceO2 = OperatorsPrecedence[indexO2];
                        if (precedenceO1 <= precedenceO2)
                        {
                            output.Enqueue(operations.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    operations.Push(infixExpression[index]);
                }

                if (IsLeftParenthesis(infixExpression[index]))
                {
                    // token is "("
                    operations.Push(infixExpression[index]);
                }

                if (IsRightParenthesis(infixExpression[index]))
                {
                    // token is ")"
                    bool leftParenthesisFound = false;
                    while (operations.Count > 0)
                    {
                        if (operations.Peek()[0] != Parenthesis[0])
                        {
                            output.Enqueue(operations.Pop());
                        }
                        else
                        {
                            leftParenthesisFound = true;
                            break;
                        }
                    }

                    if (leftParenthesisFound)
                    {
                        operations.Pop();
                    }

                    if (operations.Count > 0 && Functions.Contains(operations.Peek()))
                    {
                        output.Enqueue(operations.Pop());
                    }

                    if (!leftParenthesisFound)
                    {
                        throw new ArgumentException("There is mismatched parenthesis is the expression!");
                    }
                }

                if (index == infixExpression.Length - 1)
                {
                    // No more tokens -> pop all operations left in the stack
                    while (operations.Count > 0)
                    {
                        // - If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses.
                        if (Parenthesis.Contains(operations.Peek()[0]))
                        {
                            throw new ArgumentException("There are mismatched parenthesis into expression!");
                        }

                        output.Enqueue(operations.Pop());
                    }
                }
            }

            return output.ToArray();
        }

        // Calculates the Expression represented in RPN (postfix)
        public static double Calculate(string[] postfixExpression)
        {
            string[] operations = { "+", "-", "*", "/", "ln", "sqrt", "pow" };
            byte[] arguments = { 2, 2, 2, 2, 1, 1, 2 };
            Stack<string> output = new Stack<string>();
            int index = 0;
            string token = string.Empty;
            while (index < postfixExpression.Length)
            {
                token = postfixExpression[index];
                if (IsNumber(token))
                {
                    output.Push(token);
                }
                else
                {
                    // token is an operator (operator here includes both operators and functions).
                    // find out the number of argument required by token (function or operator)
                    byte operatorArgsNumber = arguments[Array.IndexOf(operations, token)];
                    if (output.Count >= operatorArgsNumber)
                    {
                        double result = 0.0;
                        double secondOperand;
                        switch (token)
                        {
                            case "+":
                                result = double.Parse(output.Pop()) + double.Parse(output.Pop());
                                break;
                            case "-":
                                secondOperand = double.Parse(output.Pop());
                                result = double.Parse(output.Pop()) - secondOperand;
                                break;
                            case "*":
                                result = double.Parse(output.Pop()) * double.Parse(output.Pop());
                                break;
                            case "/":
                                secondOperand = double.Parse(output.Pop());
                                result = double.Parse(output.Pop()) / secondOperand;
                                break;
                            case "ln":
                                result = Math.Log(double.Parse(output.Pop()));
                                break;
                            case "sqrt":
                                result = Math.Sqrt(double.Parse(output.Pop()));
                                break;
                            case "pow":
                                secondOperand = double.Parse(output.Pop());
                                result = Math.Pow(double.Parse(output.Pop()), secondOperand);
                                break;
                            default:
                                throw new ArgumentException("Unknown operation discovered in expression!");
                        }

                        // Push the results, if any, back onto the stack.
                        output.Push(result.ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        throw new ArgumentException("There is no sufficient values to proceed with calculation!");
                    }
                }

                index++;
            }

            // if more than one item left in the stack, there was an error within the expression
            if (output.Count != 1)
            {
                throw new ArgumentException("Invalid expression provided for calculation!");
            }

            return double.Parse(output.Pop());
        }

        // Fix the operators (dual "-",  "+-", etc.) in result of Parse method
        // Convert any negative number into arithmetic operation with positive numbers if necessary
        private static void FixOperators(List<string> result)
        {
            for (int index = 1; index < result.Count; index++)
            {
                if (result[index - 1] == "-" && result[index] == "-")
                {
                    result[index - 1] = "+";
                    result.RemoveAt(index);
                }
                else if (result[index - 1] == "-" && result[index] == "+")
                {
                    result.RemoveAt(index);
                }
                else if (result[index - 1] == "+" && result[index] == "-")
                {
                    result.RemoveAt(index - 1);
                }
                else if (result[index - 1] == "+" && result[index] == "+")
                {
                    result.RemoveAt(index - 1);
                }
                else if (index - 1 == 0 && result[index - 1] == "-")
                {
                    // first token is "-", so we add 0 in front
                    result.Insert(0, "0");
                }
                else if (index - 1 == 0 && result[index - 1] == "+")
                {
                    // first token is "+", so we remove it
                    result.RemoveAt(0);
                }
                else if (result[index - 1][0] == FunctionArgumentSeparator && result[index] == "-")
                {
                    // a token immediately after "," is "-", so we insert "0" in order to remove sign
                    result.Insert(index, "0");
                }
            }
        }

        // **************************************************
        // * Help functions for simplifing code readability *
        // **************************************************
        private static bool IsNumber(string number)
        {
            // handle invalid numbers with more than one decimal sign
            if (number.Count(x => x == '.') > 1)
            {
                throw new ArgumentException("Invalid number in the expression!");
            }

            return number.Any(symbol => Numbers.Contains(symbol));
        }

        private static bool IsFunction(string function)
        {
            return Functions.Contains(function);
        }

        private static bool IsFunctionArgumentSeparator(string separator)
        {
            return separator[0] == FunctionArgumentSeparator;
        }

        private static bool IsOperator(string operatorO1)
        {
            return Operators.Contains(operatorO1[0]);
        }

        private static bool IsRightParenthesis(string rightParenthesis)
        {
            return rightParenthesis[0] == Parenthesis[1];
        }

        private static bool IsLeftParenthesis(string leftParenthesis)
        {
            return leftParenthesis[0] == Parenthesis[0];
        }
    }
}