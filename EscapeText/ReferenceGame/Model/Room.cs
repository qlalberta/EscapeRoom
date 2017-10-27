using System;
using System.Collections.Generic;
using System.Linq;

namespace ReferenceGame.Model
        
{
    public class Room
    {
        public string Message { get; set;}

        public string Name { get; set; }

        //The first item needs to be checked in order to win the game. 
        // But the other items need to have been found in order to win.
        public Item[] WinningItems = new Item[5];

        private List<Item> FoundItems { get; set; } = new List<Item>();

        public Room()
        {
        }

        public bool DidUserFindExit(Item item)
        {
            if (item == WinningItems.First())
            {
                for (var i = 1; i < WinningItems.Count(); i += 1)
                {

                    if (WinningItems[i] == null)
                    {
                        continue;
                    }

                    if( !FoundItems.Contains(WinningItems[i]))
                    {
                        return false;
                    };
                }
                return true;
            }
            return false;
        }

        public List<String> GetFoundItemKeys()
        {
            var temp = new List<string>();

            foreach (var each in FoundItems)
            {
                temp.Add(each.Key());
            }
            return temp;
        }

        public List<String> GetFoundItemNames()
        {
            var temp = new List<string>();

            foreach (var each in FoundItems)
            {
                temp.Add(each.LongName);
            }
            return temp;
        }


        public bool AddFoundItem(Item item)
        {

            // Can not add duplicates
            if (FoundItems.Contains(item))
            {
                return false;
            }

            FoundItems.Add(item);
            return true;
        }

        public Item GetItemWithKey(string key)
        {
            foreach(var each in FoundItems)
            {
                if (key == each.Key())
                {
                    return each;
                }
            }
            return null;
        }

    }
}
