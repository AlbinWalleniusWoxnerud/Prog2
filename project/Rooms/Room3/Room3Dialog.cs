using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_3 : RoomBase
    {
        public void Dialog1()
        {
            TextRender.Render("You explore the path to the left and end up in another dark room with another marking.");
            TextRender.Render("");
            TextRender.Render("Room 3", color: Color.White);
            TextRender.Render("");
            TextRender.Render("You hear the same noises as before but this time with a metallic clink coming from a corner and decide to check it out.");
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("It is yet another ", sameLine: true);
            TextRender.Render("Goblin", sameLine: true, color: Color.Green);
            TextRender.Render(" but this time it has a and a ", sameLine: true);
            TextRender.Render("metallic armour", sameLine: true, color: Color.White);
            TextRender.Render(", a ", sameLine: true);
            TextRender.Render("broadsword", sameLine: true, color: Color.White);
            TextRender.Render(" and what looks like a ", sameLine: true);
            TextRender.Render("Steel Shield", sameLine: true, color: Color.White);
            TextRender.Render(".");
            TextRender.Render("");
        }
        public void Dialog2()
        {
            TextRender.Render("After killing the ", sameLine: true);
            TextRender.Render("Goblin", sameLine: true, color: Color.Green);
            TextRender.Render(" you notice that it's Sword seems to be better than yours, so you take it.");
            TextRender.Render("");
            TextRender.Render("Equipped new Sword: +10 attack", color: Color.White);
            player.attack += 10;
            TextRender.Render("");
            TextRender.Render("You explore the rest of the room and find a ring in addition to yet another ", sameLine: true);
            TextRender.Render("path", sameLine: true, color: Color.White);
            TextRender.Render(".");
            TextRender.Render("You decide to equip the ring.");
            TextRender.Render("");
            TextRender.Render("Equipped Ring of Crit: +20% crit chance", color: Color.White);
            player.crit += 20;
        }
    }
}