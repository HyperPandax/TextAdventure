using System;

namespace ZuulCS
{
    public class Player
    {
        private Room _currentRoom;
        private int _health;
        private Inventory _inventory;


        public Player()
        {
            _inventory = new Inventory();
            this._health = 15;
            isAlive();

        }


        public void setItem(string name, Item item)
        {
            _inventory.itemList.Add(name, item);
        }

        public string getItemList()
        {

            string returnstring = "Items:";

            // because `exits` is a Dictionary, we can't use a `for` loop
            int commas = 0;
            foreach (string key in _inventory.itemList.Keys)
            {
                if (commas != 0 && commas != _inventory.itemList.Count)
                {
                    returnstring += ",";
                }
                commas++;
                returnstring += " " + key;
            }
            return returnstring;
            //inventory.itemList
            /*for(int i = inventory.itemList.Count-1;i>=0; i--)
            {

            }*/
        }
        public Item getItem(string name)
        {

            if (_inventory.itemList.ContainsKey(name))
            {
                return (Item)_inventory.itemList[name];
            }
            else
            {
                return null;
            }

        }


        public Room currentroom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public int getHealth
        {
            get { return _health; }
        }

        public int damage(int amount)
        {
            this._health += -amount;
            return this._health;
        }

        public int heal(int amount)
        {
            this._health += amount;
            return this._health;
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
