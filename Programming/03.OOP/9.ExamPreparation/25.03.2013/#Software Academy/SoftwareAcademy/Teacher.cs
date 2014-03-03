namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : ITeacher
    {
        private readonly IList<ICourse> courses;
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (course != null)
            {
                this.courses.Add(course);
            }
            else
            {
                throw new ArgumentNullException("Course cannot be null!");
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}:", this.GetType().Name);
            output.AppendFormat(" Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                output.AppendFormat("; Courses=[{0}]", string.Join(", ", this.courses.Select(course => course.Name)));
            }

            return output.ToString();
        }
    }
}