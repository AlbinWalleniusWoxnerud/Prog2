using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_5 : RoomBase
    {
        public static void Dialog1()
        {
            TextRender.Render("You explore the new path and end up in another dark room with another marking.");
            TextRender.Render("");
            TextRender.Render("Room 5", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Before you have time to look around you're attacked by a giant ", sameLine: true);
            TextRender.Render("Wolf", sameLine: true, color: Color.DarkGray);
            TextRender.Render(".");
        }
    }
}