namespace Rooms;
partial class Room_3 : RoomBase
{
    public Room_3(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    private protected override void RoomInteractionSync()
    {
        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();

            int playerChoice1 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Fight it.. Retreat to room 2, 1st goblin room.".Split(". "));

            //If player choose so return to starting room
            if (playerChoice1 == 2)
            {
                TextRender.Render("");
                TextRender.Render("You choose to retreat.");
                currentRun.currentRoom = 2;
                return;
            }

            Fight fight = new(player, new Goblin());
            if (player._alive == false) return;

            Dialog2();

            room.clear1 = true;
        }

        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the room marked: ", sameLine: true);
            TextRender.Render("Room 3", sameLine: true, color: Color.White);
            TextRender.Render(", the second goblin room");
        }
        int playerChoice2 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Go to the new path.. Return to room 2, the first goblin room.".Split(". "));

        switch (playerChoice2)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You choose to go to the new path.");
                room.specialInteraction = true;
                currentRun.currentRoom = 4;
                return;
            case 2:
                TextRender.Render("You choose to return to room 2, the first goblin room..");
                currentRun.currentRoom = 2;
                room.specialInteraction = true;
                return;
        }
    }

}