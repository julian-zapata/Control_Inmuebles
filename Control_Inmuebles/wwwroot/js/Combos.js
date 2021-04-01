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

//Habilita Combos segun Elección

$(document).ready(function () {

    $("#ElijeInmueble").change(function () {
        if ($(this).val() === "0") {
            $("#DepartamentoContrato").prop("disabled", true);
            $("#CasaContrato").prop("disabled", true);
            $("#CocheraContrato").prop("disabled", true);
        } 

        if ($(this).val() === "Inmueble-Depto") {
            $("#DepartamentoContrato").prop("disabled", false);
        } else { $("#DepartamentoContrato").prop("disabled", true); }

        if ($(this).val() === "Inmueble-Casa") {
            $("#CasaContrato").prop("disabled", false);
        } else { $("#CasaContrato").prop("disabled", true); }

        if ($(this).val() === "Inmueble-Cochera") {
            $("#CocheraContrato").prop("disabled", false);
        } else { $("#CocheraContrato").prop("disabled", true); }
    });

});

//Habilita detalle segun inmueble elejido

$(document).ready(function () {

    var i = $("#Inmueble-Contrato-Index").val();

    if (i === "Inmueble-Depto") {
        $("#Departamento-Contrato-Index").prop("hidden", false);
    } else if (i === "Inmueble-Casa") {
        $("#Casa-Contrato-Index").prop("hidden", false);
    } else if (i === "Inmueble-Cochera") {
        $("#Cochera-Contrato-Index").prop("hidden", false);
    }
       
});


//Mostrar apellido y nombre en la lista


//$(document).ready(function () {

//    mostrarNombres($("#inqNomAp"));

   
//});

//function mostrarNombres(q) {
//    var url = "/Inquilinos/GetInquilinos";

//    $.getJSON(url, { InquilinoId: q }, function (data) {

//        var item = "";
//        $("#inqNomAp").empty();
//        $.each(data, function (i, q) {

//            item += "<option value = '" + q.id + "'>" + q.nombre + " " + q.apellido + "</option>";

//        });

//        $("#inqNomAp").html(item);

//    });
//}


//    //$("#inqNomAp").select(function () {
//    //    var inq = $("#inqNomAp").val();
//    //    var url = "/Inquilinos/GetInquilinos";

//    //    $.getJSON(url, { InquilinoId: inq }, function (data) {

//    //        var item = "";
//    //        $("#inqNomAp").empty();
//    //        $.each(data, function (i, q) {

//    //            item += "<option value = '" + q.id + "'>" + q.nombre + " " + q.apellido + "</option>";

//    //        });

//    //        $("#inqNomAp").html(item);

//    //    });
//    //});
