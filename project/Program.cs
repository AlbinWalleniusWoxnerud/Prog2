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

                        CurrentRun currentRun = new();
                        Player player = new Player();

                        //While gamelogic
                        do
                        {
                            // InitiateEvents(player, g);

                            Room[] rooms = new Room[9];
                            for (int i = 0; i < 9; i++)
                            {
                                rooms[i] = new Room();
                            }
                            //Intro dialog
                            menu.Greetings();

                            //While the game isn't over
                            while (player._alive == true)
                            {
                                //Go to the room indicated by Gamelogic
                                InitRoom(player, rooms, currentRun);
                            }

                            //Play again yes/no
                            // IsPlayAgain();
                        }
                        while (currentRun.playAgain);

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

            static void InitiateEvents(Player player, Goblin g)
            {
                player.PlayerDeathEventHandler += Battles.Battle.player_PlayerDeathEventHandler;
                g.EnemyDeathEventHandler += Battles.Battle.enemy_EnemyDeathEventHandler;
            }
        }
    }
}
