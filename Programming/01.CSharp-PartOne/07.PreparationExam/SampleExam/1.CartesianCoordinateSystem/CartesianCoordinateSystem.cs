﻿using System;

public class CartesianCoordinateSystem
{
    public static void Main()
    {
        decimal x = decimal.Parse(Console.ReadLine());
        decimal y = decimal.Parse(Console.ReadLine());
        if ((x == 0) || (y == 0))
        {
            if (x == y)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (x == 0)
                {
                    Console.WriteLine("5");
                }
                else
                {
                    Console.WriteLine("6");
                }
            }
        }
        else if (x > 0)
        {
            if (y > 0)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine("4");
            }
        }
        else
        {
            if (x > 0 && y > 0)
            {
                Console.WriteLine("1");
            }

            if (x > 0 && y < 0)
            {
                Console.WriteLine("4");
            }

            if (x < 0 && y < 0)
            {
                Console.WriteLine("3");
            }

            if (x < 0 && y > 0)
            {
                Console.WriteLine("2");
            }
        }
    }
}