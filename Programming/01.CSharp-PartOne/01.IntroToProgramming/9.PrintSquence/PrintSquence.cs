using System;

class PrintSquence
{
    static void Main()
    {
        Console.Title = "Prin a sequence of 2, -3, 4,.....";
        for (int sequenceNumber = 2; sequenceNumber <= 11; sequenceNumber++)
        {
            if ((sequenceNumber % 2) == 0)
            {
                Console.Write(sequenceNumber.ToString());
            }
            else
            {
                Console.Write((sequenceNumber * -1).ToString());
            }
            if (sequenceNumber < 11)   //за оформяне на редицата с разделител запетая
            {
                Console.Write(", "); 
            }
        }
        Console.ReadKey();
    }
}

