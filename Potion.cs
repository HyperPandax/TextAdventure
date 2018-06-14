using System;

namespace ZuulCS
{

    public class Potion : Item
    {
        public Potion()
        {
            Console.WriteLine("*constructor Potion*");

            _weight = 15;
            _name = "Potion";
            _description = "drink to heal 5 points ";

        }

        public override void use(object o)
        {

        }
    }
}