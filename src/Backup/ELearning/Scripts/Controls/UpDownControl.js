function UpDownControl(guid) {
    this.textbox = $('div.upDownControl#' + guid + ' div.textbox input')[0];
    this.increase = function () {
        this.textbox.value = parseInt(this.textbox.value) + 1;
    }
    this.decrease = function () {
        this.textbox.value = parseInt(this.textbox.value) - 1;
    }
}