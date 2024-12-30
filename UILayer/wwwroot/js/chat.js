const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7068/SignalRHub")
    .build();

document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    const placeholder = document.getElementById("placeholder-message");
    if (placeholder) {
        // Varsay�lan mesaj� kald�r
        placeholder.remove();
    }

    const currentTime = new Date();
    const currentHour = String(currentTime.getHours()).padStart(2, '0');
    const currentMinute = String(currentTime.getMinutes()).padStart(2, '0');

    const li = document.createElement("li");
    const span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += `: ${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    console.error(err.toString());
    alert("Ba�lant� kurulamad�, l�tfen tekrar deneyin.");
});

document.getElementById("sendbutton").addEventListener("click", function (event) {
    const user = document.getElementById("userinput").value.trim();
    const message = document.getElementById("messageinput").value.trim();

    if (!user || !message) {
        alert("L�tfen kullan�c� ad�n�z� ve mesaj�n�z� girin.");
        return;
    }

    connection.invoke("SendMessage", user, message).then(() => {
        document.getElementById("messageinput").value = ""; // Mesaj alan�n� temizle
    }).catch(function (err) {
        console.error(err.toString());
        alert("Mesaj g�nderilemedi, l�tfen tekrar deneyin.");
    });

    event.preventDefault();
});
