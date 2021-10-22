using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4
    {
        public static void Room5_Dialog1()
        {
            SlowRPG_Write("You explore the new path and end up in another dark room with another marking.");
            SlowRPG_Write("");
            SlowRPG_Write("Room 5", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Before you have time to look around you're attacked by a giant ", sameLine: true);
            SlowRPG_Write("Wolf", sameLine: true, color: "DarkGray");
            SlowRPG_Write(".");
        }
    }
}