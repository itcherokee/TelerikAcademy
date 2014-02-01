using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '@' } }, new MatrixCoords(1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<ShootingRacket> shootingRacket = new List<ShootingRacket>();
                MatrixCoords newCoord = this.TopLeft;
                newCoord.Row++;
                shootingRacket.Add(new ShootingRacket(newCoord, 3));
                return shootingRacket;
            }
            else
            {
                return base.ProduceObjects();
            }
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += new MatrixCoords(3, 0);
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
