using System;

public class DrunkenNumbers
{
    public static void Main()
    {
        byte rounds = byte.Parse(Console.ReadLine());
        int drunkenNumber = 0;
        char[] drunkenNumberAsChars;
        int drunkenNumberLength = 0;
        int mitkoBeers = 0;
        int vladoBeers = 0;

        for (int count = 0; count < rounds; count++)
        {
            drunkenNumber = int.Parse(Console.ReadLine());
            if (drunkenNumber < 0)
            {
                drunkenNumber *= -1;
            }

            drunkenNumberAsChars = drunkenNumber.ToString().ToCharArray();
            drunkenNumberLength = drunkenNumberAsChars.Length;
            if (drunkenNumberLength % 2 == 0)
            {
                for (int i = 0; i < drunkenNumberLength; i++)
                {
                    if (i < drunkenNumberLength / 2)
                    {
                        mitkoBeers += int.Parse(drunkenNumberAsChars[i].ToString());
                    }
                    else
                    {
                        vladoBeers += int.Parse(drunkenNumberAsChars[i].ToString());
                    }
                }
            }
            else
            {
                for (int i = 1; i <= drunkenNumberLength; i++)
                {
                    if (i <= drunkenNumberLength / 2)
                    {
                        mitkoBeers += int.Parse(drunkenNumberAsChars[i - 1].ToString());
                    }
                    else if (i > ((drunkenNumberLength / 2) + 1))
                    {
                        vladoBeers += int.Parse(drunkenNumberAsChars[i - 1].ToString());
                    }

                    if (i == ((drunkenNumberLength / 2) + 1))
                    {
                        int commonDrunkenNumber = int.Parse(drunkenNumberAsChars[i - 1].ToString());
                        vladoBeers += commonDrunkenNumber;
                        mitkoBeers += commonDrunkenNumber;
                    }
                }
            }
        }

        if (mitkoBeers == vladoBeers)
        {
            Console.WriteLine("No {0}", vladoBeers + mitkoBeers);
        }
        else if (mitkoBeers > vladoBeers)
        {
            Console.WriteLine("M {0}", mitkoBeers - vladoBeers);
        }
        else
        {
            Console.WriteLine("V {0}", vladoBeers - mitkoBeers);
        }
    }
}