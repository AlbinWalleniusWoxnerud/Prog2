using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
        public static void Room7()
        {
            if (!StaticRoom.room7.clear1)
            {
                //Usual dialog with skip
                Room7_Dialog1();

                int room7_playerChoice1 = Menu(header: "Do you: ", alternatives: "Fight it.. Retreat to room 2".Split(". "));

                //If player choose so return to starting room
                if (room7_playerChoice1 == 2)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to retreat.");
                    GameLogic.currentRoom = 2;
                    return;
                }

                //If battle returns true player won, if it returns false player lost and it is game over
                if (!Battle2Method.Battle2())
                {
                    return;
                }

                Room7_Dialog2();

                int room7_playerChoice2 = Menu(header: "Do you: ", alternatives: "Eat it.. Don't eat the meat you just took from a Hobgoblins body.".Split(". "));

                switch (room7_playerChoice2)
                {
                    case 1:
                        SlowRPG_Write("");
                        SlowRPG_Write("...", delay: 1000);
                        SlowRPG_Write("You choose to eat the meat of the ", sameLine: true);
                        SlowRPG_Write("Hobgoblin", sameLine: true, color: "DarkGreen");
                        SlowRPG_Write("...");
                        StaticPlayer.player.health += 25;
                        StaticPlayer.player.maxhealth += 25;
                        SlowRPG_Write("");
                        SlowRPG_Write("You gain ", sameLine: true);
                        SlowRPG_Write("+25 max HP", sameLine: true, color: "White");
                        SlowRPG_Write(" giving you ", sameLine: true);
                        SlowRPG_Write($"{StaticPlayer.player.health}", sameLine: true, color: "White");
                        SlowRPG_Write(" current HP.");
                        break;
                    case 2:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to not eat the meat of the ", sameLine: true);
                        SlowRPG_Write("Hobgoblin", sameLine: true, color: "DarkGreen");
                        SlowRPG_Write(" like a sane person would.");
                        StaticPlayer.player.hasMeat = true;
                        break;
                }

                Room7_Dialog3();

                StaticRoom.room7.clear1 = true;
            }


            if (StaticRoom.room7.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the room marked: ", sameLine: true);
                SlowRPG_Write("Room 7", color: "White");
            }
            int room7_playerChoice3 = Menu(header: "What do you do? ", alternatives: "Go to the even deeper path.. Return to room 2.".Split(". "));

            switch (room7_playerChoice3)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to go to the even deeper path.");
                    StaticRoom.room7.specialInteraction = true;
                    GameLogic.currentRoom = 8;
                    return;
                case 2:
                    SlowRPG_Write("You choose to return to room 2.");
                    GameLogic.currentRoom = 2;
                    StaticRoom.room7.specialInteraction = true;
                    return;
            }
        }
    }
}