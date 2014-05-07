//// Write a program to compare the performance of add, subtract, increment, multiply, divide 
//// for int, long, float, double and decimal values.

namespace SimpleMathPerformance
{
    using System;
    using System.Diagnostics;

    public class SimpleMathPerformance
    {
        static void Main()
        {
            Stopwatch timeElapsed = new Stopwatch();

            // test Addition performance
            int numberOneInt = 10000;
            int numberTwoInt = 1000;
            timeElapsed.Start();
            int resultInt = MathUtils.Add(numberOneInt, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Addition of {0} + {1} presented in \"int\" took: {2}", numberOneInt, numberTwoInt, timeElapsed.Elapsed);
            timeElapsed.Reset();

            long numberOneLong = 10000L;
            long numberTwoLong = 1000L;
            timeElapsed.Start();
            long resultLong = MathUtils.Add(numberOneLong, numberTwoLong);
            timeElapsed.Stop();
            Console.WriteLine("Addition of {0} + {1} presented in \"long\" took: {2}", numberOneLong, numberTwoLong, timeElapsed.Elapsed);
            timeElapsed.Reset();

            float numberOneFloat = 10000f;
            float numberTwoFloat = 1000f;
            timeElapsed.Start();
            float resultFloat = MathUtils.Add(numberOneFloat, numberTwoFloat);
            timeElapsed.Stop();
            Console.WriteLine("Addition of {0} + {1} presented in \"float\" took: {2}", numberOneFloat, numberTwoFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            double numberOneDouble = 10000d;
            double numberTwoDouble = 1000d;
            timeElapsed.Start();
            double resultDouble = MathUtils.Add(numberOneDouble, numberTwoDouble);
            timeElapsed.Stop();
            Console.WriteLine("Addition of {0} + {1} presented in \"double\" took: {2}", numberOneDouble, numberTwoDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            decimal numberOneDecimal = 10000m;
            decimal numberTwoDecimal = 1000m;
            timeElapsed.Start();
            decimal resultDecimal = MathUtils.Add(numberOneDecimal, numberTwoDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Addition of {0} + {1} presented in \"decimal\" took: {2}", numberOneDecimal, numberTwoDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test Subtract performance
            numberOneInt = 10000;
            numberTwoInt = 1000;
            timeElapsed.Start();
            resultInt = MathUtils.Subtract(numberOneInt, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Subtraction of {0} - {1} presented in \"int\" took: {2}", numberOneInt, numberTwoInt, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneLong = 10000L;
            numberTwoLong = 1000L;
            timeElapsed.Start();
            resultLong = MathUtils.Subtract(numberOneLong, numberTwoLong);
            timeElapsed.Stop();
            Console.WriteLine("Subtraction of {0} - {1} presented in \"long\" took: {2}", numberOneLong, numberTwoLong, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneFloat = 10000f;
            numberTwoFloat = 1000f;
            timeElapsed.Start();
            resultFloat = MathUtils.Subtract(numberOneFloat, numberTwoFloat);
            timeElapsed.Stop();
            Console.WriteLine("Subtraction of {0} - {1} presented in \"float\" took: {2}", numberOneFloat, numberTwoFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDouble = 10000d;
            numberTwoDouble = 1000d;
            timeElapsed.Start();
            resultDouble = MathUtils.Subtract(numberOneDouble, numberTwoDouble);
            timeElapsed.Stop();
            Console.WriteLine("Subtraction of {0} - {1} presented in \"double\" took: {2}", numberOneDouble, numberTwoDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDecimal = 10000m;
            numberTwoDecimal = 1000m;
            timeElapsed.Start();
            resultDecimal = MathUtils.Subtract(numberOneDecimal, numberTwoDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Subtraction of {0} - {1} presented in \"decimal\" took: {2}", numberOneDecimal, numberTwoDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test Increment performance
            numberOneInt = 10000;
            numberTwoInt = 1000;
            timeElapsed.Start();
            resultInt = MathUtils.Increment(numberOneInt, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Incremention of {0} with 1, {1} times presented in \"int\" took: {2}", numberOneInt, numberTwoInt, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneLong = 10000L;
            timeElapsed.Start();
            resultLong = MathUtils.Increment(numberOneLong, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Incremention of {0} with 1, {1} times presented in \"long\" took: {2}", numberOneLong, numberTwoLong, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneFloat = 10000f;
            timeElapsed.Start();
            resultFloat = MathUtils.Increment(numberOneFloat, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Incremention of {0} with 1, {1} times presented in \"float\" took: {2}", numberOneFloat, numberTwoFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDouble = 10000d;
            timeElapsed.Start();
            resultDouble = MathUtils.Increment(numberOneDouble, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Incremention of {0} with 1, {1} times presented in \"double\" took: {2}", numberOneDouble, numberTwoDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDecimal = 10000m;
            timeElapsed.Start();
            resultDecimal = MathUtils.Increment(numberOneDecimal, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Incremention of {0} with 1, {1} times presented in \"decimal\" took: {2}", numberOneDecimal, numberTwoDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test Multiply performance
            numberOneInt = 10000;
            numberTwoInt = 10;
            timeElapsed.Start();
            resultInt = MathUtils.Multiply(numberOneInt, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Multiply {0} by {1} presented in \"int\" took: {2}", numberOneInt, numberTwoInt, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneLong = 10000L;
            numberTwoLong = 10L;
            timeElapsed.Start();
            resultLong = MathUtils.Multiply(numberOneLong, numberTwoLong);
            timeElapsed.Stop();
            Console.WriteLine("Multiply {0} by {1} presented in \"long\" took: {2}", numberOneLong, numberTwoLong, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneFloat = 10000f;
            numberTwoFloat = 10f;
            timeElapsed.Start();
            resultFloat = MathUtils.Multiply(numberOneFloat, numberTwoFloat);
            timeElapsed.Stop();
            Console.WriteLine("Multiply {0} by {1} presented in \"float\" took: {2}", numberOneFloat, numberTwoFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDouble = 10000d;
            numberTwoDouble = 10d;
            timeElapsed.Start();
            resultDouble = MathUtils.Multiply(numberOneDouble, numberTwoDouble);
            timeElapsed.Stop();
            Console.WriteLine("Multiply {0} by {1} presented in \"double\" took: {2}", numberOneDouble, numberTwoDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDecimal = 10000m;
            numberTwoDecimal = 10m;
            timeElapsed.Start();
            resultDecimal = MathUtils.Multiply(numberOneDecimal, numberTwoDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Multiply {0} by {1} presented in \"decimal\" took: {2}", numberOneDecimal, numberTwoDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test Divide performance
            numberOneInt = 10000;
            numberTwoInt = 10;
            timeElapsed.Start();
            resultInt = MathUtils.Divide(numberOneInt, numberTwoInt);
            timeElapsed.Stop();
            Console.WriteLine("Division of {0} by {1} presented in \"int\" took: {2}", numberOneInt, numberTwoInt, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneLong = 10000L;
            numberTwoLong = 10L;
            timeElapsed.Start();
            resultLong = MathUtils.Divide(numberOneLong, numberTwoLong);
            timeElapsed.Stop();
            Console.WriteLine("Division of {0} by {1} presented in \"long\" took: {2}", numberOneLong, numberTwoLong, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneFloat = 10000f;
            numberTwoFloat = 10f;
            timeElapsed.Start();
            resultFloat = MathUtils.Divide(numberOneFloat, numberTwoFloat);
            timeElapsed.Stop();
            Console.WriteLine("Division of {0} by {1} presented in \"float\" took: {2}", numberOneFloat, numberTwoFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDouble = 10000d;
            numberTwoDouble = 10d;
            timeElapsed.Start();
            resultDouble = MathUtils.Divide(numberOneDouble, numberTwoDouble);
            timeElapsed.Stop();
            Console.WriteLine("Division of {0} by {1} presented in \"double\" took: {2}", numberOneDouble, numberTwoDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            numberOneDecimal = 10000m;
            numberTwoDecimal = 10m;
            timeElapsed.Start();
            resultDecimal = MathUtils.Divide(numberOneDecimal, numberTwoDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Division of {0} by {1} presented in \"decimal\" took: {2}", numberOneDecimal, numberTwoDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();
        }
    }
}
