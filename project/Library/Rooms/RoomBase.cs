using System;
using Library.Entities;

namespace Library
{
    //Room logic, or rather room eventflags 
    internal abstract class RoomBase
    {
        public RoomBase(Player player, RoomFlags room, CurrentRun currentRun)
        {
            this.player = player;
            this.room = room;
            this.currentRun = currentRun;
            this.RoomInteraction();
        }
        private protected virtual void RoomInteraction()
        {

        }

        private Player player;
        private RoomFlags room;
        private CurrentRun currentRun;
    }
}