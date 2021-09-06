using System;
using System.Threading;

namespace project
{
    class Room6Methods : Program
    {
        public static void Room6_Dialog1()
        {
            SlowRPG_Write("You explore the new path and end up in a room lit with an eery red light.");
            SlowRPG_Write("");
            SlowRPG_Write("Looking around you realise that the light is coming from a chained up branch.");
            SlowRPG_Write("With your mighty IQ of 73 you decide to free it from the chains to further investigate it.");
            SlowRPG_Write("With the branch in your hand you are overwhealmed by a sickening senstation.");
            SlowRPG_Write("");
            SlowRPG_Write("Branch of the Sinner: Take 10 damage to gain 5 hp");
        }
        public static void Room6_Dialog2()
        {
            SlowRPG_Write("After leaving that cursed thing you find a note.");
            SlowRPG_Write("");
            SlowRPG_Write("It reads: ");
            SlowRPG_Write("'The ", sameLine: true);
            SlowRPG_Write("computer with the keyboard", sameLine: true, color: "White");
            SlowRPG_Write(" is out of order, sorry.' - ", sameLine: true);
            SlowRPG_Write("Lord of Bacon", color: "Yellow");
            SlowRPG_Write("Damnable Gods, can't even handel a computer.");
            SlowRPG_Write("You throw the note onto thee ground and notice something on its backside.");
            SlowRPG_Write("In fine print is says: ");
            SlowRPG_Write("'To compensate you, I grant you the: ", sameLine: true);
            SlowRPG_Write("Minor blessing of Bacon: +10 attack and health", sameLine: true, color: "White");
            SlowRPG_Write("as reimbursement.'");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("Maybe the gods ain't that bad.");
        }

        public static void Room6()
        {
            if (!StaticRoom.room6.clear1)
            {
                //Usual dialog with skip
                Room6_Dialog1();
                StaticRoom.room6.clear1 = true;
            }

            if (!StaticRoom.room6.clear2)
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
                StaticRoom.room6.clear2 = true;
            }

            if (!StaticRoom.room6.clear3)
            {
                //Un-skippable dialog due to change in status
                Room6_Dialog2();
                StaticPlayer.player.health += 10;
                StaticPlayer.player.attack += 10;

                SlowRPG_Write("You search through the rest of the room and find nothing of interest.");
                StaticRoom.room6.clear3 = true;
            }

            if (StaticRoom.room6.specialInteraction)
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
                    StaticRoom.room6.specialInteraction = true;
                    GameLogic.currentRoom = 5;
                    return;
            }
        }
    }
}