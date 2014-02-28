namespace ParticleSystem
{
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        private readonly IParticleOperator particleOperator;
        private readonly IRenderer renderer;
        private readonly List<Particle> particles;
        private readonly int waitMsPerTick;

        public Engine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null, int waitMs = 1000)
        {
            this.renderer = renderer;
            this.particleOperator = particleOperator;
            if (particles != null)
            {
                this.particles = particles;
            }
            else
            {
                this.particles = new List<Particle>();
            }

            this.waitMsPerTick = waitMs;
        }

        public void AddParticle(Particle p)
        {
            this.particles.Add(p);
        }

        public void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();
                this.renderer.ClearQueue();
                var producedParticles = new List<Particle>();
                foreach (var particle in this.particles)
                {
                    producedParticles.AddRange(this.particleOperator.OperateOn(particle));
                }

                this.particleOperator.TickEnded();
                foreach (var particle in this.particles)
                {
                    this.renderer.EnqueueForRendering(particle);
                }

                this.particles.RemoveAll(p => !p.Exists);
                this.particles.AddRange(producedParticles);
                Thread.Sleep(this.waitMsPerTick);
            }
        }
    }
}