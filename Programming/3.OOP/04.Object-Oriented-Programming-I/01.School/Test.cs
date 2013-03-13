using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
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
