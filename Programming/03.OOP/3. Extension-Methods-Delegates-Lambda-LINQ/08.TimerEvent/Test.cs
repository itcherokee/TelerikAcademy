using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimerEvent
{
    public class Test
    {
        public static void PrintMessage(object sender, EventArgs e)
        {
            Console.WriteLine("I was called by the event fire!");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("\n" + new string('-', 30) + "\nTests Timer class with Events - Task 8\n" + new string('-', 30));

            // instantiates a Timer object with default interval for the event
            Timer runningTimer = new Timer(1000);

            // subscribe to the Timer event
            runningTimer.TimerEvent += PrintMessage;
            
            // starts the Timer
            runningTimer.Start();

            // user interface
            Console.WriteLine("Timer started!");
            Console.WriteLine("Press a key to stop it...");
            Console.ReadKey();

            // stops the Timer
            if (Console.KeyAvailable)
            {
                runningTimer.Stop = true;
            }

            Console.WriteLine("Timer stopped!");
        }
    }
}
