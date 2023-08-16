// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".chatbox").click(function () {
    $(".dropchat").addClass("show");
});

$(".close").click(function () {
    $(".dropchat").removeClass("show");
});

function scrollToBottom() {
    var messageBox = document.getElementById('messageBox');
    messageBox.scrollTop = messageBox.scrollHeight;
}


//SIGNALR CONNECTIONN

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    console.log("Connected!");
}).catch(function (err) {
    console.error(err.toString());
});

connection.on("ReceiveMessage", function (user, message) {

    var userNameLink = document.getElementById('userName'); 
    var userName = userNameLink.innerText; 

    var now = new Date();
    var hours = now.getHours(); 
    var minutes = now.getMinutes(); 
    var formattedTime = `${String(hours).padStart(2, '0')}:${String(minutes).padStart(2, '0')}`;

    if (user != userName) {
        var newListItem = `
    <div class="list ">
        <img class="chat-avater" src="/images/default.png" alt="">
        <div class="chat-content">
            <p>${message}</p>
            <span>${user}</span>
            <span style="float:right">&nbsp;${formattedTime}</span>
        </div>
    </div>
`;
    }
    else {
        var newListItem = `
    <div class="list revange">
        <img class="chat-avater" src="/images/default.png" alt="">
        <div class="chat-content">
            <p>${message}</p>
            <span>${user}</span>
            <span style="float:right">&nbsp;${formattedTime}</span>
        </div>
    </div>
`;
    }
    $("#messageBox").append(newListItem);

    scrollToBottom();
});

function sendMessageHub(userName) {
        var user = userName;
        var message = $(".message").val();
        $(".message").val("")

    if (message != "") {
        connection.invoke("SendMessage", user, message);
    }
};



