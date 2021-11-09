namespace Library;
public class PlayerDeathEventArgs : EventArgs
{
    public DateTime TimeOfDeath { get; private set; }

    public PlayerDeathEventArgs()
    {
        TimeOfDeath = DateTime.Now;
    }
}
public class EnemyDeathEventArgs : EventArgs
{
    public DateTime TimeOfDeath { get; private set; }
    public EntityType DeadEnemyType { get; init; }

    public EnemyDeathEventArgs(EntityType e)
    {
        TimeOfDeath = DateTime.Now;
        DeadEnemyType = e;
    }
}
internal class Methods
{
    /// <summary>
    /// Invokes the room which the player should be in/is going to according to the "currentRun" value
    /// </summary>
    /// <param name="player"></param>
    /// <param name="rooms">List of rooms specific for the current run</param>
    /// <param name="currentRun">The currentRun containing information about the current run</param>
    internal static void InitRoom(Player player, RoomFlags[] rooms, CurrentRun currentRun)
    {
        switch (currentRun.currentRoom)
        {
            case 1:
                Room_1 room1 = new(player, rooms[0], currentRun);
                break;
            case 2:
                Room_2 room2 = new(player, rooms[1], currentRun);
                break;
            case 3:
                Room_3 room3 = new(player, rooms[2], currentRun);
                break;
            case 4:
                Room_4 room4 = new(player, rooms[3], currentRun);
                break;
            case 5:
                Room_5 room5 = new(player, rooms[4], currentRun);
                break;
            case 6:
                Room_6 room6 = new(player, rooms[5], currentRun);
                break;
            case 7:
                Room_7 room7 = new(player, rooms[6], currentRun);
                break;
            case 8:
                Room_8 room8 = new(player, rooms[7], currentRun);
                break;
            case 9:
                Room_9 room9 = new(player, rooms[8], currentRun);
                break;
        }
    }
}