using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_5 : RoomFlags
    {
        public Room_5(Player player, RoomFlags room, CurrentRun currentRun)
        {
            this.player = player;
            this.room = room;
            this.currentRun = currentRun;
            this.Room();
        }
        public void Room()
        {
            if (!room.clear1)
            {
                //Usual dialog with skip
                Room5_Dialog1();
                room.clear1 = true;
            }

            if (!room.clear2)
            {
                if (StaticPlayer.player.hasMeat)
                {
                    SlowRPG_Write("You notice that it seems to have been attracted by the Hobgoblin meat which you didn't eat.");
                    SlowRPG_Write("On a whim you throw the meat to the Wolf which takes it and wanders off.");
                    SlowRPG_Write("");
                    SlowRPG_Write("Combat avoided!", color: "White");
                    SlowRPG_Write("");
                    SlowRPG_Write("Since the wolf wasn't a problem you decide to examine the rest of the room.");
                }
                else
                {
                    SlowRPG_Write("You notice that it seems to have been attracted by the remnants of the Hobgoblin meat which you ate.");
                    int room5_playerChoice1 = Menu(header: "Do you: ", alternatives: "Fight it.. Retreat to room 4, chest room.".Split(". "));

                    //If player choose to return
                    if (room5_playerChoice1 == 2)
                    {
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to retreat to room 4, chest room.");
                        GameLogic.currentRoom = 4;
                        room.specialInteraction = true;
                        return;
                    }

                    //If battle returns true player won, if it returns false player lost and it is game over
                    if (!Battle4Method.Battle4())
                    {
                        return;
                    }

                    SlowRPG_Write("After deafeating the wolf you decide to examine the rest of the room.");

                }

                if (!StaticPlayer.player.hasTrueKey)
                {
                    SlowRPG_Write("After a bit of searching you find a better suit of armour which you equip.");
                    SlowRPG_Write("");
                    SlowRPG_Write("Equipped new Armour: Take 20% less damage", color: "White");
                    StaticPlayer.player.defense = 0.7;
                    SlowRPG_Write("");
                }
                SlowRPG_Write("Getting tired of all of these paths you still find a new path to take.");
                room.clear2 = true;
            }

            if (room.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the room marked: ", sameLine: true);
                SlowRPG_Write("Room 5", sameLine: true, color: "White");
                SlowRPG_Write(", the wolf room");
            }
            int room5_playerChoice2 = Menu(header: "Do you: ", alternatives: "Go to the new path.. Return to room 4, the chest room.".Split(". "));

            switch (room5_playerChoice2)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to go to the new path.");
                    room.specialInteraction = true;
                    GameLogic.currentRoom = 6;
                    return;
                case 2:
                    SlowRPG_Write("You choose to return to room 4, the chest room..");
                    GameLogic.currentRoom = 4;
                    room.specialInteraction = true;
                    return;
            }
        }
    }
}