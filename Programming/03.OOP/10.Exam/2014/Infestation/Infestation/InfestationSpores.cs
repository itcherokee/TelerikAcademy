namespace Infestation
{
    class InfestationSpores:Supplement
    {
        private const int InitialPowerEffect = -1;
        private const int InitialAggressionEffect = 20;

        public InfestationSpores():base(InfestationSpores.InitialPowerEffect, InfestationSpores.InitialAggressionEffect)
        {
            
        }
    }
}
