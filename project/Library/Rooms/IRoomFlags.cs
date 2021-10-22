using System;

namespace Library
{
    //Room logic, or rather room eventflags 
    public interface IRoomFlags
    {
        bool clear1 { get; set; }
        bool clear2 { get; set; }
        bool clear3 { get; set; }
        bool specialInteraction { get; set; }
    }
}