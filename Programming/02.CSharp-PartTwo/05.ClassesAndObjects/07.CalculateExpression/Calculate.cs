using System;
using System.Collections.Generic;
using CalculateExpression.ReversePolishNotation;

/// <summary>
/// Task: "7. * Write a program that calculates the value of given arithmetical expression. 
/// The expression can contain the following elements only:
///     - Real numbers, e.g. 5, 18.33, 3.14159, 12.6
///     - Arithmetic operators: +, -, *, / (standard priorities)
///     - Mathematical functions: ln(x), sqrt(x), pow(x,y)
///     - Brackets (for changing the default priorities)
/// Examples:
/// (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) -> ~ 10.6
/// pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) -> ~ 21.22
/// Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation"."
/// </summary>
public class Calculate
{
    private static byte[] options = { 1, 2, 3 };

    public static void Main()
    {
        Console.Title = "Calculate Arithmetic Expression";
        bool errorDiscovered = false;
        string errorMessage = string.Empty;
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please select option:");
            Console.WriteLine("1. Manual enter the expression.");
            Console.WriteLine("2. Use predefined expressions.");
            Console.WriteLine("3. Exit.");
            Console.Write("Your selection is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            byte selection = 0;
            bool isValidSelection = byte.TryParse(Console.ReadLine(), out selection);
            if (isValidSelection)
            {
                switch (selection)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            var manualInput = ReversePolishNotation.EnterExpression();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nYour Expression in postfix (RPN) notation: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            manualInput = ReversePolishNotation.ConvertToPostfix(manualInput);
                            Console.WriteLine(string.Join(" ", manualInput));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Result after calculation is: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(ReversePolishNotation.Calculate(manualInput));
                        }
                        catch (ArgumentException e)
                        {
                            errorDiscovered = true;
                            errorMessage = e.Message;
                        }

                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;
                    case 2:
                        string[] expressions = { string.Empty, "(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)", "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)" };
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Please select predefined expression:");
                            Console.Write("1: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(expressions[1]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("2: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(expressions[2]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("3. Return to Main menu.");
                            Console.Write("Your selection is: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            bool returnToMainMenu = false;
                            isValidSelection = byte.TryParse(Console.ReadLine(), out selection);
                            if (isValidSelection)
                            {
                                switch (selection)
                                {
                                    case 1:
                                    case 2:
                                        try
                                        {
                                            var manualInput = ReversePolishNotation.EnterExpression(expressions[selection]);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("\nExpression in postfix (RPN) notation: ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            manualInput = ReversePolishNotation.ConvertToPostfix(manualInput);
                                            Console.WriteLine(string.Join(" ", manualInput));
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("Result after calculation is: ");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine(ReversePolishNotation.Calculate(manualInput));
                                        }
                                        catch (ArgumentException e)
                                        {
                                            errorDiscovered = true;
                                            errorMessage = e.Message;
                                        }

                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        returnToMainMenu = true;
                                        break;
                                    default:
                                        errorDiscovered = true;
                                        errorMessage = "You have selected an invalid option!";
                                        break;
                                }
                            }
                            else
                            {
                                errorMessage = "You have entered not a number!";
                                errorDiscovered = true;
                            }

                            if (errorDiscovered)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(errorMessage);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Press any key...");
                                Console.ReadKey();
                                errorDiscovered = false;
                            }

                            if (returnToMainMenu)
                            {
                                break;
                            }
                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Good Bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        errorDiscovered = true;
                        errorMessage = "You have selected an invalid option!";
                        break;
                }
            }
            else
            {
                errorMessage = "You have entered not a number!";
                errorDiscovered = true;
            }

            if (errorDiscovered)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                errorDiscovered = false;
            }
        }
    }
}