using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
        public static void Room6()
        {
            if (!room.clear1)
            {
                //Usual dialog with skip
                Room6_Dialog1();
                room.clear1 = true;
            }

            if (!room.clear2)
            {
                bool useBranchOfTheSinner = true;
                while (useBranchOfTheSinner)
                {
                    int room6_playerChoice1 = Menu(header: "Do you: ", alternatives: "Use the branch.. Leave the cursed thing and examine the rest of the room.".Split(". "));

                    switch (room6_playerChoice1)
                    {
                        case 1:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to Use the branch...");
                            SlowRPG_Write("");
                            SlowRPG_Write("+5 attack", color: "White");
                            SlowRPG_Write("-10 health", color: "Red");
                            StaticPlayer.player.health -= 10;
                            StaticPlayer.player.attack += 5;

                            SlowRPG_Write("");
                            SlowRPG_Write("Status: ");
                            SlowRPG_Write($"{StaticPlayer.player.health}", sameLine: true, color: "White");
                            SlowRPG_Write(" current HP.");
                            SlowRPG_Write($"{StaticPlayer.player.attack}", sameLine: true, color: "White");
                            SlowRPG_Write(" current attack.");
                            break;
                        case 2:
                            SlowRPG_Write("");
                            SlowRPG_Write("You choose to leave the cursed thing and examine the rest of the room.");
                            useBranchOfTheSinner = false;
                            break;
                    }
                    if (IsGameOver()) return;
                }
                room.clear2 = true;
            }

            if (!room.clear3)
            {
                //Un-skippable dialog due to change in status
                Room6_Dialog2();
                StaticPlayer.player.health += 10;
                StaticPlayer.player.attack += 10;

                SlowRPG_Write("You search through the rest of the room and find nothing of interest.");
                room.clear3 = true;
            }

            if (room.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the ", sameLine: true);
                SlowRPG_Write("eery red", sameLine: true, color: "Red");
                SlowRPG_Write(" room.");
            }
            int room6_playerChoice2 = Menu(header: "Return ", alternatives: "Return to room 5, the wolf room.".Split(". "));

            switch (room6_playerChoice2)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You return to room 5, the wolf room");
                    room.specialInteraction = true;
                    GameLogic.currentRoom = 5;
                    return;
            }
        }
    }
}