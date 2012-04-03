function createMarkItUp() {
    $('form#TextBook textarea#txtText').markItUp(mySettings);
}


function registerSubmitEvent() {
    $('form#TextBook').submit(replaceDangerousEntities);
}

function replaceDangerousEntities() {
    var text = $('#txtText');
    text.val(text.val().replace(/</g, "&lt;").replace(/>/g, "&gt;"));
}

$(document).ready(function () {
    createMarkItUp();
    registerSubmitEvent();
});