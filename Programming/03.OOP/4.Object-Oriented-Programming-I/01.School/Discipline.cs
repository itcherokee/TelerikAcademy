namespace MySchool
{
    using System;
    using System.Text;

    public class Discipline : ICommentable
    {
        private string name;

        /// <summary>
        /// Instantiates an object of type Discipline.
        /// </summary>
        /// <param name="name">Name of the discipline.</param>
        /// <param name="numberOfLectures">Number of Lectures in that discipline.</param>
        /// <param name="numberOfExercises">Number of Excersizes in that discipline.</param>
        public Discipline(string name, int numberOfLectures = 0, int numberOfExercises = 0)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("Discipline name cannot be null, empty or whitespace!");
                }
            }
        }

        public int NumberOfLectures { get; private set; }

        public int NumberOfExercises { get; private set; }

        public string Comment { get; set; }

        /// <summary>
        /// Format Discipline instance fields' values in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.Name);
            output.Append(" (Lectures:");
            output.Append(this.NumberOfLectures);
            output.Append(", Exercises:");
            output.Append(this.NumberOfExercises);
            output.Append(")");
            return output.ToString();
        }
    }
}