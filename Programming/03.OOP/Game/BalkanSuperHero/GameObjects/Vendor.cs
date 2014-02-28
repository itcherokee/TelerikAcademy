using BalkanSuperHero.Interfaces;

namespace BalkanSuperHero.GameObjects
{
    /// <summary>
    /// Class representing NPC (non-player character). Usually these are traders, travelers, pesants, etc.
    /// Can trade (buy, sell), give away, provide info, etc.
    /// </summary>
    public class Vendor : NPC, ITalkable
    {
        #region ITalkable Members

        public void Talk()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
