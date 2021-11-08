namespace Rooms;
partial class Room_5 : RoomBase
{
    public Room_5(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
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
            if (player.hasMeat)
            {
                TextRender.Render("You notice that it seems to have been attracted by the Hobgoblin meat which you didn't eat.");
                TextRender.Render("On a whim you throw the meat to the Wolf which takes it and wanders off.");
                TextRender.Render("");
                TextRender.Render("Combat avoided!", color: Color.White);
                TextRender.Render("");
                TextRender.Render("Since the wolf wasn't a problem you decide to examine the rest of the room.");
            }
            else
            {
                TextRender.Render("You notice that it seems to have been attracted by the remnants of the Hobgoblin meat which you ate.");
                int room5_playerChoice1 = TextRender.Table(header: "Do you: ", alternatives: "Fight it.. Retreat to room 4, chest room.".Split(". "));

                //If player choose to return
                if (room5_playerChoice1 == 2)
                {
                    TextRender.Render("");
                    TextRender.Render("You choose to retreat to room 4, chest room.");
                    currentRun.currentRoom = 4;
                    room.specialInteraction = true;
                    return;
                }

                Fight fight = new(player, new Wolf());
                if (player._alive == false) return;

                TextRender.Render("After deafeating the wolf you decide to examine the rest of the room.");

            }

            if (!player.hasTrueKey)
            {
                TextRender.Render("After a bit of searching you find a better suit of armour which you equip.");
                TextRender.Render("");
                TextRender.Render("Equipped new Armour: Take 20% less damage", color: Color.White);
                player.defense = 0.7;
                TextRender.Render("");
            }
            TextRender.Render("Getting tired of all of these paths you still find a new path to take.");
            room.clear2 = true;
        }

        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the room marked: ", sameLine: true);
            TextRender.Render("Room 5", sameLine: true, color: Color.White);
            TextRender.Render(", the wolf room");
        }
        int room5_playerChoice2 = TextRender.Table(header: "Do you: ", alternatives: "Go to the new path.. Return to room 4, the chest room.".Split(". "));

        switch (room5_playerChoice2)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You choose to go to the new path.");
                room.specialInteraction = true;
                currentRun.currentRoom = 6;
                return;
            case 2:
                TextRender.Render("You choose to return to room 4, the chest room..");
                currentRun.currentRoom = 4;
                room.specialInteraction = true;
                return;
        }
    }
}