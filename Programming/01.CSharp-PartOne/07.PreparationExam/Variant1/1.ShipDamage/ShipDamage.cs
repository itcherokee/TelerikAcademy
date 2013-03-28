using System;

class ShipDamage
{
    static void Main()
    {
        int shipX1 = int.Parse(Console.ReadLine());
        int shipY1 = int.Parse(Console.ReadLine());
        int shipX2 = int.Parse(Console.ReadLine());
        int shipY2 = int.Parse(Console.ReadLine());
        int horizon = int.Parse(Console.ReadLine());
        int catapultX1 = int.Parse(Console.ReadLine());
        int catapultY1 = int.Parse(Console.ReadLine());
        int catapultX2 = int.Parse(Console.ReadLine());
        int catapultY2 = int.Parse(Console.ReadLine());
        int catapultX3 = int.Parse(Console.ReadLine());
        int catapultY3 = int.Parse(Console.ReadLine());
        int leftShipX = Math.Min(shipX1, shipX2);
        int rightShipX = Math.Max(shipX1, shipX2);
        int topShipY = Math.Max(shipY1, shipY2);
        int bottomShipY = Math.Min(shipY1, shipY2);
        int hitShip1 = horizon * 2 - catapultY1;
        int hitShip2 = horizon * 2 - catapultY2;
        int hitShip3 = horizon * 2 - catapultY3;
        short damage = 0;
        // Catapult 1
        if (((catapultX1 == leftShipX) || (catapultX1 == rightShipX)) && ((hitShip1 == topShipY) || (hitShip1 == bottomShipY)))
        {
            damage += 25;
        }
        else if ((((catapultX1 > leftShipX) && (catapultX1 < rightShipX)) || ((hitShip1 > bottomShipY) && (hitShip1 < topShipY)))
            && (((hitShip1 == topShipY) || (hitShip1 == bottomShipY)) || ((catapultX1 == leftShipX) || (catapultX1 == rightShipX))))
        {
            damage += 50;
        }
        else if ((catapultX1 > leftShipX) && (catapultX1 < rightShipX) && (hitShip1 > bottomShipY) && (hitShip1 < topShipY))
        {
            damage += 100;
        }
        //// catapult 2
        if (((catapultX2 == leftShipX) || (catapultX2 == rightShipX)) && ((hitShip2 == topShipY) || (hitShip2 == bottomShipY)))
        {
            damage += 25;
        }
        else if ((((catapultX2 > leftShipX) && (catapultX2 < rightShipX)) || ((hitShip2 > bottomShipY) && (hitShip2 < topShipY)))
               && (((hitShip2 == topShipY) || (hitShip2 == bottomShipY)) || ((catapultX2 == leftShipX) || (catapultX2 == rightShipX))))
        {
            damage += 50;
        }
        else if ((catapultX2 > leftShipX) && (catapultX2 < rightShipX) && (hitShip2 > bottomShipY) && (hitShip2 < topShipY))
        {
            damage += 100;
        }
        ////catapult 3
        if (((catapultX3 == leftShipX) || (catapultX3 == rightShipX)) && ((hitShip3 == topShipY) || (hitShip3 == bottomShipY)))
        {
            damage += 25;
        }
        else if ((((catapultX3 > leftShipX) && (catapultX3 < rightShipX)) || ((hitShip3 > bottomShipY) && (hitShip3 < topShipY)))
             && (((hitShip3 == topShipY) || (hitShip3 == bottomShipY)) || ((catapultX3 == leftShipX) || (catapultX3 == rightShipX))))
        {
            damage += 50;
        }
        else if ((catapultX3 > leftShipX) && (catapultX3 < rightShipX) && (hitShip3 > bottomShipY) && (hitShip3 < topShipY))
        {
            damage += 100;
        }
        Console.WriteLine(damage + "%");
    }
}

