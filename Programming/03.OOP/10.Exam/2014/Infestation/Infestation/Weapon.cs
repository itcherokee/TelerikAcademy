namespace Infestation
{
    class Weapon : Supplement
    {
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = 10;
                this.AggressionEffect = 3;
            }
            base.ReactTo(otherSupplement);
        }
    }
}