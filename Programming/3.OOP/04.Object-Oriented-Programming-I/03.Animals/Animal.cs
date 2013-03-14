using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimals
{
    abstract class Animal
    {
        public enum Gender
        {
            Male,
            Female
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public virtual Gender Sex { get; set; }

        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public static Dictionary<Type, int> Average(IEnumerable<Animal> list)
        {
            Dictionary<Type, int> result = new Dictionary<Type, int>();
            Type current;

            foreach (var animal in list)
            {
                current = animal.GetType();
                if (!result.ContainsKey(current))
                {
                    result.Add(current, animal.Age);
                }
                else
                {
                    result[current] += animal.Age;
                }
            }


        }
    }
}
