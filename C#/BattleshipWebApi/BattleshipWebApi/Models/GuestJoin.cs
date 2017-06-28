using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipWebApi.Models
{
    public class GuestJoin
    {
        /// <summary>
        ///The name of the joining user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The ID of the room the new user is joining
        /// </summary>
        public string RoomID { get; set; }
    }
}