namespace BooleanConverter
{
    using System;

    /// <summary>
    /// Task 1: Refactor the following examples to produce code with well-named C# identifiers
    /// </summary>
    public class BooleanConverter
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            var booleanData = new BooleanUtils();
            booleanData.PrintToConsole(true);
        }
    }
}
