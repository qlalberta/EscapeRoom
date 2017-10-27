using System;
using System.Collections.Generic;

namespace ReferenceGame.Model
{
    public class User
    {
        public string Name { get; set; }
        public List<Item> InventoryItems { get; set; }
        public User()
        {
        }
    }
}
