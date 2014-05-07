// Refactor the following if statements

namespace IfStatementsCode
{
    using System;
    using Cooking;

    public class AgainCooking
    {
        public void SomeCode()
        {
            Potato potato = new Potato();
            Chef newChef = new Chef();

            // ... 
            if (potato != null)
            {
                if (!potato.IsRotten && potato.HasBeenPeeled)
                {
                    newChef.Cook(potato);
                }
            }
        }
    }
}
