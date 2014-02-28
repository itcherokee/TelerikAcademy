using BalkanSuperHero.Interfaces;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.GameObjects
{
    // Represents characters that are poses some logic, like want to fight, figth, magician powers, etc.
    // Always drop armory, weaponry or similar. Sometimes could drop gold as well.
    public class Enemy : NPC, ILevelUpable, IAutoHealable, IDiable
    {
        #region ILevelUpable Members

        public int Level
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IHealable Members

        public int Mana
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Heal()
        {
            throw new System.NotImplementedException();
        }

        public void AutoHeal()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDiable Members

        public int IsDead
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ISelfMovable Members

        public int Path
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void GeneratePath()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IMovable Members

        public int Speed
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Direction
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IAnimateable Members

        public void Animate()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePosition(PointF velocity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
