function autoSizeTextArea(area) {
    area.style.height = 'auto';
    if (area.value == '')
        area.style.height = area.style.minHeight;
    else
        area.style.height = area.scrollHeight + 'px';
}
function textAreaTextChanged(event) {
    setTimeout(autoSizeTextArea, 0, this);
}

function toggleQuestionContent() {
    $(this).next('div.Content').slideToggle(200);
}
function toggleHideAllQuestionContent() {
    $('div.Question div.Content').toggle(false);
}

$(document).ready(function () {
    var textAreasAutoSized = $('div.autosized textarea');
    textAreasAutoSized.each(function (i, area) { autoSizeTextArea(area); });
    textAreasAutoSized.bind('keypress paste cut drop change', textAreaTextChanged);

    var questionHeaders = $('div.Question div.Header');
    questionHeaders.click(toggleQuestionContent);

    toggleHideAllQuestionContent();
});