﻿using System;

/// <summary>
/// Task: "11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values."
/// </summary>
public class ExchangeInt
{
    public static void Main()
    {
        Console.Title = "Exchange values of two integers - version 1";
        int numberOne = 5;
        int numberTwo = 10;
        Console.WriteLine("Number A={0}, number B={1}", numberOne, numberTwo);
        numberOne += numberTwo;
        numberTwo = numberOne - numberTwo;
        numberOne -= numberTwo;
        Console.WriteLine("After swap (without using temp variable):");
        Console.WriteLine("Number A={0}, Number B={1}", numberOne, numberTwo);
        Console.ReadKey();
    }
}