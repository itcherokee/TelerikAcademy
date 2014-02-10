namespace GroupName
{
    using System.Text;

    public class Student
    {
        public Student(string name, string groupName)
        {
            this.GroupName = groupName;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public string GroupName { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.FullName);
            return output.ToString();
        }
    }
}