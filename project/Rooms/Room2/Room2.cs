namespace Rooms;
partial class Room_2 : RoomBase
{
    public Room_2(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    //Room 2 with all of its interactions
    private protected override void RoomInteractionSync()
    {
        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();

            int playerChoice1 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Fight it.. Retreat to the starting room".Split(". "));

            //If player choose so return to starting room
            if (playerChoice1 == 2)
            {
                TextRender.Render("");
                TextRender.Render("You choose to retreat.");
                currentRun.currentRoom = 1;
                return;
            }

            Fight fight = new(player, new Goblin(20, 10, 5, 0.95, 5));
            if (player._alive == false) return;

            Dialog2();

            room.clear1 = true;
        }

        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the room marked: ", sameLine: true);
            TextRender.Render("Room 2", color: Text.Color.White);
        }
        int playerChoice2 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Go to the path straight forward.. Go to the path to the left forward.. Return to the starting room.".Split(". "));

        switch (playerChoice2)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You choose to go to the path straight forward.");
                room.specialInteraction = true;
                currentRun.currentRoom = 7;
                return;
            case 2:
                TextRender.Render("You choose to go to the path to the left forward.");
                currentRun.currentRoom = 3;
                room.specialInteraction = true;
                return;
            case 3:
                TextRender.Render("You choose to return to the starting room.");
                currentRun.currentRoom = 1;
                room.specialInteraction = true;
                return;
        }
    }
}