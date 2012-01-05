function openFillingFormWindow(formID) {
    window.open('/FormInstance/FillForm/' + formID, '_blank', 'width=800, toolbar=0, resizable=1, scrollbars=1, menubar=0');
}

function refreshPageWithoutParams() {
    var location = window.location;
    window.location.replace(location.origin + location.pathname);
}

setTimeout('refreshPageWithoutParams()', 5000);