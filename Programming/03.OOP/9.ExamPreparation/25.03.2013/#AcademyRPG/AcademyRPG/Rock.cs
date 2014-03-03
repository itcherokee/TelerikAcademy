namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private const int RockOwner = 0;

        public Rock(int hitPoints, Point position)
            : base(position, RockOwner)
        {
            this.HitPoints = hitPoints;
            this.Type = ResourceType.Stone;
            this.Quantity = this.HitPoints / 2;
        }

        // The Rock should not be able to move. The command should set the HitPoints of the Rock. 
        // The Rock should be a resource with a Type property equal to Stone. 
        // The Quantity of the Rock should be half it’s HitPoints. 
        // The Rock should always be neutral and have a position.

        public int Quantity { get; private set; }

        public ResourceType Type { get; private set; }
    }
}