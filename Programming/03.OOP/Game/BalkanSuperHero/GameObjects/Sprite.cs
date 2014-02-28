using System;
using BalkanSuperHero.Enumerations;
using BalkanSuperHero.Interfaces;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.GameObjects
{

    public abstract class Sprite : IDrawable, IColideable
    {
        protected Sprite()
        {
            this.IsAlive = true;
            this.Position = new PointF(0f, 0.0f);
            this.Size = new Size(0, 0);
        }

        internal bool IsAlive { get; set; }

        private Size Size { get; set; }

        public PointF Position { get; set; }
        public object Picture { get; set; }

        public void Update()
        {
        }

        public int CanColideWith { get; set; }

        public void Respond()
        {
            throw new System.NotImplementedException();
        }

        public bool IsColiding(ref Sprite sprite)
        {
            throw new System.NotImplementedException();
        }

        #region IDrawable Members


        Point IDrawable.Size
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
