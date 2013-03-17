using System;
using System.Collections.Generic;

namespace MyAnimals
{
    public abstract class Animal
    {
        // used for calculations in Average method
        internal struct AgesCalc
        {
            internal int sum;
            internal int count;
        }

        // defines gender of the animals as enumeration
        public enum Gender
        {
            Male,
            Female
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public virtual Gender Sex { get; set; }

        /// <summary>
        /// Instantiates an animal in derived classes
        /// </summary>
        /// <param name="name">Name of the animal</param>
        /// <param name="age">Age of the animal</param>
        /// <param name="sex">Gender of the animal</param>
        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        /// <summary>
        /// Calculates average years of each type of animal that have derived from Animal class
        /// </summary>
        /// <param name="list">List with Animal objects</param>
        /// <returns>Dictionary, where Type is the derived class Name and double is the average age for the current type"/></returns>
        public static Dictionary<Type, double> Average(IEnumerable<Animal> list)
        {
            // grouping different types of Animals with sums of their ages
            Dictionary<Type, AgesCalc> result = new Dictionary<Type, AgesCalc>();
            Type current;
            AgesCalc ageCalculation = new AgesCalc();
            foreach (var animal in list)
            {
                current = animal.GetType();
                if (!result.ContainsKey(current))
                {
                    ageCalculation.sum = animal.Age;
                    ageCalculation.count = 1;
                    result.Add(current, ageCalculation);
                }
                else
                {
                    ageCalculation.sum = result[current].sum + animal.Age;
                    ageCalculation.count = result[current].count + 1;
                    result[current] = ageCalculation;
                }
            }

            // real calculation of the average age
            Dictionary<Type, double> output = new Dictionary<Type, double>();
            double calculation = 0.0;
            foreach (var item in result)
            {
                calculation = item.Value.sum / item.Value.count;
                output.Add(item.Key, calculation);
            }

            return output;
        }
    }
}
