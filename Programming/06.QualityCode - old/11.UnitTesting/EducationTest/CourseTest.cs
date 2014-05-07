using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Education
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseSetNameTrivial()
        {
            Course courseOne = new Course("Math 101");
            Assert.AreEqual("Math 101", courseOne.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseSetNameNull()
        {
            Course courseOne = new Course(null);
        }

        [TestMethod]
        public void TestCourseEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Join(student);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseReEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Join(student);
            success = courseOne.Join(student);
        }

        [TestMethod]
        public void TestCourseUnEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool successEnroll = courseOne.Join(student);
            bool successUnEnroll = courseOne.Leave(student);
            Assert.AreEqual(true, successUnEnroll);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseUnEnrollMissingStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Leave(student);
        }
    }
}
