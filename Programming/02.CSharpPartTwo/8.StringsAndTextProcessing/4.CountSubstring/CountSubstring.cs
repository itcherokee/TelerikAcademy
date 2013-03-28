using System;
using System.Globalization;
using System.Text;
using System.Threading;

public class CountSubstring
{
    // Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

    public static void Main()
    {
        Console.Title = "Find how many times a substring in a string appears";
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string userInput = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string toSearch = "in";
        int index = -1;
        int counter = 0;
        int currentCounter = 0;
        while (index < userInput.Length)
        {
            currentCounter = userInput.IndexOf(toSearch, ++index, StringComparison.InvariantCultureIgnoreCase);
            if (currentCounter < 0)
            {
                break;
            }

            index = currentCounter;
            counter += currentCounter > -1 ? 1 : 0;
            currentCounter = 0;
        }

        Console.WriteLine("Substring detected {0} times", counter);
    }
}