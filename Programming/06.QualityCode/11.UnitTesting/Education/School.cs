namespace Education
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private readonly List<Course> courses;
        private Dictionary<int, Student> students;

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
        }

        public bool AddStudent(Student student)
        {
            if (!this.students.ContainsKey(student.Uid))
            {
                this.students.Add(student.Uid, student);
            }
            else
            {
                throw new ArgumentException("This student is already registered in that school!");
            }

            return true;
        }

        public bool RemoveStudent(Student student)
        {
            if (this.students.ContainsKey(student.Uid))
            {
                this.students.Remove(student.Uid);
            }
            else
            {
                throw new ArgumentException("No such student in school!");
            }

            return true;
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
            return this.students.Count != 0 ? this.students.Select(student => student.Value).ToList() : null;
        }

        public List<Course> GetSchoolCourses()
        {
            return this.courses.Count != 0 ? this.courses : null;
        }
    }
}     
