using System;
using System.Text;

public class PolynomialsOperations
{
    // Exercise 11
    // Write a method that adds two polynomials. 
    // Represent them as arrays of their coefficients as in the example below:
    // x² + 5 = 1x² + 0x + 5 -> 5 0 1

    // Exercise 12
    // Extend the program to support also subtraction and multiplication of polynomials.

    public static void Main()
    {
        Console.Title = "Operations with polynomials.";

        // dimension 1 & 2 holds polynomials; 3 - result of addition; 4 - result of subtraction; 5 - result of multiplication
        decimal[][] polynomials = new decimal[5][];

        // input of first polynomial largest degree 
        int enteredDegree = InputDegree("first");
        polynomials[0] = new decimal[enteredDegree];

        // input of the first polynomial coeficients
        InputCoeficients(ref polynomials[0]);

        // input of second polynomial largest degree
        enteredDegree = InputDegree("second");
        polynomials[1] = new decimal[enteredDegree];

        //// input of the second polynomial coeficients
        InputCoeficients(ref polynomials[1]);
        Console.WriteLine();

        // print both polynomials for check by user
        Print(polynomials[0], "First polynomial: ");
        Print(polynomials[1], "Second polynomial: ");
        Console.WriteLine();

        // Addition of two polynomials
        polynomials[2] = new decimal[polynomials[0].Length > polynomials[1].Length ? polynomials[0].Length : polynomials[1].Length];
        Function(ref polynomials, '+');
        Print(polynomials[2], "Addition result: ");
        Console.WriteLine();

        // subtraction of two polynomials
        polynomials[3] = new decimal[polynomials[0].Length > polynomials[1].Length ? polynomials[0].Length : polynomials[1].Length];
        Function(ref polynomials, '-');
        Print(polynomials[3], "subtraction result: ");
        Console.WriteLine();

        // Multiplication of two polynomials
        polynomials[4] = new decimal[polynomials[0].Length + polynomials[1].Length];
        Function(ref polynomials, '*');
        Print(polynomials[4], "Multiplication result: ");
        Console.WriteLine();
    }

    // all operations over polynomials (addition, subtraction, multiplication)
    private static void Function(ref decimal[][] array, char operation)
    {
        int smallerPolynomial = array[0].Length > array[1].Length ? 1 : 0;
        int biggerPolynomial = array[0].Length > array[1].Length ? 0 : 1;
        for (int index = 0; index < array[biggerPolynomial].Length; index++)
        {
            switch (operation)
            {
                case '+':
                    if (index < array[smallerPolynomial].Length)
                    {
                        array[2][index] = array[0][index] + array[1][index];
                    }
                    else
                    {
                        array[2][index] = array[biggerPolynomial][index];
                    }

                    break;
                case '-':
                    if (index < array[smallerPolynomial].Length)
                    {
                        array[3][index] = array[0][index] - array[1][index];
                    }
                    else
                    {
                        array[3][index] = array[biggerPolynomial][index];
                    }

                    break;
                case '*':
                    for (int smallIndex = 0; smallIndex < array[smallerPolynomial].Length; smallIndex++)
                    {
                        int position = index + smallIndex;
                        array[4][position] += array[biggerPolynomial][index] * array[smallerPolynomial][smallIndex];
                    }

                    break;
                default:
                    Console.WriteLine("Not implemented operation! Exiting...");
                    break;
            }
        }
    }

    // print polynomial on the screen
    private static void Print(decimal[] array, string message)
    {
        Console.Write(message);
        StringBuilder polynomial = new StringBuilder();
        string textPolynomial = string.Empty;
        for (int index = array.Length - 1; index >= 0; index--)
        {
            if (array[index] != 0)
            {
                switch (index)
                {
                    case 0:
                        if (polynomial.Length > 0)
                        {
                            textPolynomial = (array[index] > 0 ? "+" : string.Empty) + array[index];
                            polynomial.Append(textPolynomial);
                        }
                        else
                        {
                            textPolynomial = array[index].ToString();
                            polynomial.Append(textPolynomial);
                        }

                        break;
                    case 1:
                        if (polynomial.Length > 0)
                        {
                            textPolynomial = (array[index] > 0 ? "+" : string.Empty) + (array[index] != 1 ? array[index].ToString() : string.Empty) + "x";
                            polynomial.Append(textPolynomial);
                        }
                        else
                        {
                            textPolynomial = (array[index] != 1 ? array[index].ToString() : string.Empty) + "x";
                            polynomial.Append(textPolynomial);
                        }

                        break;
                    default:
                        if (polynomial.Length > 0)
                        {
                            textPolynomial = (array[index] > 0 ? "+" : string.Empty) + (array[index] != 1 ? array[index].ToString() : string.Empty) + "x^" + index;
                            polynomial.Append(textPolynomial);
                        }
                        else
                        {
                            textPolynomial = (array[index] != 1 ? array[index].ToString() : string.Empty) + "x^" + index;
                            polynomial.Append(textPolynomial);
                        }

                        break;
                }
            }
        }

        Console.WriteLine(polynomial);
    }

    // manage input of polynomial's degree
    private static int InputDegree(string number)
    {
        bool noError = false;
        int degree = 0;
        do
        {
            Console.Write("What is the largest degree of your {0} polynomial: ", number);
            noError = int.TryParse(Console.ReadLine(), out degree);
            if ((!noError) || (degree < 0))
            {
                noError = ReportError(noError);
            }
        }
        while (!noError);
        return degree + 1;
    }

    // manage input of polynomial's coeficients 
    private static void InputCoeficients(ref decimal[] array)
    {
        bool noError = false;
        Console.WriteLine("Enter the coeficients to respective degree (if none enter 0).");
        for (int degree = array.Length - 1; degree >= 0; degree--)
        {
            do
            {
                if (degree > 0)
                {
                    Console.Write("coef. of x^{0}:", degree);
                }
                else
                {
                    Console.Write("free coef.:");
                }

                noError = decimal.TryParse(Console.ReadLine(), out array[degree]);
                if (!noError)
                {
                    noError = ReportError(noError);
                }
            }
            while (!noError);
        }
    }

    // method used to report user input error
    private static bool ReportError(bool noError)
    {
        Console.WriteLine("Wrong selection detected!");
        Console.WriteLine("Try again <press Enter>...");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
}