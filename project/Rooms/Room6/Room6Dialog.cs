using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_6 : RoomBase
    {
        public void Room6_Dialog1()
        {
            TextRender.Render("You explore the new path and end up in a room lit with an eery red light.");
            TextRender.Render("");
            TextRender.Render("Looking around you realise that the light is coming from a chained up branch.");
            TextRender.Render("With your mighty IQ of 73 you decide to free it from the chains to further investigate it.");
            TextRender.Render("With the branch in your hand you are overwhealmed by a sickening senstation.");
            TextRender.Render("");
            TextRender.Render("Branch of the Sinner: Take 10 damage to gain 5 hp");
        }
        public void Room6_Dialog2()
        {
            TextRender.Render("After leaving that cursed thing you find a note.");
            TextRender.Render("");
            TextRender.Render("It reads: ");
            TextRender.Render("'The ", sameLine: true);
            TextRender.Render("computer with the keyboard", sameLine: true, color: Color.White);
            TextRender.Render(" is out of order, sorry.' - ", sameLine: true);
            TextRender.Render("Lord of Bacon", color: Color.Yellow);
            TextRender.Render("Damnable Gods, can't even handel a computer.");
            TextRender.Render("You throw the note onto thee ground and notice something on its backside.");
            TextRender.Render("In fine print is says: ");
            TextRender.Render("'To compensate you, I grant you the: ", sameLine: true);
            TextRender.Render("Minor blessing of Bacon: +10 attack and health", sameLine: true, color: Color.White);
            TextRender.Render("as reimbursement.'");
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("...", delay: 200);
            TextRender.Render("Maybe the gods ain't that bad.");
        }

    }
}