using System;

class MaximalSequenceOfEquals
{
    // Write a program that finds the maximal sequence of equal elements in an array.
    // Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int size = 1;
        int index = 0;
        for (int i = 0; i < array.Length-1; i++)
        {
            if (array[i]==array[i+1])
            {
                size++;
            }
            else
            {
                    
            }
        }
    
    
    
    }
}
