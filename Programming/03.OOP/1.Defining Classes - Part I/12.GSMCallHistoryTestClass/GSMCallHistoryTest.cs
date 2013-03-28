// Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
// - Create an instance of the GSM class.
// - Add few calls.
// - Display the information about the calls.
// - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
// - Remove the longest call from the history and calculate the total price again.
// - Finally clear the call history and print it.

namespace MobilePhone
{
    using System;

    public class GSMCallHistoryTest
    {
        private TimeSpan longestCallDuration = TimeSpan.Zero;
        private Call longestCall = null;

        public GSMCallHistoryTest()
        {
            // instantiate the GSM class and initialize using it static constructor 
            GSM phone = new GSM();

            // initialize CallHistory by adding some phone calls
            GSM.CallHistory.Add(new Call("02 000000", DateTime.Now, 30));
            GSM.CallHistory.Add(new Call("02 000001", DateTime.Now.AddMinutes(1.5), 3));
            GSM.CallHistory.Add(new Call("02 000002", DateTime.Now.AddMinutes(2.5), 34));
            GSM.CallHistory.Add(new Call("02 000003", DateTime.Now.AddMinutes(3.5), 31));
            GSM.CallHistory.Add(new Call("02 000004", DateTime.Now.AddMinutes(4.5), 12));
            GSM.CallHistory.Add(new Call("02 000005", DateTime.Now.AddHours(1.0), 15));

            // prints all calls info and meanwhile search for longest call
            this.PrintCallHistory();

            // print current amount before removing the longest call
            Console.WriteLine("Total Price for all calls: {0:C}\n", phone.SumPhoneCallsPrice(0.37M));

            // find and remove longest call
            if (this.longestCall != null)
            {
                phone.RemovePhoneCall(this.longestCall);
                Console.WriteLine("Phone call with longest duration has been deleted from call history.\nDetails follow:");
                Console.WriteLine(this.longestCall.ToString());
            }

            // print current amount after removing longest call
            Console.WriteLine("\nTotal Price for all calls after removal of longest: {0:C}\n", phone.SumPhoneCallsPrice(0.37M));

            // Clear the whole call history
            phone.ClearPhoneCalls();
            Console.WriteLine("All phone calls has been deleted.\n");

            // print again the empty CallHistory static list
            this.PrintCallHistory();
        }

        // prints calls details in history list if any
        public void PrintCallHistory()
        {
            if (GSM.CallHistory.Count != 0)
            {
                // there are phone calls in list
                foreach (var call in GSM.CallHistory)
                {
                    if (this.longestCallDuration.TotalSeconds < call.Duration)
                    {
                        // remember current longest call
                        this.longestCallDuration = new TimeSpan(0, 0, call.Duration);
                        // take the reference to longest call object in order to delete it later
                        this.longestCall = call;
                    }

                    Console.WriteLine(call.ToString() + "\n");
                }

                return;
            }

            // call history is empty
            Console.WriteLine("There are no phone calls in memory.");
        }

        public static void Main()
        {
            // we are using the GSMCallHistoryTest class constructor to run the tests
            GSMCallHistoryTest test = new GSMCallHistoryTest();
        }
    }
}
