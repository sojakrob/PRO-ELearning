function Question(id, correctItemID) {
    this.ID = id;
    this.CorrectItemID = correctItemID;
    this.Evaluated = false;
}

var questions;

function init() {
     questions = new Array();
}

function addChoiceQuestion(questionID, correctItemID) {
    var question = new Question(questionID, correctItemID);
    questions[questionID] = question;
}

function evaluateChoiceAnswer(questionID, itemID) {
    if (questions[questionID].Evaluated)
        return;

    disableChoiceQuestion(questionID);
    $('#Explanation' + questionID).removeClass('hidden');

    questions[questionID].Evaluated = true;

    var selectedChoice = $('input#Q' + questionID + 'CH' + itemID);
    if (itemID == questions[questionID].CorrectItemID) {
        selectedChoice.parent().addClass('correct');
    }
    else {
        selectedChoice.parent().addClass('wrong');
        $('input#Q' + questionID + 'CH' + questions[questionID].CorrectItemID).parent().addClass('correct');
    }

    selectedChoice.parent().append('<input type="hidden" name="Q' + questionID + '" value="' + itemID + '" />');
}

function disableChoiceQuestion(questionID) {
    var radios = $('input.Q' + questionID).each(function() { $(this).attr('disabled', 'disabled')});
}