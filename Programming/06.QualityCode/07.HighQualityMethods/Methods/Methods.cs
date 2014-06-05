// Task 1:  Take the VS solution "Methods" and refactor its code to follow the guidelines of high-quality methods. 
//          Ensure you handle errors correctly: when the methods cannot do what their name says, throw an exception 
//          (do not return wrong result).Ensure good cohesion and coupling, good naming, no side effects, etc.

namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine("--- Test GraphicUtils library ---");
            Console.WriteLine("Tiangle Area (a=3, b=4, c=5) = {0}", GraphicUtils.CalcTriangleArea(3, 4, 5));
            double pointOneX = 3;
            double pointOneY = -1;
            double pointTwoX = 3;
            double pointTwoY = 2.5;
            Console.WriteLine("Distance betwenn A({0}, {1}) & B({2}, {3}) = {4}",
                pointOneX, pointOneY, pointTwoX, pointTwoY, GraphicUtils.CalculateDistance(pointOneX, pointOneY, pointTwoX, pointTwoY));
            Console.WriteLine("y1 and y2 are on the same line horizontaly: " + GraphicUtils.IsHorizontal(pointOneY, pointTwoY));
            Console.WriteLine("x1 and x2 are on the same line verticaly: " + GraphicUtils.IsVertical(pointOneX, pointTwoX));

            Console.WriteLine("\n--- Test NumberUtils library ---");
            int wordNumber = 5;
            int[] someNumbers = { 5, -1, 3, 2, 14, 2, 3 };
            float formatingNumber = 1.3f;
            Console.WriteLine("Number {0} is: {1}", wordNumber, NumberUtils.ConvertSingleDigitToWord(wordNumber));
            Console.WriteLine("Max number between {0} is: {1}",
                string.Join(", ", someNumbers), NumberUtils.FindMax(someNumbers));
            Console.WriteLine("{0} foramted as float with 2 digits afer decimal point: {1}",
                formatingNumber, NumberUtils.FormatNumber(formatingNumber, "f"));
            Console.WriteLine("{0} foramted as percentage: {1}",
                formatingNumber, NumberUtils.FormatNumber(formatingNumber, "%"));
            Console.WriteLine("{0} foramted with 8 positions for number - right alligned: {1}",
                formatingNumber, NumberUtils.FormatNumber(formatingNumber, "r"));

            Console.WriteLine("\n--- Test Person object ---");
            var peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 23), "Hometown - Sofia");
            var stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Hometown - Vidin, gender female");
            Console.WriteLine("{0} is older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
