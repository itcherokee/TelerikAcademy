using System;

class BiggestOfThree
{
    static void Main()
    {
        //Write a program that finds the biggest of three integers using nested if statements.

        int numOne = 0, numTwo = 0, numThree = 0;
        bool noError = true;
        bool equalNumbers = false;
        Console.Title = "Find the biggest number out of three";
        Console.WriteLine("Enter three different integers and program will find the biggest one.");
        do
        {
            do
            {
                Console.Write("Number 1: ");
                noError = int.TryParse(Console.ReadLine(), out numOne);
            } while (!noError);
            do
            {
                Console.Write("Number 2: ");
                noError = int.TryParse(Console.ReadLine(), out numTwo);
            } while (!noError);
            do
            {
                Console.Write("Number 3: ");
                noError = int.TryParse(Console.ReadLine(), out numThree);
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
        if (numOne > numTwo)
        {
            if (numOne > numThree)
            {
                Console.WriteLine("First number is the biggest: {0}", numOne);
            }
            else
            {
                Console.WriteLine("Third number is the biggest: {0}", numThree);
            }

        }
        else if (numTwo > numThree)
        {
            Console.WriteLine("Second number is the biggest: {0}", numTwo);
        }
        else
        {
            Console.WriteLine("Third number is the biggest: {0}", numThree);
        }
        Console.ReadKey();
    }
}

