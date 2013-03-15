namespace MyAnimals
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, Animal.Gender sex)
            : base(name, age, Gender.Male)
        {
        }

        public override Gender Sex
        {
            get
            {
                return Gender.Male;
            }
        }
    }
}
