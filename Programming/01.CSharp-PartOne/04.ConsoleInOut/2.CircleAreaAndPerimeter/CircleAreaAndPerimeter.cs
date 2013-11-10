using System;

/// <summary>
/// Task: "2. Write a program that reads the radius r of a circle and prints its perimeter and area." 
/// </summary>
public class CircleAreaAndPerimeter
{
    public static void Main()
    {
        Console.Title = "Perimeter and Area of a circle";
        Console.ForegroundColor = ConsoleColor.White;
        double radius = EnterData("Enter the circle radius in order to calculate area and perimeter (cm): ");
        double perimeter = 2d * Math.PI * radius;
        double area = Math.PI * radius * radius;
        Console.WriteLine("The Area is: {0:F5} square cm.", area);
        Console.WriteLine("The Perimeter is: {0:F5} cm.", perimeter);
        Console.ReadKey();
    }

    private static double EnterData(string message)
    {
        bool isValidInput = default(bool);
        double enteredValue = default(double);
        do
        {
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}