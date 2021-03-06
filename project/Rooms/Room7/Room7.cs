namespace Rooms;
partial class Room_7 : RoomBase
{
    public Room_7(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    private protected override void RoomInteractionSync()
    {
        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();

            int playerChoice1 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Fight it.. Retreat to room 2".Split(". "));

            //If player choose so return to starting room
            if (playerChoice1 == 2)
            {
                TextRender.Render("");
                TextRender.Render("You choose to retreat.");
                currentRun.currentRoom = 2;
                return;
            }

            //If battle returns true player won, if it returns false player lost and it is game over
            Fight fight = new(player, new HobGoblin());
            if (player._alive == false) return;

            Dialog2();

            int playerChoice2 = TextRender.TableOfOptions(header: "Do you: ", alternatives: "Eat it.. Don't eat the meat you just took from a Hobgoblins body.".Split(". "));

            switch (playerChoice2)
            {
                case 1:
                    TextRender.Render("");
                    TextRender.Render("...", delay: 1000);
                    TextRender.Render("You choose to eat the meat of the ", sameLine: true);
                    TextRender.Render("Hobgoblin", sameLine: true, color: Color.DarkGreen);
                    TextRender.Render("...");
                    player.PartialHeal(25);
                    if (player._alive == false) return;

                    player.maxhealth += 25;
                    TextRender.Render("");
                    TextRender.Render("You gain ", sameLine: true);
                    TextRender.Render("+25 max HP", sameLine: true, color: Color.White);
                    TextRender.Render(" giving you ", sameLine: true);
                    TextRender.Render($"{player.health}", sameLine: true, color: Color.White);
                    TextRender.Render(" current HP.");
                    break;
                case 2:
                    TextRender.Render("");
                    TextRender.Render("You choose to not eat the meat of the ", sameLine: true);
                    TextRender.Render("Hobgoblin", sameLine: true, color: Color.DarkGreen);
                    TextRender.Render(" like a sane person would.");
                    player.hasMeat = true;
                    break;
            }

            Dialog3();
            room.clear1 = true;
        }
        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the room marked: ", sameLine: true);
            TextRender.Render("Room 7", color: Color.White);
        }
        int layerChoice3 = TextRender.TableOfOptions(header: "What do you do? ", alternatives: "Go to the even deeper path.. Use the machine.. Return to room 2.".Split(". "));

        switch (layerChoice3)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You choose to go to the even deeper path.");
                room.specialInteraction = true;
                currentRun.currentRoom = 8;
                return;
            case 2:
                TextRender.Render("You choose to use the machine.");
                MachineActivationWithoutPassword();
                break;
            case 3:
                TextRender.Render("You choose to return to room 2.");
                currentRun.currentRoom = 2;
                room.specialInteraction = true;
                return;
        }
    }
    private static void MachineActivationWithoutPassword()
    {
        Boolean Continue = true;
        do
        {
            SpecialEncounters.Machine.MachineActivationWithoutPassword();

            int playerChoice4 = TextRender.TableOfOptions(header: "Do you want to search again?: ", alternatives: "Yes.. No.".Split(". "));

            switch (playerChoice4)
            {
                case 1:
                    break;
                case 2:
                    Continue = false;
                    break;
            }

        } while (Continue);
    }
}