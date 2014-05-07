// Refactor the following class using best practices for organizing straight-line code

namespace Cooking
{
    using System;

    public class Chef
    {
        public void Cook(Vegetable vegetable)
        {
            Bowl bowl = this.GetBowl();

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);

            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            // ... 
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            // ...
            return new Carrot();
        }

        private Potato GetPotato()
        {
            // ...
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            // ...
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }
    }
}
