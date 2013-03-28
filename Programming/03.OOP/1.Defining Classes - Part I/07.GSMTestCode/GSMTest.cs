// Write a class GSMTest to test the GSM class:
// Create an array of few instances of the GSM class.
// Display the information about the GSMs in the array.
// Display the information about the static property IPhone4S.

namespace MobilePhone
{
    using System;

    public class GSMTest
    {
        private const int count = 5;  // number of GSM objects to be created
        private GSM[] gsmArray;
        private string[] models;
        private string[] batteries;

        // constructor to initialize the fields of GSMTest class
        public GSMTest()
        {
            this.models = new string[] { "Galaxy S", "Galaxy SII", "Galaxy SIII", "Galaxy Note", "Galaxy Y", "Galaxy S+", "Galaxy SII Loflower" };
            this.batteries = new string[this.models.Length];
            Random gen = new Random();
            for (int i = 0; i < this.batteries.Length; i++)
            {
                // loading of field batteries with random values taken from Enumeration of Battery types
                this.batteries[i] = gen.Next(0, Enum.GetNames(typeof(Battery.BatteryType)).Length).ToString();
            }

            this.gsmArray = new GSM[count];
        }

        // used to create and load the GSM instances with values
        public void Load()
        {
            Random gen = new Random();
            double[] screenSizes = { 3, 3.5, 4, 4.3, 5 };
            for (int i = 0; i < count; i++)
            {
                // initalizing with random values the battery object fields that is going to be referenced by instance of GSM object
                Battery tempBattery = new Battery("built-in", TimeSpan.Zero, TimeSpan.Zero, (Battery.BatteryType)gen.Next(0, Enum.GetNames(typeof(Battery.BatteryType)).Length));

                // initalizing with random values the display object fields that is going to be referenced by instance of GSM object
                Display tempDisplay = new Display(screenSizes[gen.Next(0, screenSizes.Length)], 256000);

                // instantiating the GSM class with values and referencing previously created two objects - Display & Battery
                this.gsmArray[i] = new GSM(this.models[gen.Next(0, count - 1)], "Samsung", gen.Next(100, 1000), "Nobody", tempBattery, tempDisplay);
            }
        }

        // method used to visualize all the instantiated GSM objects + static IPhone4S static object(field)
        public void DisplayToConsole()
        {
            foreach (var mobile in this.gsmArray)
            {
                Console.WriteLine(mobile.ToString());
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone4S);
        }

        public static void Main()
        {
            GSMTest testGSMclass = new GSMTest();
            testGSMclass.Load();
            testGSMclass.DisplayToConsole();
        }
    }
}
