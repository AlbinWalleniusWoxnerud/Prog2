namespace Rooms;
partial class Room_4 : RoomBase
{
    public Room_4(Player player, RoomFlags room, CurrentRun currentRun) : base(player, room, currentRun)
    {
    }
    private protected override void RoomInteractionSync()
    {
        if (room.specialInteraction)
        {
            TextRender.Render("");
            TextRender.Render("You return to the room marked: ", sameLine: true);
            TextRender.Render("Room 4", color: Color.White);
            TextRender.Render("");
        }

        if (!room.clear1)
        {
            //Usual dialog with skip
            Dialog1();
            room.clear1 = true;
        }

        if (!room.clear2)
        {
            if (!player.hasChestKey)
            {
                TextRender.Render("");
                int room4_playerChoice1 = TextRender.Table(header: "Do you: ", alternatives: "Go to the new path.. Return to room 3, the second goblin room.".Split(". "));

                switch (room4_playerChoice1)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to go to the new path.");
                        room.specialInteraction = true;
                        currentRun.currentRoom = 5;
                        return;
                    case 2:
                        TextRender.Render("You choose to return to room 3, the second goblin room..");
                        currentRun.currentRoom = 3;
                        room.specialInteraction = true;
                        return;
                }
            }

            if (player.hasChestKey && player.brokenChestKey && !player.hasBossKey)
            {
                TextRender.Render("");
                int room4_playerChoice2 = TextRender.Table(header: "Do you: ", alternatives: "Go to the new path.. Try to use the broken key to open the Chest.. Return to room 3, the second goblin room.".Split(". "));

                switch (room4_playerChoice2)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to go to the new path.");
                        room.specialInteraction = true;
                        currentRun.currentRoom = 5;
                        return;
                    case 2:
                        TextRender.Render("");
                        TextRender.Render("You choose to try and use the broken key to open the ", sameLine: true);
                        TextRender.Render($"Chest", sameLine: true, color: Color.White);
                        TextRender.Render(".");
                        TextRender.Render("Against all odds the broken key actually managed to open the chest ever so slightly.");
                        TextRender.Render("Just as it is about to open the key completely brakes and the lid of the chest threats to slam shut for eternity.");
                        TextRender.Render("You slam your hand under the lid just in time to keep it open.");
                        TextRender.Render("Unfortunately at the cost of your hand.");
                        TextRender.Render("-20 HP", color: Color.White);
                        player.TakeDamage(20);
                        if (player._alive == false) return;
                        TextRender.Render("You have ", sameLine: true);
                        TextRender.Render($"{player.health}", sameLine: true, color: Color.White);
                        TextRender.Render(" HP remaining.");
                        break;
                    case 3:
                        TextRender.Render("You choose to return to room 3, the second goblin room.");
                        currentRun.currentRoom = 3;
                        room.specialInteraction = true;
                        return;
                }
            }

            if (player.hasChestKey && !player.brokenChestKey && !player.hasBossKey)
            {
                TextRender.Render("");
                int room4_playerChoice3 = TextRender.Table(header: "Do you: ", alternatives: "Go to the new path.. Try to use the key from the shrine to open the Chest.. Return to room 3, the second goblin room.".Split(". "));

                switch (room4_playerChoice3)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to go to the new path.");
                        room.specialInteraction = true;
                        currentRun.currentRoom = 5;
                        return;
                    case 2:
                        TextRender.Render("");
                        TextRender.Render("You choose to try and use the key from the shrine to open the ", sameLine: true);
                        TextRender.Render($"big Chest", sameLine: true, color: Color.White);
                        TextRender.Render(".");
                        TextRender.Render("The key instantly opens the chest.");
                        break;
                    case 3:
                        TextRender.Render("You choose to return to room 3, the second goblin room.");
                        currentRun.currentRoom = 3;
                        room.specialInteraction = true;
                        return;
                }
            }

            //Un-skippable due to major event
            Dialog2();

            player.hasBossKey = true;

            int room4_playerChoice4 = TextRender.Table(header: "Do you: ", alternatives: "Drink the unknown potion.. Don't drink the potentially poisonous potion and try to use the boss key..".Split(". "));

            switch (room4_playerChoice4)
            {
                case 1:
                    TextRender.Render("");
                    TextRender.Render("You choose to drink the unknown potion.");
                    TextRender.Render("It weakens your strength.");
                    TextRender.Render("-20% attack", color: Color.White);

                    //Temporary var for player attack
                    double tempAttack;

                    //Cast int player.attack to double
                    tempAttack = (double)player.attack * 0.8;

                    //Down cast double tempAttack to int
                    player.attack = (int)tempAttack;

                    TextRender.Render("Still have to try to use the boss key.");
                    break;
                case 2:
                    TextRender.Render("");
                    TextRender.Render("You choose not to drink the unknown potion and to try to use the boss key.");
                    break;
            }
            room.clear2 = true;
        }

        if (!room.clear3)
        {
            if (player.hasBossKey)
            {
                int room4_playerChoice5 = TextRender.Table(header: "Do you: ", alternatives: "Use the BOSS key on the door with the letters 'BOSS'.. Go to the new path.. Return to room 3, second goblin room.".Split(". "));

                switch (room4_playerChoice5)
                {
                    case 1:
                        TextRender.Render("");
                        TextRender.Render("You choose to use the BOSS key on the door with the letters 'BOSS'.");
                        TextRender.Render("The door unlocks with a click.");
                        break;
                    case 2:
                        TextRender.Render("");
                        TextRender.Render("You choose to go to the new path.");
                        room.specialInteraction = true;
                        currentRun.currentRoom = 5;
                        return;
                    case 3:
                        TextRender.Render("You choose to return to room 3, the second goblin room..");
                        currentRun.currentRoom = 3;
                        room.specialInteraction = true;
                        return;
                }
            }
            room.clear3 = true;
        }


        int room4_playerChoice6 = TextRender.Table(header: "What do you do: ", alternatives: "Enter the boss room.. Go to the new path.. Return to room 3, second goblin room.".Split(". "));

        switch (room4_playerChoice6)
        {
            case 1:
                TextRender.Render("");
                TextRender.Render("You choose to enter the boss room.");
                room.specialInteraction = true;
                currentRun.currentRoom = 9;
                return;
            case 2:
                TextRender.Render("");
                TextRender.Render("You choose to go to the new path.");
                room.specialInteraction = true;
                currentRun.currentRoom = 5;
                return;
            case 3:
                TextRender.Render("You choose to return to room 3, the second goblin room..");
                currentRun.currentRoom = 3;
                room.specialInteraction = true;
                return;
        }

    }
}