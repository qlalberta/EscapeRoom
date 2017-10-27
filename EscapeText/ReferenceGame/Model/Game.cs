using System;
using GameEngine;
using ReferenceGame.Model;

namespace ReferenceGame
{
    public class Game
    {
        public User Player { get; set; }
        public Room CurrentRoom { get; set; }
        public View view;
        public void Start()
        {
          
            string input = " ";

            while (input != "quit")
            {
                Parse parse = new Parse(input,view, this);
                input = parse.ExecuteCommand();
            }

        }

        public Game()
        {

            // Room Items
            var floor = new Item() { Type = ItemType.RoomItem, LongName = "Floor", Message = "Dumb as a floor" };
            var table = new Item() { Type = ItemType.RoomItem, LongName = "Table", Message = "This table was built in the 1950's" };
            var painting = new Item() { Type = ItemType.RoomItem, LongName = "Painting", Message = "This painting is a replica of the mona lisa" };
            var firePlace = new Item() { Type = ItemType.RoomItem, LongName = "Fire Place", Message = "This fireplace is not too hot but not too cold" };
            var airVent = new Item() { Type = ItemType.RoomItem, LongName = "Air Vent", Message = "There is something in this vent" };
            var door = new Item() { Type = ItemType.RoomItem, LongName = "Door 01", Message = "This door is locked" };

            // Inventory Items
            var flashLight = new Item() { Type = ItemType.InventoryItem, LongName = "FlashLight", Message = "This light has batteries" };
            var screwDriver = new Item() { Type = ItemType.InventoryItem, LongName = "Screw Driver", Message = "This can be used with the vent" };
            var doorKey = new Item() { Type = ItemType.InventoryItem, LongName = "Door Key 01", Message = "This key can be useful. You should keep it." };
            
            // Relationships
            floor.AddChild(table);
            floor.AddChild(firePlace);
            floor.AddChild(airVent);

            firePlace.AddChild(door);


            table.AddChild(flashLight);
            table.AddChild(screwDriver);

            airVent.AddChild(doorKey);


            // Create Room 1

            var room1 = new Room()
            {
                Name = "Living Room",
                Message = "You wake up.Barely.You are injured with a gaping wound, in a room you don't recognize.  How you got here is a mystery.  There is a very feint light from a lantern next to you.  Maybe you should explore?"
            };
            room1.WinningItems[0] = door;
            room1.WinningItems[1] = doorKey;

            room1.AddFoundItem(floor);
            room1.AddFoundItem(painting);

            // Create Player
            this.Player = new User();
            this.CurrentRoom = room1;

            // Create View

            view = new View(CurrentRoom.Name,
                      Display.Wrap(CurrentRoom.Message, 60),
                      CurrentRoom.GetFoundItemNames(),
                            Display.Wrap("Please type HELP for avaiable commands", 60));

        }
    }
}
