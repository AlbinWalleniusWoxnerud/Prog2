namespace Rooms;
partial class Room_9 : RoomBase
{
    public Room_9(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    private protected override void RoomInteractionSync()
    {
        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();

            int playerChoice1 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Fight".Split(". "));

            player.finalFight = true;

            //This battle will always be lost so don't return
            Fight fight = new(player, new Dragonling());

            Dialog2();

            if (player.subjectOfLordBacon == false)
            {
                TextRender.Render("");
                TextRender.Render("You died", color: Color.DarkRed);
                TextRender.Render("");
                return;
            }

            Dialog3();

            player.Revive();

            player.hasTrueKey = true;
            if (player.chooseShield)
            {
                player.defense = 0.0005;
                player.shield = 2000000;
                player.attack = 2000000;
                player.crit = 100;
            }
            else
            {
                player.defense = 0.0005;
                player.attack = 4000000;
                player.crit = 100;
            }
            player.FullHeal();
            TextRender.Render("Now to figure out what to do with the key.");
            room.clear1 = true;
        }


        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the ", sameLine: true);
            TextRender.Render("Boss Room", color: Color.White);
        }
        int playerChoice3 = TextRender.TableOfOptions(header: "What do you do? ", alternatives: "Return to room 4, the chest room.".Split(". "));

        switch (playerChoice3)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You return to room 4, the chest room.");
                room.specialInteraction = true;
                currentRun.currentRoom = 4;
                return;
        }
    }
}