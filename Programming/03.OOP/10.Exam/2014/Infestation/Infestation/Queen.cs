namespace Infestation
{
    class Queen : Parasite
    {
        private const int InitialHealthPoints = 30;

        public Queen(string id)
            : base(id, Queen.InitialHealthPoints)
        {
        }
    }
}
