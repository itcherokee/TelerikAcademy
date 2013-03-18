namespace MyException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : struct
    {
        public T Min { get; private set; }

        public T Max { get; private set; }

        public InvalidRangeException(string msg, T min, T max)
            : this(msg, min, max, null)
        {
        }

        public InvalidRangeException(string msg, T min, T max, Exception baseException)
            : base(msg, baseException)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
