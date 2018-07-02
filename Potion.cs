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
            if (o.GetType() == typeof(Player))
            {
                Player p = (Player)o; // must cast
                p.heal();
            }
            else
            {
                // Object o is not a Person
                System.Console.WriteLine("Can't use a Potion on this Object");
            }
        }

        public override void use()
        {
            System.Console.WriteLine("Potion::use()");
        }
    }
}
