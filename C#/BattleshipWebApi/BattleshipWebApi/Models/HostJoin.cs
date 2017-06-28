using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipWebApi.Models
{
    public class HostJoin
    {
        /// <summary>
        /// The name of the new user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The name of the room the user is founding
        /// </summary>
        public string RoomName { get; set; }
    }
}