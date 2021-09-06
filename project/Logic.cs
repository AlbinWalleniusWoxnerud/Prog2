using System;
using System.Threading;

namespace project
{
    class Logic
    {
        //A method that slows down the typing speed of the console
        public static void SlowRPG_Write(string input, bool sameLine = false, string color = "Magenta", int delay = 30)
        {
            //If player changed settings change them here, because otherwise it will cause a compile time error
            delay = GameLogic.delay;

            //This atleast tries to make sure that highlighted text is still highlighted
            if (color == "Magenta") color = GameLogic.textColor;

            //Split the given input string into a char array
            char[] charArray = input.ToCharArray();

            //If a color was specified try to parse it to the correct format
            if (Enum.TryParse(color, out ConsoleColor foreground))
            {
                //If the parse was successful make the console's foreground color into that color
                Console.ForegroundColor = foreground;
            }

            //Print out every letter in the char array with a slight delay
            foreach (var letter in charArray)
            {
                Console.Write(letter);
                Thread.Sleep(delay);
            }

            //Reset the foreground color
            Console.ResetColor();

            //If specified as being written on the same line return here and skip the line break
            if (sameLine) return;

            // Thread.Sleep(100);
            Console.WriteLine();

            return;
        }

        //Settings, change the settings of the game
        static void Settings()
        {
        start:
            int userInput = Menu(header: "Settings: ", alternatives: "Remove slow text. Change default text color. Return to main menu".Split(". "));
            switch (userInput)
            {
                //Slow text setting
                case 1:
                    int userInput2 = Menu(header: "Remove slow text: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                    switch (userInput2)
                    {
                        case 1:
                            GameLogic.delay = 0;
                            break;
                        case 2:
                            goto start;
                        case 3:
                            GameLogic.delay = 30;
                            break;
                    }
                    break;

                //Text color setting
                case 2:
                    int userInput3 = Menu(header: "Change default text color: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                    switch (userInput3)
                    {
                        case 1:
                            ChangeTextColor();
                            break;
                        case 2:
                            goto start;
                        case 3:
                            GameLogic.textColor = "Magenta";
                            break;
                    }
                    break;

                //Return to main menu
                case 3:
                    break;
            }
        }

        //Change text color
        static void ChangeTextColor()
        {
            //Array of all possibilities
            string[] allPossibleConsoleColors = { "Black", "Blue", "Cyan", "DarkBlue", "DarkCyan", "DarkGray", "DarkGreen", "DarkMagenta", "DarkRed", "DarkYellow", "Gray", "Green", "Magenta", "Red", "White", "Yellow" };
            SlowRPG_Write("Warning! Changing the text color might make text unreadable and or indistinguishable from the background.", color: "Red");
            int userInput = Menu(header: "Proceed?", alternatives: "Yes.. No".Split(". "));

            if (userInput == 2) return;

            //Choose between all possibilities
            int userInput2 = Menu(header: "Choose a color", alternatives: allPossibleConsoleColors);
            GameLogic.textColor = allPossibleConsoleColors[userInput2 - 1];
            SlowRPG_Write($"You choose {allPossibleConsoleColors[userInput2 - 1]}");
        }

        static void Introduction()
        {
            //An introduction to the game and its maker
            SlowRPG_Write("~ League of Narnia ~", color: "Red");
            SlowRPG_Write("A textbased game by Albin Inc. in cooperation with Woxnerud Studios.");
            SlowRPG_Write("Copyright 2021 ©");
            SlowRPG_Write("");
            SlowRPG_Write("Enter 'quit' at any time to end the program.", color: "White");
        }

        public static void Greetings()
        {
            //A greeting to the player at the start of the game
            SlowRPG_Write("Welcome to League of Narnia!");
            SlowRPG_Write("A textbased adventure of glory, heroism and honnor.");
            SlowRPG_Write("It is time for you to carve out your own path in this world adventurer!");
            SlowRPG_Write("Are you ready, ", sameLine: true);
            SlowRPG_Write("for the battles that await, ", sameLine: true);
            SlowRPG_Write("for the blood that will flow", sameLine: true, color: "Red");
            SlowRPG_Write(", for the .");
            SlowRPG_Write("But first you must prove yourself worthy, and so your first quest is to conquer the Maze of", sameLine: true);
            SlowRPG_Write(" Smedd the Terrible", color: "Green");
        }

        public static void Quest()
        {
            //The quest the player gets at the start of the game
            SlowRPG_Write("");
            SlowRPG_Write("Quest: Conquer the Maze of Smedd the Terrible", color: "White");
            SlowRPG_Write("");
        }

        public static void EnterMaze()
        {
            //Dialog essentially
            SlowRPG_Write("As you enter the maze you slip and fall, blacking out as a result...");
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("You wake up in a daze and look around.");
            SlowRPG_Write("Finding yourself in a pitch black room, thankfully you brought a ", sameLine: true);
            SlowRPG_Write("torch", sameLine: true, color: "White");
            SlowRPG_Write(" with you.");
            SlowRPG_Write("");
            SlowRPG_Write("As you ", sameLine: true);
            SlowRPG_Write("light", sameLine: true, color: "Yellow");
            SlowRPG_Write(" your torch you are able to make out faint details of the room.");
        }

        //A method that creates a menu with alternatives
        public static int Menu(string header, string[] alternatives)
        {
            //Prints out the menu with alternatives
            SlowRPG_Write($"\n{header}");
            for (int i = 0; i < alternatives.Length; i++)
            {
                SlowRPG_Write($"{i + 1}. {alternatives[i]}");
            }

            //Get an input corresponding to one the 3 alternatives given through the GetInCorrectRange() method, see GetInCorrectRange() for further info
            int? userInput = GetInCorrectRange(1, alternatives.Length);
            if (userInput == null) System.Environment.Exit(0);
            return (int)userInput;
        }

        //Method to get an integer in a certain range, also check or 'quit'
        public static int? GetInCorrectRange(int lowerRange, int upperRange)
        {
            //Init vars
            bool isInRange = false;
            int userInput = 0;

            //While the given user input isn't in the range repeat until it is
            while (!isInRange)
            {
                //Init var
                bool isInt = false;

                //While the given input isn't an integer repeat until it is
                while (!isInt)
                {
                    string rawUserInput = Console.ReadLine();
                    if (rawUserInput == "quit") return null;
                    isInt = int.TryParse(rawUserInput, out userInput);

                    //If given input isn't an integer tell the user
                    if (!isInt)
                    {
                        SlowRPG_Write("Input must be an integer, try again!", color: "Red");
                    }
                }

                //Check if given input is in the given range
                if (lowerRange <= userInput && userInput <= upperRange)
                {
                    //If it is end the while loop and return the integer
                    isInRange = true;
                }

                //If it isn't in the range tell the user the correct range and make them enter a new input
                else
                {
                    SlowRPG_Write($"Input must be between {lowerRange} and {upperRange}, try again!", color: "Red");
                }
            }

            //Return the correct input which is an integer in the correct range
            return userInput;
        }

        //Check if the player want to play another game
        public static void IsPlayAgain()
        {
            SlowRPG_Write("Would you like to play again?");
            int input = Menu("Menu:", "Play again.. End game.".Split(". "));
            switch (input)
            {
                case 1:
                    StaticPlayer.Reset();
                    StaticEnemies.Reset();
                    GameLogic.Reset();
                    StaticRoom.Reset();
                    break;
                case 2:
                    GameLogic.playAgain = false;
                    break;
            }

        }

        //Self explanatory
        public static bool IsGameOver()
        {
            //The game is over if the player is dead or if the maze is conquered
            if (StaticPlayer.player.alive == false || StaticPlayer.player.health <= 0)
            {
                GameLogic.currentRoom = 1;
                return true;
            }
            if (GameLogic.conquered == true) return true;
            return false;
        }

        //Everytime the player does something stupid increase stupidity and display that their stupidity increased, if stupidity reaches 10 the player dies, currently only works for room 1
        public static bool Stupidity()
        {
            if (StaticPlayer.player.stupidity > 9)
            {
                SlowRPG_Write("");
                SlowRPG_Write("Your stupidity has enraged the gods!", color: "Cyan");
                SlowRPG_Write("");
                SlowRPG_Write("You died", color: "Red");
                SlowRPG_Write("");

                //Change player status
                StaticPlayer.player.alive = false;
                return true;
            }
            SlowRPG_Write("");
            SlowRPG_Write("Your stupidity increases...", color: "DarkGreen");
            SlowRPG_Write("");

            //Increase stupidity
            StaticPlayer.player.stupidity++;
            return false;
        }

        //The method for when the player attacks
        public static void PlayerAttack(int enemyHealth, int enemyShield, double enemyDefense, out int enemy_remaining_shield, out int enemy_remaining_health)
        {
            double damage = StaticPlayer.player.attack;
            Random rnd = new Random();
            int critChance = rnd.Next(1, 100);

            damage = damage * enemyDefense;
            SlowRPG_Write("Damage dealt reduced by ", sameLine: true);
            SlowRPG_Write($"{Math.Round((1 - enemyDefense) * 100)}%", sameLine: true, color: "White");
            SlowRPG_Write(" due to enemy's defense.");


            //If player crits 2x the damage
            if ((100 - StaticPlayer.player.crit) <= critChance)
            {
                SlowRPG_Write("You crit!", color: "White");
                damage *= 2;
            }

            if ((enemyShield - damage) >= 0)
            {
                //Cast damage to int 
                enemyShield = enemyShield - (int)damage;

                SlowRPG_Write($"{(int)damage}", sameLine: true, color: "White");
                SlowRPG_Write(" damage blocked by enemy's shield.");
                SlowRPG_Write("Enemy has ", sameLine: true);
                SlowRPG_Write($"{enemyShield}", sameLine: true, color: "White");
                SlowRPG_Write(" remaining shield.");
            }

            //If the attack destoys the shield
            else if ((enemyShield - damage) < 0 && enemyShield > 0)
            {
                SlowRPG_Write($"{damage - enemyShield}", sameLine: true, color: "White");
                SlowRPG_Write(" damage blocked by enemy's shield.");

                //Remaining damage after shield blocked some of it
                damage = damage - enemyShield;

                //Enemy shield is destoyed since (enemyShield - damage) was less than 0
                enemyShield = 0;
                SlowRPG_Write("Enemy shield was destroyed.", color: "White");
                SlowRPG_Write($"{(int)damage}", sameLine: true, color: "White");
                SlowRPG_Write(" was dealt directly to enemy HP.");

                //Down cast double damage to int
                enemyHealth = enemyHealth - (int)damage;

                SlowRPG_Write("Enemy has ", sameLine: true);
                SlowRPG_Write($"{enemyHealth}", sameLine: true, color: "White");
                SlowRPG_Write(" HP remaining.");
            }

            //Enemies shield is destroyed so deal damage directly to enemy hp
            else
            {
                SlowRPG_Write($"{(int)damage}", sameLine: true, color: "White");
                SlowRPG_Write(" was dealt directly to enemy HP.");
                enemyHealth = enemyHealth - (int)damage;
                SlowRPG_Write("Enemy has ", sameLine: true);
                SlowRPG_Write($"{enemyHealth}", sameLine: true, color: "White");
                SlowRPG_Write(" HP remaining.");
            }

            SlowRPG_Write("");

            //return the new shield and health of the enemy
            enemy_remaining_health = enemyHealth;
            enemy_remaining_shield = enemyShield;
        }
        public static void PlayerGetsAttacked(double enemyCritChance, double enemyDamage, bool isPlayerDefending)
        {
            double defense = StaticPlayer.player.defense;
            int health = StaticPlayer.player.health;
            int shield = StaticPlayer.player.shield;
            Random rnd = new Random();
            int critChance = rnd.Next(1, 100);

            enemyDamage = enemyDamage * defense;
            SlowRPG_Write("Damage received reduced by ", sameLine: true);
            SlowRPG_Write($"{Math.Round((1 - defense) * 100)}%", sameLine: true, color: "White");
            SlowRPG_Write(" due to your armour.");


            //The critChance gives a possibility of 2x damage if your lucky 
            if ((100 - enemyCritChance) <= critChance)
            {
                SlowRPG_Write("Enemy crit!", color: "White");
                enemyDamage *= 2;
            }

            if (isPlayerDefending)
            {
                if ((shield - enemyDamage) >= 0)
                {
                    //Cast damage to int 
                    shield = shield - (int)enemyDamage;

                    SlowRPG_Write($"{(int)enemyDamage}", sameLine: true, color: "White");
                    SlowRPG_Write(" damage blocked by your shield.");
                    SlowRPG_Write("You have ", sameLine: true);
                    SlowRPG_Write($"{shield}", sameLine: true, color: "White");
                    SlowRPG_Write(" remaining shield.");
                }

                //If the attack destoys the shield
                else if ((shield - enemyDamage) < 0 && shield > 0)
                {
                    SlowRPG_Write($"{enemyDamage - shield}", sameLine: true, color: "White");
                    SlowRPG_Write(" damage blocked by your shield.");

                    //Remaining damage after shield blocked some of it
                    enemyDamage = enemyDamage - shield;

                    //Enemy shield is destoyed since (enemyShield - damage) was less than 0
                    shield = 0;
                    SlowRPG_Write("Your shield was destroyed.", color: "White");
                    SlowRPG_Write($"{(int)enemyDamage}", sameLine: true, color: "White");
                    SlowRPG_Write(" was dealt directly to your HP.");

                    //Down cast double damage to int
                    health = health - (int)enemyDamage;

                    SlowRPG_Write("You have ", sameLine: true);
                    SlowRPG_Write($"{health}", sameLine: true, color: "White");
                    SlowRPG_Write(" HP remaining.");
                }
                else
                {
                    SlowRPG_Write($"{(int)enemyDamage}", sameLine: true, color: "White");
                    SlowRPG_Write(" was dealt directly to your HP.");
                    health = health - (int)enemyDamage;
                    SlowRPG_Write("You have ", sameLine: true);
                    SlowRPG_Write($"{health}", sameLine: true, color: "White");
                    SlowRPG_Write(" HP remaining.");
                }
            }
            //shield is destroyed so deal damage directly to hp
            else
            {
                SlowRPG_Write($"{(int)enemyDamage}", sameLine: true, color: "White");
                SlowRPG_Write(" was dealt directly to your HP.");
                health = health - (int)enemyDamage;
                SlowRPG_Write("You have ", sameLine: true);
                SlowRPG_Write($"{health}", sameLine: true, color: "White");
                SlowRPG_Write(" HP remaining.");
            }

            SlowRPG_Write("");

            StaticPlayer.player.defense = defense;
            StaticPlayer.player.health = health;
            StaticPlayer.player.shield = shield;
        }

        public static bool CheckIfWinner(int enemyHealth)
        {
            if (enemyHealth <= 0)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You won the battle!", color: "White");
                SlowRPG_Write("");
                return true;
            }
            if (StaticPlayer.player.health <= 0)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You lost the battle, and died!", color: "DarkRed");
                SlowRPG_Write("");
                StaticPlayer.player.alive = false;
                return true;
            }
            return false;
        }
        public static bool CheckIfWinnerFinalFight(int enemyHealth)
        {
            if (enemyHealth <= 0)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You won the battle!", color: "White");
                SlowRPG_Write("");
                return true;
            }
            if (StaticPlayer.player.health <= 0)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You lost the battle!", color: "DarkRed");
                SlowRPG_Write("");
                return true;
            }
            return false;
        }

        public static void InitRoom(int currentRoom)
        {
            //Really just a switch made into a method to make the code less cluttered
            //Based on current room get that room
            switch (currentRoom)
            {
                case 1:
                    Room1Methods.Room1();
                    break;
                case 2:
                    Room2Methods.Room2();
                    break;
                case 3:
                    Room3Methods.Room3();
                    break;
                case 4:
                    Room4Methods.Room4();
                    break;
                case 5:
                    Room5Methods.Room5();
                    break;
                case 6:
                    Room6Methods.Room6();
                    break;
                case 7:
                    Room7Methods.Room7();
                    break;
                case 8:
                    Room8Methods.Room8();
                    break;
                case 9:
                    Room9Methods.Room9();
                    break;
            }

    }
}