using System;

namespace ProgramLibrary
{
    //Room logic, or rather room eventflags 
    internal class Room : IRoom
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
        internal Room()
        {
        }
    }
}