namespace MyAnimals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Kitten : Cat
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
