using System;

namespace ZuulCS
{

    public class Flower : Item
    {
        public Flower()
        {
            Console.WriteLine("*constructor Potion*");

            
            _name = "Flower";
            _description = "collect all ";

        }

        public override void use(object o)
        {
            if (o.GetType() == typeof(Sakura))
            {
                Sakura s = (Sakura)o; // must cast
                //s.heal(); 
            }
            else
            {
                // Object o is not a Person
                System.Console.WriteLine("Can't use a flower on this Object");
            }
        }

        public override void use()
        {
            System.Console.WriteLine("flower::use()");
        }
    }
}
