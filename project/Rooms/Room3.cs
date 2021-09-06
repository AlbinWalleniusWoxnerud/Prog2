using System;
using System.Threading;

namespace project
{
    class Room3Methods : Program
    {
        public static void Room3_Dialog1()
        {
            SlowRPG_Write("You explore the path to the left and end up in another dark room with another marking.");
            SlowRPG_Write("");
            SlowRPG_Write("Room 3", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("You hear the same noises as before but this time with a metallic clink coming from a corner and decide to check it out.");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("It is yet another ", sameLine: true);
            SlowRPG_Write("Goblin", sameLine: true, color: "Green");
            SlowRPG_Write(" but this time it has a and a ", sameLine: true);
            SlowRPG_Write("metallic armour", sameLine: true, color: "White");
            SlowRPG_Write(", a ", sameLine: true);
            SlowRPG_Write("broadsword", sameLine: true, color: "White");
            SlowRPG_Write(" and what looks like a ", sameLine: true);
            SlowRPG_Write("Steel Shield", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("");
        }
        public static void Room3_Dialog2()
        {
            SlowRPG_Write("After killing the ", sameLine: true);
            SlowRPG_Write("Goblin", sameLine: true, color: "Green");
            SlowRPG_Write(" you notice that it's Sword seems to be better than yours, so you take it.");
            SlowRPG_Write("");
            SlowRPG_Write("Equipped new Sword: +10 attack", color: "White");
            StaticPlayer.player.attack += 10;
            SlowRPG_Write("");
            SlowRPG_Write("You explore the rest of the room and find a ring in addition to yet another ", sameLine: true);
            SlowRPG_Write("path", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("You decide to equip the ring.");
            SlowRPG_Write("");
            SlowRPG_Write("Equipped Ring of Crit: +20% crit chance", color: "White");
            StaticPlayer.player.crit += 20;
        }
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