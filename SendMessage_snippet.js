window.setInterval(SendMes, 0);
function SendMes() {
    var element = document.activeElement;
    var message = element.value;
    //if message is null or just spaces, return
    if (message == null) return;
    if (message.trim() == "") return;
    var activeChatBox = element.getAttribute('relID');
    element.onkeydown = function (event) {
        if (event.keyCode == 13) {
            // Send Message
            AppHub.server.sendMessage(message, activeChatBox, '@User.Identity.GetUserId()');
            // Clear user-input
            element.value = '';
            // Clear message text from the active chat box
            activeChatBox = "";
        }
    }