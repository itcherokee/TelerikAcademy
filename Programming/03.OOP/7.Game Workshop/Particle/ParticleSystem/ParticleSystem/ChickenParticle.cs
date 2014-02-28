namespace ParticleSystem
{
    using System.Collections.Generic;

    /// <summary>
    /// Task 2: Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, 
    ///         but randomly stops at different positions for several simulation ticks and, for each of those stops, 
    ///         creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.
    /// </summary>
    public class ChickenParticle : ChaoticParticle
    {
        private int timer;
        private int simulationTickStops;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, int simulationTickStops)
            : base(position, speed)
        {
            this.simulationTickStops = simulationTickStops;
            this.timer = simulationTickStops;
        }

        public override IEnumerable<Particle> Update()
        {
            var chickens = new List<Particle>();
            if (this.timer == 0)
            {
                if (Generator.Next(0, 2) == 0)
                {
                    return base.Update();
                }

                this.timer = this.simulationTickStops;
                chickens.Add(
                    new ChickenParticle(new MatrixCoords(this.Position.Row, this.Position.Col), new MatrixCoords(1, 1), this.simulationTickStops));
            }
            else
            {
                this.timer--;
            }

            return chickens;
        }

        public override char[,] GetImage()
        {
            return new[,] { { 'O' } };
        }
    }
}
