using System;
using System.Threading;
using Battles;
using Library;
using Library.Entities;
using Library.Entities.Enemies;
using Text;
namespace Program
{
    class Program : Methods
    {
        static void Main()
        {
            Menu menu = new Menu();

            //UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Introduction
            menu.Introduction();

            while (true)
            {
                //Create a menu with the specified header and alternatives
                int input = TextRender.Table(header: "Main menu:", alternatives: "Play game. Settings. End program".Split(". "));

                // Depending on input give different results
                switch (input)
                {
                    //Play game
                    case 1:
                        CurrentRun run = new CurrentRun();
                        //While gamelogic
                        // while (run.playAgain)
                        {
                            run = new CurrentRun();
                            Player player = new Player(attack: 30, shield: 200);
                            player.PlayerDeathEventHandler += Battles.Battle.player_PlayerDeathEventHandler;

                            Room[] rooms = new Room[9];
                            for (int i = 0; i < 9; i++)
                            {
                                rooms[i] = new Room();
                            }
                            //Intro dialog
                            menu.Greetings();

                            Goblin g = new Goblin(attack: 20, health: 300);
                            Battle.Combat(player, g);

                            //While the game isn't over
                            // while (IsGameOver(player) == false)
                            {
                                //Go to the room indicated by Gamelogic
                                // InitRoom(player, rooms, CurrentRun.currentRoom);
                            }

                            //Play again yes/no
                            // IsPlayAgain();
                        }

                        break;
                    case 2:
                        //Change settings of game
                        menu.Settings();
                        break;
                    case 3:
                        //End program
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
