using System;
using System.Threading;

namespace project
{
    class Room2Methods : Program
    {
        public static void Room2_Dialog1()
        {
            SlowRPG_Write("You explore the path and end up in another dark room, this time with a marking.");
            SlowRPG_Write("");
            SlowRPG_Write("Room 2", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("You hear some noises coming from a corner and decide to check it out.");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("When the ", sameLine: true);
            SlowRPG_Write("light", sameLine: true, color: "Yellow");
            SlowRPG_Write(" of the torch reaches the noise you see an ugly little creature, a ", sameLine: true);
            SlowRPG_Write("Goblin", sameLine: true, color: "Green");
            SlowRPG_Write(".");
        }
        public static void Room2_Dialog2()
        {
            SlowRPG_Write("After killing the ", sameLine: true);
            SlowRPG_Write("Goblin", sameLine: true, color: "Green");
            SlowRPG_Write(" you explore the rest of the room and find: ", sameLine: true);
            SlowRPG_Write("2 paths", sameLine: true, color: "White");
            SlowRPG_Write(" and a ", sameLine: true);
            SlowRPG_Write("note", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("The note reads: 'Key very hidden is.'");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("(ﾉಥ益ಥ)ﾉ");
            SlowRPG_Write("You decide to check the paths out.");
        }

        //Room 2 with all of its interactions
        public static void Room2()
        {
            if (!StaticRoom.room2.clear1)
            {
                //Usual dialog with skip
                Room2_Dialog1();

                int room2_playerChoice1 = Menu(header: "Do you: ", alternatives: "Fight it.. Retreat to the starting room".Split(". "));

                //If player choose so return to starting room
                if (room2_playerChoice1 == 2)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to retreat.");
                    GameLogic.currentRoom = 1;
                    return;
                }

                //If battle returns true player won, if it returns false player lost and it is game over
                if (!Battle1Method.Battle1())
                {
                    return;
                }

                Room2_Dialog2();


                StaticRoom.room2.clear1 = true;
            }

            if (StaticRoom.room2.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the room marked: ", sameLine: true);
                SlowRPG_Write("Room 2", color: "White");
            }
            int room2_playerChoice2 = Menu(header: "Do you: ", alternatives: "Go to the path straight forward.. Go to the path to the left forward.. Return to the starting room.".Split(". "));

            switch (room2_playerChoice2)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose to go to the path straight forward.");
                    StaticRoom.room2.specialInteraction = true;
                    GameLogic.currentRoom = 7;
                    return;
                case 2:
                    SlowRPG_Write("You choose to go to the path to the left forward.");
                    GameLogic.currentRoom = 3;
                    StaticRoom.room2.specialInteraction = true;
                    return;
                case 3:
                    SlowRPG_Write("You choose to return to the starting room.");
                    GameLogic.currentRoom = 1;
                    StaticRoom.room2.specialInteraction = true;
                    return;
            }
        }
    }
}