namespace Library;
//Room logic, or rather room eventflags 
internal interface IRoomBase
{
    void RoomBase(Player player, RoomFlags room, CurrentRun currentRun)
    {
    }

    Player player { get; set; }
    RoomFlags room { get; set; }
    CurrentRun currentRun { get; set; }
}