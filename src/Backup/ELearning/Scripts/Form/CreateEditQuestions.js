var formID = -1;
var addedQuestionID = 'Q-1';

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
    $(this).next('div.Content').slideToggle(200, toggleCallback);
}
function toggleHideAllQuestionContent() {
    $('div.Question div.Content').slideUp(200, toggleCallback);
}
function toggleShowAllQuestionContent() {
    $('div.Question div.Content').slideDown(200, toggleCallback);
}
function hideAllQuestionsContentImmediatelly() {
    $('div.Question div.Content').toggle(false);
}

function getQuestionsStatesCookieName() {
    return 'QuestionsStates' + formID;
}

function toggleCallback() {
    if ($(this).is(':hidden'))
        questionHidden($(this).parents('div.Question')[0].id);
    else
        questionShown($(this).parents('div.Question')[0].id);
}
function questionShown(id) {
    var currentValue = $.cookie(getQuestionsStatesCookieName());
    if (currentValue == null) {
        $.cookie(getQuestionsStatesCookieName(), id + ';');
    }
    else {
        if(currentValue.indexOf(id + ';') == -1)
            $.cookie(getQuestionsStatesCookieName(), currentValue + id + ';');
    }
}
function questionHidden(id) {
    var currentValue = $.cookie(getQuestionsStatesCookieName());
    if (currentValue == null)
        return;

    var resultValue = currentValue.replace(id + ';', '');
    $.cookie(getQuestionsStatesCookieName(), resultValue);
}

function showSavedQuestionContents() {
    var currentValue = $.cookie(getQuestionsStatesCookieName());
    if (currentValue == null)
        return;

    var ids = currentValue.split(';');
    for (i = 0; i < ids.length; i++)
        if(ids[i].length > 0)
            $('div.Question#' + ids[i] + ' div.Content').toggle(true);
}


function showPreview(formID, invokePrint) {
    var params = formID;
    if (invokePrint)
        params += '?print=true';
    window.open('/Form/ShowPreview/' + params, '_blank', 'width=800, toolbar=0, resizable=1, scrollbars=1, menubar=0');
}


$(document).ready(function () {
    var textAreasAutoSized = $('div.autosized textarea');
    textAreasAutoSized.each(function (i, area) { autoSizeTextArea(area); });
    textAreasAutoSized.bind('keypress paste cut drop change', textAreaTextChanged);

    var questionHeaders = $('div.Question div.Header');
    questionHeaders.click(toggleQuestionContent);

    hideAllQuestionsContentImmediatelly();
    if (addedQuestionID != 'Q-1')
        questionShown(addedQuestionID);
    showSavedQuestionContents();
    if (addedQuestionID != 'Q-1')
        window.location = window.location + '#' + addedQuestionID;
});