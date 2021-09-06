using System;
using System.Threading;

namespace project
{
    class Room1Methods : Program
    {
        //Simply dialog
        public static void Room1_Dialog1()
        {
            SlowRPG_Write("You can see something in the ", sameLine: true);
            SlowRPG_Write("corner", sameLine: true, color: "White");
            SlowRPG_Write(" of the room as well as what looks like a ", sameLine: true);
            SlowRPG_Write("path.", color: "White");
        }
        public static void Room1_Dialog2()
        {
            SlowRPG_Write("As you examine the ", sameLine: true);
            SlowRPG_Write("corner", sameLine: true, color: "White");
            SlowRPG_Write(" you find:", sameLine: true);
            SlowRPG_Write(" 2 Swords", sameLine: true, color: "White");
            SlowRPG_Write(", an ", sameLine: true);
            SlowRPG_Write("Armour", sameLine: true, color: "White");
            SlowRPG_Write(" and a ", sameLine: true);
            SlowRPG_Write("Shield", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("You equip the armour when you realise that you can't carry everything.");
        }
        public static void Room1_Dialog3()
        {
            SlowRPG_Write("You examine the rest of the room and find a hidden ", sameLine: true);
            SlowRPG_Write("door", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("You try to open it but it won't budge, is locked.");
            SlowRPG_Write("A ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" might help.");
        }
        public static void Room1_Dialog4()
        {
            SlowRPG_Write("You return to the dark starting room with the ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" you seized from ", sameLine: true);
            SlowRPG_Write("Smedd", sameLine: true, color: "Green");
            SlowRPG_Write(".");
        }
        public static void Room1_Dialog5()
        {
            SlowRPG_Write("You use the ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" you got from ", sameLine: true);
            SlowRPG_Write("Smedd", sameLine: true, color: "Green");
            SlowRPG_Write(" to try and open the door.");
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);

            //If the player broke the chest key
            if (StaticPlayer.player.brokenChestKey)
            {
                SlowRPG_Write("Unlike last time the door actually opens, and you are greeted by a blinding ", sameLine: true);
            }

            else
            {
                SlowRPG_Write("The door opens, and you are greeted by a blinding ", sameLine: true);
            }

            SlowRPG_Write("white light", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("Quest complete!", color: "White");
            SlowRPG_Write("Conquered the Maze of", sameLine: true);
            SlowRPG_Write(" Smedd the Terrible", sameLine: true, color: "Green");
            SlowRPG_Write(".");
            SlowRPG_Write("");
        }

        public static void Room1_Dialog6()
        {
            SlowRPG_Write("");
            SlowRPG_Write("You return to the dark starting room but now armed with the ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" of the shrine.");
        }
        public static void Room1_Dialog7()
        {
            SlowRPG_Write("You use the ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" you got from the ", sameLine: true);
            SlowRPG_Write("shrine", sameLine: true, color: "White");
            SlowRPG_Write(" to try and open the door.");
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("The key broke...");
            StaticPlayer.player.brokenChestKey = true;
        }

        //Room 1 with all of its interactions
        public static void Room1()
        {
            //If the player didnt clear the whole room and left, display this message when they returned
            if (!StaticRoom.room1.clear2 && StaticRoom.room1.specialInteraction) SlowRPG_Write("You return to the dark starting room.");

            //If portion 1 of room 1 hasnt not been cleared
            if (!StaticRoom.room1.clear1)
            {
                Room1_Dialog1();

                //Menu
                int room1_playerChoice1 = Menu(header: "What do you do?", alternatives: "Examine the corner of the room.. Explore the path.".Split(". "));

                if (room1_playerChoice1 == 2)
                {
                    GameLogic.currentRoom = 2;
                    StaticRoom.room1.specialInteraction = true;
                    return;
                }

                //If the player opted to skip dialog skip it
                Room1_Dialog2();

                int room1_playerChoice2 = Menu(header: "Choose:", alternatives: "Keep a sword and the shield.. Keep both swords and discard the shield.".Split(". "));

                switch (room1_playerChoice2)
                {
                    //Depending on player choice get different stats
                    case 1:
                        StaticPlayer.player.attack = 10;
                        StaticPlayer.player.shield = 125;
                        StaticPlayer.player.defense = 0.8;
                        StaticPlayer.player.crit = 10;
                        StaticPlayer.player.chooseShield = true;
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to keep a sword and the shield");
                        break;
                    case 2:
                        StaticPlayer.player.attack = 20;
                        StaticPlayer.player.defense = 0.9;
                        StaticPlayer.player.crit = 30;
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to keep both swords and discard the shield.");
                        break;
                }
                //Cleared section 1 of room 1 so flag that part as finished
                StaticRoom.room1.clear1 = true;
            }

            //If portion 2 of room 1 hasn't not been cleared
            if (!StaticRoom.room1.clear2)
            {
                SlowRPG_Write("");
                int room1_playerChoice3 = Menu(header: "What do you do?", alternatives: "Examine the rest of the room.. Explore the path.".Split(". "));

                if (room1_playerChoice3 == 2)
                {
                    //Change the current room to the one that the player is going to so that the initroom() method goes to that room
                    GameLogic.currentRoom = 2;
                    StaticRoom.room1.specialInteraction = true;
                    return;
                }

                Room1_Dialog3();

                StaticRoom.room1.clear2 = true;
            }

            //If the player has the true key which one gets from defeating the Dragonling and if the player has cleared portion 2 of room 1
            if (StaticPlayer.player.hasTrueKey && StaticRoom.room1.clear2)
            {
                Room1_Dialog4();

                bool didNotUseKey = true;
                int nrLoopDidNotUseKey = 0;
                while (didNotUseKey)
                {
                    int room1_playerChoice5 = Menu(header: "Do you:", alternatives: "Use the key on the door you found earlier.. Don't use the key on the door and search for alternative uses.".Split(". "));
                    if (room1_playerChoice5 == 1)
                    {
                        //If the player opted to skip dialog skip it
                        Room1_Dialog5();
                        GameLogic.conquered = true;
                        return;
                    }

                    SlowRPG_Write("You don't use the ", sameLine: true);
                    SlowRPG_Write("key", sameLine: true, color: "White");
                    SlowRPG_Write(" and try to search for another use of it.");

                    int room1_playerChoice6 = Menu(header: "Do you:", alternatives: "Search the room for other potential uses.. Leave the room and search the rest of the maze for uses.".Split(". "));
                    if (room1_playerChoice6 == 2)
                    {
                        //The  player did not use the key but this is done in order to stop the while loop
                        didNotUseKey = false;
                        StaticRoom.room1.specialInteraction = true;
                        GameLogic.currentRoom = 2;
                        return;
                    }

                    SlowRPG_Write("You search the room for other potential uses and find none.");

                    //If the player has looped around more than once increase stupidity, if stupidity is equal to 10 player dies, therefore return
                    if (nrLoopDidNotUseKey > 0) if (Stupidity()) return;

                    //Increase the counter for the amount of loops in the didNotUseKey while loop
                    nrLoopDidNotUseKey++;
                    continue;
                }
            }

            //If the player has the chest key which isnt broken and have cleared portion 2 of room 1
            if (StaticPlayer.player.hasChestKey && !StaticPlayer.player.brokenChestKey && StaticRoom.room1.clear2)
            {
                //If the player opted to skip dialog skip it
                Room1_Dialog6();

                bool didNotUseKey = true;
                int nrLoopDidNotUseKey = 0;
                while (didNotUseKey)
                {
                    int room1_playerChoice7 = Menu(header: "Do you:", alternatives: "Use the key on the door you found earlier.. Don't use the key on the door and search for alternative uses.".Split(". "));

                    if (room1_playerChoice7 == 1)
                    {
                        //If the player opted to skip dialog skip it
                        Room1_Dialog7();

                        int room1_playerChoice8 = Menu(header: "Return to the rest of the maze to despair:", alternatives: "Yes".Split("."));

                        didNotUseKey = false;
                        GameLogic.currentRoom = 2;
                        StaticRoom.room1.specialInteraction = true;
                        return;
                    }

                    SlowRPG_Write("You don't use the ", sameLine: true);
                    SlowRPG_Write("key", sameLine: true, color: "White");
                    SlowRPG_Write(" and try to search for another use of it.");

                    int room1_playerChoice6 = Menu(header: "Do you:", alternatives: "Search the room for other potential uses.. Leave the room and search the rest of the maze for uses.".Split(". "));
                    if (room1_playerChoice6 == 2)
                    {
                        //The  player did not use the key but this is done in order to stop the while loop
                        didNotUseKey = false;
                        GameLogic.currentRoom = 2;
                        StaticRoom.room1.specialInteraction = true;
                        return;
                    }

                    SlowRPG_Write("You search the room for other potential uses and find none.");

                    //If the player has looped around more than once increase stupidity, if stupidity is equal to 10 player dies, therefore return
                    if (nrLoopDidNotUseKey > 0) if (Stupidity()) return;

                    //Increase the counter for the amount of loops in the didNotUseKey while loop
                    nrLoopDidNotUseKey++;
                    continue;
                }
            }

            //While loop that either forces the player to leave room 1 or to die of stupidity, stupidity inceases every loop after the first and the player dies after getting 10 stupidity
            bool notLeaving = true;
            int nrLoopDidNotLeave = 0;
            while (notLeaving)
            {
                if (StaticRoom.room1.clear1 && StaticRoom.room1.clear2 && StaticRoom.room1.specialInteraction)
                {
                    SlowRPG_Write("You return to the dark starting room.");
                }
                int room1_playerChoice4 = Menu(header: "What do you do?", alternatives: "Examine the room again.. Explore the path.".Split(". "));

                if (room1_playerChoice4 == 2)
                {
                    notLeaving = false;
                    GameLogic.currentRoom = 2;
                    return;
                }

                SlowRPG_Write("You examine the room again and find nothing new.");
                if (nrLoopDidNotLeave > 0) if (Stupidity()) return;
                nrLoopDidNotLeave++;
            }
        }
    }
}