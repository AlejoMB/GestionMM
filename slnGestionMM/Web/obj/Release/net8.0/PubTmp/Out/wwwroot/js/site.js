// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $(function () {
        $(".datepicker").datepicker();
    });


    $(document).on("input", ".currencyInput", function (event) {
        $(this).val(formatCurrency($(this).val()));
    });

});

function formatCurrency(value) {
    value = value.toString().replace(/\D/g, '');
    return '$' + value.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
}

function removeformatCurrency(value) {
    value = value.toString().replace('$', '').replace(/\./g, '');
    return value;
}

function validateInput(inputName) {
    if ($(inputName).val() === '' || $(inputName).val() === undefined) {
        $(inputName).addClass("error");
        return false;
    }
    else {
        $(inputName).removeClass("error");
        return true;
    }
}