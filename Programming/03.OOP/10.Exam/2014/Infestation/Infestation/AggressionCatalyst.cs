namespace Infestation
{
    class AggressionCatalyst : Supplement
    {
        private const int InitialAggressionEffect = 3;

        public AggressionCatalyst()
            : base(aggressionEffect: AggressionCatalyst.InitialAggressionEffect)
        {
        }
    }
}
