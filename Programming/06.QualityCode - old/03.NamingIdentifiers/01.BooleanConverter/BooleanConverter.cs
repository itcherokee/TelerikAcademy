// Refactor the following examples to produce code with well-named C# identifiers

namespace BooleanConverter
{
    using System;

    public class BooleanConverter
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            BooleanUtils booleanData = new BooleanUtils();
            booleanData.Print(true);
        }
    }
}
