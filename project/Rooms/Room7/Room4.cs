using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
        public static void Room4()
        {
            if (StaticRoom.room4.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the room marked: ", sameLine: true);
                SlowRPG_Write("Room 4", color: "White");
                SlowRPG_Write("");
            }

            if (!StaticRoom.room4.clear1)
            {
                //Usual dialog with skip
                Room4_Dialog1();
                StaticRoom.room4.clear1 = true;
            }

            if (!StaticRoom.room4.clear2)
            {
                if (!StaticPlayer.player.hasChestKey)
                {
                    SlowRPG_Write("");
                    int room4_playerChoice1 = Menu(header: "Do you: ", alternatives: "Go to the new path.. Return to room 3, the second goblin room.".Split(". "));

                    switch (room4_playerChoice1)
                    {
                        case 1:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to go to the new path.");
                            StaticRoom.room4.specialInteraction = true;
                            GameLogic.currentRoom = 5;
                            return;
                        case 2:
                            SlowRPG_Write("You choose to return to room 3, the second goblin room..");
                            GameLogic.currentRoom = 3;
                            StaticRoom.room4.specialInteraction = true;
                            return;
                    }
                }

                if (StaticPlayer.player.hasChestKey && StaticPlayer.player.brokenChestKey && !StaticPlayer.player.hasBossKey)
                {
                    SlowRPG_Write("");
                    int room4_playerChoice2 = Menu(header: "Do you: ", alternatives: "Go to the new path.. Try to use the broken key to open the Chest.. Return to room 3, the second goblin room.".Split(". "));

                    switch (room4_playerChoice2)
                    {
                        case 1:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to go to the new path.");
                            StaticRoom.room4.specialInteraction = true;
                            GameLogic.currentRoom = 5;
                            return;
                        case 2:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to try and use the broken key to open the ", sameLine: true);
                            SlowRPG_Write($"Chest", sameLine: true, color: "White");
                            SlowRPG_Write(".");
                            SlowRPG_Write("Against all odds the broken key actually managed to open the chest ever so slightly.");
                            SlowRPG_Write("Just as it is about to open the key completely brakes and the lid of the chest threats to slam shut for eternity.");
                            SlowRPG_Write("You slam your hand under the lid just in time to keep it open.");
                            SlowRPG_Write("Unfortunately at the cost of your hand.");
                            SlowRPG_Write("-20 HP", color: "White");
                            StaticPlayer.player.health -= 20;
                            if (IsGameOver()) return;
                            SlowRPG_Write("You have ", sameLine: true);
                            SlowRPG_Write($"{StaticPlayer.player.health}", sameLine: true, color: "White");
                            SlowRPG_Write(" HP remaining.");
                            break;
                        case 3:
                            SlowRPG_Write("You choose to return to room 3, the second goblin room.");
                            GameLogic.currentRoom = 3;
                            StaticRoom.room4.specialInteraction = true;
                            return;
                    }
                }

                if (StaticPlayer.player.hasChestKey && !StaticPlayer.player.brokenChestKey && !StaticPlayer.player.hasBossKey)
                {
                    SlowRPG_Write("");
                    int room4_playerChoice3 = Menu(header: "Do you: ", alternatives: "Go to the new path.. Try to use the key from the shrine to open the Chest.. Return to room 3, the second goblin room.".Split(". "));

                    switch (room4_playerChoice3)
                    {
                        case 1:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to go to the new path.");
                            StaticRoom.room4.specialInteraction = true;
                            GameLogic.currentRoom = 5;
                            return;
                        case 2:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to try and use the key from the shrine to open the ", sameLine: true);
                            SlowRPG_Write($"big Chest", sameLine: true, color: "White");
                            SlowRPG_Write(".");
                            SlowRPG_Write("The key instantly opens the chest.");
                            break;
                        case 3:
                            SlowRPG_Write("You choose to return to room 3, the second goblin room.");
                            GameLogic.currentRoom = 3;
                            StaticRoom.room4.specialInteraction = true;
                            return;
                    }
                }

                //Un-skippable due to major event
                Room4_Dialog2();

                StaticPlayer.player.hasBossKey = true;

                int room4_playerChoice4 = Menu(header: "Do you: ", alternatives: "Drink the unknown potion.. Don't drink the potentially poisonous potion and try to use the boss key..".Split(". "));

                switch (room4_playerChoice4)
                {
                    case 1:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to drink the unknown potion.");
                        SlowRPG_Write("It weakens your strength.");
                        SlowRPG_Write("-20% attack", color: "White");

                        //Temporary var for player attack
                        double tempAttack;

                        //Cast int player.attack to double
                        tempAttack = (double)StaticPlayer.player.attack * 0.8;

                        //Down cast double tempAttack to int
                        StaticPlayer.player.attack = (int)tempAttack;

                        SlowRPG_Write("Still have to try to use the boss key.");
                        break;
                    case 2:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose not to drink the unknown potion and to try to use the boss key.");
                        break;
                }
                StaticRoom.room4.clear2 = true;
            }

            if (!StaticRoom.room4.clear3)
            {
                if (StaticPlayer.player.hasBossKey)
                {
                    int room4_playerChoice5 = Menu(header: "Do you: ", alternatives: "Use the BOSS key on the door with the letters 'BOSS'.. Go to the new path.. Return to room 3, second goblin room.".Split(". "));

                    switch (room4_playerChoice5)
                    {
                        case 1:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to use the BOSS key on the door with the letters 'BOSS'.");
                            SlowRPG_Write("The door unlocks with a click.");
                            break;
                        case 2:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to go to the new path.");
                            StaticRoom.room4.specialInteraction = true;
                            GameLogic.currentRoom = 5;
                            return;
                        case 3:
                            SlowRPG_Write("You choose to return to room 3, the second goblin room..");
                            GameLogic.currentRoom = 3;
                            StaticRoom.room4.specialInteraction = true;
                            return;
                    }
                }
                StaticRoom.room4.clear3 = true;
            }


            int room4_playerChoice6 = Menu(header: "What do you do: ", alternatives: "Enter the boss room.. Go to the new path.. Return to room 3, second goblin room.".Split(". "));

            switch (room4_playerChoice6)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to enter the boss room.");
                    StaticRoom.room4.specialInteraction = true;
                    GameLogic.currentRoom = 9;
                    return;
                case 2:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to go to the new path.");
                    StaticRoom.room4.specialInteraction = true;
                    GameLogic.currentRoom = 5;
                    return;
                case 3:
                    SlowRPG_Write("You choose to return to room 3, the second goblin room..");
                    GameLogic.currentRoom = 3;
                    StaticRoom.room4.specialInteraction = true;
                    return;
            }

        }
    }