namespace Animals
{
    public class Dog : Animal, ISound
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
