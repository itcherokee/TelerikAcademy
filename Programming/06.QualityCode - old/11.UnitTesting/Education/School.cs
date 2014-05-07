namespace Education
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private Dictionary<int, Student> students;
        private readonly List<Course> courses;

        public School(string schoolName)
        {
            this.students = new Dictionary<int, Student>();
            this.SchoolName = schoolName;
            this.courses = new List<Course>();
        }

        public string SchoolName { get; private set; }

        public Dictionary<int, Student> Students 
        {
            get
            {
                return this.students;
            }
            private set
            {
                this.students = value;
            }
        }

        public bool AddStudent(Student student)
        {
            bool isSuccesfulStudentAddition = true;
            if (!this.students.ContainsKey(student.Uid))
            {
                this.students.Add(student.Uid, student);
            }
            else
            {
                isSuccesfulStudentAddition = false;
                throw new ArgumentException("This student is already in that school!");
            }

            return isSuccesfulStudentAddition;
        }

        public bool RemoveStudent(Student student)
        {
            bool isSuccessfulStudentRemove = true;
            if (this.students.ContainsKey(student.Uid))
            {
                this.students.Remove(student.Uid);
            }
            else
            {
                isSuccessfulStudentRemove = false;
                throw new ArgumentException("No such student in school!");
            }

            return isSuccessfulStudentRemove;
        }

        public bool AddCourse(Course course)
        {
            bool isSuccessfulCourseAddition = true;
            if (course != null)
            {
                this.courses.Add(course);
            }
            else
            {
                isSuccessfulCourseAddition = false;
            }

            return isSuccessfulCourseAddition;
        }

        public bool RemoveCourse(Course course)
        {
            bool isSuccessfulStudentRemove = this.courses.Remove(course);
            return isSuccessfulStudentRemove;
        }

        public List<Student> GetSchoolStudents()
        {
            if (this.students.Count != 0)
            {
                List<Student> listOfStudentsInSchool = new List<Student>();
                foreach (var student in this.students)
                {
                    listOfStudentsInSchool.Add(student.Value);
                }

                return listOfStudentsInSchool;
            }
            else
            {
                return null;
            }
        }

        public List<Course> GetSchoolCourses()
        {
            if (this.courses.Count != 0)
            {
                return this.courses;
            }
            else
            {
                return null;
            }
        }
    }
}
