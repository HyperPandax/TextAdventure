using System;

namespace ZuulCS
{
    public class Player
    {
        private Room _currentRoom;

        private int _health;
        private int numI;

        private Inventory _inventory;
        internal Inventory Inventory { get => _inventory; }
        internal Inventory Innventory { set =>  _inventory = value; }


        public Player()
        {
            System.Console.WriteLine("player Constructor");

            _inventory = new Inventory();
            this._health = 15;
            numI = 0;
            isAlive();
        }

        public int NumberOFitems
        {
            get { return numI;  }
            set { numI = value;  }
        }
        public void setItem(string name, Item item)
        {
            Console.WriteLine(name + " is added to your inventory");
            _inventory.addItem(name, item);
        }

        public Room currentroom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public bool isAlive()
        {
            if(_health < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
   
        }
        
    }
}
