﻿using System;
using System.Collections.Generic;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player;
       

        public Game ()
		{
            player = new Player();
			createRooms();
            parser = new Parser();
		}


		private void createRooms()
		{
            Room garden, violets, hibiscuses, bridge, grassfield, poppys, lotuses, flowerdome, sakura, roses;
            Item violet, hibiscus, poppy, lotus, rose, key;

            //create items
            violet = new Flower();
            hibiscus = new Flower();
            poppy = new Flower();
            lotus = new Flower();
            rose = new Flower();

            key = new Key();

			// create the rooms
			garden = new Room("You are outside the main entrance of the Garden");
			violets = new Room("You are in a field full of violets");
			hibiscuses = new Room("You see hibiscus plants everywhere");
            sakura = new Room("You see a big sakura tree in the middel of a field");

            bridge = new Room("You are on a bridge that goes over the river in the garden");

			grassfield = new Room("You are in a grassfield with on some places daisy's");
            flowerdome = new Room("You are in a dome made of roses but they are to high to reach. there is a ladder");
            poppys = new Room("");
            lotuses = new Room("You see a small lake full of lotuses");

            roses = new Room("You are this high up and see a lot of roses");


            // initialise room exits
            garden.setExit("north", sakura);
            garden.setExit("east", violets);
            garden.setExit("south", bridge);
            garden.setExit("west", hibiscuses);
            
            violets.setExit("west", garden);
            hibiscuses.setExit("east", garden);
            sakura.setExit("south", garden);

            bridge.setExit("north", garden);
            bridge.setExit("south", grassfield);

            grassfield.setExit("north", bridge);
            grassfield.setExit("east", flowerdome);
            grassfield.setExit("south", lotuses);
            grassfield.setExit("west", poppys);

            flowerdome.setExit("west", grassfield);
            poppys.setExit("east", grassfield);
            lotuses.setExit("north", grassfield);

            flowerdome.setExit("up", roses);
            roses.setExit("down", flowerdome);

            //set Items
            hibiscuses.Inventory.addItem("hibiscus", hibiscus);
            violets.Inventory.addItem("violet", violet);
            roses.Inventory.addItem("rose", rose);
            poppys.Inventory.addItem("poppy", poppy);
            lotuses.Inventory.addItem("lotus", lotus);

            //if all flowers are in player inventory
           // garden.Inventory.addItem("key", key);

            player.currentroom = garden;  // start game outside
		}
     
        /*
        Main play routine.  Loops until end of play.
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
                }
			}
			Console.WriteLine("Thank you for playing.");
		}

		/*
	    Print out the opening message for the player.
	    */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Flower Garden!");
			Console.WriteLine("Flower Garden is a cute and happy flower collecting game");
            Console.WriteLine("Something terible happend. the sakura tree won't bloom");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentroom.getLongDescription());
		}

		/*
	    Given a command, process (that is: execute) the command.
	    If this command ends the game, true is returned, otherwise false is
	    returned.
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

		/*
	    Print out some help information.
	    Here we print some stupid, cryptic message and a list of the
	    command words.
	    */
		private void printHelp()
		{
            Console.WriteLine("=============================================");
            Console.WriteLine("You trying to make the sakura tree bloom ");
            Console.WriteLine("Go collect all flower and put them underneath the sakura tree");
            Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

        private void printLongDiscription()
        {
            string discription = player.currentroom.getLongDescription();
            Console.WriteLine("=============================================");
            Console.WriteLine(discription);
            Console.WriteLine("the Flower in this room:");
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
				Console.WriteLine("There is no way to "+direction+"!");
			} else {
				player.currentroom = nextRoom;
                //player.damage(1);

                Console.WriteLine("=============================================");
                Console.WriteLine(player.currentroom.getLongDescription());
                //Console.WriteLine("you have: " + player.getHealth + " health");
                
            }
        }

	}
}
