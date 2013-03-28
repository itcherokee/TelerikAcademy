using System;

class CalculateSum
{
    static void Main()
    {
        //Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

        decimal currentSum = 1m, previousSum;
        int counter = 1;
        do
        {
            previousSum = currentSum;
            currentSum += (++counter % 2 == 0) ? (1m / counter) : (-1m / counter);
        } while (Math.Abs(currentSum - previousSum) >= 0.001m);
        Console.Title = "Sum with accuracy of 0.001";
        Console.WriteLine("The series is: 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...");
        Console.WriteLine("Sum of series with accuracy up to 0.001 is: {0:F3}", currentSum);
        Console.WriteLine("Sum of series is: {0}", currentSum);
        Console.WriteLine("Number of iterations: {0}", counter);
        Console.ReadKey();
    }
}