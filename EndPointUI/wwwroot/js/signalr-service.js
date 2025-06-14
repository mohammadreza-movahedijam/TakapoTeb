let connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();
connection.start();
function AppendMessageToChat(message, type) {
    const chatMessages = document.getElementById('popup-chat-messages');
    const messageDiv = document.createElement('div');
    messageDiv.classList.add('message');
    messageDiv.classList.add(type);
    messageDiv.textContent = message;
    chatMessages.appendChild(messageDiv);
    chatMessages.scrollTop = chatMessages.scrollHeight;
}
function SendMessageHub() {
    let message = document.getElementById("messageChatBox").value;
    document.getElementById("messageChatBox").value = "";
    connection.invoke("SendMessageAsync", "user-message", message);
}



connection.on("ReceiveMessage", function (sender, message) {
    ReciveMessage(sender, message);
});
function ReciveMessage(sender, message) {

    AppendMessageToChat(message, sender);
}

