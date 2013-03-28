using System;

class SortRealNumbers
{
    static void Main()
    {
        //Sort 3 real values in descending order using nested if statements.
        decimal numOne = 0.0m;
        decimal numTwo = 0.0m;
        decimal numThree = 0.0m;
        bool noError = true;
        bool equalNumbers = false;
        Console.Title = "Sorting in descendant order three real numbers";
        Console.WriteLine("Enter three different real numbers to sort them in descending order.");
        do
        {
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
            if ((numOne == numTwo) || (numOne == numThree) || (numTwo == numThree))
            {
                Console.WriteLine("You have entered 2 or 3 numbers with equal values. Please reenter all.");
                equalNumbers = true;
            }
            else
            {
                equalNumbers = false;
            }
        } while (equalNumbers);

        if (decimal.Compare(numOne, numTwo) > 0)
        {
            if (decimal.Compare(numOne, numThree) > 0)
            {
                Console.WriteLine("{0:F1}",numOne);
                if (decimal.Compare(numTwo, numThree) > 0)
                {
                    Console.WriteLine("{0:F1}", numTwo);
                    Console.WriteLine("{0:F1}", numThree);
                }
                else
                {
                    Console.WriteLine("{0:F1}", numThree);
                    Console.WriteLine("{0:F1}", numTwo);
                }
            }
            else
            {
                Console.WriteLine("{0:F1}", numThree);
                Console.WriteLine("{0:F1}", numOne);
                Console.WriteLine("{0:F1}", numTwo);
            }

        }
        else if (decimal.Compare(numTwo, numThree) > 0)
        {
            Console.WriteLine("{0:F1}", numTwo);
            if (decimal.Compare(numOne, numThree) > 0)
            {
                Console.WriteLine("{0:F1}", numOne);
                Console.WriteLine("{0:F1}", numThree);
            }
            else
            {
                Console.WriteLine("{0:F1}", numThree);
                Console.WriteLine("{0:F1}", numOne);
            }
        }
        else
        {
            Console.WriteLine("{0:F1}", numThree);
            Console.WriteLine("{0:F1}", numTwo);
            Console.WriteLine("{0:F1}", numOne);
        }
        Console.ReadKey();
    }
}
