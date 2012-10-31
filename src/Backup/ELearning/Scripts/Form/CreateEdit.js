function setQuestionaireControls() {
    $('input#TimeToFill').val("");
    $('div#TimeToFillGroup').hide();
    $('input#MaxFills').val("");
    $('div#MaxFillsGroup').hide();
    $('input#Shuffle').attr('checked', false);
    $('div#ShuffleGroup').hide();
}
function setTestControls() {
    $('div#TimeToFillGroup').show();
    $('div#MaxFillsGroup').show();
    $('div#ShuffleGroup').show();
}
function setTrainingTestControls() {
    $('div#TimeToFillGroup').show();
    $('div#MaxFillsGroup').show();
    $('div#ShuffleGroup').show();
}

function formTypeChanged() {
    var type = $('select#Type_ID option:selected').val();
    switch (parseInt(type)) {
        case 1: // Questionaire
            setQuestionaireControls();
            break;
        case 2: // Test
            setTestControls();
            break;
        case 3: // Training test
            setTrainingTestControls();
            break;
        default:
            alert("FormType error");
            break;
    }
}

$(document).ready(function () {
    $('select#Type_ID').change(function () { formTypeChanged(); });
    formTypeChanged();
});