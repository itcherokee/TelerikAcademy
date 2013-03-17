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
            : base(topLeft, new char[,] { { '@' } }, new MatrixCoords(1, 0))
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

        protected virtual void UpdatePosition()
        {
            this.TopLeft += new MatrixCoords(1, 0);
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
