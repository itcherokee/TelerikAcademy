namespace MyRangeException.RangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : struct, IComparable<T>, IComparable
    {
        public InvalidRangeException(string msg, T start, T end, Exception innerEx = null)
            : base(msg, innerEx)
        {
            if (start.Equals(default(T)) || end.Equals(default(T)))
            {
                throw new ArgumentNullException("Range parameters cannot be null!");
            }

            if (start.CompareTo(end) > 0)
            {
                string message = "Invalid range parameters provided! End's value must be ahead of Satrt's value. ";
                throw new ArgumentOutOfRangeException(message);
            }

            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }

        public T End { get; private set; }
    }
}