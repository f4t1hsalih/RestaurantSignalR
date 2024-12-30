const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7068/SignalRHub")
    .build();

document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});