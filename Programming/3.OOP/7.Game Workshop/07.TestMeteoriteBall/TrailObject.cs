using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        private int lifeTime;
        private static char[,] trailBody = new char[1,1] { { '.' } };

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, trailBody)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
            else
            {
                lifeTime--;
            }
        }
    }
}
