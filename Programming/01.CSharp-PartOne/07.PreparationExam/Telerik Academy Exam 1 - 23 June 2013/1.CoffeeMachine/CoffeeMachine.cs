using System;

public class CoffeeMachine
{
    public static void Main()
    {
        // variables declariations
        float[,] slot = { { 0, 0.05f }, { 0, 0.10f }, { 0, 0.20f }, { 0, 0.50f }, { 0, 1.00f } };
        float deposit;
        float price;
        float totalAmountInMachine = 0.0f;

        // input N's slots - n[0]=0.05 ... n[4]=1.00
        for (int count = 0; count < 5; count++)
        {
            slot[count, 0] = short.Parse(Console.ReadLine()) * slot[count, 1];
            totalAmountInMachine += slot[count, 0];
        }

        deposit = float.Parse(Console.ReadLine());
        price = float.Parse(Console.ReadLine());

        if (deposit < price)
        {
            // check does the amount developer given is less the price for drink
            Console.WriteLine("More {0,2:F}", price - deposit);
        }
        else if (deposit - price > totalAmountInMachine)
        {
            // check does machine has no enough money for change
            Console.WriteLine("No {0,2:F}", deposit - price - totalAmountInMachine);
        }
        else
        {
            // chek what is the change to return
            Console.WriteLine("Yes {0,2:F}", totalAmountInMachine - (deposit - price));
        }
    }
}