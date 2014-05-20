namespace HumanManagement
{
    using System;

    /// <summary>
    /// Task 2: Refactor the following examples to produce code with 
    ///         well-named identifiers in C#.
    /// </summary>
    public class HumanManagement
    {
        public static void Main()
        {
            Person man = CreatePerson(9999990001);
            Console.WriteLine(man.ToString());

            Person woman = CreatePerson(9999990011);
            Console.WriteLine(woman.ToString());
        }

        public static Person CreatePerson(long esgraon)
        {
            var human = new Person();
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