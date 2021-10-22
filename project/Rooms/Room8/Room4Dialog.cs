using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4
    {
        public static void Room8_Dialog1()
        {
            SlowRPG_Write("You explore the deep path and come to massive gate");
            SlowRPG_Write("It says: ");
            SlowRPG_Write("'Shrine of Bacon'", sameLine: true, color: "DarkRed");
            SlowRPG_Write("");
            SlowRPG_Write("You try to push it open and surprisingly enough it actually opens, unleashing an overwhelming aroma of ", sameLine: true);
            SlowRPG_Write("Bacon", sameLine: true, color: "DarkRed");
            SlowRPG_Write(".");
            SlowRPG_Write("Unable to contain yourself your rush inside in a maddened state of hunger.");
            SlowRPG_Write("Well inside the ", sameLine: true);
            SlowRPG_Write("Shrine", sameLine: true, color: "White");
            SlowRPG_Write(" you find yourself face to face with a massive statue depicting a ", sameLine: true);
            SlowRPG_Write("Golden Pig", sameLine: true, color: "Yellow");
            SlowRPG_Write(".");
            SlowRPG_Write("");
            SlowRPG_Write("Seeing the statue you manage to calm yourself enough the read the placards below the statue, wouldn't want to accidentally offend a ", sameLine: true);
            SlowRPG_Write("God", sameLine: true, color: "Cyan");
            SlowRPG_Write(" now would we.");
            SlowRPG_Write("The placard reads: 'Praise me mortal and this kind and handsome God might just bless you'");
            SlowRPG_Write("...");
            SlowRPG_Write("");
        }
        public static void Room8_Dialog2()
        {
            SlowRPG_Write("You choose to praise the statue.");
            SlowRPG_Write("");
            SlowRPG_Write("As you praise the statue a ");
            SlowRPG_Write("holy glow", sameLine: true, color: "White");
            SlowRPG_Write(" envelopes your body.");
            SlowRPG_Write("");
            SlowRPG_Write("Heal ", sameLine: true);
            SlowRPG_Write("10 HP", sameLine: true, color: "White");
        }
        public static void Room8_Dialog3()
        {
            SlowRPG_Write("");
            SlowRPG_Write("Gained Buff: ", sameLine: true);
            SlowRPG_Write("Subject of Lord Bacon", sameLine: true, color: "White");
            SlowRPG_Write(": ", sameLine: true);
            SlowRPG_Write("+10 attack", color: "White");
            SlowRPG_Write("");
            SlowRPG_Write("Status: ");
            SlowRPG_Write($"{StaticPlayer.player.health}", sameLine: true, color: "White");
            SlowRPG_Write(" current HP.");
            SlowRPG_Write($"{StaticPlayer.player.attack}", sameLine: true, color: "White");
            SlowRPG_Write(" current attack.");
        }
        public static void Room8_Dialog4()
        {
            SlowRPG_Write("");
            SlowRPG_Write("After a while the ", sameLine: true);
            SlowRPG_Write("holy glow", sameLine: true, color: "White");
            SlowRPG_Write(" disappears.");
            SlowRPG_Write("You take a look at the statue and try to abuse the game by praising it again.");
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("...", delay: 1000);
            SlowRPG_Write("Nothing happens, damnable cheapskate ", sameLine: true);
            SlowRPG_Write(" Gods", sameLine: true, color: "White");
            SlowRPG_Write(".", sameLine: true);
        }
    }
}