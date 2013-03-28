using System;

class PrintSquareOfNumberSolutionTwo
{
    static void Main()
    {
        Console.Title = "Print square of a number - ver.2";
        Console.WriteLine("The square of number 12345 is: {0}",Math.Pow(12345,2).ToString());  //компилатора разрешава (скрито преобразуване) и без употребата на "ToString()", но така смятам, че е по прегледно
        Console.ReadKey();
    }
}

