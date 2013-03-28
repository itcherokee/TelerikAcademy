using System;

class SignOfProduct
{
    static void Main()
    {
        //Write a program that shows the sign (+ or -) of the product of 
        //three real numbers without calculating it. Use a sequence of if statements.

        byte? counter = 0;
        decimal numOne = 0.0m;
        decimal numTwo = 0.0m;
        decimal numThree = 0.0m;
        bool noError = true;
        Console.Title = "Product sign of 3 real numbers without calculation";
        Console.WriteLine("Enter three different real numbers to discover their product sign.");
        do
        {
            Console.Write("Number 1: ");
            noError = decimal.TryParse(Console.ReadLine(), out numOne);
        } while (!noError);
        do
        {
            Console.Write("Number 2: ");
            noError = decimal.TryParse(Console.ReadLine(), out numTwo);
        } while (!noError);
        do
        {
            Console.Write("Number 3: ");
            noError = decimal.TryParse(Console.ReadLine(), out numThree);
        } while (!noError);
        if (((decimal.Compare(numOne, 0.0m) == 0)) || ((decimal.Compare(numTwo, 0.0m) == 0))
            || ((decimal.Compare(numThree, 0.0m) == 0)))
        {
            counter = null;
        }
        else
        {
            if (decimal.Compare(numOne, 0.0m) < 0)
            {
                counter++;
            }
            if (decimal.Compare(numTwo, 0.0m) < 0)
            {
                counter++;
            }
            if (decimal.Compare(numThree, 0.0m) < 0)
            {
                counter++;
            }
        }
        switch (counter)
        {
            case 1:
            case 3: Console.WriteLine("Product sign will be negative."); break;
            case 0:
            case 2: Console.WriteLine("Product sign will be positive."); break;
            default: Console.WriteLine("Product will be zero (0)."); break;
        }
        Console.WriteLine("{0} x {1} x {2} = {3}", numOne, numTwo, numThree, numOne * numTwo * numThree);
        Console.ReadKey();
    }
}
