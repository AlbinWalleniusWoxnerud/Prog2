using System;
using System.Threading;

namespace project
{
    class Room9Methods : Program
    {
        public static void Room9_Dialog1()
        {
            SlowRPG_Write("As you're entering the boss room, the door slams shut, preventing any escape.");
            SlowRPG_Write("Preparing yourself for the final battle you rush forward to face the ", sameLine: true);
            SlowRPG_Write("Overlord", sameLine: true, color: "White");
            SlowRPG_Write(" of the maze, the Dragonling ");
            SlowRPG_Write("Smedd the Terrible", sameLine: true, color: "Green");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("It doesn't take long before you reach the middle of the room where a massive throne of bones stand, upon which ", sameLine: true);
            SlowRPG_Write("Smedd", sameLine: true, color: "Green");
            SlowRPG_Write(" rests.");
            SlowRPG_Write("Weak mortal, YOU DARE FACE ME!");
        }
        public static void Room9_Dialog2()
        {
            SlowRPG_Write("Ahahahhahahahahaha, foolish insect.");
            SlowRPG_Write("To think you thought you could defeat me.");
            SlowRPG_Write("Weak!");
            SlowRPG_Write("Weak!");
            SlowRPG_Write("Weak!");
            SlowRPG_Write("Weaklings derserve to die, you should be thankful that you have the honnor of being killed by me, ", sameLine: true);
            SlowRPG_Write("Smedd the Terrible", sameLine: true, color: "Green");
            SlowRPG_Write(".");
        }
        public static void Room9_Dialog3()
        {
            SlowRPG_Write("As death approches you're suddenly enveloped by the smell of bacon.");
            SlowRPG_Write("As a ", sameLine: true);
            SlowRPG_Write("Subject of Lord Bacon", sameLine: true, color: "White");
            SlowRPG_Write(" you are under his divine protection.", sameLine: true);
            SlowRPG_Write("");
            SlowRPG_Write("The heavens split open to reveal a gargatuam ", sameLine: true);
            SlowRPG_Write("Golden Pig", sameLine: true, color: "Yellow");
            SlowRPG_Write(": To dare attack my subject, you are quite presumptuous ", sameLine: true);
            SlowRPG_Write("Smedd", sameLine: true, color: "Green");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("Take this: ", sameLine: true);
            SlowRPG_Write("Heavenly Divine Super Saiyan Mega Ultra Nine Fold Galaxy Beam of Soggy Bacon", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Oh no, my only weakness, ", sameLine: true);
            SlowRPG_Write("Soggy bacon.", color: "White");
            SlowRPG_Write("Noooooooooooooooooooooo");
            SlowRPG_Write("");
            SlowRPG_Write("Smedd the Terrible", sameLine: true, color: "Green");
            SlowRPG_Write(" vanquished.", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Before you can make sense of what happend the heavens revert back to normal leaving behind but the ashes of ", sameLine: true);
            SlowRPG_Write("Smedd", sameLine: true, color: "Green");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("Victory?", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Breaking free of your sense of vertigo you proceed to immediately plunder ", sameLine: true);
            SlowRPG_Write("Smedd's", sameLine: true, color: "Green");
            SlowRPG_Write(" ashes as well as the rest of the boss room.");
            if (StaticPlayer.player.chooseShield)
            {
                SlowRPG_Write("You find: a", sameLine: true);
                SlowRPG_Write($" key", sameLine: true, color: "White");
                SlowRPG_Write(", a ", sameLine: true);
                SlowRPG_Write($"Sword", sameLine: true, color: "White");
                SlowRPG_Write(", an ", sameLine: true);
                SlowRPG_Write($"Armour", sameLine: true, color: "White");
                SlowRPG_Write(", a ", sameLine: true);
                SlowRPG_Write($"Ring", sameLine: true, color: "White");
                SlowRPG_Write(" and a ", sameLine: true);
                SlowRPG_Write($" Shield", sameLine: true, color: "White");
                SlowRPG_Write(".");
                SlowRPG_Write("");
                SlowRPG_Write("Equipped Dragonslayer Armour: Take 2000% less damage", color: "White");
                SlowRPG_Write("Equipped Dragonslayer Shield: Can block 2.000.000 damage", color: "White");
                SlowRPG_Write("Equipped Dragonslayer Sword: Increase attack by 2.000.000", color: "White");
                SlowRPG_Write("Equipped Dragonslayer Ring: Increase crit chance to 100%", color: "White");
            }
            else
            {
                SlowRPG_Write("You find: a", sameLine: true);
                SlowRPG_Write($" key", sameLine: true, color: "White");
                SlowRPG_Write(", 2 ", sameLine: true);
                SlowRPG_Write($"Swords", sameLine: true, color: "White");
                SlowRPG_Write(", an ", sameLine: true);
                SlowRPG_Write($"Armour", sameLine: true, color: "White");
                SlowRPG_Write(", and a ", sameLine: true);
                SlowRPG_Write($"Ring", sameLine: true, color: "White");
                SlowRPG_Write(".");
                SlowRPG_Write("");
                SlowRPG_Write("Equipped Dragonslayer Armour: Take 2000% less damage", color: "White");
                SlowRPG_Write("Equipped Dragonslayer 2 Sword: Increase attack by 4.000.000", color: "White");
                SlowRPG_Write("Equipped Dragonslayer Ring: Increase crit chance to 100%", color: "White");
            }
        }
        public static void Room9()
        {
            if (!StaticRoom.room9.clear1)
            {
                //Usual dialog with skip
                Room9_Dialog1();

                int room9_playerChoice1 = Menu(header: "Do you: ", alternatives: "Fight".Split(". "));

                //This battle will always be lost so don't return
                Battle5Method.Battle5();

                Room9_Dialog2();

                if (!StaticPlayer.player.subjectOfLordBacon)
                {
                    SlowRPG_Write("");
                    SlowRPG_Write("You died", color: "DarkRed");
                    StaticPlayer.player.alive = false;
                    SlowRPG_Write("");
                    return;
                }

                //Un-skippable dialog due important story event
                Room9_Dialog3();

                StaticPlayer.player.hasTrueKey = true;
                if (StaticPlayer.player.chooseShield)
                {
                    StaticPlayer.player.defense = 0.0005;
                    StaticPlayer.player.shield = 2000000;
                    StaticPlayer.player.attack = 2000000;
                    StaticPlayer.player.crit = 100;
                }
                else
                {
                    StaticPlayer.player.defense = 0.0005;
                    StaticPlayer.player.attack = 4000000;
                    StaticPlayer.player.crit = 100;
                }
                StaticPlayer.player.health = StaticPlayer.player.maxhealth;
                SlowRPG_Write("Now to figure out what to do with the key.");
                StaticRoom.room9.clear1 = true;
            }


            if (StaticRoom.room9.specialInteraction)
            {
                SlowRPG_Write("");
                SlowRPG_Write("You return to the ", sameLine: true);
                SlowRPG_Write("Boss Room", color: "White");
            }
            int room9_playerChoice3 = Menu(header: "What do you do? ", alternatives: "Return to room 4, the chest room.".Split(". "));

            switch (room9_playerChoice3)
            {
                case 1:
                    SlowRPG_Write("");
                    SlowRPG_Write("You return to room 4, the chest room.");
                    StaticRoom.room7.specialInteraction = true;
                    GameLogic.currentRoom = 4;
                    return;
            }
        }
    }
}