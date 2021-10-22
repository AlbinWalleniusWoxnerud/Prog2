using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3
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
    }
}