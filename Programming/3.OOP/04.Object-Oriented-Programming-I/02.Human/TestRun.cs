// Define abstract class Human with first name and last name. 
// Define new class Student which is derived from Human and has 
// new field – grade. Define class Worker derived from Human with 
// new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
// that returns money earned by hour by the worker. Define the proper 
// constructors and properties for this hierarchy. Initialize a list of 
// 10 students and sort them by grade in ascending order (use LINQ or OrderBy() 
// extension method). Initialize a list of 10 workers and sort them by money 
// per hour in descending order. Merge the lists and sort them by first name and last name.

namespace MyHuman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestRun
    {
        public static void Main()
        {
            // create list with/and students
            List<Student> students = new List<Student>()
            {
                        new Student("AsenOne", "Tsakov"),
                        new Student("AsenTwo", "Makov"),
                        new Student("AsenThree", "Zizov"),
                        new Student("AsenFour", "Tetkov"),
                        new Student("AsenFive", "Mikov"),
                        new Student("AsenSix", "Kikov"),
                        new Student("AsenSeven", "Tetinchov"),
                        new Student("AsenEight", "Gurbev"),
                        new Student("AsenNine", "Pudarchov"),
                        new Student("AsenTen", "Tikvenov") 
            };

            // assign random grades to sstudents
            Random grade = new Random();
            for (int index = 0; index < students.Count; index++)
            {
                students[index].SetGrade((Student.GradeScores)grade.Next(2, 7));
            }

            // print students sorted by grade in ascending order
            var queryStudents = from student in students
                                orderby student.Grade
                                select student;
            Console.WriteLine("Students:");
            foreach (var student in queryStudents)
            {
                Console.Write("{0}  Grade: {1}\n", student.ToString(), student.Grade);

            }
            // create list with/and workers
            List<Worker> workers = new List<Worker>() 
            {
                        new Worker("AsenOne", "Asenchov"),
                        new Worker("AsenTwo", "Petkanov"),
                        new Worker("AsenThree", "Zevzekov"),
                        new Worker("AsenFour", "Rahitov"),
                        new Worker("AsenFive", "Nikolov"),
                        new Worker("AsenSix", "Tutkov"),
                        new Worker("AsenSeven", "Asenchov"),
                        new Worker("AsenEight", "Krastev"),
                        new Worker("AsenNine", "Pippov"),
                        new Worker("AsenTen", "Petranov") 
            };

            // assign random working hours per day to workers
            Random workHoursPerDay = new Random();
            for (int index = 0; index < workers.Count; index++)
            {
                workers[index].WorkHoursPerDay = workHoursPerDay.Next(0, 23);
            }

            // assign random week salaries to workers
            Random salary = new Random();
            for (int index = 0; index < workers.Count; index++)
            {
                workers[index].SetWeekSalary(salary.Next(1, 800));
            }

            // print students sorted by grade in ascending order
            //var salaryPerHourSorted = workers.OrderByDescending(x => x.MoneyPerHour());
            var queryWorkers = from worker in workers
                               orderby worker.MoneyPerHour()
                               select worker;

            Console.WriteLine("\nWorkers:");
            foreach (var worker in queryWorkers)
            {
                Console.Write("{0}  Salary per Hour: {1:C2}\n", worker.ToString(), worker.MoneyPerHour());

            }

            // Merge and sort the lists
            Console.WriteLine("\nCombined List:");
            IEnumerable<Human> merge =
                queryStudents.Concat<Human>(queryWorkers).OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            Console.WriteLine(string.Join("\n", merge));
        }
    }
}
