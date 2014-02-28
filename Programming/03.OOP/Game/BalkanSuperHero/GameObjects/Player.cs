using BalkanSuperHero.Interfaces;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.GameObjects
{
    public sealed class Player : Character, ILevelUpable, IFightable, ITalkable, IHealable, IDiable
    {
        private byte lives;

        Player()
        {
            this.lives = 3;
        }

        public static Player Instance
        {
            get
            {
                return Singleton.instance;
            }
        }

        class Singleton
        {
            // Implementing Singleton pattern for the Player class
            static Singleton()
            {
            }

            internal static readonly Player instance = new Player();
        }

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

        #region IFightable Members

        public int Attack
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

        public int Defence
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

        public void Equip()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ITalkable Members

        public void Talk()
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

        #endregion

        public byte Lives
        {
            get
            {
                return this.lives;
            }
        }

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