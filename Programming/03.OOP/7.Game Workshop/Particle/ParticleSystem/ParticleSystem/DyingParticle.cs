namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class DyingParticle : Particle
    {
        private int lifetime = 0;

        public DyingParticle(MatrixCoords position, MatrixCoords speed, int lifetime) :
            base(position, speed)
        {
            if (lifetime < 0)
            {
                throw new ArgumentException("lifetime must be greater than or equal to zero");
            }

            this.lifetime = lifetime;
        }

        public override bool Exists
        {
            get
            {
                return this.lifetime > 0;
            }
        }

        public override IEnumerable<Particle> Update()
        {
            this.lifetime--;

            return base.Update();
        }
    }
}
