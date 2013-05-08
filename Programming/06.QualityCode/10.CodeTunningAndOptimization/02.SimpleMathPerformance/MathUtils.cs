namespace SimpleMathPerformance
{
    using System;

    class MathUtils
    {
        internal static T Add<T>(T operandOne, T operandTwo) where T : struct
        {
            dynamic firstOperand = operandOne;
            dynamic secondOperand = operandTwo;
            T result = firstOperand + secondOperand;
            return result;
        }

        internal static T Subtract<T>(T operandOne, T operandTwo) where T : struct
        {
            dynamic firstOperand = operandOne;
            dynamic secondOperand = operandTwo;
            T result = firstOperand - secondOperand;
            return result;
        }

        internal static T Increment<T>(T operandOne, int incrementOffset) where T : struct
        {
            dynamic firstOperand = operandOne;
            int secondOperand = incrementOffset;
            for (int index = 0; index < incrementOffset; index++)
            {
                firstOperand++;
            }

            return firstOperand;
        }

        internal static T Multiply<T>(T operandOne, T operandTwo) where T : struct
        {
            dynamic firstOperand = operandOne;
            dynamic secondOperand = operandTwo;
            T result = firstOperand * secondOperand;
            return result;
        }

        internal static T Divide<T>(T operandOne, T operandTwo) where T : struct
        {
            dynamic firstOperand = operandOne;
            dynamic secondOperand = operandTwo;
            T result = firstOperand / secondOperand;
            return result;
        }
    }
}
