// Task description is in the solution folder
namespace OneTaskIsNotEnough
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OneTaskIsNotEnoughExec
    {
        public static void Main()
        {
            // Input
            int numberOfLamps = int.Parse(Console.ReadLine());
            //StringBuilder moves = new StringBuilder();
            string firstMove = Console.ReadLine();

            string secondMove = Console.ReadLine();

            // Task 1
            Console.WriteLine(WhichIsLastLapmTurnedOn(numberOfLamps) + 1);

            // Task 2

            Console.WriteLine(IsBounded(firstMove));
            Console.WriteLine(IsBounded(secondMove)); 
        }

        private static int WhichIsLastLapmTurnedOn(int numberOfLamps)
        {
            bool[] lamps = new bool[numberOfLamps];
            int lampsOffCounter = numberOfLamps;
            int lastLamp = 0;
            int firstLampOff = 0;
            int offset = 1;
            while (lampsOffCounter != 0)
            {
                for (int turnedOffIndex = firstLampOff; turnedOffIndex < numberOfLamps; turnedOffIndex++)
                {
                    if (lamps[turnedOffIndex] == false)
                    {
                        firstLampOff = turnedOffIndex;
                        break;
                    }
                }

                int stepPassed = offset;
                // TODO: trqybva da go preprabotya na while i da go prekysvam po-rano ako do kraya ima po-malko lampi
                for (int i = firstLampOff; i < numberOfLamps; i++)
                {
                    if (!lamps[i])
                    {
                        if (firstLampOff == i)
                        {
                            lamps[i] = true;
                            lastLamp = i;
                            lampsOffCounter--;
                            continue;
                        }

                        if (lamps[i] == false && stepPassed > 0)
                        {
                            stepPassed--;
                        }
                        else if (lamps[i] == false)
                        {
                            lamps[i] = true;
                            lastLamp = i;
                            lampsOffCounter--;
                            stepPassed = offset;
                        }
                    }
                }

                offset++;
            }

            return lastLamp;
        }

        private static string IsBounded(string c)
        {
            // int result = 0;

            int r = 0;// = moves.Count(x => x == 'R');
            int l = 0;// = moves.Count(x => x == 'L');


            //   foreach (var c in moves)

            //  StringBuilder c = new StringBuilder(moves);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 'S')
                {
                    if (c[i] == 'L')
                    {
                        l++;
                    }
                    else
                    {
                        r++;
                    }
                    //l += c.Equals('L') ? 1 : 0;
                    //r += c.Equals('R') ? 1 : 0; 
                }
            }

            if (l - r < 0 || l - r > 0)
            {
                return "bounded";
            }
            else
            {
                return "unbounded";
            }

            //char firstTurn = 'S';
            //for (int i = 0; i < moves.Length; i++)
            //{
            //    switch (moves[i])
            //    {
            //        case 'R':
            //            if (firstTurn.Equals('S'))
            //            {
            //                firstTurn = 'R';
            //                result++;
            //            }
            //            else
            //            {
            //                if (firstTurn.Equals('R'))
            //                {
            //                    result++;
            //                }
            //                else
            //                {
            //                    result--;
            //                }
            //            }

            //            break;
            //        case 'L':
            //            if (firstTurn.Equals('S'))
            //            {
            //                firstTurn = 'L';
            //                result++;
            //            }
            //            else
            //            {
            //                if (firstTurn.Equals('L'))
            //                {
            //                    result++;
            //                }
            //                else
            //                {
            //                    result--;
            //                }
            //            }

            //            break;
            //    }
            //}

            //return result > 0 ? true : false;
        }
    }
}