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

//Habilita Combos segun Elección


//    $("#ElijeInmueble").change(function () {
//        if ($(this).val() === "0") {
//            $("#DepartamentoContrato").prop("disabled", true);
//            $("#CasaContrato").prop("disabled", true);
//            $("#CocheraContrato").prop("disabled", true);
//        } 

//        if ($(this).val() === "Inmueble-Depto") {
//            $("#DepartamentoContrato").prop("disabled", false);
//        } else { $("#DepartamentoContrato").prop("disabled", true); }

//        if ($(this).val() === "Inmueble-Casa") {
//            $("#CasaContrato").prop("disabled", false);
//        } else { $("#CasaContrato").prop("disabled", true); }

//        if ($(this).val() === "Inmueble-Cochera") {
//            $("#CocheraContrato").prop("disabled", false);
//        } else { $("#CocheraContrato").prop("disabled", true); }
//    });

//$(document).ready(function () {
//});

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

//$(document).ready(function () {
//    var item = "<option value = '0'> Selecione Inquilino </option>";
//    $("#NomApellido-Create").html(item);
//});


//$("#NomApellido-Create").change(function () {
//    var inq = $("#NomApellido-Create").val();
//    var url = "/Inquilinos/GetInquilinos";

//    $.getJSON(url, { InquilinoId: inq }, function (data) {

//        var item = "";
//        $("#NomApellido-Create").empty();
//        $.each(data, function (i, q) {
//            item += "<option value = '" + q.id + "'>" + q.nombre + " " + q.apellido + "</option>";
//        });

//        $("#NomApellido-Create").html(item);

//    });
//});

