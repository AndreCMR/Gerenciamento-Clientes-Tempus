$(document).ready(function () {
    carregarRelatorio("mes");
});

function carregarRelatorio(action) {
    $("#relatorio").fadeOut();
    $('#spinner').fadeIn();
    $.get("home/" + action, function (data) {
        $('#spinner').fadeOut();
        $("#relatorio").html(data);
        $("#relatorio").fadeIn();
    });
}