namespace MySchool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class School
    {
        public HashSet<Class> Classes { get; private set; }

        /// <summary>
        /// Instantiates an object of type School. It also instantiates the HashSet collection to hold objects of type Class
        /// </summary>
        public School()
        {
            this.Classes = new HashSet<Class>();
        }

        /// <summary>
        /// Add Class to school
        /// </summary>
        /// <param name="klas">Class object</param>
        public void AddClass(Class klas)
        {
            this.Classes.Add(klas);
        }

        /// <summary>
        /// Remove class from school
        /// </summary>
        /// <param name="klas">Class object</param>
        public void RemoveDiscipline(Class klas)
        {
            this.Classes.Remove(klas);
        }

        /// <summary>
        /// Prints object's School details in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this.Classes.Count != 0)
            {
                // Classes list is not empty, so we can enumerate
                foreach (Class item in this.Classes)
                {
                    output.Append(item.ToString() + " ");
                }
            }
            else
            {
                output.Append("None");
            }

            return output.ToString();
        }
    }
}
