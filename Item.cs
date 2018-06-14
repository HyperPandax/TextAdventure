using System;


namespace ZuulCS
{


    public class Item
    {
        protected string _name;
        protected string _description;
        protected string _use;
        protected int _weight;
        

        //private string _description;

        public Item()
        {
            Console.WriteLine("*constructor Item*");

            _weight = 0;
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual void use(object o)
        {

        }



    }
}
