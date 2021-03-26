//Combos para localidades

$(document).ready(function () {
    var item = "<option value = '0'> Selecione Provincia </option>";
    $("#ProvinciaId").html(item);
});

$("#PaisId").change(function () {
    var paisSelect = $("#PaisId").val();
    var url = "/Provincias/GetProvincias";

    $.getJSON(url, { PaisId : paisSelect }, function(data){

        var item = "";
        $("#ProvinciaId").empty();
        $.each(data, function (i, provincia) {
            item += "<option value = '" + provincia.id + "'>" + provincia.descripcion + "</option>";
        });

        $("#ProvinciaId").html(item);

    });
});

$("#BaseInmuebleId-Create").change(function () {
    var inmuebleSelect = $("#BaseInmuebleId-Create").val();
    var url = "/PisoInmuebles/GetPisos";

    $.getJSON(url, { baseId: inmuebleSelect }, function (data) {

        var item = "";
        $("#PisoInmuebleId-Create").empty();
        $.each(data, function (i, piso) {
            item += "<option value = '" + piso.id + "'>" + piso.descripcion + "</option>";
        });

        $("#PisoInmuebleId-Create").html(item);

    });
});

