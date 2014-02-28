using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExploadingBlock : Block
    {
        class Boom : MovingObject
        {
            public Boom(MatrixCoords topLeft, MatrixCoords speed)
                : base(topLeft, new char[,] { { '*' } }, speed)
            {
            }

            public override void Update()
            {
                this.IsDestroyed = true;
            }

            public override bool CanCollideWith(string otherCollisionGroupString)
            {
                return otherCollisionGroupString == Block.CollisionGroupString;
            }
        }

        public const char Symbol = '*';

        public ExploadingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExploadingBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<GameObject> booms = new List<GameObject>();
                booms.Add(new Boom(this.topLeft, new MatrixCoords(-1, -1)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(0, -1)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(1, -1)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(-1, 0)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(1, 0)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(-1, 1)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(0, 1)));
                booms.Add(new Boom(this.topLeft, new MatrixCoords(1, 1)));
                return booms;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
