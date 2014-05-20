﻿// ********************************
// <copyright file="NumberUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Contains utils to manipulate numbers
    /// </summary>
    public static class NumberUtils
    {
        /// <summary>
        /// Returns name in english of single digit. 
        /// </summary>
        /// <param name="number">Single digit.</param>
        /// <returns>English word of the provided digit.</returns>
        public static string ConvertSingleDigitToWord(int number)
        {
            if (number.ToString().Length < 2)
            {
                string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                return words[number];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Parameter is not single digit.");
            }
        }

        /// <summary>
        /// Find maximal element in provided range of elements.
        /// </summary>
        /// <param name="elements">Range of integer elements.</param>
        /// <returns>Maximal element in provided range.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements != null && elements.Length != 0)
            {
                int[] workingElements = new int[elements.Length];
                elements.CopyTo(workingElements, 0);
                int maxElement = workingElements[0];
                for (int i = 1; i < elements.Length; i++)
                {
                    if (workingElements[i] > maxElement)
                    {
                        maxElement = elements[i];
                    }
                }

                return maxElement;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No arguments provided.");
            }
        }

        /// <summary>
        /// Formats number as requested by <paramref name="format"/>.
        /// </summary>
        /// <param name="number">Number to be formatted.</param>
        /// <param name="format">Format to be applied: "f" - 2 places after decimal point; "%' - percentage; "r" - 8 places for number.</param>
        /// <returns>Formatted number as string.</returns>
        public static string FormatNumber(object number, string format)
        {
            if (number != null)
            {
                string result = string.Empty;
                switch (format)
                {
                    case "f":
                        result = string.Format("{0:f2}", number);
                        break;
                    case "%":
                        result = string.Format("{0:p0}", number);
                        break;
                    case "r":
                        result = string.Format("{0,8}", number);
                        break;
                    default: throw new ArgumentException("Illegal format parameter provided.");
                }

                return result;
            }
            else
            {
                throw new ArgumentNullException("No number provided to be formated.");
            }
        }
    }
}