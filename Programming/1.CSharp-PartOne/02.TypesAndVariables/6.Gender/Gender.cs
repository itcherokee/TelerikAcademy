using System;

class Gender
{
    static void Main()
    {
        // Declare a boolean variable called isFemale and assign 
        // an appropriate value corresponding to your gender.

        bool isFemale = true;
        string gender = "жена";
        byte number = 0;
        Console.Title = "Check your gender";
        Console.Write("Въведете предпоследната цифра от Вашето ЕГН: ");
        number = byte.Parse(Console.ReadLine());
        if (number % 2 == 0)
        {
            isFemale = false;
            gender = "мъж";
        }
        Console.WriteLine("Вие сте {0}.", gender);
        Console.ReadKey();
    }
}
