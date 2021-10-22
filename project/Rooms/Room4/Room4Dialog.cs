using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4 : RoomBase
    {
        public static void Dialog1()
        {
            TextRender.Render("You explore the new path and end up in another dark room with another marking.");
            TextRender.Render("");
            TextRender.Render("Room 4", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Surprisingly it is completely silent.");
            TextRender.Render("With nothing to direct you, you blindly examine the room.");
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("After a little while you realise that there is nothing but a ", sameLine: true);
            TextRender.Render("big Chest", sameLine: true, color: Color.White);
            TextRender.Render(" and a ", sameLine: true);
            TextRender.Render("locked door", sameLine: true, color: Color.White);
            TextRender.Render(" with the letters ", sameLine: true);
            TextRender.Render("'BOSS'", sameLine: true, color: Color.White);
            TextRender.Render(" written on it in the room");
            TextRender.Render("");
            TextRender.Render("Nither of them budge when you try to use force, ", sameLine: true);
            TextRender.Render("keys", sameLine: true, color: Color.White);
            TextRender.Render(" might help.");
            TextRender.Render("You try to look for more ", sameLine: true);
            TextRender.Render("paths", sameLine: true, color: Color.White);
            TextRender.Render(" to go deeper into the maze.");
            TextRender.Render("Luck is on your side and you find yet another new path, yay...");
        }
        public static void Dialog2()
        {
            TextRender.Render("Inside the ", sameLine: true);
            TextRender.Render("chest", sameLine: true, color: Color.White);
            TextRender.Render(" lay another ", sameLine: true);
            TextRender.Render("key", sameLine: true, color: Color.White);
            TextRender.Render(" and a ", sameLine: true);
            TextRender.Render("potion", sameLine: true, color: Color.White);
            TextRender.Render(".");
            TextRender.Render("Picked up: ");
            TextRender.Render("Key: Boss Key ", color: Color.White);
            TextRender.Render("Potion: Unknown potion", color: Color.White);
        }
    }
}