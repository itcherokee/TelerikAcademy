using System;

class CompareAndExchange
{
    static void Main()
    {
        //Write an if statement that examines two integer variables and exchanges 
        //their values if the first one is greater than the second one.

        int numberOne = 0, numberTwo = 0;
        bool noError = true;
        Console.WriteLine("Enter two integers to sort them if necessary.");
        do
        {
            Console.Write("Number 1: ");
            noError = int.TryParse(Console.ReadLine(), out numberOne);
        }
        while (!noError);
        do
        {
            Console.Write("Number 2: ");
            noError = int.TryParse(Console.ReadLine(), out numberTwo);
        }
        while (!noError);
        if (numberOne > numberTwo)
        {
            numberOne = numberOne ^ numberTwo;
            numberTwo = numberOne ^ numberTwo;
            numberOne = numberOne ^ numberTwo;
        }
        Console.WriteLine("Your ascending sorted numbers are: {0}, {1}", numberOne, numberTwo);
        Console.ReadKey();
    }
}

