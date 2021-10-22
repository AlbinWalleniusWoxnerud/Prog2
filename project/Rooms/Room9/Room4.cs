using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
    {
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