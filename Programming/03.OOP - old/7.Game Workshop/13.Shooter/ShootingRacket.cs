using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        public bool givenShot;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.givenShot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            givenShot = false;
            List<Bullet> bullet = new List<Bullet>();
            bullet.Add(new Bullet(this.topLeft));
            return bullet;

        }


    }
}
