using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Education
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestAddStudent()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            Assert.IsTrue(school.Students.ContainsKey(10000));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudentWhoAlreadyExist()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            school.AddStudent(studentOne);
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            Assert.IsTrue(school.RemoveStudent(studentOne));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStudentWhoNotExist()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.RemoveStudent(studentOne);
        }
    }
}
