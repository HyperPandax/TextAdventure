using System;

namespace ZuulCS
{
    public class Player
    {
        private Room _currentRoom;
        private int _health;

        public Player()
        {
            this._health = 15;
            isAlive();

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
