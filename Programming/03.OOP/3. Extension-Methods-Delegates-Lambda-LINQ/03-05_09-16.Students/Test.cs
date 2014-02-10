// Task 3:  Write a method that from a given array of students finds all students whose first name is 
//          before its last name alphabetically. Use LINQ query operators.
// Task 4:  Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
// Task 5:  Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by 
//          first name and last name in descending order. Rewrite the same with LINQ.
// Task 9:  Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), 
//          GroupNumber. Create a List<Student> with sample students. Select only the students that are from 
//          group number 2. Use LINQ query. Order the students by FirstName.
// Task 10: Implement the previous using the same query expressed with extension methods.
// Task 11: Extract all students that have email in abv.bg. Use string methods and LINQ.
// Task 12: Extract all students with phones in Sofia. Use LINQ.
// Task 13: Select all students that have at least one mark Excellent (6) into a new anonymous class 
//          that has properties – FullName and Marks. Use LINQ.
// Task 14: Write down a similar program that extracts the students with exactly  two marks "2". 
//          Use extension methods.
// Task 15: Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as 
//          their 5-th and 6-th digit in the FN).
// Task 16: * Create a class Group with properties GroupNumber and DepartmentName. Introduce a property 
//          Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.

namespace MyStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Test
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', 60) + "\nTasks 3, 4, 5, 9, 10, 11, 12, 13, 14, 15, 16, 18, 19\n" + new string('-', 60));
            Console.ForegroundColor = ConsoleColor.White;

            var students = new Students 
            { 
                   new Student
                   {
                        FirstName = "Anton",
                        LastName = "Petrov",
                        Age = 17,
                        GroupNumber = 2,
                        Email = "hoho@abv.bg",
                        Tel = "023444908",
                        Fn = 103456,
                        Marks = new List<byte> { 4, 6, 2, 2 },
                   },

                   new Student
                   {
                        FirstName = "Zoro",
                        LastName = "Petrov",
                        Age = 24,
                        GroupNumber = 3,
                        Email = "zoro@mail.bg",
                        Tel = "023444908",
                        Fn = 233406,
                        Marks = new List<byte> { 2, 6, 4, 6 },
                   },
                   
                   new Student
                   {
                        FirstName = "Petyo",
                        LastName = "Zabov",
                        Age = 18,
                        GroupNumber = 2,
                        Email = "haralampi@abv.bg",
                        Tel = "0323444908",
                        Fn = 544506,
                        Marks = new List<byte> { 2, 2 },
                   },
            };

            // Task 3
            SetTaskTitle("3", "Students with First name are before their Last name:");
            foreach (Student student in students.FirstBeforeLast())
            {
                Console.WriteLine("Student: {0}", student);
            }

            // Task 4
            SetTaskTitle("4", "Students with Age between 18 and 24:");
            foreach (Student student in students.AgeBetween(18, 24))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Age));
            }

            // Task 5a
            SetTaskTitle("5a", "Students sorted in descending (first,last) using lambda expression:");
            foreach (Student student in students.SortExtension())
            {
                Console.WriteLine("Student: {0}", student);
            }

            // Task 5b
            SetTaskTitle("5b", "Students sorted in descending (first,last) using LINQ:");
            foreach (Student student in students.SortLinq())
            {
                Console.WriteLine("Student: {0}", student);
            }

            NextPage();

            // Task 9
            SetTaskTitle("9", "Students with Group Number = 2 (using LINQ):");
            foreach (Student student in students.GroupLinq(2))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Group));
            }

            // Task 10
            SetTaskTitle("10", "Students with Group Number = 2 (using Extension methods):");
            foreach (Student student in students.GroupExtension(2))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Group));
            }

            // Task 11a
            SetTaskTitle("11a", "Students with e-mail from abv.bg (LINQ):");
            foreach (Student student in students.MatchEmailDomain("abv.bg"))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Email));
            }

            // Task 11b
            SetTaskTitle("11b", "Students with e-mail from abv.bg (String methods):");
            foreach (Student student in students)
            {
                string mailDomain = student.Email.Substring(student.Email.LastIndexOf('@') + 1);
                if (mailDomain.Equals("abv.bg"))
                {
                    Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Email));
                }
            }

            // Task 12
            SetTaskTitle("12", "Students with Sofia's area phone number :");
            foreach (Student student in students.MatchPhoneCode("02"))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Tel));
            }

            NextPage();

            // Task 13
            SetTaskTitle("13", "Students with at least one mark of 6:");
            var outstandingStudents = from student in students.GetAllStudents()
                                      where student.Marks.Contains(6)
                                      select new { FullName = student.FirstName + " " + student.LastName, student.Marks };
            foreach (var student in outstandingStudents)
            {
                Console.WriteLine("Student: {0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            // Task 14a
            SetTaskTitle("14a", "Students with exactly two marks \"2\" (could have others as well):");
            var poorStudents = students
                               .GetAllStudents()
                               .Where(student => student.Marks.Count(x => x == 2) == 2)
                               .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });
            foreach (var student in poorStudents)
            {
                Console.WriteLine("Student: {0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            // Task 14b
            SetTaskTitle("14b", "Students with exactly two marks \"2\" (only these marks):");
            var totalPoorStudents = students
                                    .GetAllStudents()
                                    .Where(student => student.Marks.Count(x => x == 2) == 2 && student.Marks.Count() == 2)
                                    .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });

            foreach (var student in totalPoorStudents)
            {
                Console.WriteLine("Student: {0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            // Task 15
            SetTaskTitle("15", "Students graduate in 2006 with their marks:");
            foreach (Student student in students.Graduated(2006))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Fn | Fields.Marks));
            }

            // Task 16
            SetTaskTitle("16", "Students from Mathematics department:");
            var departments = new List<Group>
                                {
                                     new Group { DapartmentName = "Phisics", GroupNumber = 1 },   
                                     new Group { DapartmentName = "Mathematics", GroupNumber = 2 },   
                                     new Group { DapartmentName = "Biology", GroupNumber = 3 },   
                                };

            var mathStudents = from student in students.GetAllStudents()
                               join department in departments on student.GroupNumber equals department.GroupNumber
                               where department.DapartmentName == "Mathematics"
                               select student;

            foreach (var student in mathStudents)
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last));
            }

            NextPage();
        }

        private static void NextPage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        private static void SetTaskTitle(string taskNumber, string description)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Task {0}: ", taskNumber);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(description);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}