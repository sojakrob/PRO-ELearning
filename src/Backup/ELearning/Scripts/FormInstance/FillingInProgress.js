function openFillingFormWindow(formID) {
    window.open('/FormInstance/FillForm/' + formID, '_blank', 'width=800, toolbar=0, resizable=1, scrollbars=1, menubar=0');
}

function refreshPageWithoutParams() {
    var href = window.location.href;
    var getParamsStart = href.indexOf("?");
    if (getParamsStart != -1)
        href = href.substring(0, getParamsStart);

    window.location.href = href;
}

setTimeout('refreshPageWithoutParams()', 4000);