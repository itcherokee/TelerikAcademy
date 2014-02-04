namespace Mobile
{
    using System;

    /// <summary>
    /// Task 12: "Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
    ///             - Create an instance of the GSM class.
    ///             - Add few calls.
    ///             - Display the information about the calls.
    ///             - Assuming that the price per minute is 0.37 calculate and print the total price 
    ///               of the calls in the history.
    ///             - Remove the longest call from the history and calculate the total price again.
    ///             - Finally clear the call history and print it."
    /// </summary>
    public class GSMCallHistoryTest
    {
        public GSMCallHistoryTest()
        {
            // Instantiates GSM class - single phone
            GSM phone = new GSM("Galaxy S", "Samsung");

            // Adding few phone calls
            phone.AddPhoneCall("02 000000", 1);
            phone.AddPhoneCall("02 000001", 3, DateTime.Now.AddMinutes(5));
            phone.AddPhoneCall("02 000002", 4, DateTime.Now.AddHours(1));
            phone.AddPhoneCall("02 000003", 260, DateTime.Now.AddHours(3));
            phone.AddPhoneCall("02 000004", 1740, DateTime.Now.AddHours(7));
            phone.AddPhoneCall("02 000005", 1000, DateTime.Now.AddHours(48));

            // Prints all calls and meanwhile search for longest call
            double longestCallTime = 0.0;
            Guid longestCallId = Guid.Empty;
            int longestCallIndex = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Phonecall List:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int index = 0; index < phone.CallHistory.Count; index++)
            {
                Console.WriteLine(new string('-', 20));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Phone call number {0}: ", index);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(phone.CallHistory[index].ToString());
                if (longestCallTime < phone.CallHistory[index].CallDuration)
                {
                    longestCallTime = phone.CallHistory[index].CallDuration;
                    longestCallId = phone.CallHistory[index].CallId;
                    longestCallIndex = index;
                }
            }

            // print current cost for all phone calls
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTotal cost of all calls: {0:C}\n", phone.CalculatePhoneCallsPrice(0.37m));

            // Remove longest call
            if (longestCallId != Guid.Empty)
            {
                phone.RemovePhoneCall(longestCallId);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Phone call with longest duration has been deleted from call history.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Details for longest phone call:");
                Console.WriteLine(phone.CallHistory[longestCallIndex].ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no any phone calls done from the phone!");
            }

            // Print current amount after removing longest call
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTotal Price for all calls after removal of longest: {0:C}\n", phone.CalculatePhoneCallsPrice(0.37m));

            // Clear the whole call history
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(phone.ClearPhoneCalls() ? "All phone calls has been deleted." : "There is problem deleting phone's call list!");

            // Print again the empty CallHistory list
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPhone's call List:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 20));
            if (phone.CallHistory.Count > 0)
            {
                Console.WriteLine(string.Join("\n", phone.CallHistory));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("List empty!");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Main()
        {
            // we are using the GSMCallHistoryTest class constructor to run the tests
            GSMCallHistoryTest test = new GSMCallHistoryTest();
        }
    }
}
