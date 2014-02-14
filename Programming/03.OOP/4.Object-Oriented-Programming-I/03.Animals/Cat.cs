﻿namespace Animals
{
    public abstract class Cat : Animal, ISound
    {
        protected Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public string DoVoice()
        {
            return "Myauuuuu!";
        }
    }
}
