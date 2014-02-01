// We are given a school. In the school there are classes of students. Each class has a set of teachers. 
// Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have 
// unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. 
// Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments 
// (free text block). Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
// encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

namespace MySchool
{
    using System;

    public class Test
    {
        public static void Main(string[] args)
        {
            // teacher & disciplines load
            Teacher teacherOne = new Teacher("Goshko", "Goshkov");
            Discipline disciplineOne = new Discipline("Mathematica", 10, 10);
            Discipline disciplineTwo = new Discipline("Phisics", 10, 10);
            teacherOne.Add(disciplineOne);
            teacherOne.Add(disciplineTwo);

            // student create
            Student studentOne = new Student("Petarcho", "Ptarchov", 1);
            Student studentTwo = new Student("Yordancho", "Yordanov", 2);

            // class create and fill with students and teachers
            Class classOne = new Class("Class One");
            try
            {
                classOne.AddStudent(studentOne);
                classOne.AddStudent(studentTwo);
                classOne.AddTeacher(teacherOne);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // creates school and add class
            School school = new School();
            school.AddClass(classOne);
            Console.WriteLine(school.ToString());
        }
    }
}
