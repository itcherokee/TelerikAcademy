namespace Infestation
{
    class PowerCatalyst : Supplement
    {
        private const int InitialPowerEffect = 3;

        public PowerCatalyst()
            : base(powerEffect: PowerCatalyst.InitialPowerEffect)
        {
        }
    }
}
