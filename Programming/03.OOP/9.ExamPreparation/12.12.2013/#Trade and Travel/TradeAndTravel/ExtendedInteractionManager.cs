namespace TradeAndTravel
{
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            if (actor != null)
            {
                string craftWhat = commandWords[2];
                string itemName = commandWords[3];
                var hasIron = actor.ListInventory().FirstOrDefault(x => x.ItemType == ItemType.Iron);
                switch (craftWhat)
                {
                    case "armor":
                        if (hasIron != null)
                        {
                            this.AddToPerson(actor, new Armor(itemName));
                        }

                        break;
                    case "weapon":
                        var hasWood = actor.ListInventory().FirstOrDefault(x => x.ItemType == ItemType.Wood);
                        if (hasIron != null && hasWood != null)
                        {
                            this.AddToPerson(actor, new Weapon(itemName));
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor != null)
            {
                string itemName = commandWords[2];
                switch (actor.Location.LocationType)
                {
                    case LocationType.Mine:
                        var hasArmor = actor.ListInventory().FirstOrDefault(x => x.ItemType == ItemType.Armor);
                        if (hasArmor != null)
                        {
                            this.AddToPerson(actor, new Iron(itemName));
                        }

                        break;
                    case LocationType.Forest:
                        var hasWeapon = actor.ListInventory().FirstOrDefault(x => x.ItemType == ItemType.Weapon);
                        if (hasWeapon != null)
                        {
                            this.AddToPerson(actor, new Wood(itemName));
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}