using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class Teacher : Person, ICommentable
    {
        // Using HashSet in order to overcome duplicate records and faster access than List<T>
        private HashSet<Discipline> disciplines;

        public List<Discipline> Disciplines
        {
            get
            {
                // Returns List<Discipline> in order list to be indexable
                return this.disciplines.ToList();
            }
        }

        public string Comment { get; set; }

        /// <summary>
        /// Instantiate an object of type Teacher. It also instantiates the HashSet collection to hold objects of type Discipline
        /// </summary>
        /// <param name="firstName">String value holding first name of the Teacher</param>
        /// <param name="lastName">String value holding last name of the Teacher</param>
        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.disciplines = new HashSet<Discipline>();
        }

        /// <summary>
        /// Add discipline lead by the teacher
        /// </summary>
        /// <param name="discipline">Discipline object</param>
        public void Add(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        /// <summary>
        /// Remove discipline lead by the teacher
        /// </summary>
        /// <param name="discipline">Discipline object</param>
        public void Remove(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }

        /// <summary>
        /// Prints object Teacher details in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Name: {0}\n", this.FullName));
            output.Append("Teaches Disciplines: "); 
            if (this.disciplines.Count != 0)
            {
                // Disciplines list is not empty, so we can enumerate
                foreach (Discipline item in this.disciplines)
                {
                    output.Append(item.Name.ToString() + " ");
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
