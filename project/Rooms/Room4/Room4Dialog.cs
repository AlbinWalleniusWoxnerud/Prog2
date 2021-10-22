using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4
    {
        public static void Room4_Dialog1()
        {
            SlowRPG_Write("You explore the new path and end up in another dark room with another marking.");
            SlowRPG_Write("");
            SlowRPG_Write("Room 4", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Surprisingly it is completely silent.");
            SlowRPG_Write("With nothing to direct you, you blindly examine the room.");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("After a little while you realise that there is nothing but a ", sameLine: true);
            SlowRPG_Write("big Chest", sameLine: true, color: "White");
            SlowRPG_Write(" and a ", sameLine: true);
            SlowRPG_Write("locked door", sameLine: true, color: "White");
            SlowRPG_Write(" with the letters ", sameLine: true);
            SlowRPG_Write("'BOSS'", sameLine: true, color: "White");
            SlowRPG_Write(" written on it in the room");
            SlowRPG_Write("");
            SlowRPG_Write("Nither of them budge when you try to use force, ", sameLine: true);
            SlowRPG_Write("keys", sameLine: true, color: "White");
            SlowRPG_Write(" might help.");
            SlowRPG_Write("You try to look for more ", sameLine: true);
            SlowRPG_Write("paths", sameLine: true, color: "White");
            SlowRPG_Write(" to go deeper into the maze.");
            SlowRPG_Write("Luck is on your side and you find yet another new path, yay...");
        }
        public static void Room4_Dialog2()
        {
            SlowRPG_Write("Inside the ", sameLine: true);
            SlowRPG_Write("chest", sameLine: true, color: "White");
            SlowRPG_Write(" lay another ", sameLine: true);
            SlowRPG_Write("key", sameLine: true, color: "White");
            SlowRPG_Write(" and a ", sameLine: true);
            SlowRPG_Write("potion", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("Picked up: ");
            SlowRPG_Write("Key: Boss Key ", color: "White");
            SlowRPG_Write("Potion: Unknown potion", color: "White");
        }
    }
}