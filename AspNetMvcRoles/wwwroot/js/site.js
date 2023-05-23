// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function InverterData(data) {
    var data = data.replace("/", "");
    var datatxt = data.replace("/", "");
    var qtd = datatxt.length;
    var dia = datatxt.substring(0, 2);
    var mes = datatxt.substring(2, qtd - 4)
    var ano = datatxt.substring(4, qtd);

    if (datatxt != "") {
        var datafinal = ano + "-" + mes + "-" + dia;
    } else {
        var datafinal = "";
    }
    
    return datafinal;
}
