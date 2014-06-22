namespace Education
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseSetNameTrivial()
        {
            Course courseOne = new Course("Math 101");
            Assert.AreEqual("Math 101", courseOne.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseSetNameNull()
        {
            Course courseOne = new Course(null);
        }

        [TestMethod]
        public void CourseEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Join(student);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void CourseEnrollStudentWhenCourseIsFull()
        {
            Course courseOne = new Course("Math 101");
            courseOne.JoinMultiple(CourseCreateListWithMultipleStudents(29).ToList());
            bool success = courseOne.Join(new Student("Pencho", 20000));
            Assert.AreEqual(false, success);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseReEnrollMultipleStudent()
        {
            Course courseOne = new Course("Math 101");
            courseOne.JoinMultiple(CourseCreateListWithMultipleStudents(10).ToList());
            courseOne.JoinMultiple(CourseCreateListWithMultipleStudents(10).ToList());
        }

        [TestMethod]
        public void CourseEnrollMoreStudentsThanAllowed()
        {
            Course courseOne = new Course("Math 101");
            bool success = courseOne.JoinMultiple(CourseCreateListWithMultipleStudents(30).ToList());
            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void CourseGetEnrolledStudents()
        {
            var course = new Course("Math 101");
            var students = CourseCreateListWithMultipleStudents().ToList();
            course.JoinMultiple(students);
            CollectionAssert.AreEqual(students, course.GetEnrolledStudents());
        }

        [TestMethod]
        public void CourseGetEnrolledStudentsWhenThereIsNone()
        {
            var course = new Course("Math 101");
            Assert.IsNull(course.GetEnrolledStudents());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseReEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Join(student);
            success = courseOne.Join(student);
        }

        [TestMethod]
        public void CourseUnEnrollStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool successEnroll = courseOne.Join(student);
            bool successUnEnroll = courseOne.Leave(student);
            Assert.AreEqual(true, successUnEnroll);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseUnEnrollMissingStudent()
        {
            Student student = new Student("Pencho", 10000);
            Course courseOne = new Course("Math 101");
            bool success = courseOne.Leave(student);
        }

        private static IEnumerable<Student> CourseCreateListWithMultipleStudents(int number = 5)
        {
            var students = new List<Student>();
            for (int i = 0; i < number; i++)
            {
                students.Add(new Student("Goshko" + i, 10000 + i));
            }

            return students;
        }
    }
}
