using System;
using System.Collections.Generic;

namespace ZuulCS
{


    public class Inventory
    {
        private int maxWeight;

        public Dictionary<string, Item> itemList;
       // private Item key;

	    public Inventory()
	    {
            Console.WriteLine("*constructor Inventory*");

            itemList = new Dictionary<string, Item>();
            /*//key = new Item();
            //key.Description = "a key";
            //itemList["key"] = key;

            foreach(KeyValuePair<string,Item> entry in itemList)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value.Description);
            }*/

        }





    }
}
