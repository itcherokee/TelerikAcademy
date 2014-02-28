using System;
using BalkanSuperHero.Enumerations;

namespace BalkanSuperHero.Interfaces
{
    public interface IInputControl
    {
        new InputType InputControl { get; }

        void InitializeInputControls(InputType inputType);

        void Action(object sender, EventArgs e);

        void ProcessInput();
    }
}
