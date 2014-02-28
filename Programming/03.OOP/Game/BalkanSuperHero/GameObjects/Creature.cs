using BalkanSuperHero.Interfaces;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.GameObjects
{
    // Represents all non ??!?!?! mindfull characters - monsters, dragons, animals, etc.
    // Could drop some gold when dead, but no any armory, weaponry, etc.
    public class Creature : NPC, ILevelable, IDiable
    {
        #region ILevelable Members

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
