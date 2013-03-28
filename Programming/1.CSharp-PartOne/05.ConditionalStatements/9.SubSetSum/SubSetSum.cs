using System;

class SubSetSum
{
    static void Main()
    {
        //We are given 5 integer numbers. Write a program that checks if the sum
        //of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

        Console.Title = "Find subset in 5 integers row equal to 0";
        Console.WriteLine("Enter five integers in one line splited by space (0 is not allowed).");
        Console.Write("Numbers: ");
        int[] numbers = new int[5];
        string[] numbersInput = Console.ReadLine().Split(' ');
        bool noError = false;
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            noError = int.TryParse(numbersInput[i], out numbers[i]);
            if ((!noError) || (numbers[i])==0)
            {
                Console.WriteLine("You have entered invalid number or symbol. Press key to exit!");
                Console.ReadKey();
                return;
            }
        }
        Console.Write("Entered numbers: ");
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            Console.Write("{0}", numbers[i]);
            if (i < numbers.Length - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine();
            }
        }
        for (int i = 0; i <= numbers.Length - 2; i++)
        {
            int tempSum = 0;
            for (int k = i; k <= numbers.Length - 1; k++)
            {
                tempSum += numbers[k];
                if (tempSum == 0)
                {
                    Console.Write("We have a winner (sub set is equal to 0): ");
                    for (int iterate = i; iterate <= k; iterate++)
                    {
                        Console.Write("{0}", numbers[iterate]);
                        if (iterate != k)
                        {
                            switch (numbers[iterate + 1] < 0)
                            {
                                case true: break;
                                case false: Console.Write("+"); break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("={0}", tempSum);
                        }
                    }
                    Console.WriteLine("Press <Enter> to exit...");
                    Console.ReadKey();
                    return;
                }
            }
        }
        Console.WriteLine("There is no subset which sum is equal to 0!");
    }
}