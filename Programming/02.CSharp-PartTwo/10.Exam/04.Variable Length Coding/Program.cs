using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _04.Variable_Length_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] encodedText = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
            byte codeTableLines = byte.Parse(Console.ReadLine());
            Dictionary<int, char> codeTable = new Dictionary<int, char>(codeTableLines);
            for (int i = 0; i < codeTableLines; i++)
            {
                string line = Console.ReadLine();
                char value = line[0];
                int ones = int.Parse(line.Substring(1));
                codeTable.Add(ones, value);
            }

            // build the mesage as binary
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < encodedText.Length; i++)
            {
                message.Append(ConvertDecToBin(encodedText[i]));
            }

            // Remove most rigth zeroes
            string lastdigitAsBinary = ConvertDecToBin(encodedText[encodedText.Length - 1]);
            int lastNonDigitIndex = 0;
            for (int i = 7; i >= 0; i--)
            {
                if (lastdigitAsBinary[i].Equals('0'))
                {
                    lastNonDigitIndex++;
                    continue;
                }
                else
                {
                    message.Remove(message.Length - lastNonDigitIndex, lastNonDigitIndex);
                    break;
                }
            }

            // Start decoding '1'
            StringBuilder final = new StringBuilder();
            int index = 0;
            while (message.Length > 0)
            {
                var number = ExtractNumber(message.ToString());
                try
                {
                    final.Append(codeTable[number]);
                }
                catch (Exception)
                {
                    
                    
                }
                if (message.Length > number)
                {
                    message.Remove(0, number + 1); // +1 to remove the zeroes

                }
                else
                {
                    message.Remove(0, number); // +1 to remove the zeroes

                }
                //message.Remove(0, number + 1); // +1 to remove the zeroes
                // index += number + 1;
            }

            Console.WriteLine(final.ToString());
        }

        // Extracts first appearance of number starting from begining or end of a text
        private static int ExtractNumber(string text)
        {
            int number = 0;
            int index = 0;
            do
            {
                int isOne = int.Parse(text[index++].ToString());
                if (isOne == 1)
                {
                    number++;
                }
                else
                {
                    break;
                }
            } while (index < text.Length);

            return number;
        }

        private static string ConvertDecToBin(byte numberToConvert)
        {
            byte result = numberToConvert;
            bool isNegative = false;
            int size = 8;

            // Discover bits in the number and store them in Stack
            const int NumeralBase = 2;
            Stack<long> resultNumber = new Stack<long>();
            while (result > 0)
            {
                resultNumber.Push(result % NumeralBase);
                result /= NumeralBase;
            }

            // Construct the binary representation of number
            StringBuilder binNumber = new StringBuilder();
            int stackSize = resultNumber.Count;
            for (int i = 0; i < stackSize; i++)
            {
                binNumber.Append(resultNumber.Pop());
            }

            // Finalizing binary representation by including negative bit if applicable 
            // and padding as well up to the byte size of type of the number (8-bit, 16-bit, 32-bit, 64-bit)
            string binRepresentation = default(string);

            binRepresentation = binNumber.ToString().PadLeft(size, '0');

            return binRepresentation;
        }
    }
}
