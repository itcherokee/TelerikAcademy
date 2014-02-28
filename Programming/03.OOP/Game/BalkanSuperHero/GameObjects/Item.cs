using System;
using BalkanSuperHero.Enumerations;
using BalkanSuperHero.Exceptions;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.GameObjects
{
    public class Item
    {
        private Powers attributes;
        private ItemType kind;

        public Item(ItemType kind)
        {
            this.Kind = kind;
        }

        public ItemType Kind
        {
            get
            {
                return this.kind;
            }

            private set
            {
                if (Enum.IsDefined(typeof(ItemType), value))
                {
                    this.kind = value;
                }
                else
                {
                    throw new GameItemTypeException();
                }
            }
        }

        public Powers Attributes
        {
            get
            {
                return this.attributes;
            }
            set
            {
                this.attributes = value;
            }
        }
    }
}
