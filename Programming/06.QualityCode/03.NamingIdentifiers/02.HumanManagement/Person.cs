namespace HumanManagement
{
    /// <summary>
    /// Specifies class representing a person object.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the Person's gender.
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// Gets or sets the Person's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Person's UCN.
        /// </summary>
        public long UniqueCitizenNumber { get; set; }
       
        /// <summary>
        /// Converts Person's instance to string representation.
        /// </summary>
        /// <returns>All properties formated as string.</returns>
        public override string ToString()
        {
            return string.Format("Sex: {0}, Name: {1}, UCN: {2}", this.Sex, this.Name, this.UniqueCitizenNumber);
        }
    }
}