using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
        public static void Room8()
        {
            if (!room.clear1)
            {
                //Usual dialog with skip
                Room8_Dialog1();

                int room8_playerChoice1 = Menu(header: "Do you: ", alternatives: "Praise it.. Don' praise it.".Split(". "));

                //If player choose so return to room 7
                if (room8_playerChoice1 == 2)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose not to praise it.");
                    room.clear1 = true;
                }

                if (!room.clear1)
                {
                    //If missing HP is greater than 10 or equal to 10 simply add 10 onto current HP
                    if ((StaticPlayer.player.maxhealth - StaticPlayer.player.health) >= 10)
                    {
                        StaticPlayer.player.health = StaticPlayer.player.health + 10;
                    }

                    //If missing HP is less than 10 the player will heal all the missing health but nothing more, the 'else if' can be changed to simply else but the readability would be harmed
                    else if ((StaticPlayer.player.maxhealth - StaticPlayer.player.health) < 10)
                    {
                        StaticPlayer.player.health = StaticPlayer.player.health + (StaticPlayer.player.maxhealth - StaticPlayer.player.health);
                    }

                    //Un-skippable dialog due to change in player status
                    Room8_Dialog2();

                    //Player gets +10 attack
                    StaticPlayer.player.attack += 10;

                    //Un-skippable dialog due to change in player status, dialog happens after the increase in attack so it displays the right values 
                    Room8_Dialog3();

                    StaticPlayer.player.subjectOfLordBacon = true;
                    Room8_Dialog4();

                    room.clear1 = true;
                }
            }

            if (room.clear1 && !room.clear2)
            {
                int room8_playerChoice2 = Menu(header: "Do you: ", alternatives: "Examine the rest of the shrine.. Return to room 7, Hobgoblin room.".Split(". "));

                switch (room8_playerChoice2)
                {
                    case 1:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to examine the rest of the shrine and find a ", sameLine: true);
                        SlowRPG_Write("key", sameLine: true, color: "White");
                        SlowRPG_Write(".");
                        SlowRPG_Write("Engraved on the key is the marking of a chest...");

                        //Player found the chest key
                        StaticPlayer.player.hasChestKey = true;

                        SlowRPG_Write("This could be useful.");
                        SlowRPG_Write("You find nothing else.");
                        room.clear2 = true;
                        break;
                    case 2:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to return to room 7, Hobgoblin room.");
                        GameLogic.currentRoom = 7;
                        room.specialInteraction = true;
                        return;
                }
            }

            if (room.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the ", sameLine: true);
                SlowRPG_Write("shrine", sameLine: true, color: "White");
                SlowRPG_Write(".");
            }

            if (room.clear2)
            {
                SlowRPG_Write("");
                SlowRPG_Write("There is nothing else in the shrine.");

                //No need to do anything special with the choice since there is only one alternative
                int room8_playerChoice3 = Menu(header: "Return to room 7, Hobgoblin room: ", alternatives: "Yes".Split(". "));

                GameLogic.currentRoom = 7;
                room.specialInteraction = true;
                return;
            }
        }
    }
}