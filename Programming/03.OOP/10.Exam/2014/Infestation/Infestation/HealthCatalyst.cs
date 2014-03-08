namespace Infestation
{
    class HealthCatalyst : Supplement
    {
        private const int InitialHealthEffect = 3;

        public HealthCatalyst()
            : base(healthEffect: HealthCatalyst.InitialHealthEffect)
        {
        }
    }
}
