// Task definition is in the solution folder
namespace ConsoleJustification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ConsoleJustificationExec
    {
        public static void Main()
        {
            int totalNumberOfLines = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int index = 0; index < totalNumberOfLines; index++)
            {
                var lineWords = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int word = 0; word < lineWords.Length; word++)
                {
                    words.Add(lineWords[word]);
                }
            }

            List<string> final = new List<string>();
            StringBuilder line = new StringBuilder(width);

            while (words.Count > 0)
            {
                int occupiedPositions = 0;
                bool isEndOfLine = false;
                int wordCount = 0;
                int wordIndex = 0;
                while (!isEndOfLine)
                {
                    if (words.Count == 0 || words.Count - wordCount == 0)
                    {
                        break;
                    }

                    int currentEmptyPositions = width - occupiedPositions - words[wordIndex].Length;
                    if (currentEmptyPositions >= 0)
                    {
                        if (words[wordIndex].Equals('.') || words[wordIndex].Equals(','))
                        {
                            if (line.Length > 0 && line[line.Length - 1].Equals(' '))
                            {
                                line.Remove(line.Length - 1, 1);
                            }
                        }

                        line.Append(words[wordIndex]);
                        wordCount++;
                        if (line.Length < width)
                        {
                            line.Append(" ");
                            occupiedPositions += words[wordIndex].Length + 1;
                        }
                        else
                        {
                            occupiedPositions += words[wordIndex].Length;
                        }

                        wordIndex++;
                    }
                    else
                    {
                        isEndOfLine = true;
                    }
                }

                if (line[line.Length - 1].Equals(' '))
                {
                    line.Remove(line.Length - 1, 1);
                }

                words.RemoveRange(0, wordIndex);

                // adjust spaces
                int totalEmpty = width - line.Length;
                string currentLine = line.ToString();
                int index = 0;
                while (totalEmpty > 0 && wordCount > 1)
                {
                    int spaceIndex = currentLine.IndexOf(" ", index);
                    if (spaceIndex > 0)
                    {
                        // Whitespace found - let's find index of next symbol different from whitespace
                        while (currentLine[spaceIndex++].Equals(' '))
                        {
                            if (!currentLine[spaceIndex].Equals(' '))
                            {
                                // First non whitespace symbol found - Insert whitespace here
                                currentLine = currentLine.Insert(spaceIndex, " ");
                                totalEmpty--;
                                index = spaceIndex + 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Last whitespace passed by, but there are still spaces to be distributed
                        // spaceIndex = 0;
                        index = 0;
                    }
                }

                final.Add(currentLine.ToString());
                line.Clear();
            }

            for (int i = 0; i < final.Count; i++)
            {
                Console.WriteLine(final[i]);
            }
        }
    }
}