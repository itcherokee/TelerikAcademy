namespace Education
{
    using System;

    public class Student
    {
        private string name;
        private int uid;

        public Student(string studentName, int studentId)
        {
            this.Name = studentName;
            this.Uid = studentId;
        }

        public int Uid
        {
            get
            {
                return this.uid;
            }

            set
            {
                if (value < 10000)
                {
                    throw new ArgumentException("Student's unique Id can't be less than 10000!");
                }

                if (value > 99999)
                {
                    throw new ArgumentException("Student's unique Id can't be greater than 99999!");
                }

                this.uid = value;
            }
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
                    throw new ArgumentException("Student's name can not be null, empty or only white spaces!");
                }

                this.name = value;
            }
        }
    }
}
