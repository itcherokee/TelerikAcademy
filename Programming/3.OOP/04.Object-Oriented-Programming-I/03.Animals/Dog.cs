namespace MyAnimals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Dog : Animal, ISound
    {

        public Dog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public string DoVoice()
        {
            return "Bauuuu!";
        }


    }
}
