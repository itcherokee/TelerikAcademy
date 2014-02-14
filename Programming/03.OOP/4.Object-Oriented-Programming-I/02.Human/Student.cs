namespace People
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        private GradeScore grade;

        public Student(string firstName, string lastName, GradeScore grade = GradeScore.Undefined)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public GradeScore Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (Enum.IsDefined(typeof(GradeScore), value))
                {
                    this.grade = value;
                }
                else
                {
                    throw new ArgumentException("Not valid grade score provided!");
                }
            }
        }
    }
}
