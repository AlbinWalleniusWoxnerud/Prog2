using System;
using System.Threading;
using Text;

namespace ProgramLibrary
{
    public class PlayerDeathEventArgs : EventArgs
    {
        public DateTime TimeOfDeath { get; private set; }

        public PlayerDeathEventArgs()
        {
            TimeOfDeath = DateTime.Now;
        }
    }
    internal class Menu
    {
        internal bool play { get; set; } = true;
        internal bool playAgain { get; set; } = true;

        public void Settings()
        {
        start:
            int userInput = TextRender.Table(header: "Settings: ", alternatives: "Remove slow text. Change default text color. Return to main menu".Split(". "));
            switch (userInput)
            {
                //Slow text setting
                case 1:
                    int userInput2 = TextRender.Table(header: "Remove slow text: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                    switch (userInput2)
                    {
                        case 1:
                            TextRender.Delay = 0;
                            break;
                        case 2:
                            goto start;
                        case 3:
                            TextRender.Delay = 30;
                            break;
                    }
                    break;

                //Text color setting
                case 2:
                    int userInput3 = TextRender.Table(header: "Change default text color: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                    switch (userInput3)
                    {
                        case 1:
                            // ChangeTextColor();
                            break;
                        case 2:
                            goto start;
                        case 3:
                            TextRender.TextColor = Color.Magenta;
                            break;
                    }
                    break;

                //Return to main menu
                case 3:
                    break;
            }

        }
        internal void Introduction()
        {
            //An introduction to the game and its maker
            Text.TextRender.Render("~ League of Narnia ~", color: Text.Color.Red);
            Text.TextRender.Render("A textbased game by Albin Inc. in cooperation with Woxnerud Studios.");
            Text.TextRender.Render("Copyright 2021 ©");
            Text.TextRender.Render("");
            Text.TextRender.Render("Enter 'quit' at any time to end the program.", color: Text.Color.White);
        }

        internal void Greetings()
        {
            //A greeting to the player at the start of the game
            TextRender.Render("Welcome to League of Narnia!");
            TextRender.Render("A textbased adventure of glory, heroism and honnor.");
            TextRender.Render("It is time for you to carve out your own path in this world adventurer!");
            TextRender.Render("Are you ready, ", sameLine: true);
            TextRender.Render("for the battles that await, ", sameLine: true);
            TextRender.Render("for the blood that will flow", sameLine: true, color: Text.Color.Red);
            TextRender.Render(", for the .");
            TextRender.Render("But first you must prove yourself worthy, and so your first quest is to conquer the Maze of", sameLine: true);
            TextRender.Render(" Smedd the Terrible", color: Text.Color.Green);
            TextRender.Render("");
            TextRender.Render("As you enter the maze you slip and fall, blacking out as a result...");
            TextRender.Render("...", delay: 1000);
            TextRender.Render("...", delay: 1000);
            TextRender.Render("You wake up in a daze and look around.");
            TextRender.Render("Finding yourself in a pitch black room, thankfully you brought a ", sameLine: true);
            TextRender.Render("torch", sameLine: true, color: Text.Color.White);
            TextRender.Render(" with you.");
            TextRender.Render("");
            TextRender.Render("As you ", sameLine: true);
            TextRender.Render("light", sameLine: true, color: Text.Color.Yellow);
            TextRender.Render(" your torch you are able to make out faint details of the room.");
        }

        //Change text color
        // internal void ChangeTextColor()
        // {
        //     //Array of all possibilities
        //     string[] allPossibleConsoleColors = { "Black", "Blue", "Cyan", "DarkBlue", "DarkCyan", "DarkGray", "DarkGreen", "DarkMagenta", "DarkRed", "DarkYellow", "Gray", "Green", "Magenta", "Red", "White", "Yellow" };
        //     TextRender.Render("Warning! Changing the text color might make text unreadable and or indistinguishable from the background.", color: Text.Color.Red);
        //     int userInput = TextRender.Table(header: "Proceed?", alternatives: "Yes.. No".Split(". "));

        //     if (userInput == 2) return;

        //     //Choose between all possibilities
        //     int userInput2 = TextRender.Table(header: "Choose a color", alternatives: allPossibleConsoleColors);
        //     CurrentRun.textColor = allPossibleConsoleColors[userInput2 - 1];
        //     TextRender.Render($"You choose {allPossibleConsoleColors[userInput2 - 1]}");
        // }
    }

    //Fundamental game logic of the game
    internal class CurrentRun
    {
        internal int currentRoom { get; set; } = 1;
        internal bool conquered { get; set; } = false;
    }

    partial class Methods
    {
        //Check if the player want to play another game
        // internal static void IsPlayAgain()
        // {
        //     SlowRPGWrite("Would you like to play again?");
        //     int input = TextRender.Table("Menu:", "Play again.. End game.".Split(". "));
        //     switch (input)
        //     {
        //         case 1:
        //             StaticPlayer.Reset();
        //             StaticEnemies.Reset();
        //             GameLogic.Reset();
        //             StaticRoom.Reset();
        //             break;
        //         case 2:
        //             GameLogic.playAgain = false;
        //             break;
        //     }

        // }

        //Self explanatory
        internal static bool IsGameOver(Player player, CurrentRun run)
        {
            //The game is over if the player is dead or if the maze is conquered
            if (player._alive == false || player._health <= 0)
            {
                return true;
            }
            if (run.conquered == true) return true;
            return false;
        }

        // internal static void InitRoom(Player player, Room[] rooms, int currentRoom)
        // {
        //     //Really just a switch made into a method to make the code less cluttered
        //     //Based on current room get that room
        //     switch (currentRoom)
        //     {
        //         case 1:
        //             Rooms.Room1.Room(player, rooms[0]);
        //             break;
        //         case 2:
        //             Rooms.Room2.Room(player, rooms[1]);
        //             break;
        //             // case 3:
        //             //     Room3Methods.Room3();
        //             //     break;
        //             // case 4:
        //             //     Room4Methods.Room4();
        //             //     break;
        //             // case 5:
        //             //     Room5Methods.Room5();
        //             //     break;
        //             // case 6:
        //             //     Room6Methods.Room6();
        //             //     break;
        //             // case 7:
        //             //     Room7Methods.Room7();
        //             //     break;
        //             // case 8:
        //             //     Room8Methods.Room8();
        //             //     break;
        //             // case 9:
        //             //     Room9Methods.Room9();
        //             // break;
        //     }
        // }
    }
}