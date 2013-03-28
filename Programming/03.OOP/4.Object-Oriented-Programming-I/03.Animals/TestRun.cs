// Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
// Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
// Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be 
// only female and tomcats can be only male. Each animal produces a specific sound. 
// Create arrays of different kinds of animals and calculate the average age of each kind of animal 
// using a static method (you may use LINQ).

namespace MyAnimals
{
    using System;
    using System.Collections.Generic;

    public class TestRun
    {
        public static void Main()
        {
            // add a couple of different Animals
            List<Animal> animals = new List<Animal>()
            { 
                new Dog("Sharo", 10, Animal.Gender.Male),
                new Dog("Baro", 4, Animal.Gender.Male),
                new Dog("Ceca", 5, Animal.Gender.Female),
                new Dog("Tochka", 7,  Animal.Gender.Female),
                new Frog("Kvaki", 54, Animal.Gender.Female),
                new Cat("To", 9, Animal.Gender.Male),
                new Kitten("Tomka", 2, Animal.Gender.Female),
                new Tomcat("Tom", 10, Animal.Gender.Male),
                new Tomcat("Slon", 12, Animal.Gender.Male)
            };

            // print the average age per Animal type
            foreach (var item in Animal.Average(animals))
            {
                Console.WriteLine("Animal type: {0}; Average years: {1}", item.Key.ToString().Substring(item.Key.ToString().IndexOf('.', 0) + 1), item.Value);
            }
        }
    }
}
