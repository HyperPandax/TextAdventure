using System;
using System.Collections.Generic;

namespace ZuulCS
{


    public class Inventory
    {
        

        private Dictionary<string, Item> itemList;
       // private Item key;

	    public Inventory()
	    {
            Console.WriteLine("*constructor Inventory*");

            itemList = new Dictionary<string, Item>();

        }

        public void addItem(string tag, Item item)
        {
            this.itemList.Add(tag,item);
        }

        public Item getItem(string name)
        {

            if (itemList.ContainsKey(name))
            {
                return (Item)itemList[name];
            }
            else
            {
                return null;
            }

        }

        public string  getItemList()
        {
            string returnstring = "Items:";

            // because `ItemList` is a Dictionary, we can't use a `for` loop
            int commas = 0;
            foreach (string key in itemList.Keys)
            {
                if (commas != 0 && commas != itemList.Count)
                {
                    returnstring += ",";
                }
                commas++;
                returnstring += " " + key;
            }
            return returnstring;
        }
        



    }
}
