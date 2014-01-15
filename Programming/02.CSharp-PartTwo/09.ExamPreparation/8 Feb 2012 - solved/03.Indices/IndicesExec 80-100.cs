/*//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Indices
//{
//    public class IndicesExec
//    {
//        public static void Main()
//        {
//            // Read input
//            int size = int.Parse(Console.ReadLine());
//            string[] input = (Console.ReadLine()).Split();
//            int[] indexes = new int[size];
//            for (int index = 0; index < input.Length; index++)
//            {
//                indexes[index] = int.Parse(input[index]);
//            }

//            bool[] visitedIndexes = new bool[size];
//            //  List<int> result = new List<int>(indexes.Length + 2);
//            StringBuilder result = new StringBuilder();
//            int currentIndex = 0;
//            int nextIndex;

//            // Loop until current index is out of range
//            while (currentIndex < indexes.Length && currentIndex >= 0)
//            {
//                nextIndex = indexes[currentIndex];
//                visitedIndexes[currentIndex] = true;
//                //                result.Add(currentIndex);
//                result.Append(currentIndex + " ");
//                if (nextIndex >= indexes.Length || nextIndex < 0)
//                {
//                    break;
//                }

//                if (visitedIndexes[nextIndex] == true && currentIndex > nextIndex)
//                {
//                    // Cycle found
//                    //                    int indexOfBracket = result.IndexOf(nextIndex);
//                    int indexOfBracket = result.ToString().IndexOf(nextIndex.ToString());
//                    //Print(result, indexOfBracket);
//                    //for (int i = 0; i < result.Count; i++)
//                    //{
//                    //    if (i == indexOfBracket)
//                    //    {
//                    //        Console.Write("(");
//                    //    }

//                    //    Console.Write(result[i]);
//                    //    if (i + 1 < result.Count && i + 1 != indexOfBracket)
//                    //    {
//                    //        Console.Write(" ");
//                    //    }
//                    //}
//                    result.Remove(result.Length - 1, 1);
//                    if (indexOfBracket==0)
//                    {
//                        result.Insert(indexOfBracket, "(");
//                    }
//                    else
//                    {
//                        result.Replace(" ", "(", indexOfBracket-1, 1);
//                    }
                    
//                    Console.Write(result.ToString());
//                    Console.WriteLine(")");
//                    return;
//                }

//                currentIndex = nextIndex;
//            }

//            // Print(result);
//            //for (int i = 0; i < result.Count; i++)
//            //{
//            //    Console.Write(result[i]);
//            //    if (i + 1 < result.Count)
//            //    {
//            //        Console.Write(" ");
//            //    }
//            //}

//            Console.WriteLine(result.ToString());
//        }
//
//        /// <summary>
//        /// Output to Console
//        /// </summary>
//        /// <param name="result"></param>
//        /// <param name="startBracket"></param>
//        private static void Print(List<int> result, int startBracket)
//        {
//            for (int i = 0; i < result.Count; i++)
//            {
//                if (i == startBracket)
//                {
//                    Console.Write("(");
//                }

//                Console.Write(result[i]);
//                if (i + 1 < result.Count && i + 1 != startBracket)
//                {
//                    Console.Write(" ");
//                }
//            }

//            Console.WriteLine(")");
//        }

//        private static void Print(List<int> result)
//        {
//            for (int i = 0; i < result.Count; i++)
//            {
//                Console.Write(result[i]);
//                if (i + 1 < result.Count)
//                {
//                    Console.Write(" ");
//                }
//            }

//            Console.WriteLine();
//        }
//    }
//}
*/