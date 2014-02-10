namespace MyStudents
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student
    {
        private List<byte> marks;
        private string email;

        public Student()
        {
            this.marks = new List<byte>();
            this.Group = new Group();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public uint Fn { get; set; }

        public string Tel { get; set; }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                Regex patternOne = new Regex(@"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z");
                Regex patternTwo = new Regex(@"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
                if (patternOne.IsMatch(value) && patternTwo.IsMatch(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid e-mail!");
                }
            }
        }

        public uint GroupNumber { get; set; }

        public Group Group { get; set; }

        public IList<byte> Marks
        {
            get
            {
                return this.marks.AsReadOnly();
            }

            set
            {
                this.marks = value as List<byte>;
            }
        }

        public void AssignMark(byte mark)
        {
            if (mark >= 1 && mark <= 6)
            {
                this.marks.Add(mark);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid mark!");
            }
        }

        /// <summary>
        /// Converts predifined fields (First and Last names, Age) of Student class to be printed.
        /// </summary>
        /// <returns>String.string</returns>
        public override string ToString()
        {
            return this.ToString(fields: Fields.First | Fields.Last);
        }

        /// <summary>
        /// Convert and creates custom look of the Student class fields to be printed
        /// </summary>
        /// <returns>String.string</returns>
        public string ToString(Fields fields)
        {
            var output = new StringBuilder();
            {
                output.Append(fields.HasFlag(Fields.First) ? string.Format("FirstName: {0}; ", this.FirstName) : string.Empty);
                output.Append(fields.HasFlag(Fields.Last) ? string.Format("LastName: {0}; ", this.LastName) : string.Empty);
                output.Append(fields.HasFlag(Fields.Age) ? string.Format("Age: {0}; ", this.Age) : string.Empty);
                output.Append(fields.HasFlag(Fields.Fn) ? string.Format("FN: {0}; ", this.Fn) : string.Empty);
                output.Append(fields.HasFlag(Fields.Tel) ? string.Format("Tel.: {0}; ", this.Tel) : string.Empty);
                output.Append(fields.HasFlag(Fields.Email) ? string.Format("E-mail: {0}; ", this.Email) : string.Empty);
                output.Append(fields.HasFlag(Fields.Group) ? string.Format("Group: {0}; ", this.GroupNumber) : string.Empty);
                output.Append(fields.HasFlag(Fields.Marks) ? string.Format("Marks: ({0}); ", string.Join(",", this.Marks)) : string.Empty);
            }

            return output.ToString();
        }
    }
}