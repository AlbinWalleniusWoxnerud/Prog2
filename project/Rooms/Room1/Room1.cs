using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_1
    {
        //Room 1 with all of its interactions
        internal static void Room(Player player, Room room)
        {
            //If the player didnt clear the whole room and left, display this message when they returned
            if (!room.clear2 && room.specialInteraction) TextRender.Render("You return to the dark starting room.");

            //If portion 1 of room 1 hasnt not been cleared
            if (!room.clear1)
            {
                Dialog1();

                //Menu
                int playerChoice1 = TextRender.Table(header: "What do you do?", alternatives: "Examine the corner of the room.. Explore the path.".Split(". "));

                if (playerChoice1 == 2)
                {
                    CurrentRun.currentRoom = 2;
                    room.specialInteraction = true;
                    return;
                }

                //If the player opted to skip dialog skip it
                Dialog2();

                int playerChoice2 = TextRender.Table(header: "Choose:", alternatives: "Keep a sword and the shield.. Keep both swords and discard the shield.".Split(". "));

                switch (playerChoice2)
                {
                    //Depending on player choice get different stats
                    case 1:
                        player.attack = 10;
                        player.shield = 125;
                        player.defense = 0.8;
                        player.crit = 10;
                        player.chooseShield = true;
                        TextRender.Render("");
                        TextRender.Render("You choose to keep a sword and the shield");
                        break;
                    case 2:
                        player.attack = 20;
                        player.defense = 0.9;
                        player.crit = 30;
                        TextRender.Render("");
                        TextRender.Render("You choose to keep both swords and discard the shield.");
                        break;
                }
                //Cleared section 1 of room 1 so flag that part as finished
                room.clear1 = true;
            }

            //If portion 2 of room 1 hasn't not been cleared
            if (!room.clear2)
            {
                TextRender.Render("");
                int playerChoice3 = TextRender.Table(header: "What do you do?", alternatives: "Examine the rest of the room.. Explore the path.".Split(". "));

                if (playerChoice3 == 2)
                {
                    //Change the current room to the one that the player is going to so that the initroom() method goes to that room
                    CurrentRun.currentRoom = 2;
                    room.specialInteraction = true;
                    return;
                }

                Dialog3();

                room.clear2 = true;
            }

            //If the player has the true key which one gets from defeating the Dragonling and if the player has cleared portion 2 of room 1
            if (player.hasTrueKey && room.clear2)
            {
                Dialog4();

                bool didNotUseKey = true;
                int nrLoopDidNotUseKey = 0;
                while (didNotUseKey)
                {
                    int playerChoice5 = TextRender.Table(header: "Do you:", alternatives: "Use the key on the door you found earlier.. Don't use the key on the door and search for alternative uses.".Split(". "));
                    if (playerChoice5 == 1)
                    {
                        //If the player opted to skip dialog skip it
                        Dialog5();
                        CurrentRun.conquered = true;
                        return;
                    }

                    TextRender.Render("You don't use the ", sameLine: true);
                    TextRender.Render("key", sameLine: true, color: Text.Color.White);
                    TextRender.Render(" and try to search for another use of it.");

                    int playerChoice6 = TextRender.Table(header: "Do you:", alternatives: "Search the room for other potential uses.. Leave the room and search the rest of the maze for uses.".Split(". "));
                    if (playerChoice6 == 2)
                    {
                        //The  player did not use the key but this is done in order to stop the while loop
                        didNotUseKey = false;
                        room.specialInteraction = true;
                        CurrentRun.currentRoom = 2;
                        return;
                    }

                    TextRender.Render("You search the room for other potential uses and find none.");

                    //If the player has looped around more than once increase stupidity, if stupidity is equal to 10 player dies, therefore return
                    if (nrLoopDidNotUseKey > 0) if (Stupidity(player)) return;

                    //Increase the counter for the amount of loops in the didNotUseKey while loop
                    nrLoopDidNotUseKey++;
                    continue;
                }
            }

            //If the player has the chest key which isnt broken and have cleared portion 2 of room 1
            if (player.hasChestKey && !player.brokenChestKey && room.clear2)
            {
                //If the player opted to skip dialog skip it
                Dialog6();

                bool didNotUseKey = true;
                int nrLoopDidNotUseKey = 0;
                while (didNotUseKey)
                {
                    int playerChoice7 = TextRender.Table(header: "Do you:", alternatives: "Use the key on the door you found earlier.. Don't use the key on the door and search for alternative uses.".Split(". "));

                    if (playerChoice7 == 1)
                    {
                        //If the player opted to skip dialog skip it
                        Dialog7();

                        int playerChoice8 = TextRender.Table(header: "Return to the rest of the maze to despair:", alternatives: "Yes".Split("."));

                        didNotUseKey = false;
                        CurrentRun.currentRoom = 2;
                        room.specialInteraction = true;
                        return;
                    }

                    TextRender.Render("You don't use the ", sameLine: true);
                    TextRender.Render("key", sameLine: true, color: Text.Color.White);
                    TextRender.Render(" and try to search for another use of it.");

                    int playerChoice6 = TextRender.Table(header: "Do you:", alternatives: "Search the room for other potential uses.. Leave the room and search the rest of the maze for uses.".Split(". "));
                    if (playerChoice6 == 2)
                    {
                        //The  player did not use the key but this is done in order to stop the while loop
                        didNotUseKey = false;
                        CurrentRun.currentRoom = 2;
                        room.specialInteraction = true;
                        return;
                    }

                    TextRender.Render("You search the room for other potential uses and find none.");

                    //If the player has looped around more than once increase stupidity, if stupidity is equal to 10 player dies, therefore return
                    if (nrLoopDidNotUseKey > 0) if (Stupidity(player)) return;

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
                if (room.clear1 && room.clear2 && room.specialInteraction)
                {
                    TextRender.Render("You return to the dark starting room.");
                }
                int playerChoice4 = TextRender.Table(header: "What do you do?", alternatives: "Examine the room again.. Explore the path.".Split(". "));

                if (playerChoice4 == 2)
                {
                    notLeaving = false;
                    CurrentRun.currentRoom = 2;
                    return;
                }

                TextRender.Render("You examine the room again and find nothing new.");
                if (nrLoopDidNotLeave > 0) if (Stupidity(player)) return;
                nrLoopDidNotLeave++;
            }
        }
    }
}