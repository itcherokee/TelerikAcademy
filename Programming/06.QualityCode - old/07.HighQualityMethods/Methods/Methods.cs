// Take the VS solution "Methods" and refactor its code to follow the guidelines of high-quality methods. 
// Ensure you handle errors correctly: when the methods cannot do what their name says, throw an exception 
// (do not return wrong result).Ensure good cohesion and coupling, good naming, no side effects, etc.

namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(GraphicsUtils.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberUtils.ConvertSingleDigitToWord(5));

            Console.WriteLine(NumberUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(NumberUtils.FormatNumber(1.3, "f"));
            Console.WriteLine(NumberUtils.FormatNumber(0.75, "%"));
            Console.WriteLine(NumberUtils.FormatNumber(2.30, "r"));

            double pointOneX = 3;
            double pointOneY = -1;
            double pointTwoX = 3;
            double pointTwoY = 2.5;
            Console.WriteLine(GraphicsUtils.CalculateDistance(pointOneX, pointOneY, pointTwoX, pointTwoY));
            Console.WriteLine("Horizontal? " + GraphicsUtils.IsHorizontal(pointOneY, pointTwoY));
            Console.WriteLine("Vertical? " + GraphicsUtils.IsVertical(pointOneX, pointTwoX));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");

            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
