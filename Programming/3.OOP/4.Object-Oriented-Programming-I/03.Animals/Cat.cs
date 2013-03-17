namespace MyAnimals
{
    using System;

    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public string DoVoice()
        {
            return "Myauuuuu!";
        }
    }
}
