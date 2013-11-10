using System;

/// <summary>
/// Task: "8. Write a program that, depending on the user's choice inputs int, 
/// double or string variable. If the variable is integer or double, increases 
/// it with 1. If the variable is string, appends "*" at its end. The program 
/// must show the value of that variable as a console output. Use switch statement."
/// </summary>
public class RecognizeInputType
{
    public static void Main()
    {
        Console.Title = "Recognize user input type";
        bool isValidSelect = false;
        bool isValidInput = true;
        do
        {
            Console.WriteLine("Select the type of the value to enter:");
            Console.WriteLine("1. Integer number (int): ");
            Console.WriteLine("2. Real number (double): ");
            Console.WriteLine("3. Text (string): ");
            Console.Write("Make you selection [1..3]:");
            switch (Console.ReadLine())
            {
                case "1":
                    int inputValueInt = 0;
                    do
                    {
                        Console.Write("Make your input:");
                        isValidInput = int.TryParse(Console.ReadLine(), out inputValueInt);
                        inputValueInt++;
                    }
                    while (!isValidInput);

                    isValidSelect = false;
                    Console.WriteLine("The entered value +1 is: {0}", inputValueInt);
                    break;
                case "2":
                    double inputValueDouble = 0.0;
                    do
                    {
                        Console.Write("Make your input:");
                        isValidInput = double.TryParse(Console.ReadLine(), out inputValueDouble);
                        inputValueDouble++;
                    }
                    while (!isValidInput);

                    isValidSelect = false;
                    Console.WriteLine("The entered value +1 is: {0}", inputValueDouble);
                    break;
                case "3":
                    Console.Write("Make your input:");
                    string inputValueString = Console.ReadLine();
                    inputValueString += "*";
                    isValidSelect = false;
                    Console.WriteLine("The entered value + \"*\" symbol is: {0}", inputValueString);
                    break;
                default:
                    Console.WriteLine("There is no such selector, try again. Press a key...");
                    Console.ReadKey();
                    Console.Clear();
                    isValidSelect = true;
                    break;
            }
        }
        while (isValidSelect);
    }
}