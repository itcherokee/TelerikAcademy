using System;

class NullableVariables
{
    static void Main()
    {
        // Create a program that assigns null values to an integer and to double variables. 
        // Try to print them on the console, try to add some values or the null literal 
        // to them and see the result.

        int? integerNumber = null;
        double? doubleNumber = null;
        Console.WriteLine("{0,35}{1,10}", "Integer", "Double");
        Console.WriteLine("Initial values (null):{0,10}{1,10}",
                            integerNumber.GetValueOrDefault(), doubleNumber.GetValueOrDefault());
        integerNumber += 3;
        doubleNumber += 3.0d;
        Console.WriteLine("Addition of number 3:{0,11}{1,10}",
                            integerNumber.GetValueOrDefault(), doubleNumber.GetValueOrDefault());
        integerNumber += null;
        doubleNumber += null;
        Console.WriteLine("Addition of null:{0,15}{1,10}",
                            integerNumber.GetValueOrDefault(), doubleNumber.GetValueOrDefault());
        Console.WriteLine("In three cases the value are null!");
        Console.ReadKey();
    }
}
