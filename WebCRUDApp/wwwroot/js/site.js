////function deleteItem(form) {
////    $(form).parents('li').remove();
////}
function deletePerson(id) {
    if (confirm('Deseja realmente excluir essa Pessoa?')) {
        $.ajax({
            url: "/Pessoa/Delete",
            type: "GET",
            data: {
                id: id
            },
            error: function (result) {
                alert('Houve um erro ao remover essa Pessoa!');
            }
        });
    }
}

$(document).ready(function () {
    $("#srch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$("#cep").focusout(function () {
    $.ajax({
        url: 'https://viacep.com.br/ws/' + $(this).val() + '/json/unicode/',
        dataType: 'json',
        success: function (resposta) {
            $("#logradouro").val(resposta.logradouro);
            $("#complemento").val(resposta.complemento);
            $("#bairro").val(resposta.bairro);
            $("#cidade").val(resposta.localidade);
            $("#uf").val(resposta.uf);
            $("#numero").focus();
        }
    });
});
