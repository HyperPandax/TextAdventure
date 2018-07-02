using System;


namespace ZuulCS
{

    public class Key : Item
    {
        public Key()
        {
            Console.WriteLine("*constructor Key*");

            _name = "key";
            _description = "a key to open a door";

        }

        public override void use(object o)
        {
            if (o.GetType() == typeof(Room))
            {
                Room r = (Room)o; // must cast
                r.unlock();
            }
            else
            {
                // Object o is not a Room
                System.Console.WriteLine("Can't use a key on this Object");
            }
        }

        public override void use()
        {
            System.Console.WriteLine("Key::use()");
        }
    }
}
