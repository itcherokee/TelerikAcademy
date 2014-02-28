namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ParticleSystemMain
    {
        private const int SimulationRows = 30;
        private const int SimulationCols = 40;
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new AdvancedParticleOperator();

            var particles = new List<Particle>
            {
                new Particle(new MatrixCoords(5, 5), new MatrixCoords(1, 1)),

                // new ParticleEmitter(new MatrixCoords(5, 10), new MatrixCoords(0, 0), RandomGenerator),
                // new ParticleEmitter(new MatrixCoords(5, 20), new MatrixCoords(0, 0), RandomGenerator),
                // new VariousLifetimeParticleEmitter(new MatrixCoords(29, 1), new MatrixCoords(0, 0), RandomGenerator),
                // new ParticleAttractor(new MatrixCoords(15, 8), new MatrixCoords(), 5),
                // new ParticleAttractor(new MatrixCoords(15, 20), new MatrixCoords(), 1),
                new ChaoticParticle(new MatrixCoords(15, 15), new MatrixCoords(0, 0)),
                new ChaoticParticle(new MatrixCoords(10, 10), new MatrixCoords(0, 0)),
                new ChickenParticle(new MatrixCoords(15, 15), new MatrixCoords(3, 3), 5),
                new ParticleRepeller(new MatrixCoords(15, 14), new MatrixCoords(0, 0), 2),
            };

            var engine = new Engine(renderer, particleOperator, particles, 500);
            engine.Run();
        }
    }
}