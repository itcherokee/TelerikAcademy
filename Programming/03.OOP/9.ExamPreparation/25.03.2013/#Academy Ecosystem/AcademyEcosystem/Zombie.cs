namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 0;
        private const int ZombieMeat = 10;

        public Zombie(string name, Point location)
            : base(name, location, ZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return ZombieMeat;
        }
    }
}