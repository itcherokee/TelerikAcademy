namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
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
