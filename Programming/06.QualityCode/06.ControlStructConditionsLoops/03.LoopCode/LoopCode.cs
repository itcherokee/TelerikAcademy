// Task 3:  Refactor the following loop

namespace LoopCode
{
    using System;

    public class LoopCode
    {
        public void LoopOverNumbers(int[] numbersToCheck, int expectedValue)
        {
            bool expectedValueFound = false;
            for (int index = 0; index < 100; index++)
            {
                if (index % 10 == 0)
                {
                    Console.WriteLine(numbersToCheck[index]);
                    if (numbersToCheck[index] == expectedValue)
                    {
                        expectedValueFound = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(numbersToCheck[index]);
                }
            }

            // More code here
            if (expectedValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}