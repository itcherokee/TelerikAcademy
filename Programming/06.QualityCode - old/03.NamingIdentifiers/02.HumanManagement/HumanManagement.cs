// Refactor the following examples to produce code with well-named identifiers in C#

namespace HumanManagement
{
    using System;

    public class HumanManagement
    {
        public static void Main()
        {
            // lets create a man
            Person man = Create(9999990001);
            Console.WriteLine(man.ToString());

            // lets create a woman
            Person woman = Create(9999990011);
            Console.WriteLine(woman.ToString());
        }

        public static Person Create(long esgraon)
        {
            Person human = new Person();
            human.UniqueCitizenNumber = esgraon;
            if ((esgraon / 10) % 2 == 0)
            {
                human.Name = "Батката";
                human.Sex = Gender.Male;
            }
            else
            {
                human.Name = "Мацето";
                human.Sex = Gender.Female;
            }

            return human;
        }
    }
}
