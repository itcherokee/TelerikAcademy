namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class AdvancedParticleOperator : ParticleUpdater
    {
        private readonly List<Particle> currentTickParticles = new List<Particle>();
        private readonly List<ParticleAttractor> currentTickAttractors = new List<ParticleAttractor>();
        private readonly List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialAttractor = p as ParticleAttractor;
            var potentialRepeller = p as ParticleRepeller;
            if (potentialAttractor != null)
            {
                this.currentTickAttractors.Add(potentialAttractor);
            }
            else if (potentialRepeller != null)
            {
                this.currentTickRepellers.Add(potentialRepeller);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var particle in this.currentTickParticles)
            {
                this.Accelerate(particle);
                this.Repell(particle);
            }

            this.currentTickParticles.Clear();
            this.currentTickAttractors.Clear();
            this.currentTickRepellers.Clear();
            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int partToAttrCoord)
        {
            if (Math.Abs(partToAttrCoord) > attractor.AttractionPower)
            {
                partToAttrCoord = (partToAttrCoord / (int)Math.Abs(partToAttrCoord)) * attractor.AttractionPower;
            }

            return partToAttrCoord;
        }

        private void Accelerate(Particle particle)
        {
            foreach (var attractor in this.currentTickAttractors)
            {
                var currParticleToAttractorVector = attractor.Position - particle.Position;

                int partToAttrRow = currParticleToAttractorVector.Row;
                partToAttrRow = DecreaseVectorCoordToPower(attractor, partToAttrRow);

                int partToAttrCol = currParticleToAttractorVector.Col;
                partToAttrCol = DecreaseVectorCoordToPower(attractor, partToAttrCol);

                var currAcceleration = new MatrixCoords(partToAttrRow, partToAttrCol);

                particle.Accelerate(currAcceleration);
            }
        }

        private void Repell(Particle particle)
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                if (this.Distance(repeller.Position, particle.Position) <= repeller.RepulsionRadius)
                {
                    var inversePartRow = particle.Speed.Row * 2 * -1;
                    var inversePartCol = particle.Speed.Col * 2 * -1;
                    particle.Accelerate(new MatrixCoords(inversePartRow, inversePartCol));
                }
            }
        }

        private int Distance(MatrixCoords repeller, MatrixCoords partical)
        {
            return (int)Math.Sqrt(Math.Pow(repeller.Row - partical.Row, 2) + Math.Pow(repeller.Col - partical.Col, 2));
        }
    }
}