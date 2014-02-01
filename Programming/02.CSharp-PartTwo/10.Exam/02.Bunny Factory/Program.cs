using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bunny_Factory
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<byte> cages = new List<byte>();
            byte index = 0;
            //   int numberOfCages = 0;
            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }

                byte temp = byte.Parse(input);
                //if (temp <= 1)
                //{
                //    continue;
                //}

                cages.Add(temp);
                index++;
                //     numberOfCages++;
            }


            index = 0;
            //  string result = string.Empty;
            int step = 0;
            while (cages.Count > step)
            {

                //1.	If there are less than i cages, the factory stops the multiplication process.
                int sum = 0;

                //2.	The factory gets the first i cages and calculate the sum s of all bunnies in them. 
                for (int i = 0; i <= step; i++)
                {
                    sum += cages[i];
                }


                //3.	If there are less than s cages after the i-th one, the factory stops the multiplication process.
                if (sum > cages.Count - step)
                {
                    break; // not enough cages after i-th cage
                }

                //4.	The factory gets the next s cages after the i-th one and calculates the sum and product of all bunnies in them. 
                BigInteger tempSum = 0;
                BigInteger product = 1;
                for (int j = step + 1; j < step + 1 + sum; j++)
                {
                    tempSum += (ulong)cages[j];
                    product *= (ulong)cages[j];
                }

                //5.	These sum and product are concatenated as next cages. All cages that were not included in the calculations are simply appended to next.
                StringBuilder nextCages = new StringBuilder();
                nextCages.Append(tempSum);
                nextCages.Append(product);
                for (int z = step + 1 + sum; z < cages.Count; z++)
                {
                    nextCages.Append(cages[z]);
                }

                //6.	The factory gets several empty cages then gets the digits of next and for each digit puts the same amount of bunnies in each cell. If the digit is 1 or 0, the digit is ignored.
                nextCages.Replace("1", "");
                nextCages.Replace("0", "");
                // numberOfCages = nextCages.Length;
                cages.Clear();
                //7.	Step 1 is repeated for the newly generated cages with bunnies.
                //try
                //{
                for (int i = 0; i < nextCages.Length; i++)
                {
                    cages.Add(byte.Parse(nextCages[i].ToString()));
                }
                //}
                //catch (IndexOutOfRangeException)
                //{

                //    throw new ArgumentNullException();
                //}

                step++;

            }

            StringBuilder result = new StringBuilder(cages.Count);
            for (int i = 0; i < cages.Count; i++)
            {
                result.Append(cages[i]);
                if (i < cages.Count - 1)
                {
                    result.Append(" ");
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
