var isTimed = false;
var endTime = new Date();
var updateIntervalID;

var divTime;

function setTimeToFill(seconds) {
    isTimed = true;
    endTime = new Date(new Date().valueOf() + (seconds * 1000));
}

function startCountdown() {
    updateIntervalID = setInterval('updateTime();', 200);
    updateTime();
}

function updateTime() {
    //var currentTime = new Date(endTime.valueOf() - new Date().valueOf());
    var now = new Date();
    var currentTime = new Date();
    currentTime.setHours(endTime.getHours() - now.getHours(), endTime.getMinutes() - now.getMinutes(), endTime.getSeconds() - now.getSeconds(), 0);

    divTime.html(getTimeString(currentTime));

    if (currentTime.getHours() <= 0
        && currentTime.getMinutes() <= 0
        ) {
        divTime.parent().addClass('warning');

        if (currentTime.getSeconds() <= 0) {
            clearInterval(updateIntervalID);
            forceFormSubmit();
        }
    }
}

function forceFormSubmit() {
    $('form#FillForm').submit();
}

function getTimeString(time) {
    var hours = time.getHours();
    var minutes = time.getMinutes();
    var seconds = time.getSeconds();
    var result = '';

    if (hours != 0) {
        if (hours < 10)
            result += '0' + hours;
        else
            result += hours;
        result += ':';
    }
    if (minutes < 10)
        result += '0' + minutes;
    else
        result += minutes;
    result += ':';
    if (seconds < 10)
        result += '0' + seconds;
    else
        result += seconds;

    return result;
}

$(document).ready(function () {
    if (isTimed) {
        divTime = $('div#Time');
        startCountdown();
    }
});