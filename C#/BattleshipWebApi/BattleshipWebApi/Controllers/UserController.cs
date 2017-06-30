using BattleshipWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BattleshipWebApi.Controllers
{
    /// <summary>
    /// User-related functions
    /// </summary>
    [RoutePrefix("api/User")]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        string connectionString = "Server=GMRSKYBASE;Database=EthanOllinsBattleships2017;User Id=EthanOllinsAppUser;Password = Sauce;";

        ///<summary>
        ///Registers a new host
        /// </summary>
        /// <param name="info">The host's display name and room name</param>
        /// <returns>UserInfo model with host name and room name</returns>
        [HttpPost]
        [Route("CreateRoom")]
        public string CreateRoom([FromBody] HostJoin info)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_addHost", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Username", info.Name));
            command.Parameters.Add(new SqlParameter("@RoomName", info.RoomName));
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            string username2 = table.Rows[0][0].ToString();
            string userID = table.Rows[0][1].ToString();
            string roomname2 = table.Rows[0][2].ToString();
            string roomID = table.Rows[0][3].ToString();
            string hostID = table.Rows[0][4].ToString();

            return username2 + "|" + userID + "|" + roomname2 + "|" + roomID + "|" + hostID;
        }

        ///<summary>
        ///Registers a new guest
        /// </summary>
        /// <param name="info">The guest's display name</param>
        [HttpPost]
        [Route("JoinRoom")]
        public string JoinRoom([FromBody] GuestJoin info)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_addGuest", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Username", info.Name));
            command.Parameters.Add(new SqlParameter("@RoomID", info.RoomID));
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            string username2 = table.Rows[0][0].ToString() + "|" + table.Rows[0][1].ToString() + "|" + table.Rows[0][2].ToString() + "|" + table.Rows[0][3].ToString() + "|" + table.Rows[0][4];
            return username2;
        }

        ///<summary>
        ///Gets a room name by the room's ID
        ///</summary>
        ///<param name="roomID">The numerical ID of the room in question</param>
        [HttpGet]
        [Route("GetRoomNameByID/{roomID}")]
        public string GetRoomNameByID(int roomID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getRoomByID", connection);
            command.Parameters.Add(new SqlParameter("@roomID", roomID));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        ///<summary>
        ///Gets a room ID by the room's name
        ///</summary>
        ///<param name="roomName">The name of the room in question</param>
        [HttpGet]
        [Route("GetRoomIDByName/{roomName}")]
        public string GetRoomIDByName(string roomName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getIDByRoom", connection);
            command.Parameters.Add(new SqlParameter("@roomName", roomName));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        ///<summary>
        ///Gets a username by the user's ID
        /// </summary>
        /// <param name="userID">The numerical ID of the user in question</param>
        [HttpGet]
        [Route("GetUsernameByID/{userID}")]
        public string GetUsernameByID(int userID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getUserByID", connection);
            command.Parameters.Add(new SqlParameter("@userID", userID));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        ///<summary>
        ///Gets a user ID by the user's name
        /// </summary>
        /// <param name="username">The name of the user in question</param>
        [HttpGet]
        [Route("GetIDByUsername/{username}")]
        public string GetIDByUsername(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getIDByUser", connection);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        ///<summary>
        ///Returns host ID of specific room
        /// </summary>
        /// <param name="roomID">The ID of the room being checked</param>
        [HttpGet]
        [Route("GetHost/{roomID}")]
        public string GetHost(int roomID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getHost", connection);
            command.Parameters.Add(new SqlParameter("@roomID", roomID));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        ///<summary>
        ///Returns guest ID of specific room
        /// </summary>
        /// <param name="roomID">The ID of the room being checked</param>
        [HttpGet]
        [Route("GetGuest/{roomID}")]
        public string GetGuest(int roomID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getGuest", connection);
            command.Parameters.Add(new SqlParameter("@roomID", roomID));
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table.Rows[0][0].ToString();
        }

        /// <summary>
        /// Marks a player in a specific room as Ready
        /// </summary>
        /// <param name="param">The user and room being marked</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ToggleReady")]
        public string ToggleReady([FromBody] ReadyParameters param)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getHost", connection);
            command.Parameters.AddWithValue("@roomID", param.roomID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            int hostID = int.Parse(table.Rows[0][0].ToString());
            int playerType = 0;

            if (hostID != param.userID)
                playerType = 1;

            SqlCommand command2 = new SqlCommand("usp_toggleReady", connection);
            command2.Parameters.AddWithValue("@roomID", param.roomID);
            command2.Parameters.AddWithValue("@PlayerType", playerType);
            command2.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            connection.Close();

            return table2.Rows[0][0].ToString();
        }

        /// <summary>
        /// Gets the room that the user is in
        /// </summary>
        /// <param name="userID">The ID of the user whose room is being searched for</param>
        /// <param name="getName">Returns the room's name if true, ID if false</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoomOfUser/{userID}/{getName}")]
        public string GetRoomOfUser(int userID, string getName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getRoomOfUser", connection);
            command.Parameters.AddWithValue("@userID", userID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (getName == "true")
            {
                return table.Rows[0][0].ToString();
            }
            else
            {
                return table.Rows[0][1].ToString();
            }
        }

        /// <summary>
        /// Receives the identity of the grid assigned to a specific user ID
        /// </summary>
        /// <param name="userID">The ID of the user whose grid is being searched for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGridOfUser/{userID}")]
        public string GetGridOfUser(int userID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getGridOfUser", connection);
            command.Parameters.AddWithValue("@userID", userID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows[0][0].ToString();
        }


        /// <summary>
        /// Creates a ship at the specified origin point
        /// </summary>
        /// <param name="assignShip">The parameters of the ship being assigned</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AssignShip")]
        public string AssignShip([FromBody] AssignShip assignShip)
        {
            int room = int.Parse(GetRoomOfUser(assignShip.userID, "false"));
            int grid = int.Parse(GetGridOfUser(assignShip.userID));

            AssignCell assign = new Models.AssignCell();
            assign.grid = grid;
            assign.x = assignShip.x;
            assign.y = assignShip.y;
            assign.status = 'A';

            AssignCell(assign);
            int cell = int.Parse(GetCellIDByCoordinates(assignShip.x, assignShip.y, grid));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_addShip", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", assignShip.userID);
            command.Parameters.AddWithValue("@RoomID", room);
            command.Parameters.AddWithValue("@GridID", grid);
            command.Parameters.AddWithValue("@CellID", cell);
            command.Parameters.AddWithValue("@Orientation", assignShip.orientation);
            command.Parameters.AddWithValue("@Length", assignShip.length);
            command.Parameters.AddWithValue("@status", assignShip.status);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return null;
        }

        /// <summary>
        /// Assigns a status to a certain cell on a certain grid
        /// </summary>
        /// <param name="cell">The grid, location and status of the new cell</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AssignCell")]
        public string AssignCell([FromBody] AssignCell cell)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_assignCell", connection);
            command.Parameters.AddWithValue("@GridID", cell.grid);
            command.Parameters.AddWithValue("@x", cell.x);
            command.Parameters.AddWithValue("@y", cell.y);
            command.Parameters.AddWithValue("@status", cell.status);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return null;
        }

        /// <summary>
        /// Receives the ID of a cell at a specific location on a specific grid
        /// </summary>
        /// <param name="x">The horizontal location of the cell being searched</param>
        /// <param name="y">The vertical location of the cell being searched</param>
        /// <param name="grid">The grid on which the cell is located</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCellIDByCoordinates/{x}/{y}/{grid}")]
        public string GetCellIDByCoordinates(int x, int y, int grid)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getCellByCoordinates", connection);
            command.Parameters.AddWithValue("@GridID", grid);
            command.Parameters.AddWithValue("@x", x);
            command.Parameters.AddWithValue("@y", y);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows[0][0].ToString();
        }

        /// <summary>
        /// Gets the coordinates of a cell by its assigned ID
        /// </summary>
        /// <param name="cellID">The ID of the cell whose coordinates are being searched for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCoordinatesByCellID/{cellID}")]
        public string GetCoordinatesByCellID(int cellID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getCoordinatesByCell", connection);
            command.Parameters.AddWithValue("@CellID", cellID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            try
            {
                return table.Rows[0][0].ToString() + ", " + table.Rows[0][1].ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Sends an attack command to a specific coordinate in a specific room
        /// </summary>
        /// <param name="roomID">The ID of the room the attack is coming from; attacker and victim are determined by backend</param>
        /// <param name="x">Horizontal location of attack</param>
        /// <param name="y">Vertical location of attack</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Attack")]
        public string Attack(int roomID, int x, int y)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_Attack", connection);
            command.Parameters.AddWithValue("@RoomID", roomID);
            command.Parameters.AddWithValue("@x", x);
            command.Parameters.AddWithValue("@y", y);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            try
            {
                return table.Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all available rooms for the user to join
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllAvailableRooms/{msg}")]
        public string GetAllAvailableRooms(string msg)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_getAllAvailableRooms", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            string info = "";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                info += table.Rows[i][0];
                info += "-";
                info += table.Rows[i][1];
                info += "-";
                info += table.Rows[i][2];
                info += "~";
            }

            return info;
        }

        /// <summary>
        /// Checks to see if a name has been previously registered
        /// </summary>
        /// <param name="name">Name being checked</param>
        /// <param name="roomname">Room name being checked</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckNameAvailability/{name}/{roomname}")]
        public string AreParametersAvailable(string name, string roomname)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_isNameAvailable", connection);
            command.Parameters.AddWithValue("@ProposedName", name);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            SqlCommand command2 = new SqlCommand("usp_isRoomAvailable", connection);
            command2.Parameters.AddWithValue("@ProposedRoomName", roomname);
            command2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);

            connection.Close();

            if ((table.Rows.Count > 0 || table2.Rows.Count > 0) || (table.Rows.Count > 0 && table2.Rows.Count > 0))
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

        /// <summary>
        /// Verifies the availability of a supplied username
        /// </summary>
        /// <param name="name">The name being checked</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckUsernameAvailability/{name}")]
        public string CheckUsernameAvailability(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_isNameAvailable", connection);
            command.Parameters.AddWithValue("@ProposedName", name);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            if (table.Rows.Count > 0)
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

        [HttpGet]
        [Route("DisableRoom/{roomID}")]
        public string DisableRoom(int roomID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_disableRoom", connection);
            command.Parameters.AddWithValue("@RoomID", roomID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            return table.Rows[0][0].ToString();
        }
    }
}
