namespace ParticleSystem
{
    /// <summary>
    /// Task 3: Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes 
    /// other particles away from it (i.e. accelerates them in a direction, opposite of the direction 
    /// in which the repeller is). The repeller has an effect only on particles within a certain radius 
    /// (see Euclidean distance)
    /// </summary>
    public class ParticleRepeller : Particle
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int radius)
            : base(position, speed)
        {
            this.RepulsionRadius = radius;
        }

        public int RepulsionRadius { get; private set; }

        public override char[,] GetImage()
        {
            return new[,] { { '@' } };
        }
    }
}