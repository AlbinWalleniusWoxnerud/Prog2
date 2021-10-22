using System;
using Library.Entities;

namespace Library
{
    //Room logic, or rather room eventflags 
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

        public RoomFlags(Player player, RoomFlags room, CurrentRun currentRun)
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