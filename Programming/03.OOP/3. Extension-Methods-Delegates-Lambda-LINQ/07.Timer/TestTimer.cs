namespace MyTimer
{
    using System;

    public class TestTimer
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', 30) + "\nTests Timer class - Task 7\n" + new string('-', 30));
            Console.ForegroundColor = ConsoleColor.White;

            // instantiates a Timer object with default interval for the event
            Timer runningTimer = new Timer(1000);

            // attach a task to a Timer delegate to be executed each interval pass
            runningTimer.Tasks = () => { Console.WriteLine("I'm an event!"); };

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
