using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bittris
{
    internal static byte[,] playboard = new byte[4, 32];
    internal static byte step = 0;
    internal static bool stuck = false; // used to promote stucked active line - no more moves available down until next number
    internal static BigInteger totalScore = 0;
    internal static byte[] currentNumber = new byte[32];

    public static void Main()
    {
        // User input
        int turns = int.Parse(Console.ReadLine());
        byte currentLine = 0;
        BigInteger score = 0;


        // Game engine
        string command = default(string);
        int turn = turns / 4;
        for (int step = 0; step < turn; step++)
        {
            stuck = false;
            currentLine = 0;

            // read number
            char[] numberAsStringArrayOfBits = Convert.ToString(uint.Parse(Console.ReadLine()), 2).PadLeft(32, '0').ToArray<char>();
            for (int index = 0; index < currentNumber.Length; index++)
            {
                string n = numberAsStringArrayOfBits[index].ToString();
                currentNumber[index] = byte.Parse(n);
                playboard[0, index] = currentNumber[index];
            }

            // Console.WriteLine(string.Join(".", number));

            // read 1st command
            command = Console.ReadLine();
            if (!stuck)
            {
                ExecuteCommand(command, currentLine);
                score = ExecuteStepDown(currentLine);
                currentLine++;
                totalScore += score;
                score = 0;
            }

            // read 2nd command
            command = Console.ReadLine();
            if (!stuck)
            {
                ExecuteCommand(command, currentLine);
                score = ExecuteStepDown(currentLine);
                currentLine++;
                totalScore += score;
                score = 0;
            }

            // read 3rd command
            command = Console.ReadLine();
            if (!stuck)
            {
                ExecuteCommand(command, currentLine);
                score = ExecuteStepDown(currentLine);
                //currentLine++;
                totalScore += score;
            }
        }

        Console.WriteLine(totalScore);
    }

    private static int ExecuteStepDown(int currentLine)
    {
        int result = 0;

        // check does below line is empty
        if (!IsLineEmpty(currentLine + 1))
        {
            // below line is not empty
            // Check does below line can accomodate current one
            if (CanBelowLineAccomodateCurrentOne(currentLine))
            {
                // Will it end after move with full result line with 1s
                if (currentLine != 3)
                {
                    int wholeLine = 8;
                    for (int index = 24; index < 32; index++)
                    {
                        wholeLine -= playboard[currentLine + 1, index];
                        wholeLine -= playboard[currentLine, index];
                    }

                    if (wholeLine == 0) // full result line
                    {
                        result = CalculateScore(currentLine) * 10;
                        // full result line => zero currentLine + below line
                        // ClearLine(currentLine);
                        // ClearLine(currentLine + 1);
                        MoveLineDown(currentLine, true);
                        ClearLine(currentLine + 1);
                        MoveLineDown(currentLine, false);
                        stuck = true;

                    }
                    else  // not full result line
                    {
                        result = CalculateScore(currentLine);
                        stuck = true;
                        MoveLineDown(currentLine, true);
                    }
                }
            }
            else
            {
                result = CalculateScore(currentLine);
                stuck = true;
            }
        }
        else if (currentLine + 1 == 3)
        {
            result = CalculateScore(currentLine);
        }

        // Actual move down if necessary or possible
        if (!stuck)
        {
            MoveLineDown(currentLine, true);
        }

        return result;
    }

    private static void ClearLine(int currentLine)
    {
        for (int index = 0; index < 32; index++)
        {
            playboard[currentLine, index] = 0;
        }
    }

    private static void ExecuteCommand(string command, int currentLine)
    {
        byte[] tempNumber = new byte[32];
        Array.Copy(currentNumber, tempNumber, 32);
        switch (command)
        {
            case "D":
                // do nothing
                break;
            case "L":

                // shift from 24bit to 31-bit to the left
                if (currentNumber[24] != 1)
                {
                    if (IsCurrentNumberAloneOnLine(currentLine))
                    {
                        ShiftLeft(currentLine);
                    }
                    else
                    {
                        for (int index = 24; index < 31; index++)
                        {
                            int numberBit = currentNumber[index];
                            int lineBit = playboard[currentLine, index];
                            if (lineBit > numberBit && currentNumber[index + 1] == 1)
                            {
                                break;
                            }

                            ShiftLeft(currentLine);
                        }
                    }
                }

                break;
            case "R":
                // shift from 24bit to 31-bit to the right
                if (currentNumber[31] != 1)
                {
                    if (IsCurrentNumberAloneOnLine(currentLine))
                    {
                        ShiftRight(currentLine);
                    }
                    else
                    {
                        for (int index = 25; index < 32; index++)
                        {
                            int numberBit = currentNumber[index];
                            int lineBit = playboard[currentLine, index];
                            if (lineBit > numberBit && currentNumber[index - 1] == 1)
                            {
                                break;
                            }

                            ShiftRight(currentLine);
                        }
                    }
                }

                //if (playboard[currentLine, 31] != 1)
                //{
                //    for (int index = 31; index > 24; index--)
                //    {
                //        playboard[currentLine, index] = playboard[currentLine, index - 1];
                //        currentNumber[index] = playboard[currentLine, index - 1];
                //    }
                //    playboard[currentLine, 24] = 0;
                //}
                break;
        }
    }

    private static void ShiftRight(int currentLine)
    {
        for (int index = 31; index > 24; index--)
        {
            if (currentNumber[index - 1] == 1)
            {
                playboard[currentLine, index] = playboard[currentLine, index - 1];
                currentNumber[index] = playboard[currentLine, index - 1];
                playboard[currentLine, index - 1] = 0;
                currentNumber[index - 1] = 0;

            }
        }

       // playboard[currentLine, 24] = 0;
    }

    private static void ShiftLeft(int currentLine)
    {
        for (int index = 24; index < 31; index++)
        {
            if (currentNumber[index + 1] == 1)
            {
                playboard[currentLine, index] = playboard[currentLine, index + 1];
                currentNumber[index] = playboard[currentLine, index + 1];
                playboard[currentLine, index + 1] = 0;
                currentNumber[index + 1] = 0;
            }
        }

      //  playboard[currentLine, 31] = 0;
    }

    private static int CalculateScore(int currentLine)
    {
        int result = 0;
        for (int index = 0; index < 32; index++)
        {
            result += playboard[currentLine, index];
            if (index < 24)
            {
                playboard[currentLine, index] = 0;
            }
        }

        return result;
    }

    // Checks does the line is empty - no 1s
    private static bool IsLineEmpty(int currentLine)
    {
        bool result = true;
        for (int i = 0; i < 32; i++)
        {
            if (playboard[currentLine, i] == 1)
            {
                result = false;
                break;
            }
        }

        return result;
    }

    private static bool CanBelowLineAccomodateCurrentOne(int currentLine)
    {
        bool result = true;
        bool currentLineBitIsUp = false; ;
        bool belowLineBitIsUp = false;
        for (int index = 24; index < 32; index++)
        {
            currentLineBitIsUp = playboard[currentLine, index] == 1 ? true : false;
            belowLineBitIsUp = playboard[currentLine + 1, index] == 1 ? true : false;
            if (currentLineBitIsUp & belowLineBitIsUp)
            {
                result = false;
                break;
            }
        }

        return result;
    }

    private static byte[] CombineLines(int currentLine)
    {
        // combines only shape - higer bits are zeroed
        // combination is done in temp line, not in currentLine
        byte[] tempLine = new byte[32];
        Array.Copy(currentNumber, 24, tempLine, 24, 8);

        for (int i = 24; i < 32; i++)
        {
            if (playboard[currentLine + 1, i] == 1)
            {
                tempLine[i] = 1;
            }

            if (currentNumber[i] == 1)
            {
                playboard[currentLine, i] = 0;
            }
        }

        //for (int i = 24; i < 32; i++)
        //{
        //    if (playboard[currentLine + 1, i] == 1)
        //    {
        //        playboard[currentLine, i] = 1;
        //    }
        //}

        // zeros the higher bits
        //for (int i = 0; i < 24; i++)
        //{
        //    playboard[currentLine, i] = 0;
        //}

        return tempLine;
    }

    private static void MoveLineDown(int currentLine, bool withCombining)
    {
        byte[] tempCombinedLine = new byte[32];
        if (withCombining)
        {
            Array.Copy(CombineLines(currentLine), tempCombinedLine, 32);
            for (int index = 0; index < 32; index++)
            {
                playboard[currentLine + 1, index] = tempCombinedLine[index];
            }
        }
        else
        {
            // shift above lines (above currentLine +1) with one down 
            for (int row = currentLine; row >= 0; row--)
            {
                for (int index = 0; index < 32; index++)
                {
                    playboard[row + 1, index] = playboard[row, index];
                }
            }

            // zeros the row 0 of playboard
            ClearLine(0);
        }
    }

    private static bool IsCurrentNumberAloneOnLine(int currentLine)
    {
        bool result = true;
        for (int index = 24; index < 32; index++)
        {
            if (currentNumber[index] != playboard[currentLine, index])
            {
                result = false;
                break;
            }
        }

        return result;
    }
}