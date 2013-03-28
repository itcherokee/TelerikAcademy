using System;
using System.Collections.Generic;

public class Crossword
{
    public static int crossSize = 0;
    public static List<string> words = new List<string>();
    public static List<string> result = new List<string>();
    public static List<string> finalResult = new List<string>();
    private static int wordsNumber = 0;

    public static void Main(string[] args)
    {
        crossSize = int.Parse(Console.ReadLine());
        wordsNumber = crossSize * 2;
        for (int i = 0; i < wordsNumber; i++)
        {
            words.Add(Console.ReadLine());
        }

        Combinate(0);
        if (finalResult.Count != 0)
        {
            PrintCross(finalResult);
        }
        else
        {
            Console.WriteLine("NO SOLUTION!");
        }
    }

    private static void Combinate(int cuurentBound)
    {
        if (crossSize == cuurentBound)
        {
            if (CheckCross(result))
            {
                if (finalResult.Count == 0)
                {
                    for (int i = 0; i < crossSize; i++)
                    {
                        finalResult.Add(result[i]);
                    }
                }
                else if (LexicographicalCompare(finalResult, result))
                {
                    finalResult.Clear();
                    for (int i = 0; i < crossSize; i++)
                    {
                        finalResult.Add(result[i]);
                    }
                }
            }

            return;
        }

        for (int element = 0; element < wordsNumber; element++)
        {
            result.Add(words[element]);
            Combinate(cuurentBound + 1);
            for (int i = cuurentBound; i < result.Count; i++)
            {
                result.RemoveAt(i);
            }
        }
    }

    //check for correct crossword
    private static bool CheckCross(List<string> crossWord)
    {
        string verticalWord = string.Empty;
        int counterEquality = 0;
        for (int col = 0; col < crossSize; col++)
        {
            for (int row = 0; row < crossSize; row++)
            {
                verticalWord += crossWord[row][col];
            }

            for (int index = 0; index < wordsNumber; index++)
            {
                if (verticalWord == words[index].ToString())
                {
                    counterEquality++;
                    break;
                }
            }

            verticalWord = string.Empty;
        }

        if (counterEquality == crossSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool LexicographicalCompare(List<string> arrayOne, List<string> arrayTwo)
    {
        string arrayOneString = string.Join(string.Empty, arrayOne.ToArray());
        string arrayTwoString = string.Join(string.Empty, arrayTwo.ToArray());
        for (int index = 0; index < crossSize * crossSize; index++)
        {
            if (arrayOneString[index] < arrayTwoString[index])
            {
                return false;
            }
            else if (arrayOneString[index] > arrayTwoString[index])
            {
                return true;
            }
        }

        return false;
    }

    private static void PrintCross(List<string> outputWords)
    {
        for (int i = 0; i < outputWords.Count; i++)
        {
            Console.WriteLine(outputWords[i]);
        }
    }
}