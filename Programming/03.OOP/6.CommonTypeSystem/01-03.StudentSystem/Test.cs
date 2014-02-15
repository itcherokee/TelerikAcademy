namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using Enumerations;

    public class Test
    {
        public static void Main(string[] args)
        {
            List<Student.Student> list = new List<Student.Student>();
            Student.Student studentOne = new Student.Student("Goshko", "Goshkov", "Georgiev", 1234567890, "Sofia", "088888888",
                "goshko@gmail.com", 1, Speciality.ComputerSystems, Faculty.ComputerScience, University.Technical);
            Student.Student studentTwo = studentOne.Clone();
            Console.WriteLine("Both students are one and the same object: {0}", ReferenceEquals(studentOne, studentTwo));
            Console.WriteLine("Both students are with same values: {0}\n", studentOne.Equals(studentTwo));
            studentTwo.Ssn = 1111111111;
            Student.Student studentThree = new Student.Student("Goshko", "Goshkov", "Georgiev", 00000000000, "Sofia", "088888888",
                "goshko@gmail.com", 1, Speciality.ComputerSystems, Faculty.ComputerScience, University.Technical);
            studentTwo.MiddleName = "Anakin";
            list.Add(studentOne);
            list.Add(studentTwo);
            list.Add(studentThree);
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item + "\n");
            }
        }
    }
}
