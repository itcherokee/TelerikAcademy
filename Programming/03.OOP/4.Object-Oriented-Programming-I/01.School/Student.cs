namespace MySchool
{
    using System.Globalization;
    using System.Text;

    public class Student : Person, ICommentable
    {
        /// <summary>
        /// Instantiate an Student object
        /// </summary>
        /// <param name="firstName">String value holding Student first name</param>
        /// <param name="lastName">String value holding Student last name</param>
        /// <param name="classNumber">Integer value holding unique Student identifier in the class</param>
        public Student(string firstName, string lastName, uint classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// Prints object's Student details in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Student: ");
            output.Append(this.FullName);
            output.Append(" (Number in the class: ");
            output.Append(this.ClassNumber.ToString(CultureInfo.InvariantCulture));
            output.Append(")");
            return output.ToString();
        }
    }
}