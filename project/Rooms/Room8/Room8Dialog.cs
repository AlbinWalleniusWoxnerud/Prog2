using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4 : RoomBase
    {
        public static void Room8_Dialog1()
        {
            TextRender.Render("You explore the deep path and come to massive gate");
            TextRender.Render("It says: ");
            TextRender.Render("'Shrine of Bacon'", sameLine: true, color: Color.DarkRed);
            TextRender.Render("");
            TextRender.Render("You try to push it open and surprisingly enough it actually opens, unleashing an overwhelming aroma of ", sameLine: true);
            TextRender.Render("Bacon", sameLine: true, color: Color.DarkRed);
            TextRender.Render(".");
            TextRender.Render("Unable to contain yourself your rush inside in a maddened state of hunger.");
            TextRender.Render("Well inside the ", sameLine: true);
            TextRender.Render("Shrine", sameLine: true, color: Color.White);
            TextRender.Render(" you find yourself face to face with a massive statue depicting a ", sameLine: true);
            TextRender.Render("Golden Pig", sameLine: true, color: Color.Yellow);
            TextRender.Render(".");
            TextRender.Render("");
            TextRender.Render("Seeing the statue you manage to calm yourself enough the read the placards below the statue, wouldn't want to accidentally offend a ", sameLine: true);
            TextRender.Render("God", sameLine: true, color: Color.Cyan);
            TextRender.Render(" now would we.");
            TextRender.Render("The placard reads: 'Praise me mortal and this kind and handsome God might just bless you'");
            TextRender.Render("...");
            TextRender.Render("");
        }
        public static void Room8_Dialog2()
        {
            TextRender.Render("You choose to praise the statue.");
            TextRender.Render("");
            TextRender.Render("As you praise the statue a ");
            TextRender.Render("holy glow", sameLine: true, color: Color.White);
            TextRender.Render(" envelopes your body.");
            TextRender.Render("");
            TextRender.Render("Heal ", sameLine: true);
            TextRender.Render("10 HP", sameLine: true, color: Color.White);
        }
        public static void Room8_Dialog3()
        {
            TextRender.Render("");
            TextRender.Render("Gained Buff: ", sameLine: true);
            TextRender.Render("Subject of Lord Bacon", sameLine: true, color: Color.White);
            TextRender.Render(": ", sameLine: true);
            TextRender.Render("+10 attack", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Status: ");
            TextRender.Render($"{player.health}", sameLine: true, color: Color.White);
            TextRender.Render(" current HP.");
            TextRender.Render($"{player.attack}", sameLine: true, color: Color.White);
            TextRender.Render(" current attack.");
        }
        public static void Room8_Dialog4()
        {
            TextRender.Render("");
            TextRender.Render("After a while the ", sameLine: true);
            TextRender.Render("holy glow", sameLine: true, color: Color.White);
            TextRender.Render(" disappears.");
            TextRender.Render("You take a look at the statue and try to abuse the game by praising it again.");
            TextRender.Render("...", delay: 1000);
            TextRender.Render("...", delay: 1000);
            TextRender.Render("...", delay: 1000);
            TextRender.Render("Nothing happens, damnable cheapskate ", sameLine: true);
            TextRender.Render(" Gods", sameLine: true, color: Color.White);
            TextRender.Render(".", sameLine: true);
        }
    }
}