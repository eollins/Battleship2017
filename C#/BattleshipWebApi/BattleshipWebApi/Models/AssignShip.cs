using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipWebApi.Models
{
    public class AssignShip
    {
        /// <summary>
        /// The ID of the user a ship is being assigned to
        /// </summary>
        public int userID { get; set; }
        /// <summary>
        /// The orientation of the ship on the grid
        /// </summary>
        public int orientation { get; set; }
        /// <summary>
        /// The length of the ship being placed
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// The horizontal location of the ship
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// The vertical location of the shipo
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// The status code of the cells being changed
        /// </summary>
        public char status { get; set; }
    }
}