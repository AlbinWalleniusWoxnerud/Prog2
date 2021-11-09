namespace Library;
//Room eventflags 
internal class RoomFlags : IRoomFlags
{
    public bool clear1
    {
        get;
        set;
    } = false;
    public bool clear2
    {
        get;
        set;
    } = false;
    public bool clear3
    {
        get;
        set;
    } = false;
    public bool specialInteraction
    {
        get;
        set;
    } = false;

    //Initialize room
    internal RoomFlags()
    {
    }
}