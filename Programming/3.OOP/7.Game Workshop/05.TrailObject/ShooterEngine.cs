using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShooterEngine : Engine
    {
        public ShooterEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
        }
    }
}
