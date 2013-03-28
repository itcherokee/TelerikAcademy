// Implement an extension method Substring(int index, int length) for the 
// class StringBuilder that returns new StringBuilder and has the same 
// functionality as Substring in the class String.

namespace StringBuilderExt
{
    using System;
    using System.Text;

    public static class StringBuilderExt
    {
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the specified position and has the specified length.
        /// </summary>
        /// <param name="index">The zero-based starting character position of subsstring</param>
        /// <param name="length">The number of characters in the substring</param>
        /// <returns>Substring from the specified position with specified length</returns>
        public static StringBuilder SubString(this StringBuilder input, int index, int length)
        {
            StringBuilder output = new StringBuilder();
            output.Append(input.ToString().Substring(index, length));
            return output;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the specified position.
        /// </summary>
        /// <param name="index">The zero-based starting character position of subsstring</param>
        /// <returns>Substring from the specified position to the end</returns>
        public static StringBuilder SubString(this StringBuilder input, int index)
        {
            StringBuilder output = new StringBuilder();
            output.Append(input.ToString().Substring(index));
            return output;
        }
    }
}
