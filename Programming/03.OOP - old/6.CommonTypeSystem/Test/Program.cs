using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStudent;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Student studentOne = new Student("Goshko", "Goshkov", "Georgiev", 1234567890, "Sofia", "088888888",
                "goshko@gmail.com", 1, Student.Specialties.ComputerSystems, Student.Faculties.ComputerScience, Student.Universities.Technical);
            Student studentTwo = studentOne.Clone();
            studentTwo.Ssn = 1111111111;
            studentTwo.MiddleName = "Anakin";
            //studentOne.;
            list.Add(studentOne);
            list.Add(studentTwo);
            //Console.WriteLine("StudentOne:\n" + studentOne.ToString());
            //Console.WriteLine("StudentTwo:\n" + studentTwo.ToString());
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item + "\n");
            }

          
        }
    }
}
