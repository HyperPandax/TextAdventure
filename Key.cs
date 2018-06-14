using System;


namespace ZuulCS
{

    public class Key : Item
    {
        public Key()
        {
            Console.WriteLine("*constructor Key*");

            _weight = 10;
            _name = "key";
            _description = "a key to open a door";

        }

        public override void use(object o)
        {

        }
    }
}