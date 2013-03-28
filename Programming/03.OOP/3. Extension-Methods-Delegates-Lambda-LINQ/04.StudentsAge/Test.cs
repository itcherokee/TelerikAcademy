namespace MyStudentsAge
{
    using System;
    using System.Linq;

    public class Test
    {
        public static void Main(string[] args)
        {
            // Tests LINQ query that finds students between age 18 & 24 - Task 4
            Console.WriteLine("\n" + new string('-', 50) + "\nTests LINQ query that finds students between age 18 & 24 - Task 4\n" + new string('-', 50));

            Student firstStudent = new Student() { FirstName = "Anton", LastName = "Petrov", Age = 17 };
            Student secondStudent = new Student() { FirstName = "Zoro", LastName = "Petrov", Age = 24 };
            Student thirdStudent = new Student() { FirstName = "Petyo", LastName = "Zabov", Age = 18 };
            Students students = new Students() { firstStudent, secondStudent, thirdStudent };
            Console.WriteLine(students.ToString());
        }
    }
}
