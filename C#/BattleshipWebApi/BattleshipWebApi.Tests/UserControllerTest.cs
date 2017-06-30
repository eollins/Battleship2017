using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipWebApi.Controllers;
using System.Net;
using BattleshipWebApi.Models;
using System.Collections.Generic;

namespace BattleshipWebApi.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        List<int> rooms = new List<int>();
        Random ran2 = new Random();

        [TestMethod]
        public void CreateRoomTest()
        {
            UserController user = new UserController();
            HostJoin join = new HostJoin();
            join.Name = "TESTINGUSER";
            join.RoomName = "TESTINGROOM";
            string result = user.CreateRoom(join);
            string[] parts = result.Split('|');
            rooms.Add(int.Parse(parts[3]));
            Assert.AreEqual(parts[0], join.Name);
        }

        [TestMethod]
        public void JoinRoomTest()
        {
            CreateRoomTest();
            UserController user = new UserController();
            GuestJoin join = new GuestJoin();
            join.Name = "TESTINGUSER";
            join.RoomID = rooms[ran2.Next(0, rooms.Count - 1)].ToString();
            rooms.Remove(int.Parse(join.RoomID));
            string result = user.JoinRoom(join);
            string[] parts = result.Split('|');
            Assert.AreEqual(parts[3], join.RoomID);
        }
    }
}
