//Cambia nombre del piso 0

$(document).ready(function () {
    var piso = $("#pisoCreado").val();
    if (piso = "0") {
        var pb = "PB";
        $("#pisoCreado").html(pb);
    }
})



