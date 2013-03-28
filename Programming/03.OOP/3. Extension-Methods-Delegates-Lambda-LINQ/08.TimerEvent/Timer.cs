// Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace MyTimerEvent
{
    using System;
    using System.Threading;

    public class Timer
    {
        // event declaration
        public event EventHandler TimerEvent;

        public int Interval { get; private set; }

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
        /// Event invocation on TImer object
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected virtual void OnTimeElapsed(EventArgs e)
        {
            EventHandler handler = this.TimerEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// ThreadStart method delegate to be executed when timer starts
        /// </summary>
        private void DoWork()
        {
            while (!this.Stop)
            {
                Thread.Sleep(this.Interval);
                this.OnTimeElapsed(new EventArgs());
            }
        }
    }
}
