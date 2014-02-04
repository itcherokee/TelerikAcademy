// Write a class GSMTest to test the GSM class:
// Create an array of few instances of the GSM class.
// Display the information about the GSMs in the array.
// Display the information about the static property IPhone4S.

namespace Mobile
{
    using System;

    public class GSMTest
    {
        private readonly string[] models = new[] { "Galaxy S", "Galaxy SII", "Galaxy SIII", "Galaxy Note", "Galaxy Y", "Galaxy S+", "Galaxy SII+" };
        private readonly GSM[] gsms;

        // constructor to initialize the fields of GSMTest class
        public GSMTest(int numberOfPhones)
        {
            string[] batteries = new string[this.models.Length];
            Random gen = new Random();
            for (int i = 0; i < batteries.Length; i++)
            {
                // loads batteries with random values taken from BatteryType enumeration
                batteries[i] = gen.Next(0, Enum.GetNames(typeof(BatteryType)).Length).ToString();
            }

            this.gsms = new GSM[numberOfPhones];
        }

        // Create and load the GSM instances with values
        public void Initialize()
        {
            Random generator = new Random();
            double[] screenSizes = { 3, 3.5, 4, 4.3, 5 };
            for (int i = 0; i < this.gsms.Length; i++)
            {
                // initalizing with random values the battery object fields 
                Battery tempBattery =
                    new Battery("built-in", (BatteryType)generator.Next(0, Enum.GetNames(typeof(BatteryType)).Length));

                // initalizing with random values the display object fields 
                Display tempDisplay =
                    new Display(screenSizes[generator.Next(0, screenSizes.Length)], (ColorDepth)generator.Next(0, Enum.GetNames(typeof(ColorDepth)).Length));

                // instantiating a GSM class as an element from the array
                this.gsms[i] =
                    new GSM(this.models[generator.Next(0, this.gsms.Length - 1)], "Samsung", generator.Next(100, 1000), "Nobody", tempBattery, tempDisplay);
            }
        }

        // Visualize all the instantiated GSM objects + static IPhone4S static object(field)
        public void Print()
        {
            foreach (var mobile in this.gsms)
            {
                Console.WriteLine(mobile.ToString());
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}