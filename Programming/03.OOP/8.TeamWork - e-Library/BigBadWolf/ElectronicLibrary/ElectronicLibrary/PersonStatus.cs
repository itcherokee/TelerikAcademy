using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    /// <summary>
    ///  Holding different statusses that an user can have
    ///  Unknown
    ///  Operational - fully functional user (can do any thing: reading, buying, renting,...)
    ///  NonOperational - user is no more allowed to do any operations - it is like no more existing for the system
    ///  Blocked - User is blocked due to some reason and his rights are put in pause (did not return a rented book, etc.)
    /// </summary>
    public enum PersonStatus
    {
        Unknown,
        Operational,
        NonOprational,
        Blocked
    }
}
