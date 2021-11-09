namespace Rooms;
partial class Room_2 : RoomBase
{
    private void Dialog1()
    {
        TextRender.Render("You explore the path and end up in another dark room, this time with a marking.");
        TextRender.Render("");
        TextRender.Render("Room 2", color: Text.Color.White);
        TextRender.Render("");
        TextRender.Render("You hear some noises coming from a corner and decide to check it out.");
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("When the ", sameLine: true);
        TextRender.Render("light", sameLine: true, color: Text.Color.Yellow);
        TextRender.Render(" of the torch reaches the noise you see an ugly little creature, a ", sameLine: true);
        TextRender.Render("Goblin", sameLine: true, color: Text.Color.Green);
        TextRender.Render(".");
    }
    private void Dialog2()
    {
        TextRender.Render("After killing the ", sameLine: true);
        TextRender.Render("Goblin", sameLine: true, color: Text.Color.Green);
        TextRender.Render(" you explore the rest of the room and find: ", sameLine: true);
        TextRender.Render("2 paths", sameLine: true, color: Text.Color.White);
        TextRender.Render(" and a ", sameLine: true);
        TextRender.Render("note", sameLine: true, color: Text.Color.White);
        TextRender.Render(".");
        TextRender.Render("The note reads: 'Key very hidden is.'");
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("...", delay: 200);
        TextRender.Render("(ﾉಥ益ಥ)ﾉ");
        TextRender.Render("You decide to check the paths out.");
    }
}