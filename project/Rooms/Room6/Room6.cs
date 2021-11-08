namespace Rooms;
partial class Room_6 : RoomBase
{
    public Room_6(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    private protected override void RoomInteractionSync()
    {
        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();
            room.clear1 = true;
        }

        if (!room.clear2)
        {
            bool useBranchOfTheSinner = true;
            while (useBranchOfTheSinner)
            {
                int room6_playerChoice1 = TextRender.Table(header: "Do you: ", alternatives: "Use the branch.. Leave the cursed thing and examine the rest of the room.".Split(". "));

                switch (room6_playerChoice1)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to Use the branch...");
                        TextRender.Render("");
                        TextRender.Render("+5 attack", color: Color.White);
                        TextRender.Render("-10 health", color: Color.Red);
                        player.TakeDamage(10);
                        if (player._alive == false) return;
                        player.attack += 5;

                        TextRender.Render("");
                        TextRender.Render("Status: ");
                        TextRender.Render($"{player.health}", sameLine: true, color: Color.White);
                        TextRender.Render(" current HP.");
                        TextRender.Render($"{player.attack}", sameLine: true, color: Color.White);
                        TextRender.Render(" current attack.");
                        break;
                    case 2:
                        TextRender.Render("");
                        TextRender.Render("You choose to leave the cursed thing and examine the rest of the room.");
                        useBranchOfTheSinner = false;
                        break;
                }
            }
            room.clear2 = true;
        }

        if (room.clear3 == false)
        {
            Dialog2();
            player.PartialHeal(10);
            if (player._alive == false) return;

            player.attack += 10;

            TextRender.Render("You search through the rest of the room and find nothing of interest.");
            room.clear3 = true;
        }

        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the ", sameLine: true);
            TextRender.Render("eery red", sameLine: true, color: Color.Red);
            TextRender.Render(" room.");
        }
        int room6_playerChoice2 = TextRender.Table(header: "Return ", alternatives: "Return to room 5, the wolf room.".Split(". "));

        switch (room6_playerChoice2)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You return to room 5, the wolf room");
                room.specialInteraction = true;
                currentRun.currentRoom = 5;
                return;
        }
    }
}