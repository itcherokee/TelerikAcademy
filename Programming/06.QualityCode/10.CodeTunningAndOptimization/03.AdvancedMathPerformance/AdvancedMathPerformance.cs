//// Write a program to compare the performance of square root, natural logarithm, sinus 
//// for float, double and decimal values.

namespace AdvancedMathPerformance
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathPerformance
    {
        static void Main()
        {
            Stopwatch timeElapsed = new Stopwatch();

            // test square root performance
            float numberFloat = 10000f;
            timeElapsed.Start();
            float resultFloat = MathAdvanceUtils.SquareRoot(numberFloat);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} presented in Float took: {1}", numberFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            double numberDouble = 10000d;
            timeElapsed.Start();
            double resultDouble = MathAdvanceUtils.SquareRoot(numberDouble);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} presented in Double took: {1}", numberDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            decimal numberDecimal = 10000m;
            timeElapsed.Start();
            decimal resultDecimal = MathAdvanceUtils.SquareRoot(numberDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} presented in Float took: {1}", numberDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test natural logarythm performance
            timeElapsed.Start();
            resultFloat = MathAdvanceUtils.Logarithm(numberFloat);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} presented in Float took: {1}", numberFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDouble = MathAdvanceUtils.Logarithm(numberDouble);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} presented in Double took: {1}", numberDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDecimal = MathAdvanceUtils.Logarithm(numberDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} presented in Float took: {1}", numberDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test sinus performance
            float angleFloat = 20f;
            timeElapsed.Start();
            resultFloat = MathAdvanceUtils.Sinus(angleFloat);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} degrees presented in Float took: {1}", angleFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            double angleDouble = 10000d;
            timeElapsed.Start();
            resultDouble = MathAdvanceUtils.Sinus(angleDouble);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} presented in Double took: {1}", angleDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            decimal angleDecimal = 10000m;
            timeElapsed.Start();
            resultDecimal = MathAdvanceUtils.Sinus(angleDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} presented in Float took: {1}", angleDecimal, timeElapsed.Elapsed);
        }
    }
}
