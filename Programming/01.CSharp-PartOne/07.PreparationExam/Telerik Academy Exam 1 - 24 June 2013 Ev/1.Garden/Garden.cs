using System;

public class Garden
{
    public static void Main(string[] args)
    {
        decimal[] seedsPrice = { 0.5m, 0.4m, 0.25m, 0.6m, 0.3m, 0.4m };
        int[,] seedsInfo = new int[3, 6]; // First row is for Seed number; Second row is for Seed Area

        // User input
        seedsInfo[0, 0] = int.Parse(Console.ReadLine());
        seedsInfo[1, 0] = int.Parse(Console.ReadLine());
        seedsInfo[0, 1] = int.Parse(Console.ReadLine());
        seedsInfo[1, 1] = int.Parse(Console.ReadLine());
        seedsInfo[0, 2] = int.Parse(Console.ReadLine());
        seedsInfo[1, 2] = int.Parse(Console.ReadLine());
        seedsInfo[0, 3] = int.Parse(Console.ReadLine());
        seedsInfo[1, 3] = int.Parse(Console.ReadLine());
        seedsInfo[0, 4] = int.Parse(Console.ReadLine());
        seedsInfo[1, 4] = int.Parse(Console.ReadLine());
        seedsInfo[0, 5] = int.Parse(Console.ReadLine());

        // Calculate total seeds cost
        decimal totalCost = 0;
        for (int index = 0; index < 6; index++)
        {
            totalCost += seedsInfo[0, index] * seedsPrice[index];
        }

        Console.WriteLine("Total costs: {0,2:F}", totalCost);

        // Calculate total area except beans
        int totalArea = 250;
        for (int index = 0; index < 5; index++)
        {
            totalArea -= seedsInfo[1, index];
        }

        if (totalArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else if (totalArea < 0)
        {
            Console.WriteLine("Insufficient area");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", totalArea);
        }
    }
}
