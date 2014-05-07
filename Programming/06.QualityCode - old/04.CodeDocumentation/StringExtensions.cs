// --------------------------------------------
// <copyright file="StringExtensions.cs" company="Telerik Academy">
//      Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// -------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extends with additional features the base type class <see cref="System.String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculate the MD5 hash of the string.
        /// </summary>
        /// <param name="input">String which MD5 hash to be calculated.</param>
        /// <returns>System.String representing the computed MD5 hash of provided input data.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var calculatedHash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var resultHash = new StringBuilder();
            for (int i = 0; i < calculatedHash.Length; i++)
            {
                resultHash.Append(calculatedHash[i].ToString("x2"));
            }

            return resultHash.ToString();
        }

        /// <summary>
        /// Check does string contains boolean true values.
        /// </summary>
        /// <param name="input">String to be verified.</param>
        /// <returns>True if contains "true" values, else False.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert string to 16-bit signed integer value.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>16-bit signed integer type converted string if successful else returns 0.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to 32-bit signed integer value.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>32-bit signed integer value if conversion successful else returns 0.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to 64-bit signed integer value.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>64-bit signed integer value if conversion successful else returns 0.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert string to DateTime type.
        /// </summary>
        /// <param name="input">Date in System.String format.</param>
        /// <returns>System.DateTime type converted string.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Convert the string to sentence type (first sentence letter capital).
        /// </summary>
        /// <param name="input">String to be sentence like capitalized.</param>
        /// <returns>System.String formatted in sentence like capitalization.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extract substring by using <paramref name="startString"/> and <paramref name="endString"/>, starting to look-up from position <paramref name="startFrom"/>.
        /// </summary>
        /// <param name="input">String to be processed.</param>
        /// <param name="startString">String to start from.</param>
        /// <param name="endString">String to finish the extraction.</param>
        /// <param name="startFrom">Position from where to start the search for <paramref name="startString"/>.</param>
        /// <returns>Extracted System.String, if one of parameters is not valid or not found, returns System.Empty.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts string in bulgarian to latin letters using Bulgarian phonetic representation of Latin letters.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>System.String containing latin letters mapped to bulgarian phonetic/sound representation of latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts string to cyrillic using Bulgarian representation of Latin keyboard characters.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>System.String containing cyrillic letters mapped to latin keyboard position.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts username written in cyrillic to valid one written in latin letters.
        /// </summary>
        /// <param name="input">Username written with cyrillic letters.</param>
        /// <returns>System.String username with valid formatting and latin letters.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Format a filename to valid one in terms of syntax naming.
        /// </summary>
        /// <param name="input">Filename to be checked and corrected.</param>
        /// <returns>Correct filename string.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extracts first <see cref="charsCount"/> characters form a string, starting from position 0.
        /// </summary>
        /// <param name="input">String to be processed.</param>
        /// <param name="charsCount">Number of characters to be extracted.</param>
        /// <returns>Returns System.String contained requested substring.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extract the file extension from file name.
        /// </summary>
        /// <param name="fileName">File name to extract the extension.</param>
        /// <returns>File extension of provided filename in string format. If <see cref="fileName"/>fileName input string is empty, returns empty string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Find content type of a file.
        /// </summary>
        /// <param name="fileExtension">File name extension.</param>
        /// <returns>Content type of file.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts string into sequence of bytes.
        /// </summary>
        /// <param name="input">System.String type data.</param>
        /// <returns>Array of unsigned bytes.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var resultInBytes = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, resultInBytes, 0, resultInBytes.Length);
            return resultInBytes;
        }
    }
}
