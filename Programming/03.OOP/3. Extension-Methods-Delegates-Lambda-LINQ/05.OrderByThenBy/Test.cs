namespace MyOrderByThenBy
{
    using System;
    using System.Linq;

    public class Test
    {
        public static void Main(string[] args)
        {
            // Tests Extension methods OrderBy and ThenBy - Task 5
            Console.WriteLine("\n" + new string('-', 50) + "\nTests Extension methods OrderBy and ThenBy - Task 5\n" + new string('-', 50));

            Student firstStudent = new Student() { FirstName = "Anton", LastName = "Petrov", Age = 17 };
            Student secondStudent = new Student() { FirstName = "Zoro", LastName = "Petrov", Age = 24 };
            Student thirdStudent = new Student() { FirstName = "Petyo", LastName = "Zabov", Age = 18 };
            Student fourthStudent = new Student() { FirstName = "Hihi", LastName = "Muhito", Age = 18 };
            Student fifthStudent = new Student() { FirstName = "Hihi", LastName = "Ahito", Age = 18 };
            Student sixthStudent = new Student() { FirstName = "Hihi", LastName = "Hihito", Age = 18 };
            Students students = new Students() { firstStudent, secondStudent, thirdStudent, fourthStudent, fifthStudent, sixthStudent };
            Console.WriteLine("Using LINQ query:\n");
            var sortedOne = students.SortLINQ();
            foreach (Student item in sortedOne)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nUsing Extension methods:\n");
            var sortedTwo = students.SortExtension();
            foreach (Student item in sortedTwo)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
