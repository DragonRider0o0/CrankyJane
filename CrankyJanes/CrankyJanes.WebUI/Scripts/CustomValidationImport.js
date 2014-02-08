$(function () {
    jQuery.validator.addMethod("regex", function (value, element, regexString) {
        var regex = new RegExp(rule.ValidationRegex);
        return regex.exec(value) != null;
    }, rule.Message);
});