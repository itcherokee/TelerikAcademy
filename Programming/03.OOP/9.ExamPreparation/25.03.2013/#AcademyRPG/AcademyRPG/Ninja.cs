namespace AcademyRPG
{
    using System.Collections.Generic;
    using System.Linq;

    public class Ninja : Character, IFighter, IGatherer
    {
        private const int NinjaHitPoints = 1;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.AttackPoints = 0;
            this.HitPoints = NinjaHitPoints;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var maxHitPoints = availableTargets.Where(x => x.Owner != this.Owner && x.Owner != 0).Max(x => x.HitPoints);
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && availableTargets[i].HitPoints == maxHitPoints)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber || resource.Type == ResourceType.Stone)
            {
                switch (resource.Type)
                {
                    case ResourceType.Lumber:
                        this.AttackPoints += resource.Quantity;
                        break;
                    case ResourceType.Stone:
                        this.AttackPoints = resource.Quantity * 2;
                        break;
                }

                return true;
            }

            return false;
        }
    }
}
