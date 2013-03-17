namespace MySchool
{
    using System;
    using System.Linq;
    using System.Text;
    
    public class Discipline : ICommentable
    {
        public string Name { get; private set; }

        public int NumberOfLectures { get; set; }
        
        public int NumberOfExercises { get; set; }
        
        public string Comment { get; set; }

        /// <summary>
        /// Instantiates an object of type Discipline
        /// </summary>
        /// <param name="name">String value holding Name of the discipline</param>
        /// <param name="numberOfLectures">Integer value holding the number of Lectures in that Discipline</param>
        /// <param name="numberOfExercises">Integer value holding the number of Excersizes in that Discipline</param>
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        /// <summary>
        /// Prints object Discipline dields value in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Discipline Name:     {0}\n", this.Name));
            output.Append(string.Format("Number of Lecture:   {0}\n", this.Name));
            output.Append(string.Format("Number of Exercises: {0}\n", this.Name));
            return output.ToString();
        }
    }
}
