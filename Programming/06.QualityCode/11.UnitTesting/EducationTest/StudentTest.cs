using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Education
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestNewStudentIdTrivial()
        {
            Student studentOne = new Student("Pencho", 12300);
            Assert.AreEqual(12300, studentOne.Uid);
        }

        [TestMethod]
        public void TestNewStudentNameTrivial()
        {
            Student studentOne = new Student("Pencho", 12300);
            Assert.AreEqual("Pencho", studentOne.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNewStudentIdBelowAllowed()
        {
            Student studentOne = new Student("Pencho", 123);
        }  

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNewStudentIdAboveAllowed()
        {
            Student studentOne = new Student("Pencho", 123000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNewStudentNameEmpty()
        {
            Student studentOne = new Student("", 12300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNewStudentNameNull()
        {
            Student studentOne = new Student(null, 12300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNewStudentNameSpaces()
        {
            Student studentOne = new Student("    ", 12300);
        }
    }
}
