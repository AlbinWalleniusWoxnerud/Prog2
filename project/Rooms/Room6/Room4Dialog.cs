using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;
namespace Rooms
{
    partial class Room_4
    {
        public static void Room6_Dialog1()
        {
            SlowRPG_Write("You explore the new path and end up in a room lit with an eery red light.");
            SlowRPG_Write("");
            SlowRPG_Write("Looking around you realise that the light is coming from a chained up branch.");
            SlowRPG_Write("With your mighty IQ of 73 you decide to free it from the chains to further investigate it.");
            SlowRPG_Write("With the branch in your hand you are overwhealmed by a sickening senstation.");
            SlowRPG_Write("");
            SlowRPG_Write("Branch of the Sinner: Take 10 damage to gain 5 hp");
        }
        public static void Room6_Dialog2()
        {
            SlowRPG_Write("After leaving that cursed thing you find a note.");
            SlowRPG_Write("");
            SlowRPG_Write("It reads: ");
            SlowRPG_Write("'The ", sameLine: true);
            SlowRPG_Write("computer with the keyboard", sameLine: true, color: "White");
            SlowRPG_Write(" is out of order, sorry.' - ", sameLine: true);
            SlowRPG_Write("Lord of Bacon", color: "Yellow");
            SlowRPG_Write("Damnable Gods, can't even handel a computer.");
            SlowRPG_Write("You throw the note onto thee ground and notice something on its backside.");
            SlowRPG_Write("In fine print is says: ");
            SlowRPG_Write("'To compensate you, I grant you the: ", sameLine: true);
            SlowRPG_Write("Minor blessing of Bacon: +10 attack and health", sameLine: true, color: "White");
            SlowRPG_Write("as reimbursement.'");
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("...", delay: 200);
            SlowRPG_Write("Maybe the gods ain't that bad.");
        }

    }
}