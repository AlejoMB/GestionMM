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

function calcularValorFinal(valorOriginal, porcentaje) {
    // Sumarle el 20% al valor original
    let valorConIncremento = Math.round(valorOriginal * porcentaje/*1.20*/);

    // Obtener las decenas
    let decenas = valorConIncremento % 100;
    let valorFinal;

    // Redondear según las reglas
    if (decenas < 50) {
        valorFinal = valorConIncremento - decenas; // Redondear hacia abajo
    } else if (decenas === 50) {
        valorFinal = valorConIncremento; // Mantener igual si las decenas son 50
    } else {
        valorFinal = valorConIncremento + (100 - decenas); // Redondear hacia arriba
    }

    return valorFinal;
}