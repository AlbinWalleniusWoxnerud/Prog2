using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3 : RoomBase
    {
        public Room_8(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
        {
        }
        public static void Room8()
        {
            if (!room.clear1)
            {
                //Usual dialog with skip
                Room8_Dialog1();

                int room8_playerChoice1 = TextRender.Table(header: "Do you: ", alternatives: "Praise it.. Don' praise it.".Split(". "));

                //If player choose so return to room 7
                if (room8_playerChoice1 == 2)
                {
                    TextRender.Render("");
                    TextRender.Render("You choose not to praise it.");
                    room.clear1 = true;
                }

                if (!room.clear1)
                {
                    //If missing HP is greater than 10 or equal to 10 simply add 10 onto current HP
                    if ((player.maxhealth - player.health) >= 10)
                    {
                        player.health = player.health + 10;
                    }

                    //If missing HP is less than 10 the player will heal all the missing health but nothing more, the 'else if' can be changed to simply else but the readability would be harmed
                    else if ((player.maxhealth - player.health) < 10)
                    {
                        player.health = player.health + (player.maxhealth - player.health);
                    }

                    //Un-skippable dialog due to change in player status
                    Room8_Dialog2();

                    //Player gets +10 attack
                    player.attack += 10;

                    //Un-skippable dialog due to change in player status, dialog happens after the increase in attack so it displays the right values 
                    Room8_Dialog3();

                    player.subjectOfLordBacon = true;
                    Room8_Dialog4();

                    room.clear1 = true;
                }
            }

            if (room.clear1 && !room.clear2)
            {
                int room8_playerChoice2 = TextRender.Table(header: "Do you: ", alternatives: "Examine the rest of the shrine.. Return to room 7, Hobgoblin room.".Split(". "));

                switch (room8_playerChoice2)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to examine the rest of the shrine and find a ", sameLine: true);
                        TextRender.Render("key", sameLine: true, color: Color.White);
                        TextRender.Render(".");
                        TextRender.Render("Engraved on the key is the marking of a chest...");

                        //Player found the chest key
                        player.hasChestKey = true;

                        TextRender.Render("This could be useful.");
                        TextRender.Render("You find nothing else.");
                        room.clear2 = true;
                        break;
                    case 2:
                        TextRender.Render("");
                        TextRender.Render("You choose to return to room 7, Hobgoblin room.");
                        currentRun.currentRoom = 7;
                        room.specialInteraction = true;
                        return;
                }
            }

            if (room.specialInteraction)
            {
                TextRender.Render("");
                TextRender.Render("You return to the ", sameLine: true);
                TextRender.Render("shrine", sameLine: true, color: Color.White);
                TextRender.Render(".");
            }

            if (room.clear2)
            {
                TextRender.Render("");
                TextRender.Render("There is nothing else in the shrine.");

                //No need to do anything special with the choice since there is only one alternative
                int room8_playerChoice3 = TextRender.Table(header: "Return to room 7, Hobgoblin room: ", alternatives: "Yes".Split(". "));

                currentRun.currentRoom = 7;
                room.specialInteraction = true;
                return;
            }
        }
    }
}