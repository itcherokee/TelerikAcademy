//using System;

//public class Permutations
//{
//    // * Write a program that reads a number N and generates and prints 
//    // all the permutations of the numbers [1 … N]. 
//    // Example: n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

//    public static int arraySize = 0;
//    public static int[] arrayOfNumbers;
//    public static bool[] used;

//    public static void Main()
//    {
//        Console.Title = "Print all combinations of K elements from set [1..N].";
//        Console.Write("Enter upper bound of set [1..(N)]: ");
//        arraySize = int.Parse(Console.ReadLine());
//        arrayOfNumbers = new int[arraySize];
//        used = new bool[arraySize];
//        Console.WriteLine("All possible distinct combinations follow...");


//        //Combinate(0);
//        Console.WriteLine();
//    }

//    //////private static void Combinate(int currentSize)
//    //////{
//    //////    if (arraySize == currentSize)
//    //////    {
//    //////        Console.Write("{");
//    //////        for (int i = 0; i < arraySize; i++)
//    //////        {
//    //////            Console.Write("{0}", arrayOfNumbers[i]);
//    //////            if (i < arraySize - 1)
//    //////            {
//    //////                Console.Write(",");
//    //////            }
//    //////        }

//    //////        Console.Write("} ");

//    //////        return;
//    //////    }

//    //////    for (int i = 1 + currentSize; i <= arraySize; i++)
//    //////    {
//    //////        if (!used[i - 1])
//    //////        {

//    //////            used[i - 1] = true;
//    //////            arrayOfNumbers[currentSize] = i;

//    //////            Combinate(currentSize + 1);
//    //////        }
//    //////        used[i - 1] = false;


//    //////        { 
//    ////private static void PermutationsRun(int[] array, int k, int n)
//    ////{
//    ////    int t;
//    ////    if (k == n)
//    ////    {
//    ////        //Print
//    ////        return;
//    ////    }
//    ////    else
//    ////    {
//    ////        for (int i = k; i < n; i++)
//    ////        {
//    ////            t = array[k];
//    ////            array[k] = array[i];
//    ////            array[i] = t;
//    ////            PermutationsRun(array, k + 1, n);
//    ////            t = array[k];
//    ////            array[k] = array[i];
//    ////            array[i] = t;
//    ////        }
//    ////    }

//    ////}

//    public static int[] Combinate(int[] teams)
//    {
//        int[] array = new int[teams.Length];
//        for (int index = 0; index < teams.Length; index++)
//        {
//            array[index] = 0;
//        }
//        int[] result = new int[];

//        while (true)
//        {
//            int[] members = new int[teams.Length];
//            for (int iTeam = 0; iTeam < teams.Length; iTeam++)
//            {
//                members[(teams[iTeam].Names[array[iTeam]]);
//            }
//            result.Add(new Team(members));
//            int i = 0;
//            while (true)
//            {
//                if (i >= teams.Count)
//                {
//                    return result;
//                }
//                array[i]++;
//                if (array[i] >= teams[i].Names.Count)
//                {
//                    array[i] = 0;
//                    i++;
//                    continue;
//                }
//                break;
//            }
//        }
//    }


//}
