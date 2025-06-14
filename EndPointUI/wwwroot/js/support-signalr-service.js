let connection = new signalR.HubConnectionBuilder()
    .withUrl("/SupportHub")
    .build();
let connectionSite = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();


var activeRoomId = '';

document.addEventListener("DOMContentLoaded", () => {
    Init();
});
function Init() {
    connection.start();
    connectionSite.start();
}
connectionSite.on("ReceiveMessage", function (sender, message) {
    AppendMessage(sender, message,"اکنون" );
});


connection.on("SyncGoupMessages", function (messages) {

    SyncGoupMessages(messages);
});

function ShowMessages(id) {
    connectionSite.invoke("LeftGroupAsync", activeRoomId);
    activeRoomId = id;
    let activeGroupId = "Group_" + id;
    var groups = document.getElementsByName("group")
    groups.forEach((item, index) => {

        if (item.id == activeGroupId) {

            item.className = "chat-contact-list-item active";
        } else {
            item.className = "chat-contact-list-item";
        }
    });
    connectionSite.invoke("JoinGroupAsync", id);
    connection.invoke("LoadMessagesAsync", id);
}
function SyncGoupMessages(messages) {

    if (!messages) {
        return;
    }
    let ulList = document.getElementById("chat-messages");
    ulList.innerHTML = "";
    messages.forEach((item, index) => {
        AppendMessage(item.userType, item.message, item.createAt);
    });

    const height = ulList.offsetHeight;


    chatHistoryBody = document.querySelector('.chat-history-body');


    chatHistoryBody.scrollTo(0, height - 80);
}
function AppendMessage(sender, message, time) {
    debugger
    let ulList = document.getElementById("chat-messages");

    let li = document.createElement("li");
    if (sender == "user-message") {
        li.className = "chat-message chat-message-right";
        li.innerHTML = ` <div class="d-flex overflow-hidden">
                                    <div class="chat-message-wrapper flex-grow-1">
                                        <div class="chat-message-text">
                                            <p class="mb-0">`+ message + `</p>
                                        </div>
                                        <div class="text-end text-muted mt-1">
                                            <i class="bx bx-check-double text-success"></i>
                                            <small>`+ time + `</small>
                                        </div>
                                    </div>
                                    <div class="user-avatar flex-shrink-0 ms-3">
                                        <div class="avatar avatar-sm">
                                            <img src="../../assets/img/avatars/1.png" alt="آواتار" class="rounded-circle">
                                        </div>
                                    </div>
                                </div>
                       
                           `;
    } else {
        li.className = "chat-message"
        li.innerHTML = `  <div class="d-flex overflow-hidden">
                              <div class="user-avatar flex-shrink-0 me-3">
                                <div class="avatar avatar-sm">
                                  <img src="../../assets/img/avatars/2.png" alt="آواتار" class="rounded-circle">
                                </div>
                              </div>
                              <div class="chat-message-wrapper flex-grow-1">
                                <div class="chat-message-text">
 <p class="mb-0">`+ message + `</p>                                </div>
                                <div class="text-muted mt-1">
                                   <small>`+ time + `</small>
                                </div>
                              </div>
                            </div>
                           `;
    }

 
    ulList.appendChild(li);


}


function NewMessage() {
    let text = document.getElementById("textNewMessage").value;
    document.getElementById("textNewMessage").value = "";
    connection.invoke("SendMessageAsync", text, activeRoomId);
}


connection.on("Rooms", function (groups) {

    LoadGroups(groups);
});
function LoadGroups(groups) {
    if (!groups) {
        return;
    }
    let ulList = document.getElementById("chat-list");
    ulList.innerHTML = "";
    groups.forEach((item) => {

        let li = document.createElement("li");
        li.setAttribute("name", "group");
        li.id = "Group_" + item.id;
        li.className = "chat-contact-list-item";
        li.innerHTML = `<a onclick="ShowMessages('${item.id}')"  class="d-flex align-items-center">
                            <div class="flex-shrink-0 avatar">
                                <span class="avatar-initial rounded-circle bg-label-success p-1">
                                <i class="speech-to-text bx bx-chat bx-sm cursor-pointer"></i></span>
                            </div>
                            <div class="chat-contact-info flex-grow-1 ms-3">
                                <h6 class="chat-contact-name text-truncate m-0">${item.ipAddress}</h6>
                                <p class="chat-contact-status text-truncate mb-0 text-muted">
                                   ${item.connectionId}
                                </p>
                            </div>
                            <small class="text-muted mb-auto">
                             ${item.createAt}
                            </small>
                        </a>`;
        ulList.appendChild(li);
    });
}

connectionSite.on("NewGroup", function (NewGroup) {
    debugger
    let ulList = document.getElementById("chat-list");
    let firstLi = ulList.querySelector('li');  
    let li = document.createElement("li");
    li.setAttribute("name", "group");
    li.id = "Group_" + NewGroup.id;
    li.className = "chat-contact-list-item";
    li.innerHTML = `<a onclick="ShowMessages('${NewGroup.id}')"  class="d-flex align-items-center">
                            <div class="flex-shrink-0 avatar">
                                <span class="avatar-initial rounded-circle bg-newchat p-1">
                                <i class="speech-to-text bx bx-chat bx-sm cursor-pointer"></i></span>
                            </div>
                            <div class="chat-contact-info flex-grow-1 ms-3">
                                <h6 class="chat-contact-name text-truncate m-0">${NewGroup.ip}</h6>
                                <p class="chat-contact-status text-truncate mb-0 text-muted">
                                   ${NewGroup.connectionId}
                                </p>
                            </div>
                            <small class="text-muted mb-auto">
                             ${NewGroup.createAt}
                            </small>
                        </a>`;
 

    ulList.insertBefore(li, firstLi); 

});

