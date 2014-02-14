// Task 2:  Define abstract class Human with first name and last name. Define new class Student which is 
//          derived from Human and has new field – grade. Define class Worker derived from Human with new 
//          property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by 
//          hour by the worker. Define the proper constructors and properties for this hierarchy. Initialize 
//          a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension 
//          method). Initialize a list of 10 workers and sort them by money per hour in descending order. 
//          Merge the lists and sort them by first name and last name.

namespace People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestRun
    {
        public static void Main()
        {
            // create list with/and students
            var students = new List<Student>()
            {
                        new Student("Asen", "Asenov"),
                        new Student("Asen", "Balakov"),
                        new Student("Asen", "Georgiev"),
                        new Student("Asen", "Ivanov"),
                        new Student("Asen", "Kamarov"),
                        new Student("Asen", "Nikolov"),
                        new Student("Asen", "Petrov"),
                        new Student("Asen", "Rusev"),
                        new Student("Asen", "Sosev"),
                        new Student("Asen", "Yonkov", GradeScore.Six) 
            };

            // Assign random grades to students without last one who already have
            Random grade = new Random();
            for (int index = 0; index < students.Count - 1; index++)
            {
                students[index].Grade = (GradeScore)grade.Next(1, 7);
            }

            // Query and print students sorted by grade in ascending order
            var queryStudents = from student in students
                                orderby student.Grade
                                select student;
            Console.WriteLine("Students:");
            foreach (var student in queryStudents)
            {
                Console.Write("{0}  Grade: {1}\n", student, student.Grade);
            }

            // Create list with workers
            var workers = new List<Worker>() 
            {
                        new Worker("Zelyo", "Asenov"),
                        new Worker("Zelyo", "Bozev"),
                        new Worker("Zelyo", "Cocev"),
                        new Worker("Zelyo", "Ivanov"),
                        new Worker("Zelyo", "Kirov"),
                        new Worker("Zelyo", "Lyolev"),
                        new Worker("Zelyo", "Minkov"),
                        new Worker("Zelyo", "Naroden"),
                        new Worker("Zelyo", "Onev"),
                        new Worker("Zelyo", "Zelyov", 3, 1000.0m) 
            };

            // Assign random working hours per day to workers (except last one who already have)
            Random workHoursPerDay = new Random();
            for (int index = 0; index < workers.Count - 1; index++)
            {
                workers[index].WorkHoursPerDay = workHoursPerDay.Next(0, 23);
            }

            // Assign random week salaries to workers (except last one who already have)
            Random salary = new Random();
            for (int index = 0; index < workers.Count - 1; index++)
            {
                workers[index].WeekSalary = salary.Next(1, 8000);
            }

            // Print workers sorted by money per hour
            var queryWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            // var queryWorkers = from worker in workers
            //                   orderby worker.MoneyPerHour()
            //                   select worker;
            Console.WriteLine("\nWorkers:");
            foreach (var worker in queryWorkers)
            {
                Console.Write("{0}  Salary per Hour: {1:C2}\n", worker, worker.MoneyPerHour());
            }

            // Merge and sort the lists (Students & Workers)
            Console.WriteLine("\nCombined List:");
            IEnumerable<Human> mergedList = queryStudents
                                            .Concat<Human>(queryWorkers)
                                            .OrderBy(x => x.FirstName)
                                            .ThenByDescending(x => x.LastName);
            Console.WriteLine(string.Join("\n", mergedList));
        }
    }
}