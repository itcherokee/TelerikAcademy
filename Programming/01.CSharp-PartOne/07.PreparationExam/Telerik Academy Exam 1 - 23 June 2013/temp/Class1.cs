using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    static public class Class1
    {
        static public void test()
        {
            //List<string> myString = new List<string> { "a", "b", "c", "d", "f" };
            //List<String> result = new List<String>();
            //for (int i = 0; i < myString.Count; i++)
            //{
            //    for (int j = 0; j < myString.Count; j++)
            //    {
            //        if (i == j)
            //            continue;
            //        result.Add(myString[i] + myString[j]);
            //    }
            //}
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToString());

            //}

            int numberOfCows = 4;
            string test = "1234";

            for (int i = 0; i < numberOfCows; i++)
            {
                if (numberOfCows == 1)
                {
                    Console.WriteLine("{0}", test[i]);
                    continue;
                }

                for (int j = 0; j < numberOfCows; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (numberOfCows == 2)
                    {
                        Console.WriteLine("{0}{1}", test[i], test[j]);
                        continue;
                    }

                    for (int k = 0; k < numberOfCows; k++)
                    {
                        if (i==k || j == k)
                        {
                            continue;
                        }

                        if (numberOfCows == 3)
                        {
                            Console.WriteLine("{0}{1}{2}", test[i], test[j], test[k]);
                            continue;
                        }


                        for (int l = 0; l < numberOfCows; l++)
                        {
                            if (i == l || j == l || k == l)
                            {
                                continue;
                            }

                            Console.WriteLine("{0}{1}{2}{3}", test[i], test[j], test[k], test[l]);
                        }
                    }
                }
            }
        }
    }
}
