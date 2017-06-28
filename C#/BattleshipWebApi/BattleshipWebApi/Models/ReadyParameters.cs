using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipWebApi.Models
{
    public class ReadyParameters
    {
        /// <summary>
        /// The ID of the user being marked
        /// </summary>
        public int userID { get; set; }
        /// <summary>
        /// The ID of the room the user is in
        /// </summary>
        public int roomID { get; set; }
    }
}