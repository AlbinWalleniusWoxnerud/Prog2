namespace Library
{
    //Fundamental game logic of the game
    internal class CurrentRun
    {
        internal int currentRoom { get; set; } = 1;
        internal bool conquered { get; set; } = false;
        internal bool playAgain { get; set; } = false;
    }
}