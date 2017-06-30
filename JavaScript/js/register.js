'use strict';

var createRoom = {
    "Name": "",
    "RoomName": ""
};

function createGame() {
    var request = new XMLHttpRequest();
    request.open("POST", "http://localhost:52927/api/User/CreateRoom", true);
    request.setRequestHeader("Content-Type", "application/json");
    
    createRoom.Name = usernameBoxCreate.value;
    createRoom.RoomName = roomname.value;

    request.onreadystatechange = () => {
        if (request.readyState == 4 && request.status >= 200 && request.status < 300) {
            if (request.responseText !== "") {
                var parts = request.responseText.split('|');
                alert("Created room " + parts[2]);
                moveHostToWaitingRoom(usernameBoxCreate.value, roomname.value, parts[3]);   
            }
            else {
                alert("Room")
            }    
        }
    };



    request.send(JSON.stringify(createRoom));
}

function moveHostToWaitingRoom(id, roomID, roomIDNumber) {



    localStorage.setItem("currentUser", id);
    localStorage.setItem("userRoom", roomID);
    localStorage.setItem("userRoomID", roomIDNumber)
    window.location = "waitingRoom.html";
}

function joinGame() {

}

var joinGameCredentials = {
    "Name": "",
    "RoomID": ""
}

function joinRoom() {
    var request = new XMLHttpRequest();
    request.open("POST", "http://localhost:52927/api/User/JoinRoom", true);
    request.setRequestHeader("Content-type", "application/json");
    
    joinGameCredentials.Name = joinName.value;
    joinGameCredentials.RoomID = roomInput.value;

    request.onreadystatechange = () => {
        if (request.readyState == 4 && request.status >= 200 && request.status < 300) {
            if (request.responseText !== "") {
                var parts = request.responseText.split('|');
                alert("Joined room " + parts[3] + " with player " + parts[4]);
            }
            else {
                alert("Room")
            }    
        }
    };

    request.send(JSON.stringify(joinGameCredentials));
}

function checkName() {
    var request = new XMLHttpRequest();
    request.open("GET", `http://localhost:52927/api/User/CheckUsernameAvailability/${joinName.value}`, true);
    request.setRequestHeader("Content-Type", "application/json");
    request.onreadystatechange = () => {
        if (request.readyState == 4 && request.status >= 200 && request.status < 300) {
            if (request.responseText.charAt(1) === "t") {
                submitName.disabled = false;
            }
            else {
                submitName.disabled = true;
            }
        }
    };

    request.send();
}

