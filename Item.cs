using System;


namespace ZuulCS
{


    public class Item
    {
        protected string _name;
        protected string _description;
        protected int _weight;
        

        //private string _description;

        public Item()
        {
            Console.WriteLine("*constructor Item*");
            _description = "A generic Item";
           
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public virtual void use(object o)
        {
            System.Console.WriteLine("Item::use(Object o)");
        }

        public virtual void use()
        {
            System.Console.WriteLine("Item::use()");
        }

    }
}
