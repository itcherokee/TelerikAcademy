namespace MyAnimals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Tomcat : Cat
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
