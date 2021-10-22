using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4
    {
        public static void Room7_Dialog1()
        {
            SlowRPG_Write("You explore the path and end up in another dark room with the marking: ", sameLine: true);
            SlowRPG_Write("Room 3", sameLine: true, color: "White");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("You once again hear some noises coming from a corner and decide to once again check it out.");
            SlowRPG_Write("Last time wasn't that bad...");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("The noise is of course coming from another foul creature, but a quite big one this time. A ", sameLine: true);
            SlowRPG_Write("Hobgoblin", sameLine: true, color: "DarkGreen");
            SlowRPG_Write(".");
        }
        public static void Room7_Dialog2()
        {
            SlowRPG_Write("After killing the ", sameLine: true);
            SlowRPG_Write("Hobgoblin", sameLine: true, color: "DarkGreen");
            SlowRPG_Write(" you desecrate its body and find piece of ", sameLine: true);
            SlowRPG_Write("meat", sameLine: true, color: "Red");
            SlowRPG_Write(" which looks supremely succulent.");
        }
        public static void Room7_Dialog3()
        {
            SlowRPG_Write("");
            SlowRPG_Write("You search around the rest of the room and find a ", sameLine: true);
            SlowRPG_Write("weird machine", sameLine: true, color: "White");
            SlowRPG_Write(" with a keyboard.");
            SlowRPG_Write("You try some random combinations but nothing happens, maybe you need a ", sameLine: true);
            SlowRPG_Write("special password", sameLine: true, color: "White");
            SlowRPG_Write(", but where would you find that.");
            SlowRPG_Write("");
            SlowRPG_Write("You also find a new, even deeper ", sameLine: true);
            SlowRPG_Write("path", sameLine: true, color: "White");
            SlowRPG_Write(".");
        }
    }
}