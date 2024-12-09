const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    const msg = document.createElement("div");
    msg.textContent = `${user}: ${message}`;
    document.getElementById("messages").appendChild(msg);
});

document.getElementById("sendButton").addEventListener("click", async () => {
    const recipient = document.getElementById("recipientInput").value;
    const message = document.getElementById("messageInput").value;

    try {
        await connection.invoke("SendPrivateMessage", recipient, message);
        document.getElementById("messageInput").value = "";
    } catch (err) {
        console.error(err);
    }
});

connection.start()
    .catch(err => console.error(err));
