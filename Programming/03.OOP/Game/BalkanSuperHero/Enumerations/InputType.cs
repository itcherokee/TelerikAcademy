using System;

namespace BalkanSuperHero.Enumerations
{
    [Flags]
    public enum InputType
    {
        Keyboard = 0x01,
        Mouse = 0x02,
    }
}