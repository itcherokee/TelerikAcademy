namespace AdvancedMathPerformance
{
    using System;

    class MathAdvanceUtils
    {
        internal static T SquareRoot<T>(T operand) where T : struct
        {
            double firstOperand = (double)operand;
            T result = (T)Math.Sqrt(firstOperand);
            return result;
        }

        internal static T Logarithm<T>(T operand) where T : struct
        {
            double firstOperand = (double)operand;
            T result = (T)Math.Log(firstOperand);
            return result;
        }

        internal static T Sinus<T>(T angle) where T : struct
        {
            double angleOperand = (double)angle;
            T result = (T)Math.Sin(angleOperand);
            return result;
        }
    }
}
