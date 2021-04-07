//Combos para localidades

$("#Cobro-Contrato-Create").change(function () {
    var inmuebleSelect = $("#Cobro-Contrato-Create").val();
    var url = "/PisoInmuebles/GetPisos";

    $.getJSON(url, { baseId: inmuebleSelect }, function (data) {

        var item = "";
        $("#Cobro-Cuota-Create").empty();
        $.each(data, function (i, cobro) {
            item += "<option value = '" + cobro.id + "'>" + cobro.cuotaMensualPrimerAño + "</option>";
        });

        $("#Cobro-Cuota-Create").html(item);

    });
});



