// Task 1:  Define a class Student, which contains data about a student – first, middle and last name, SSN, 
//          permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration 
//          for the specialties, universities and faculties. Override the standard methods, inherited by  
//          System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
// Task 2:  Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's 
//          fields into a new object of type Student.
// Task 3:  Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
//          in lexicographic order) and by social security number (as second criteria, in increasing order).

namespace StudentSystem.Student
{
    using System;
    using System.Text;
    using Enumerations;

    public class Student : ICloneable, IComparable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, int ssn, string address, string mobile, string email, int course, Speciality specialty, Faculty faculty, University uni)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.MobilePhone = mobile;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.Faculty = faculty;
            this.University = uni;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

        public int Ssn { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int Course { get; set; }

        public Speciality Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        /// <summary>
        /// Compares two instances of Student for reference equality as they are not immutable 
        /// in order to compare them as value.
        /// </summary>
        public static bool operator ==(Student studentOne, Student studentTwo)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(studentOne, studentTwo))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)studentOne == null) || ((object)studentTwo == null))
            {
                return false;
            }

            // Return true if the fields match:
            return studentOne.Ssn == studentTwo.Ssn && studentOne.FullName == studentTwo.FullName;
        }

        public static bool operator !=(Student studentOne, Student studentTwo)
        {
            return !(studentOne == studentTwo);
        }

        public override int GetHashCode()
        {
            return this.Ssn.GetHashCode() ^ this.LastName.GetHashCode() ^ this.FirstName.GetHashCode();
        }

        // Override of the base class (Object) method for comparing for equality.
        public override bool Equals(object obj)
        {
            // Checks does obj parameter is null
            if (obj == null)
            {
                return false;
            }

            // Checks does obj parameter is of type Student
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            return this.Ssn == student.Ssn && this.FullName == student.FullName;
        }

        // This is not override of the base class (Object) Equals(), but instead is supouse to speed up comaparison
        // following Microsoft guidelines in MSDN for the current Student class.
        public bool Equals(Student student)
        {
            // Checks does obj parameter is null
            if (student == null)
            {
                return false;
            }

            return this.Ssn == student.Ssn && this.FullName == student.FullName;
        }

        /// <summary>
        /// Formats the string representation of the instantiated object output in properway way.
        /// </summary>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Name: " + this.FullName);
            output.AppendLine("SSN: " + this.Ssn);
            output.AppendLine("Address: " + this.Address);
            output.AppendLine("Mobile: " + this.MobilePhone);
            output.AppendLine("e-Mail: " + this.Email);
            output.AppendLine("Course: " + this.Course);
            output.AppendLine("Specialty: " + this.Specialty);
            output.AppendLine("Faculty: " + this.Faculty);
            output.Append("University: " + this.University);
            return output.ToString();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            // MemberwiseClone() is OK to be used as all the properties are ValueTypes, 
            // so they will be bit-by-bit copy.
            Student source = (Student)this.MemberwiseClone();
            return source;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Cannot compare with null!");
            }

            Student student = obj as Student;
            if (student == null)
            {
                throw new ArgumentException("Provided instance is not of type Student!");
            }

            return this.CompareTo(student);
        }

        public int CompareTo(Student student)
        {
            string thisStudent = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherStudent = student.FirstName + " " + student.MiddleName + " " + student.LastName;
            if (string.Compare(thisStudent, otherStudent, StringComparison.Ordinal) < 0)
            {
                return -1;
            }

            if (string.Compare(thisStudent, otherStudent, StringComparison.Ordinal) > 0)
            {
                return 1;
            }

            return this.Ssn - student.Ssn;
        }
    }
}