using System;

namespace ZuulCS
{
    public class Player
    {
        private Room _currentRoom;

        private int _health;
        private int _maxHealth;

        private Inventory _inventory;


        public Player()
        {
            _inventory = new Inventory();
            this._health = 15;
            this._maxHealth = 50;
            isAlive();

            System.Console.WriteLine("player Constructor");
        }

        public void setItem(string name, Item item)
        {
            _inventory.addItem(name, item);
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

        /*public int heal(int amount)
        {
            this._health += amount;
            return this._health;
        }*/
        public void heal()
        {
            if (this._health < this._maxHealth)
            {
                this._health = this._maxHealth;
                System.Console.WriteLine("-- Person is healed");
            }
            else
            {
                System.Console.WriteLine("-- Person already has full health");
            }
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
