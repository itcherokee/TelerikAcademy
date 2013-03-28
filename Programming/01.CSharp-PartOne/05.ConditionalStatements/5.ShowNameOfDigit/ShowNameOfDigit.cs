using System;

class ShowNameOfDigit
{
    static void Main()
    {
        //Write program that asks for a digit and depending on the input 
        //shows the name of that digit (in English) using a switch statement.

        int numOneDigit = 0;
        string numOneName = "";
        bool noError = true;
        Console.Title = "Converting digit to name";
        Console.WriteLine("Enter number between 0 and 10:");
        do
        {
            Console.Write("Digit: ");
            noError = int.TryParse(Console.ReadLine(), out numOneDigit);
        } while (!noError);
        switch (numOneDigit)
        {
            case 0: numOneName = "zero"; break;
            case 1: numOneName = "one"; break;
            case 2: numOneName = "two"; break;
            case 3: numOneName = "three"; break;
            case 4: numOneName = "four"; break;
            case 5: numOneName = "five"; break;
            case 6: numOneName = "six"; break;
            case 7: numOneName = "seven"; break;
            case 8: numOneName = "eight"; break;
            case 9: numOneName = "nine"; break;
            case 10: numOneName = "ten"; break;
            default: numOneName = "out of requested bounadry"; break;
        }
        Console.WriteLine("You have entered number {0}.", numOneName);
        Console.ReadKey();
    }
}
