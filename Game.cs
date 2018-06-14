using System;
using System.Collections.Generic;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player;
        private bool finished;

        public Game ()
		{
            player = new Player();
			createRooms();
            parser = new Parser();
		}


		private void createRooms()
		{
			Room outside, theatre, pub, lab, office, dungeon, flowergarden;
            Item potion, key;

            //create items
            potion = new Potion();
            key = new Key();

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing admin office");
            dungeon = new Room("in a dungeon underneath the admin office. what you see is terrifying");
            flowergarden = new Room("beautifull flowers and butterflies everywhere");

			// initialise room exits
			outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);
            outside.setExit("north", flowergarden);

            flowergarden.setExit("south", outside);

            theatre.setExit("west", outside);

			pub.setExit("east", outside);

			lab.setExit("north", outside);
			lab.setExit("east", office);

			office.setExit("west", lab);
            office.setExit("down", dungeon);

            dungeon.setExit("up", office);

            //set Items
            theatre.setItem("key", key);

            lab.setItem("potion", potion);

	        player.currentroom = outside;  // start game outside
		}

        private Dictionary<string, Item> itemList = new Dictionary<string, Item>();
       
        
            /**
             *  Main play routine.  Loops until end of play.
             */
        public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
                bool p = player.isAlive();
                if (!p)
                {
                    Console.WriteLine("You're DEAD");

                    finished = true;
                    //return finished;
                }
			}
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentroom.getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
                case "look":
                    printLongDiscription();
                    break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
            Console.WriteLine("=============================================");
            Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

        private void printLongDiscription()
        {
            string discription = player.currentroom.getLongDescription();
            Console.WriteLine("=============================================");
            Console.WriteLine(discription);
            Console.WriteLine("the items in this room:");
           /* foreach (KeyValuePair<string, Item> entry in itemList)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value.Description);
            }*/
        }


		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentroom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to "+direction+"!");
			} else {
				player.currentroom = nextRoom;
                player.damage(1);

                //player.getHealth;

                Console.WriteLine("=============================================");
                Console.WriteLine(player.currentroom.getLongDescription());
                Console.WriteLine("you have: " + player.getHealth + " health");
                
                //bool finished = false; 
                /*while (!finished)
                {
                    Command command = parser.getCommand();
                    finished = processCommand(command);
                }*/
            }
        }

	}
}
