using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Location
    {
        public string Title;
        public string Description;
        public int RoomNumber;
        public List<Items> items = new List<Items>();
        public Location North;
        public Location East;
        public Location South;
        public Location West;

        public Location(int _roomNumber, string _title, string _description)
        {
            RoomNumber = _roomNumber;
            Title = _title;
            Description = _description;

        }
        public static Location MapSetUp()
        {
            Location parkingSpot = new Location(
                0,
               "The parking spot",
               "You're at the Parking slot. It's cold outside and it snows. You're hungry andthere is a supermarket in front of you.");

            Location supermarket = new Location(
                1,
                "The supermarket",
                "You're in the supermarket. You can see some food and something to eat. In the moment you can't see anybody.");
            Items chocolate = new Items("chocolate", "It seems to be soo delicious:(");
            Items water = new Items("water", "I'm not so thirsty now, but maybe for later.");
            Items bread = new Items("bread", "It looks delicios. I have'nt have eaten something for a long time...");

            Location office = new Location(
                2,
                "The office",
                "You're in the office. There is nothing.");

            Location coolingRoom = new Location(
                3,
                "The cooling room",
                "You're in the cooling room. It's very cold. You can see something to eat and drink. Furthermore you're noticing a flare.");
            Items meat = new Items("meat", "Oh, is looks so good. I don't know when I had the last time meat to eat.");
            Items milk = new Items("milk", "It looks old.");
            Items plier = new Items("plier", "Hmm..I could need it..");
            Items screwdriver = new Items("screwdriver", "It looks old. I don't know if its useable.");

            Location backyard = new Location(
                4,
                "The backyard",
                "You're at backyard. It's cold outside and it snows. there are fences around you.");

            parkingSpot.South = supermarket;

            supermarket.North = parkingSpot;
            supermarket.East = office;
            supermarket.South = coolingRoom;
            supermarket.items.Add(chocolate);
            supermarket.items.Add(water);
            supermarket.items.Add(bread);

            office.West = supermarket;

            coolingRoom.North = supermarket;
            coolingRoom.East = backyard;
            coolingRoom.items.Add(meat);
            coolingRoom.items.Add(milk);
            coolingRoom.items.Add(plier);
            coolingRoom.items.Add(screwdriver);

            backyard.West = coolingRoom;

            return parkingSpot;
        }        
    }
}