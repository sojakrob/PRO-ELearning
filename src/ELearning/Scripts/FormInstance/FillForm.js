var isTimed = false;
var timeToFill = 0;
var currentTime = new Date();
var updateIntervalID;

var divTime;

function setTimeToFill(minutes) {
    isTimed = true;
    timeToFill = minutes;
}

function startCountdown() {
    currentTime.setHours(timeToFill / 60, timeToFill % 60, 0, 0);
    updateIntervalID = setInterval('decrementTimeAndUpdateView();', 1000);
    updateTimeView();
}

function updateTimeView() {
    divTime.html(getTimeString(currentTime));
    if (currentTime.getHours() == 0
        && currentTime.getMinutes() == 0
        ) {
        divTime.parent().addClass('warning');
    }
}

function decrementTimeAndUpdateView() {
    currentTime = new Date(currentTime.valueOf() - 1000);
    updateTimeView();

    if (currentTime.getHours() == 0
        && currentTime.getMinutes() == 0
        && currentTime.getSeconds() == 0
        ) {
        clearInterval(updateIntervalID);
        forceFormSubmit();
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