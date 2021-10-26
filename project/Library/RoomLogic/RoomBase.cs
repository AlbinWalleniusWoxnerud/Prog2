namespace Library;
//Room logic, or rather room eventflags 
internal abstract class RoomBase : IRoomBase
{
    public RoomBase(Player player, RoomFlags room, CurrentRun currentRun)
    {
        this.player = player;
        this.room = room;
        this.currentRun = currentRun;
        this.RoomInteraction();
    }
    private protected abstract void RoomInteraction();

    public Player player { get; set; }
    public RoomFlags room { get; set; }
    public CurrentRun currentRun { get; set; }
}