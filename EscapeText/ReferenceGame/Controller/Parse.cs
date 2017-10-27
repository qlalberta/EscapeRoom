using System;
using System.Collections.Generic;
using System.Text;
using GameEngine;

namespace ReferenceGame
{
    public class Parse
    {
        public String[] commands;
        public Game game;
        public View view;
        public Parse(string s, View view, Game game)
        {
            s = string.IsNullOrWhiteSpace(s) ? "HELP" : s;
            commands = s.ToLower().Split(' ');
            this.game = game;
            this.view = view;
        }

        public void UpdateCommandHistory(TextBoxArea boxToUse)
        {
            var height = view.GetTextBox(boxToUse).height;
            view.SetArea(view.GetCommandHistory(height), boxToUse);
        }


        public string ExecuteCommand()
        {
            UpdateCommandHistory(TextBoxArea.C);
            updateItems();
            switch (commands[0])
            {
                case "help":
                    view.SetArea("1.Examine; 2. Explore; 3.Quit", TextBoxArea.A);
                    return view.UpdateScreenAndGetInput();
                case "examine":
                    return Examine();
                case "explore":
                   return Explore();
                default:
                    view.SetArea("Command not found. Type help for a list of commands.", TextBoxArea.A);
                    return view.UpdateScreenAndGetInput();
            }
        }

        public void updateItems()
        {
            view.SetArea( "These are the items you have found: ", game.CurrentRoom.GetFoundItemNames(), TextBoxArea.B);

        }

        string Explore()
        {
            if (commands.Length > 1)
            {
                view.SetArea("Explore doesn't take any arguments", TextBoxArea.A);
            }
            view.SetArea("You are exploring " + game.CurrentRoom.Name, TextBoxArea.A);
            return view.UpdateScreenAndGetInput();
        }

        string Examine()
        {
            string keyOfItem = "";
            for (var i = 1; i < commands.Length; i += 1)
            {
                keyOfItem += commands[i];
            }
            var item = game.CurrentRoom.GetItemWithKey(keyOfItem);

            if (item != null)
            {
                if (game.CurrentRoom.DidUserFindExit(item))
                {
                    view.SetArea("You won!!!!!!!!!!!!", TextBoxArea.A);

                    //TODO: This is where we go to the next room
                    return view.UpdateScreenAndGetInput();

                } else
                {
                    view.SetArea("This message was found in the item:", item.Message, TextBoxArea.A);
                }
                if (item.GetChildren().Count > 0)
                {
                    //var text = "You've found the following item" + (item.GetChildren().Count == 1 ? ":" : "s:");
                    view.SetArea("You Found these items:", item.GetChildrenLongNames(), TextBoxArea.A);

                    foreach( var itemChild in item.GetChildren())
                    {
                        game.CurrentRoom.AddFoundItem(itemChild);
                    }
                }
               
            } else
            {
                view.SetArea("Item not found.", TextBoxArea.A);
            }
            return view.UpdateScreenAndGetInput();

        }

    }
}
