namespace ParticleSystem
{
    using System.Collections.Generic;

    public class Particle : IRenderable, IAcceleratable
    {
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public MatrixCoords Position { get; protected set; }

        public virtual bool Exists
        {
            get { return true; }
        }

        public MatrixCoords Speed { get; protected set; }

        public virtual IEnumerable<Particle> Update()
        {
            this.Move();
            return new List<Particle>();
        }
        
        public MatrixCoords GetTopLeft()
        {
            return this.Position;
        }

        public virtual char[,] GetImage()
        {
            return new[,] { { '*' } };
        }
        
        public void Accelerate(MatrixCoords acceleration)
        {
            this.Speed += acceleration;
        }

        protected virtual void Move()
        {
            this.Position += this.Speed;
        }
    }
}