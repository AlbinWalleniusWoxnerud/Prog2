namespace Rooms;
partial class Room_1 : RoomBase
{
    //Simply dialog
    private void Dialog1()
    {
        TextRender.Render("You can see something in the ", sameLine: true);
        TextRender.Render("corner", sameLine: true, color: Text.Color.White);
        TextRender.Render(" of the room as well as what looks like a ", sameLine: true);
        TextRender.Render("path.", color: Text.Color.White);
    }
    private void Dialog2()
    {
        TextRender.Render("As you examine the ", sameLine: true);
        TextRender.Render("corner", sameLine: true, color: Text.Color.White);
        TextRender.Render(" you find:", sameLine: true);
        TextRender.Render(" 2 Swords", sameLine: true, color: Text.Color.White);
        TextRender.Render(", an ", sameLine: true);
        TextRender.Render("Armour", sameLine: true, color: Text.Color.White);
        TextRender.Render(" and a ", sameLine: true);
        TextRender.Render("Shield", sameLine: true, color: Text.Color.White);
        TextRender.Render(".");
        TextRender.Render("");
        TextRender.Render("You equip the armour when you realise that you can't carry everything.");
    }
    private void Dialog3()
    {
        TextRender.Render("You examine the rest of the room and find a hidden ", sameLine: true);
        TextRender.Render("door", sameLine: true, color: Text.Color.White);
        TextRender.Render(".");
        TextRender.Render("You try to open it but it won't budge, is locked.");
        TextRender.Render("A ", sameLine: true);
        TextRender.Render("key", sameLine: true, color: Text.Color.White);
        TextRender.Render(" might help.");
    }
    private void Dialog4()
    {
        TextRender.Render("You return to the dark starting room with the ", sameLine: true);
        TextRender.Render("key", sameLine: true, color: Text.Color.White);
        TextRender.Render(" you seized from ", sameLine: true);
        TextRender.Render("Smedd", sameLine: true, color: Text.Color.Green);
        TextRender.Render(".");
    }
    private void Dialog5()
    {
        TextRender.Render("You use the ", sameLine: true);
        TextRender.Render("key", sameLine: true, color: Text.Color.White);
        TextRender.Render(" you got from ", sameLine: true);
        TextRender.Render("Smedd", sameLine: true, color: Text.Color.Green);
        TextRender.Render(" to try and open the door.");
        TextRender.Render("...", delay: 1000);
        TextRender.Render("...", delay: 1000);
        TextRender.Render("...", delay: 1000);

        //If the player broke the chest key
        if (player.brokenChestKey)
        {
            TextRender.Render("Unlike last time the door actually opens, and you are greeted by a blinding ", sameLine: true);
        }
        else
        {
            TextRender.Render("The door opens, and you are greeted by a blinding ", sameLine: true);
        }

        TextRender.Render("white light", sameLine: true, color: Text.Color.White);
        TextRender.Render(".");
        TextRender.Render("");
        TextRender.Render("Quest complete!", color: Text.Color.White);
        TextRender.Render("Conquered the Maze of", sameLine: true);
        TextRender.Render(" Smedd the Terrible", sameLine: true, color: Text.Color.Green);
        TextRender.Render(".");
        TextRender.Render("");
    }

    private void Dialog6()
    {
        TextRender.Render("");
        TextRender.Render("You return to the dark starting room but now armed with the ", sameLine: true);
        TextRender.Render("key", sameLine: true, color: Text.Color.White);
        TextRender.Render(" of the shrine.");
    }
    private void Dialog7()
    {
        TextRender.Render("You use the ", sameLine: true);
        TextRender.Render("key", sameLine: true, color: Text.Color.White);
        TextRender.Render(" you got from the ", sameLine: true);
        TextRender.Render("shrine", sameLine: true, color: Text.Color.White);
        TextRender.Render(" to try and open the door.");
        TextRender.Render("...", delay: 1000);
        TextRender.Render("...", delay: 1000);
        TextRender.Render("...", delay: 1000);
        TextRender.Render("The key broke...");
        player.brokenChestKey = true;
    }
}