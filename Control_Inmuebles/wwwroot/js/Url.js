//URL de la Pagina de Registros - Personas

$("#ContratosBT").click(function () {
    window.location.href = "/contratos/index/";
});

//URL de la Pagina de Registros - Personas

$("#InquilinosBT").click(function () {
    window.location.href = "/inquilinos/index/";
});

$("#GarantesBT").click(function () {
    window.location.href = "/garantes/index/";
});

$("#PropietariosBT").click(function () {
    window.location.href = "/propietarios/index/";
});

//URL de la Pagina de Registros - Obligaciones

$("#ImpuestosBT").click(function () {
    window.location.href = "/TipoImpuesto/index/";
});

$("#ServiciosBT").click(function () {
    window.location.href = "/TipoServicio/index/";
});

//URL de la Pagina de Registros - Inmuebles

$("#DepartamentoBT").click(function () {
    window.location.href = "/Departamentos/index/";
});

$("#EdificioBT").click(function () {
    window.location.href = "/Edificios/index/";
});

$("#CasaBT").click(function () {
    window.location.href = "/Casas/index/";
});

$("#CocheraBT").click(function () {
    window.location.href = "/Cocheras/index/";
});


//Resalta campo NOTA en /Inquilinos/Edit/ 
$(document).ready(function () {
    if (location.href.includes("#NotaEdit")) {
        $("#NotaEdit").css("background", "yellow");
    }
});




