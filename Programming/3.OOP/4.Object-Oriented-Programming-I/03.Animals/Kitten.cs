namespace MyAnimals
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, Animal.Gender sex)
            : base(name, age, Gender.Female)
        {
        }

        public override Gender Sex
        {
            get
            {
                return Gender.Female;
            }
        }
    }
}
