namespace Education
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private readonly Dictionary<int, Student> attendingStudents;
        private string name;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.attendingStudents = new Dictionary<int, Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course's name can not be null, empty or only white spaces!");
                }

                this.name = value;
            }
        }

        public bool Join(Student attendingStudent)
        {
            bool isSuccesfulJoin = true;
            if (this.attendingStudents.Count < 30)
            {
                if (!this.attendingStudents.ContainsKey(attendingStudent.Uid))
                {
                   this.attendingStudents.Add(attendingStudent.Uid, attendingStudent);
                }
                else
                {
                    isSuccesfulJoin = false;
                    throw new ArgumentException("This student already enrolled in that course!");
                }
            }
            else
            {
                isSuccesfulJoin = false;
            }

            return isSuccesfulJoin;
        }

        public bool Leave(Student leavingStudent)
        {
            bool isSuccessfulLeave = true;
            if (this.attendingStudents.ContainsKey(leavingStudent.Uid))
            {
                this.attendingStudents.Remove(leavingStudent.Uid);
            }
            else
            {
                isSuccessfulLeave = false;
                throw new ArgumentException("No such student enrolled in the course!");
            }

            return isSuccessfulLeave;
        }

        public List<Student> GetEnrolledStudents()
        {
            if (this.attendingStudents.Count != 0)
            {
                List<Student> listOfAttendingStudents = new List<Student>();
                foreach (var student in this.attendingStudents)
                {
                    listOfAttendingStudents.Add(student.Value);
                }

                return listOfAttendingStudents;
            }
            else
            {
                return null;
            }
        }
    }
}
