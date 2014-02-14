﻿namespace Banking.Utils
{
    using System;

    public static class EikValidator
    {
        private static readonly int[] FirstSum9DigitWeights = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static readonly int[] SecondSum9DigitWeights = { 3, 4, 5, 6, 7, 8, 9, 10 };
        private static readonly int[] FirstSum13DigitWeights = { 2, 7, 3, 5 };
        private static readonly int[] SecondSum13DigitWeights = { 4, 9, 5, 7 };

        public static bool CalculateChecksumForNineDigitsEik(string eik)
        {
            int[] digits = CheckInput(eik, 9);
            int ninthDigit = CalculateNinthDigitInEik(digits);
            return ninthDigit == digits[8];
        }

        public static bool CalculateChecksumForThirteenDigitsEik(string eik)
        {
            int[] digits = CheckInput(eik, 13);
            int thirteenDigit = CalculateThirteenthDigitInEik(digits);
            return thirteenDigit == digits[12];
        }

        private static int CalculateNinthDigitInEik(int[] digits)
        {
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum = sum + (digits[i] * FirstSum9DigitWeights[i]);
            }

            int remainder = sum % 11;
            if (remainder != 10)
            {
                return remainder;
            }

            // remainder= 10
            int secondSum = 0;
            for (int i = 0; i < 8; i++)
            {
                secondSum = secondSum + (digits[i] * SecondSum9DigitWeights[i]);
            }

            int secondRem = secondSum % 11;
            if (secondRem != 10)
            {
                return secondRem;
            }

            // secondRemainder= 10
            return 0;
        }

        private static int CalculateThirteenthDigitInEik(int[] digits)
        {
            int ninthDigit = CalculateNinthDigitInEik(digits);
            if (ninthDigit != digits[8])
            {
                throw new ArgumentException("Incorrect 9th digit in EIK-13.");
            }

            // 9thDigit is a correct checkSum. Continue with 13thDigit
            int sum = 0;
            for (int i = 8, j = 0; j < 4; i++, j++)
            {
                sum = sum + (digits[i] * FirstSum13DigitWeights[j]);
            }

            int remainder = sum % 11;
            if (remainder != 10)
            {
                return remainder;
            }

            // remainder= 10
            int secondSum = 0;
            for (int i = 8, j = 0; j < 4; i++, j++)
            {
                secondSum = secondSum + (digits[i] * SecondSum13DigitWeights[j]);
            }

            int secondRem = secondSum % 11;
            if (secondRem != 10)
            {
                return secondRem;
            }

            // secondRemainder= 10
            return 0;
        }

        private static int[] CheckInput(string eik, int eikLength)
        {
            if (eik != null && eik.Length != eikLength)
            {
                throw new ArgumentException("Incorrect count of digits in EIK: " + eik.Length + "!= 9 or 13");
            }

            // eik.length= eikLength
            char[] charDigits = eik.ToCharArray();
            int[] digits = new int[charDigits.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                if (char.IsDigit(charDigits[i]))
                {
                    digits[i] = int.Parse(charDigits[i].ToString());
                }
                else
                {
                    throw new ArgumentException("Incorrect input character. Only digits are allowed.");
                }
            }

            return digits;
        }
    }
}