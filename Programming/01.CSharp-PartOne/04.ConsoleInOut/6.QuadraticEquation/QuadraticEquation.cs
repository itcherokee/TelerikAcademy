using System;

class QuadraticEquation
{
    static void Main()
    {
        //Write a program that reads the coefficients a, b and c 
        //of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

        double coefficientA, coefficientB, coefficientC, discriminant, roots;
        //Handling of Console Input
        bool noError = true;
        Console.Title = "Program to solve quadratic equation ax" + '\u00B2' + "+bx+c=0";
        Console.WriteLine("Enter the three coefficients in order to find equation real roots.");
        do
        {
            Console.Write("Coefficient \"а\": ");
            noError = double.TryParse(Console.ReadLine(), out coefficientA);
        } while (!noError);
        do
        {
            Console.Write("Coefficient \"b\": ");
            noError = double.TryParse(Console.ReadLine(), out coefficientB);
        } while (!noError);
        do
        {
            Console.Write("Coefficient \"c\": ");
            noError = double.TryParse(Console.ReadLine(), out coefficientC);
        } while (!noError);
        // Logic of the program starts here
        if ((coefficientA == 0) && (coefficientB == 0) && (coefficientC == 0))
        {
            Console.WriteLine("You have entered only 0 for all coefficients and the result is NaN (not a number) or in other words, there is no solution!");
        }
        else
        {
            if (coefficientA == 0)
            {
                roots = -(coefficientB / (2 * coefficientA));
                Console.WriteLine("For \"a\" was entered 0, so equation is linear and solution is: {0}", -(coefficientC / coefficientB));
            }
            else
            {
                discriminant = Math.Pow(coefficientB, 2) - (4 * coefficientA * coefficientC);
                if (discriminant == 0)
                {
                    roots = -(coefficientB / (2 * coefficientA));
                    Console.WriteLine("The equation has only one real root: {0}", -(coefficientB / (2 * coefficientA)));
                }
                else if (discriminant > 0)
                {
                    Console.WriteLine("The equation has 2 real roots:");
                    Console.WriteLine("Root 1: {0}", ((-coefficientB) + Math.Sqrt(discriminant)) / (2 * coefficientA));
                    Console.WriteLine("Root 2: {0}", ((-coefficientB) - Math.Sqrt(discriminant)) / (2 * coefficientA));
                }
                else
                {
                    Console.WriteLine("The equation has no real roots!");
                }
            }
        }
        Console.ReadKey();
    }
}
