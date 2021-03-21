﻿//Combos para localidades

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