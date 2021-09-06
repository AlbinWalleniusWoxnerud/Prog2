using System;
using System.Threading;

namespace project
{
    class Room8Methods : Program
    {
        public static void Room8_Dialog1()
        {
            SlowRPG_Write("You explore the deep path and come to massive gate");
            SlowRPG_Write("It says: ");
            SlowRPG_Write("'Shrine of Bacon'", sameLine: true, color: "DarkRed");
            SlowRPG_Write("");
            SlowRPG_Write("You try to push it open and surprisingly enough it actually opens, unleashing an overwhelming aroma of ", sameLine: true);
            SlowRPG_Write("Bacon", sameLine: true, color: "DarkRed");
            SlowRPG_Write(".");
            SlowRPG_Write("Unable to contain yourself your rush inside in a maddened state of hunger.");
            SlowRPG_Write("Well inside the ", sameLine: true);
            SlowRPG_Write("Shrine", sameLine: true, color: "White");
            SlowRPG_Write(" you find yourself face to face with a massive statue depicting a ", sameLine: true);
            SlowRPG_Write("Golden Pig", sameLine: true, color: "Yellow");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("Seeing the statue you manage to calm yourself enough the read the placards below the statue, wouldn't want to accidentally offend a ", sameLine: true);
            SlowRPG_Write("God", sameLine: true, color: "Cyan");
            SlowRPG_Write(" now would we.");
            SlowRPG_Write("The placard reads: 'Praise me mortal and this kind and handsome God might just bless you'");
            SlowRPG_Write("...");
            SlowRPG_Write("");
        }
        public static void Room8_Dialog2()
        {
            SlowRPG_Write("You choose to praise the statue.");
            SlowRPG_Write("");
            SlowRPG_Write("As you praise the statue a ");
            SlowRPG_Write("holy glow", sameLine: true, color: "White");
            SlowRPG_Write(" envelopes your body.");
            SlowRPG_Write("");
            SlowRPG_Write("Heal ", sameLine: true);
            SlowRPG_Write("10 HP", sameLine: true, color: "White");
        }
        public static void Room8_Dialog3()
        {
            SlowRPG_Write("");
            SlowRPG_Write("Gained Buff: ", sameLine: true);
            SlowRPG_Write("Subject of Lord Bacon", sameLine: true, color: "White");
            SlowRPG_Write(": ", sameLine: true);
            SlowRPG_Write("+10 attack", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Status: ");
            SlowRPG_Write($"{StaticPlayer.player.health}", sameLine: true, color: "White");
            SlowRPG_Write(" current HP.");
            SlowRPG_Write($"{StaticPlayer.player.attack}", sameLine: true, color: "White");
            SlowRPG_Write(" current attack.");
        }
        public static void Room8_Dialog4()
        {
            SlowRPG_Write("");
            SlowRPG_Write("After a while the ", sameLine: true);
            SlowRPG_Write("holy glow", sameLine: true, color: "White");
            SlowRPG_Write(" disappears.");
            SlowRPG_Write("You take a look at the statue and try to abuse the game by praising it again.");
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("Nothing happens, damnable cheapskate ", sameLine: true);
            SlowRPG_Write(" Gods", sameLine: true, color: "White");
            SlowRPG_Write(".", sameLine: true);
        }
        //Room 8 with all of its interactions
        public static void Room8()
        {
            if (!StaticRoom.room8.clear1)
            {
                //Usual dialog with skip
                Room8_Dialog1();

                int room8_playerChoice1 = Menu(header: "Do you: ", alternatives: "Praise it.. Don' praise it.".Split(". "));

                //If player choose so return to room 7
                if (room8_playerChoice1 == 2)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You choose not to praise it.");
                    StaticRoom.room8.clear1 = true;
                }

                if (!StaticRoom.room8.clear1)
                {
                    //If missing HP is greater than 10 or equal to 10 simply add 10 onto current HP
                    if ((StaticPlayer.player.maxhealth - StaticPlayer.player.health) >= 10)
                    {
                        StaticPlayer.player.health = StaticPlayer.player.health + 10;
                    }

                    //If missing HP is less than 10 the player will heal all the missing health but nothing more, the 'else if' can be changed to simply else but the readability would be harmed
                    else if ((StaticPlayer.player.maxhealth - StaticPlayer.player.health) < 10)
                    {
                        StaticPlayer.player.health = StaticPlayer.player.health + (StaticPlayer.player.maxhealth - StaticPlayer.player.health);
                    }

                    //Un-skippable dialog due to change in player status
                    Room8_Dialog2();

                    //Player gets +10 attack
                    StaticPlayer.player.attack += 10;

                    //Un-skippable dialog due to change in player status, dialog happens after the increase in attack so it displays the right values 
                    Room8_Dialog3();

                    StaticPlayer.player.subjectOfLordBacon = true;
                    Room8_Dialog4();

                    StaticRoom.room8.clear1 = true;
                }
            }

            if (StaticRoom.room8.clear1 && !StaticRoom.room8.clear2)
            {
                int room8_playerChoice2 = Menu(header: "Do you: ", alternatives: "Examine the rest of the shrine.. Return to room 7, Hobgoblin room.".Split(". "));

                switch (room8_playerChoice2)
                {
                    case 1:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to examine the rest of the shrine and find a ", sameLine: true);
                        SlowRPG_Write("key", sameLine: true, color: "White");
                        SlowRPG_Write(".");
                        SlowRPG_Write("Engraved on the key is the marking of a chest...");

                        //Player found the chest key
                        StaticPlayer.player.hasChestKey = true;

                        SlowRPG_Write("This could be useful.");
                        SlowRPG_Write("You find nothing else.");
                        StaticRoom.room8.clear2 = true;
                        break;
                    case 2:
                        SlowRPG_Write("");
                        SlowRPG_Write("You choose to return to room 7, Hobgoblin room.");
                        GameLogic.currentRoom = 7;
                        StaticRoom.room8.specialInteraction = true;
                        return;
                }
            }

            if (StaticRoom.room8.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the ", sameLine: true);
                SlowRPG_Write("shrine", sameLine: true, color: "White");
                SlowRPG_Write(".");
            }

            if (StaticRoom.room8.clear2)
            {
                SlowRPG_Write("");
                SlowRPG_Write("There is nothing else in the shrine.");

                //No need to do anything special with the choice since there is only one alternative
                int room8_playerChoice3 = Menu(header: "Return to room 7, Hobgoblin room: ", alternatives: "Yes".Split(". "));

                GameLogic.currentRoom = 7;
                StaticRoom.room8.specialInteraction = true;
                return;
            }
        }
    }
}