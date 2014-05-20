// Task 2:  Refactor the following class using best practices 
//          for organizing straight-line code

namespace ConditionCode
{
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
                    newChef.Cook();
                }
            }
        }
    }
}
