using System;
using System.Text;

class ExchangeCustomBits
{
    //*Write a program that exchanges bits {p, p+1, …, p+k-1) 
    // with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

    static uint numberEntered = 0u; //number entered 
    static int numberOfBits = 0; //number of bits to be exchanged "k"
    static int firstBitRangeStart = 0; // start bit for the first range of bits "p"
    static int secondBitRangeStart = 0; // start bit for the second range of bits "q"

    //Exchange two values (represent bits) without temp variable
    static Tuple<int, int> ChangeBits(int bit1, int bit2)
    {
        bit1 = bit1 ^ bit2;
        bit2 = bit1 ^ bit2;
        bit1 = bit1 ^ bit2;
        return new Tuple<int, int>(bit1, bit2);
    }

    // Console input management
    static uint EnterData(string message, byte caseInput)
    {
        bool correctUInteger = false;
        uint enteredValue = 0;
        do
        {
            Console.Write(message);
            correctUInteger = uint.TryParse(Console.ReadLine(), out enteredValue);
            switch (caseInput)
            {
                case 1: break;  //nothing to check in number as it has been checked above in "parse"
                case 2: // checks value for bits number "k"
                    if ((enteredValue < 1) || (enteredValue > 16))
                    {
                        correctUInteger = false;
                    }
                    break;
                case 3: // checks value for first position "p"
                    if (enteredValue > (31 - (numberOfBits + numberOfBits - 1)))
                    {
                        correctUInteger = false;
                    }
                    break;
                case 4: // checks value for second position "q"
                    if ((enteredValue > (31 - numberOfBits+1)) || ((firstBitRangeStart + numberOfBits) > enteredValue))
                    {
                        correctUInteger = false;
                    }
                    break;
            }
            if (!correctUInteger)
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!correctUInteger);
        Console.Clear();
        return enteredValue;
    }

    static void Main()
    {
        Console.Title = "Exchange 2 groups of \"k\" bits in a given number";
        // Input with built-in checks
        numberEntered = EnterData("Please enter the number to be modified: ", 1);
        numberOfBits = (int)EnterData("How many bits are going to be replaced [1..16]: ", 2);
        firstBitRangeStart = (int)EnterData("Enter the first bits group position: ", 3);
        secondBitRangeStart = (int)EnterData("Enter the second bits group position: ", 4);
        StringBuilder numberChangedStr = new StringBuilder();
        numberChangedStr.Append(Convert.ToString(numberEntered, 2).PadLeft(32, '0'));
        uint[] wrongInput = new uint[32];
        for (int i = 0; i <= 31; i++)
        {
            wrongInput[i] = uint.Parse(numberChangedStr[i].ToString());
        }
        Array.Reverse(wrongInput);
        Tuple<int, int> exchangedBits;
        for (int i = 0; i <= numberOfBits - 1; i++)
        {
            exchangedBits = ChangeBits(Convert.ToInt32(wrongInput[firstBitRangeStart + i]), Convert.ToInt32(wrongInput[(secondBitRangeStart + i)]));
            wrongInput[firstBitRangeStart + i] = (uint)exchangedBits.Item1;
            wrongInput[secondBitRangeStart + i] = (uint)exchangedBits.Item2;
        }
        Array.Reverse(wrongInput);
        numberChangedStr.Clear();
        for (int i = 0; i <= 31; i++)
        {
            numberChangedStr.Append(wrongInput[i]);
        }
        Console.WriteLine("Original binary number {0}", Convert.ToString(numberEntered, 2).PadLeft(32, '0'));
        Console.WriteLine("Modified binary number {0}", numberChangedStr);
        Console.ReadKey();
    }
}
