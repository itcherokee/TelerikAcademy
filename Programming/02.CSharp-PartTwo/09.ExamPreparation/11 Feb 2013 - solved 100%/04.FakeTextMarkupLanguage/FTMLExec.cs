// Task description is in the solution folder
namespace FakeTextMarkupLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FTMLExec
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                text.Append(Console.ReadLine());
                if (i < lines - 1)
                {
                    text.Append("\n");
                }
            }

            Parse(text);
            Console.WriteLine(text.ToString());
        }

        /// <summary>
        /// Parse text and applys all tags.
        /// </summary>
        /// <param name="text">Text to be parsed.</param>
        private static void Parse(StringBuilder text)
        {
            int index = 0;
            Stack<KeyValuePair<string, int>> tags = new Stack<KeyValuePair<string, int>>();
            while (index < text.Length)
            {
                while (index < text.Length && text[index].Equals('<'))
                {
                    string currentTag = ExtractTag(text, index);
                    if (currentTag[0].Equals('/'))
                    {
                        // It is good to have here check does Stack is not empty as well does the first element in the stack is the opening tag
                        var openingTag = tags.Pop();
                        string operation = openingTag.Key;
                        int startIndex = openingTag.Value;
                        string oldValue;
                        string newValue;
                        switch (operation)
                        {
                            case "upper":
                                oldValue = text.ToString(startIndex, index - startIndex);
                                newValue = oldValue.ToUpper();
                                if (oldValue.Length > 0)
                                {
                                    text.Replace(oldValue, newValue, startIndex, oldValue.Length);
                                }

                                break;
                            case "lower":
                                oldValue = text.ToString(startIndex, index - startIndex);
                                newValue = oldValue.ToLower();
                                if (oldValue.Length > 0)
                                {
                                    text.Replace(oldValue, newValue, startIndex, oldValue.Length);
                                }

                                break;
                            case "toggle":
                                oldValue = text.ToString(startIndex, index - startIndex);
                                if (oldValue.Length > 0)
                                {
                                    StringBuilder toggled = new StringBuilder(oldValue.Length);
                                    for (int pos = 0; pos < oldValue.Length; pos++)
                                    {
                                        if ((oldValue[pos] >= 65 && oldValue[pos] <= 90) || (oldValue[pos] >= 97 && oldValue[pos] <= 122))
                                        {
                                            if (char.IsUpper(oldValue[pos]))
                                            {
                                                toggled.Append((char)(oldValue[pos] + 32));
                                            }
                                            else if (char.IsLower(oldValue[pos]))
                                            {
                                                toggled.Append((char)(oldValue[pos] - 32));
                                            }
                                        }
                                        else
                                        {
                                            toggled.Append(oldValue[pos]);
                                        }
                                    }

                                    text.Replace(oldValue, toggled.ToString(), startIndex, oldValue.Length);
                                }

                                break;
                            case "del":
                                text.Remove(startIndex, index - startIndex);
                                index = startIndex;
                                break;
                            case "rev":
                                oldValue = text.ToString(startIndex, index - startIndex);
                                char[] reversed = oldValue.ToCharArray();
                                Array.Reverse(reversed);
                                if (oldValue.Length > 0)
                                {
                                    text.Replace(oldValue, new string(reversed), startIndex, oldValue.Length);
                                }

                                break;
                        }
                    }
                    else
                    {
                        tags.Push(new KeyValuePair<string, int>(currentTag, index));
                    }
                }

                index++;
            }
        }

        /// <summary>
        /// Extracts the tag at given position and removing it from text.
        /// </summary>
        /// <param name="text">Text from where the tag must be extracted.</param>
        /// <param name="index">Position in the text, where the tag starts.</param>
        /// <returns>Name of the tag: if it is an opening tag - only name; if it is closing tag - "\" + name of the tag</returns>
        private static string ExtractTag(StringBuilder text, int index)
        {
            string tag = string.Empty;
            char symbol = text[index];
            int indexOfClosingBracket = index;
            while (symbol != '>')
            {
                indexOfClosingBracket++;
                symbol = text[indexOfClosingBracket];
            }

            tag = text.ToString(index + 1, indexOfClosingBracket - index - 1);
            text.Remove(index, indexOfClosingBracket - index + 1);
            return tag;
        }
    }
}
