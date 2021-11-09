namespace Library;
/// <summary>
/// Interface for room logic
/// </summary>
internal interface IRoomBase
{
    void RoomBase(Player player, RoomFlags room, CurrentRun currentRun)
    {
    }

    Player player { get; set; }
    RoomFlags room { get; set; }
    CurrentRun currentRun { get; set; }
}