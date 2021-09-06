using System;
using System.Threading;

namespace project
{
    class Program : Logic
    {
        static void Main()
        {
            //UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Introduction
            Introduction();

            while (GameLogic.play)
            {
                //Create a menu with the specified header and alternatives
                int input = Menu(header: "Main menu:", alternatives: "Play game. Settings. End program".Split(". "));

                // Depending on input give different results
                switch (input)
                {
                    //Play game
                    case 1:
                        //While gamelogic
                        while (GameLogic.playAgain)
                        {
                            //Intro dialog
                            Greetings();
                            Quest();
                            EnterMaze();

                            //While the game isn't over
                            while (!IsGameOver())
                            {
                                //Go to the room indicated by Gamelogic
                                InitRoom(GameLogic.currentRoom);
                                if (IsGameOver()) break;
                            }

                            //Play again yes/no
                            IsPlayAgain();
                        }
                        break;
                    case 2:
                        //Change settings of game
                        Settings();
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
