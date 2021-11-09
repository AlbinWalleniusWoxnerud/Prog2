namespace Library;
/// <summary>
/// Baseclass of all rooms
/// </summary>
internal abstract class RoomBase : IRoomBase
{
    /// <summary>
    /// Initializes the room and invokes the rooms specific interaction
    /// </summary>
    /// <param name="player"></param>
    /// <param name="room"></param>
    /// <param name="currentRun"></param>
    public RoomBase(Player player, RoomFlags room, CurrentRun currentRun)
    {
        this.player = player;
        this.room = room;
        this.currentRun = currentRun;
        this.RoomInteractionSync();
    }

    /// <summary>
    /// Override to specify behavior for specific room
    /// </summary>
    private protected abstract void RoomInteractionSync();

    //Properties of the rooms, necessary to make the logic of the rooms work
    public Player player { get; set; }
    public RoomFlags room { get; set; }
    public CurrentRun currentRun { get; set; }
}