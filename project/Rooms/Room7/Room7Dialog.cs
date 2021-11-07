namespace Rooms;
partial class Room_7 : RoomBase
{
    public void Dialog1()
    {
        TextRender.Render("You explore the path and end up in another dark room with the marking: ", sameLine: true);
        TextRender.Render("Room 3", sameLine: true, color: Color.White);
        TextRender.Render(".");
        TextRender.Render("");
        TextRender.Render("You once again hear some noises coming from a corner and decide to once again check it out.");
        TextRender.Render("Last time wasn't that bad...");
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("The noise is of course coming from another foul creature, but a quite big one this time. A ", sameLine: true);
        TextRender.Render("Hobgoblin", sameLine: true, color: Color.DarkGreen);
        TextRender.Render(".");
    }
    public void Dialog2()
    {
        TextRender.Render("After killing the ", sameLine: true);
        TextRender.Render("Hobgoblin", sameLine: true, color: Color.DarkGreen);
        TextRender.Render(" you desecrate its body and find piece of ", sameLine: true);
        TextRender.Render("meat", sameLine: true, color: Color.Red);
        TextRender.Render(" which looks supremely succulent.");
    }
    public async Task Dialog3()
    {
        TextRender.Render("");
        TextRender.Render("You search around the rest of the room and find a ", sameLine: true);
        TextRender.Render("weird machine", sameLine: true, color: Color.White);
        TextRender.Render(" with a keyboard.");
        TextRender.Render("You try some random combinations but nothing happens, maybe you need a ", sameLine: true);
        TextRender.Render("special password", sameLine: true, color: Color.White);
        TextRender.Render(", but where would you find that.");
        TextRender.Render("");
        TextRender.Render("You try some more combinations and the machine lights up!");
        await MachineActivationWithoutPasswordDialog();
        TextRender.Render("");
        TextRender.Render("You also find a new, even deeper ", sameLine: true);
        TextRender.Render("path", sameLine: true, color: Color.White);
        TextRender.Render(".");
    }

    private static async Task MachineActivationWithoutPasswordDialog()
    {
        TextRender.Render("");
        TextRender.Render("TV Information.");
        TextRender.Render("");
        TextRender.Render("Enter a search term!", color: Color.White);
        TextRender.Render("Enter a search term?");
        TextRender.Render("You simply press enter.");
        TextRender.Render("...", delay: 200);
        TextRender.Render("Error! Faulty search term!\nTry again!", color: Color.Red);
        await MachineActivationWithoutPassword();
    }
}