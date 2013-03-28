using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "bullet";

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '^' } }, new MatrixCoords(0, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString ||
                otherCollisionGroupString == IndestructibleBlock.CollisionGroupString ||
                otherCollisionGroupString == UnpassableBlock.CollisionGroupString ||
                otherCollisionGroupString == GiftBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += new MatrixCoords(-1, 0);
        }

        public override void Update()
        {
            this.UpdatePosition();
        }

    }
}
