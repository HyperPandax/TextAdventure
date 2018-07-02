using System.Collections.Generic;

namespace ZuulCS
{
	public class Room
	{

        private bool locked;

        private string description;
		private Dictionary<string, Room> exits; // stores exits of this room.

        private Inventory inventory;
        internal Inventory Inventory { get => inventory;  }


		/*
	     * Create a room described "description". Initially, it has no exits.
	     * "description" is something like "in a kitchen" or "in an open court
	     * yard".
	     */

		public Room(string description)
		{
            if (this.description == "a big sakura tree in the middel of a field")
            {
                this.locked = true;
            }
            else
            {
                this.locked = false;
            }
            inventory = new Inventory();
            this.description = description;
			exits = new Dictionary<string, Room>();
		}

        public void removeItem(string name, Item item)
        {
            Inventory.remove(name, item);
        }

        public void unlock()
        {
            if (this.locked)
            {
                this.locked = false;
                System.Console.WriteLine("-- This room is now unlocked");
            }
            else
            {
                System.Console.WriteLine("-- This room was already unlocked");
            }
        }

        /**
	     * Define an exit from this room.
	     */
        public void setExit(string direction, Room neighbor)
		{
			exits[direction] = neighbor;
		}

        
  
        /**
	     * Return the description of the room (the one that was defined in the
	     * constructor).
	     */
        public string getShortDescription()
		{
			return description;
		}

		/**
	     * Return a long description of this room, in the form:
	     *     You are in the kitchen.
	     *     Exits: north west
	     */
		public string getLongDescription()
		{
			string returnstring = " ";
			returnstring += description;
			returnstring += ".\n";
			returnstring += getExitstring();
            returnstring += ".\n";
            returnstring += inventory.getItemList();
            return returnstring;
		}

		/**
	     * Return a string describing the room's exits, for example
	     * "Exits: north, west".
	     */
		private string getExitstring()
		{
			string returnstring = "Exits:";

			// because `exits` is a Dictionary, we can't use a `for` loop
			int commas = 0;
			foreach (string key in exits.Keys) {
				if (commas != 0 && commas != exits.Count) {
					returnstring += ",";
				}
				commas++;
				returnstring += " " + key;
			}
			return returnstring;
		}

		/**
	     * Return the room that is reached if we go from this room in direction
	     * "direction". If there is no room in that direction, return null.
	     */
		public Room getExit(string direction)
		{
			if (exits.ContainsKey(direction)) {
				return (Room)exits[direction];
			} else {
				return null;
			}

		}

    }
}
