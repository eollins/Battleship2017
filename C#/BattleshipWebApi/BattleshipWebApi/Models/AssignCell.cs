using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipWebApi.Models
{
    public class AssignCell
    {
        /// <summary>
        /// The ID of the grid the cell is being assigned to
        /// </summary>
        public int grid { get; set; }
        /// <summary>
        /// The horizontal location of the cell
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// The vertical location of the cell
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// The status code of the cell being assigned
        /// </summary>
        public int status { get; set; }
    }
}