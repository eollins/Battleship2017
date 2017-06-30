var request = new XMLHttpRequest();
request.open("GET", "http://localhost:52927/api/User/GetAllAvailableRooms/sauce", true);
request.setRequestHeader("Content-type", "application/json");
request.onreadystatechange = () => {
    if (request.readyState == 4 && request.status >= 200 && request.status < 300) {
        roomText.innerText = "";
        if (request.responseText !== "") {
            var rooms = request.responseText.split('~');
            for (var i = 0; i < rooms.length - 1; i++) {
                var parts = rooms[i].split('-');
                var current = roomText.innerText;
                current += parts[2] + " (" + parts[0] + ")" + "\n";
                roomText.innerText = current;
            }
        }
        else {
            alert("Room")
        }    
    }
};
request.send();