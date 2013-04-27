namespace HumanManagement
{
    using System;

    public class Person
    {
        public Gender Sex { get; set; }

        public string Name { get; set; }

        public long UniqueCitizenNumber { get; set; }
       
        public override string ToString()
        {
            return string.Format("Sex: {0}, Name: {1}, UniqueCitizenNumber: {2}", this.Sex, this.Name, this.UniqueCitizenNumber);
        }
    }
}
