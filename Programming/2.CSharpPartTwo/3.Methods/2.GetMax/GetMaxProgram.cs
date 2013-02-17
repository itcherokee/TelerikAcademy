using System;

public class GetMaxProgram
{
    // Write a method GetMax() with two parameters that returns 
    // the bigger of two integers. Write a program that reads 3 
    // integers from the console and prints the biggest of them 
    // using the method GetMax().

    public static void Main()
    {
        Console.WriteLine("Enter three integers to find the bigest.");
        Console.Write("Number 1:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Number 2:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Number 3:");
        int thirdNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Bigest number is {0}", GetMax(GetMax(firstNumber, secondNumber), thirdNumber));
    }

    private static int GetMax(int numberOne, int numberTwo)
    {
        return numberOne > numberTwo ? numberOne : numberTwo;
    }
}