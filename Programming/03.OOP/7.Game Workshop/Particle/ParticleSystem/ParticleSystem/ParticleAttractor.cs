namespace ParticleSystem
{
    public class ParticleAttractor : Particle
    {
        public ParticleAttractor(MatrixCoords position, MatrixCoords speed, int attractionPower) :
            base(position, speed)
        {
            this.AttractionPower = attractionPower;
        }

        public int AttractionPower { get; protected set; }
    }
}