using System;
using System.Collections.Generic;

namespace ReferenceGame.Model
{
    public class Item
    {
        // This key is used to retrieve the an object
        public string Key (string input = "")
        {
            input = string.IsNullOrWhiteSpace(input) ? LongName : input;      
            return CreateKey(input);
        }

        public static string CreateKey(string input)
        {
            string newInput = input.Replace(" ", "").ToLower();
            return newInput;
        }


        public string LongName = " ";
        public string Message { get; set; }
        public ItemType Type { get; set; }
        private List<Item> Children { get; set; } = new List<Item>();

        public bool AddChild(Item item)
        {
            //  Can not add self as a children
            if (Key() == item.Key()) 
            {
                return false;
            }
            // Can not add duplicates to children 
            if (Children.Contains(item))
            {
                return false;
            }

            Children.Add(item);
            return true;
        }

        public Item GetChild(string key)
        {
            foreach(var each in Children)
            {
                if (Key() == key)
                {
                    return each;
                }
            }

            return null;
        }

        public List<Item> GetChildren()
        {
            return this.Children;
        }

        public List<String> GetChildrenLongNames()
        {
            List<string> childrensNames = new List<String>();

            foreach(var each in Children)
            {
                childrensNames.Add(each.LongName);
            }
            return childrensNames;
        }

    }

    public enum ItemType
    {
        InventoryItem, RoomItem
    }

}
