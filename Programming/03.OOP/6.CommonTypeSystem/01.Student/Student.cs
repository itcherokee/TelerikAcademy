// Define a class Student, which contains data about a student – first, middle and last name,
// SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. 
// Use an enumeration for the specialties, universities and faculties. Override the standard 
// methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

namespace MyStudent
{
    using System;
    using System.Text;

    public class Student
    {
        public Student(string firstName, string middleName, string lastName, int ssn, string address, string mobile, string email, int course, Specialties specialty, Faculties faculty, Universities uni)
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

        public enum Specialties
        {
            ComputerSystems,
            LowVoltage,
            HighVoltage,
            TracianHistory,
            GreeceHistory,
            WorldEconomics,
            NuclearPhisics,
            NonOrganicChemistry,
            OrganicChemistry
        }

        public enum Universities
        {
            Technical,
            Economic,
            Sofia,
            NewBulgarian
        }

        public enum Faculties
        {
            ComputerScience,
            Telecomunication,
            Physics,
            Chemistry,
            Mathematics,
            Electronics,
            Literature,
            History,
            Economic
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Ssn { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int Course { get; set; }

        public Specialties Specialty { get; set; }

        public Universities University { get; set; }

        public Faculties Faculty { get; set; }

        public static bool operator ==(Student studentOne, Student studentTwo)
        {
            return Student.Equals(studentOne, studentTwo);
        }

        public static bool operator !=(Student studentOne, Student studentTwo)
        {
            return !Student.Equals(studentOne, studentTwo);
        }

        public override bool Equals(object obj)
        {
            Student studentTwo = obj as Student;
            if (obj == null)
            {
                return false;
            }

            if (this.Ssn != studentTwo.Ssn)
            {
                return false;
            }

            if (!(object.Equals(this.FirstName, studentTwo.FirstName)
                && object.Equals(this.MiddleName, studentTwo.MiddleName)
                && object.Equals(this.LastName, studentTwo.LastName)))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Ssn.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Name: " + this.FirstName + " " + this.MiddleName + " " + this.LastName);
            output.Append("\nSSN: " + this.Ssn.ToString());
            output.Append("\nAddress: " + this.Address);
            output.Append("\nMobile: " + this.MobilePhone);
            output.Append("\ne-Mail: " + this.Email);
            output.Append("\nCourse: " + this.Course.ToString());
            output.Append("\nSpecialty: " + this.Specialty.ToString());
            output.Append("\nFaculty: " + this.Faculty.ToString());
            output.Append("\nUniversity: " + this.University.ToString());
            return output.ToString();
        }
    }
}