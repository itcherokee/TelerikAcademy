namespace ParticleSystem
{
    public interface IAcceleratable
    {
        MatrixCoords Speed { get; }

        void Accelerate(MatrixCoords acceleration);
    }
}