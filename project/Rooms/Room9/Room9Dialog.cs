using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_9 : RoomBase
    {
        public void Dialog1()
        {
            TextRender.Render("As you're entering the boss room, the door slams shut, preventing any escape.");
            TextRender.Render("Preparing yourself for the final battle you rush forward to face the ", sameLine: true);
            TextRender.Render("Overlord", sameLine: true, color: Color.White);
            TextRender.Render(" of the maze, the Dragonling ");
            TextRender.Render("Smedd the Terrible", sameLine: true, color: Color.Green);
            TextRender.Render(".");
            TextRender.Render("");
            TextRender.Render("It doesn't take long before you reach the middle of the room where a massive throne of bones stand, upon which ", sameLine: true);
            TextRender.Render("Smedd", sameLine: true, color: Color.Green);
            TextRender.Render(" rests.");
            TextRender.Render("Weak mortal, YOU DARE FACE ME!");
        }
        public void Dialog2()
        {
            TextRender.Render("Ahahahhahahahahaha, foolish insect.");
            TextRender.Render("To think you thought you could defeat me.");
            TextRender.Render("Weak!");
            TextRender.Render("Weak!");
            TextRender.Render("Weak!");
            TextRender.Render("Weaklings derserve to die, you should be thankful that you have the honnor of being killed by me, ", sameLine: true);
            TextRender.Render("Smedd the Terrible", sameLine: true, color: Color.Green);
            TextRender.Render(".");
        }
        public void Dialog3()
        {
            TextRender.Render("As death approches you're suddenly enveloped by the smell of bacon.");
            TextRender.Render("As a ", sameLine: true);
            TextRender.Render("Subject of Lord Bacon", sameLine: true, color: Color.White);
            TextRender.Render(" you are under his divine protection.", sameLine: true);
            TextRender.Render("");
            TextRender.Render("The heavens split open to reveal a gargatuam ", sameLine: true);
            TextRender.Render("Golden Pig", sameLine: true, color: Color.Yellow);
            TextRender.Render(": To dare attack my subject, you are quite presumptuous ", sameLine: true);
            TextRender.Render("Smedd", sameLine: true, color: Color.Green);
            TextRender.Render(".");
            TextRender.Render("");
            TextRender.Render("Take this: ", sameLine: true);
            TextRender.Render("Heavenly Divine Super Saiyan Mega Ultra Nine Fold Galaxy Beam of Soggy Bacon", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Oh no, my only weakness, ", sameLine: true);
            TextRender.Render("Soggy bacon.", color: Color.White);
            TextRender.Render("Noooooooooooooooooooooo");
            TextRender.Render("");
            TextRender.Render("Smedd the Terrible", sameLine: true, color: Color.Green);
            TextRender.Render(" vanquished.", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Before you can make sense of what happend the heavens revert back to normal leaving behind but the ashes of ", sameLine: true);
            TextRender.Render("Smedd", sameLine: true, color: Color.Green);
            TextRender.Render(".");
            TextRender.Render("");
            TextRender.Render("Victory?", color: Color.White);
            TextRender.Render("");
            TextRender.Render("Breaking free of your sense of vertigo you proceed to immediately plunder ", sameLine: true);
            TextRender.Render("Smedd's", sameLine: true, color: Color.Green);
            TextRender.Render(" ashes as well as the rest of the boss room.");
            if (player.chooseShield)
            {
                TextRender.Render("You find: a", sameLine: true);
                TextRender.Render($" key", sameLine: true, color: Color.White);
                TextRender.Render(", a ", sameLine: true);
                TextRender.Render($"Sword", sameLine: true, color: Color.White);
                TextRender.Render(", an ", sameLine: true);
                TextRender.Render($"Armour", sameLine: true, color: Color.White);
                TextRender.Render(", a ", sameLine: true);
                TextRender.Render($"Ring", sameLine: true, color: Color.White);
                TextRender.Render(" and a ", sameLine: true);
                TextRender.Render($" Shield", sameLine: true, color: Color.White);
                TextRender.Render(".");
                TextRender.Render("");
                TextRender.Render("Equipped Dragonslayer Armour: Take 2000% less damage", color: Color.White);
                TextRender.Render("Equipped Dragonslayer Shield: Can block 2.000.000 damage", color: Color.White);
                TextRender.Render("Equipped Dragonslayer Sword: Increase attack by 2.000.000", color: Color.White);
                TextRender.Render("Equipped Dragonslayer Ring: Increase crit chance to 100%", color: Color.White);
            }
            else
            {
                TextRender.Render("You find: a", sameLine: true);
                TextRender.Render($" key", sameLine: true, color: Color.White);
                TextRender.Render(", 2 ", sameLine: true);
                TextRender.Render($"Swords", sameLine: true, color: Color.White);
                TextRender.Render(", an ", sameLine: true);
                TextRender.Render($"Armour", sameLine: true, color: Color.White);
                TextRender.Render(", and a ", sameLine: true);
                TextRender.Render($"Ring", sameLine: true, color: Color.White);
                TextRender.Render(".");
                TextRender.Render("");
                TextRender.Render("Equipped Dragonslayer Armour: Take 2000% less damage", color: Color.White);
                TextRender.Render("Equipped Dragonslayer 2 Sword: Increase attack by 4.000.000", color: Color.White);
                TextRender.Render("Equipped Dragonslayer Ring: Increase crit chance to 100%", color: Color.White);
            }
        }
    }
}