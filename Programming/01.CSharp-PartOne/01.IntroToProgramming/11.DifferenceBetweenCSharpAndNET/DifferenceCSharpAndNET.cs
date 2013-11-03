using System;
using System.Text;

/// <summary>
/// Task: "11. Describe the difference between C# and .NET Framework."
/// Note: "Engine" from previous task has been used to view the text.
/// </summary>
public class DifferenceCSharpAndNET
{
    public static void Main()
    {
        string topicDifference = "Не може да става въпрос за сравнение между двете, защото .NET Framework е цялостна платформа за програмни решения, "
            + "докато C# е език за програмиране, част от .NET Framework платформата (заедно с други включени от Microsoft - F#, VB.NET, C++). Сам по себе си C# използва библиотеките включени в .NET "
            + "и може да се каже, че не е в състояние да съществува и работи без наличието на NET Framework-а.\r\n";

        Console.SetWindowSize(80, 35);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Разлика между C# и .NET Framework");
        Console.WriteLine("---------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Сравнение: ");
        PrintLines(topicDifference);
        Console.WriteLine();
        Console.ReadKey();
    }

    private static void PrintLines(string content)
    {
        Console.ForegroundColor = ConsoleColor.White;
        int maxCharsPerLine = 60;
        StringBuilder lineWithWords = new StringBuilder();
        string[] topic = content.Split(' ');
        for (int index = 0; index < topic.Length; index++)
        {
            lineWithWords.Append(topic[index]);
            lineWithWords.Append(" ");
            if ((lineWithWords.Length > maxCharsPerLine) || (index == topic.Length - 1))
            {
                Console.WriteLine(lineWithWords);
                lineWithWords.Clear();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
    }
}