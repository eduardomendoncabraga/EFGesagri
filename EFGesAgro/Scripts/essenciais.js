$(document).ready(function () {

    //Escondendo campos quando carregar página
    $('.ocultarIns').hide();
    $('.ocultarRg').hide();
    // Exibindo/ Escondendo conforme valor de Unidade

    $('#ocultarDoc').change(function () {
        if (this.value == 'F') { //SE FOR PESSOA FÍSICA OCULTA INSCRIÇÃO ESTADUAL E APRESENTA RG
            $('.ocultarIns').hide();
            $('#Inscricao').val('');
            $('.ocultarRg').show();
        } else { //SE NÃO FOR PESSOA FÍSICA E SIM PESSOA JURIDICA OCULTA RG E APRESENTA INSCRIÇÃO ESTADUAL
            $('.ocultarIns').show();
            $('.ocultarRg').hide();
            $('#Rg').val('');
        } if (this.value == '') {//SE FOR VAZIO OU SEJA NENHUMA DAS OPÇÕES OCULTA TANTO RG COMO INSCRIÇÃO ESTADUAL
            $('.ocultarIns').hide();
            $('.ocultarRg').hide();
        }
    });
});

$(document).ready(function () {
    $("#mytable #checkall").click(function () {
        if ($("#mytable #checkall").is(':checked')) {
            $("#mytable input[type=checkbox]").each(function () {
                $(this).prop("checked", true);
            });

        } else {
            $("#mytable input[type=checkbox]").each(function () {
                $(this).prop("checked", false);
            });
        }
    });

    $("[data-toggle=tooltip]").tooltip();
});


function Deletar(idPessoa) {
    var confirmar = confirm("Deseja Realmente Apagar ?");
    if (confirmar) {
        $.ajax({
            type: 'POST',
            url: "/App/Deletar",
            data: { id: idPessoa },
            success: function () {
                Listar();
                Mensagem("success", "Deletado com sucesso!");
            },
            error: function () {
                Mensagem("danger", "Erro ao Deletar!");
            }
        });
    }
}
