using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int GiantOwner = 0;
        private bool stoneGathered;

        public Giant(string name, Point position)
            : base(name, position, GiantOwner)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.DefensePoints = 80;
            this.stoneGathered = false;

        }

        // It should have 150 AttackPoints, 80 DefensePoints and 200 HitPoints. 
        // It should have a name and a position, but should be always neutral. 
        // The Giant should also be able to gather Stone resources. 
        // When a Giant gathers such a resource, his AttackPoints are permanently increased by 100. 
        // This should only work once. When attacking, the Giant should pick the first available target, 
        // which is not neutral.

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!this.stoneGathered)
                {
                    this.stoneGathered = true;
                    this.AttackPoints += 100;
                }

                return true;
            }

            return false;
        }
    }
}
