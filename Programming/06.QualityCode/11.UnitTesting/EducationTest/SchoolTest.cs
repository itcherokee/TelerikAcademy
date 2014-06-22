namespace Education
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolAddStudent()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            Assert.IsTrue(school.Students.ContainsKey(10000));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolAddStudentWhoAlreadyExist()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            school.AddStudent(studentOne);
        }

        [TestMethod]
        public void SchoolRemoveStudent()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            Assert.IsTrue(school.RemoveStudent(studentOne));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolRemoveStudentWhoNotExist()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.RemoveStudent(studentOne);
        }

        [TestMethod]
        public void SchoolAddSingleCourse()
        {
            School school = new School("Alabala");
            Course course = new Course("Math 101");
            school.AddCourse(course);
            Assert.AreEqual(school.GetSchoolCourses()[0].Name, "Math 101");
        }

        [TestMethod]
        public void SchoolRemoveSingleCourse()
        {
            School school = new School("Alabala");
            Course course = new Course("Math 101");
            school.AddCourse(course);
            bool isRemoved = school.RemoveCourse(course);
            Assert.AreEqual(true, isRemoved);
        }

        [TestMethod]
        public void SchoolAddNNullCourse()
        {
            School school = new School("Alabala");
            Assert.AreEqual(school.AddCourse(null), false);
        }

        [TestMethod]
        public void SchoolGetCourses()
        {
            School school = new School("Alabala");
            Course course = new Course("Math 101");
            school.AddCourse(course);
            Assert.AreEqual(school.GetSchoolCourses().Count, 1);
        }

        [TestMethod]
        public void SchoolGetCoursesWithoutAnyExisitng()
        {
            School school = new School("Alabala");
            Assert.IsNull(school.GetSchoolCourses());
        }

        [TestMethod]
        public void SchoolGetStudentsWithoutAnyExisitng()
        {
            School school = new School("Alabala");
            Assert.IsNull(school.GetSchoolStudents());
        }

        [TestMethod]
        public void SchoolGetStudents()
        {
            Student studentOne = new Student("Pencho", 10000);
            School school = new School("Harvard");
            school.AddStudent(studentOne);
            List<Student> schoolStudents = school.GetSchoolStudents();
            Assert.AreEqual(schoolStudents[0].Name, "Pencho");
        }
    }
}
