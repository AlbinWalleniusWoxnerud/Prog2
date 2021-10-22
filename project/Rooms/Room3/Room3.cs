using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
        public static void Room3()
        {
            if (!StaticRoom.room3.clear1)
            {
                //Usual dialog with skip
                Room3_Dialog1();

                int room3_playerChoice1 = Menu(header: "Do you: ", alternatives: "Fight it.. Retreat to room 2, 1st goblin room.".Split(". "));

                //If player choose so return to starting room
                if (room3_playerChoice1 == 2)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to retreat.");
                    GameLogic.currentRoom = 2;
                    return;
                }

                //If battle returns true player won, if it returns false player lost and it is game over
                if (!Battle3Method.Battle3())
                {
                    return;
                }

                //Un-skippable dialog due to change in player status
                Room3_Dialog2();

                StaticRoom.room3.clear1 = true;
            }

            if (StaticRoom.room3.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the room marked: ", sameLine: true);
                SlowRPG_Write("Room 3", sameLine: true, color: "White");
                SlowRPG_Write(", the second goblin room");
            }
            int room3_playerChoice2 = Menu(header: "Do you: ", alternatives: "Go to the new path.. Return to room 2, the first goblin room.".Split(". "));

            switch (room3_playerChoice2)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to go to the new path.");
                    StaticRoom.room3.specialInteraction = true;
                    GameLogic.currentRoom = 4;
                    return;
                case 2:
                    SlowRPG_Write("You choose to return to room 2, the first goblin room..");
                    GameLogic.currentRoom = 2;
                    StaticRoom.room3.specialInteraction = true;
                    return;
            }
        }

    }
}