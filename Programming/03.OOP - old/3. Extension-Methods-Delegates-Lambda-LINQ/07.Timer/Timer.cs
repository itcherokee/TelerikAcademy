// Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace MyTimer
{
    using System;
    using System.Threading;

    public class Timer
    {
        public delegate void ExecuteTask();

        public int Interval { get; private set; }

        public ExecuteTask Tasks { get; set; }

        /// <summary>
        /// Stop the timer by setting the value to False
        /// </summary>
        public bool Stop { get; set; }

        /// <summary>
        /// Instantiate an object of Timer with interval set to rise an event
        /// </summary>
        /// <param name="interval">Miliseconds</param>
        public Timer(int interval)
        {
            this.Interval = interval;
        }

        /// <summary>
        /// Starts the background process
        /// </summary>
        public void Start()
        {
            Thread timerThread = new Thread(new ThreadStart(this.DoWork));
            timerThread.Start();
            timerThread.IsBackground = true;
            this.Stop = false;
        }

        /// <summary>
        /// ThreadStart method delegate to be executed when timer starts
        /// </summary>
        private void DoWork()
        {
            if (this.Tasks != null)
            {
                while (!this.Stop)
                {
                    this.Tasks();
                    Thread.Sleep(this.Interval);
                }
            }
        }
    }
}
