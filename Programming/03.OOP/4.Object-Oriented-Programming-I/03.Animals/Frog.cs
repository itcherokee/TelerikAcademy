namespace Animals
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public string DoVoice()
        {
            return "Kvak!";
        }
    }
}
