using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    abstract class Supplement : ISupplement
    {
        protected Supplement(int powerEffect = 0, int healthEffect = 0, int aggressionEffect = 0)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }

        public int PowerEffect { get; protected set; }
        public int HealthEffect { get; protected set; }
        public int AggressionEffect { get; protected set; }
    }
}
