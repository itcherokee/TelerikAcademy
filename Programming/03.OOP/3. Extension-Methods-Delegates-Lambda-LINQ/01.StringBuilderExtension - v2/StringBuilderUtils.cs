// Task 1:  Implement an extension method Substring(int index, int length) for the class StringBuilder
//          that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace StringBuilderExtension
{
    using System.Text;

    public static class StringBuilderUtils
    {
        /// <summary>
        /// Retrieves a substring from this instance. 
        /// The substring starts at the specified position and has the specified length.
        /// </summary>
        /// <param name="source">Instance object, which is going to be used as source.</param>
        /// <param name="index">The zero-based starting character position of subsstring.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>Substring from the instance string.</returns>
        public static StringBuilder SubString(this StringBuilder source, int index, int length)
        {
            var output = new StringBuilder(length);
            for (int i = index; i < index + length; i++)
            {
                output.Append(source[i]);
            }

            return output;
        }

        /// <summary>
        /// Retrieves a substring from this instance.
        /// The substring starts at the specified position to the end of the instance text.
        /// </summary>
        /// <param name="source">Instance object, which is going to be used as source.</param>
        /// <param name="index">The zero-based starting character position of subsstring</param>
        /// <returns>Substring from the instance string.</returns>
        public static StringBuilder SubString(this StringBuilder source, int index)
        {
            var output = new StringBuilder();
            for (int i = index; i < source.Length; i++)
            {
                output.Append(source[i]);
            }

            return output;
        }
    }
}
