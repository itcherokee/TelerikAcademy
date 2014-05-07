// Add exception handling (where missing) and refactor all incorrect error handling in the code 
// from the "Exceptions-Homework" project to follow the best practices for using exceptions.

namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            var substr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            try
            {
                Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
                Console.WriteLine(Utils.ExtractEnding("Nakov", 4));

                //// uncomment below two lines to enable exception throw
                //// Console.WriteLine(Utils.ExtractEnding("beer", 4));
                //// Console.WriteLine(Utils.ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            bool isPrime = false;
            int prime = 0;

            try
            {
                prime = 23;
                isPrime = Utils.CheckPrime(prime);
                Console.WriteLine("{0} is" + (isPrime ? " " : " not ") + "prime.", prime);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                prime = 33;
                isPrime = Utils.CheckPrime(prime);
                Console.WriteLine("{0} is" + (isPrime ? " " : " not ") + "prime.", prime);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                prime = -1;
                isPrime = Utils.CheckPrime(prime);
                Console.WriteLine("{0} is" + (isPrime ? " " : " not ") + "prime.", prime);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}