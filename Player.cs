using System;

namespace ZuulCS
{
    public class Player
    {
        private Room _currentRoom;
        private int _health;


        public Room currentroom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public int damage
        {

        }

        public bool isAlive()
        {
            return true;
        }
        
    }
}
