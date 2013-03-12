// Write a method that from a given array of students finds all students 
// whose first name is before its last name alphabetically. Use LINQ query operators.

namespace MyStudents
{
    using System;
    using System.Linq;

    public class Test
    {
        public static void Main()
        {
            // Tests Student's method FirstBeforeLast name - Task 3
            Console.WriteLine("\n" + new string('-', 50) + "\nTests Student's method FirstBeforeLast name - Task 3\n" + new string('-', 50));

            Student firstStudent = new Student() { FirstName = "Anton", LastName = "Petrov", Age = 10 };
            Student secondStudent = new Student() { FirstName = "Zoro", LastName = "Petrov", Age = 20 };
            Student thirdStudent = new Student() { FirstName = "Petyo", LastName = "Zabov", Age = 30 };
            Students students = new Students() { firstStudent, secondStudent, thirdStudent };
            Console.WriteLine(students.ToString());
        }
    }
}
