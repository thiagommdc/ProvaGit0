
function MouseOverTurma(Turma) {
    $("#Turma").val(Turma);
}

function CalculoMedia() {

    var Media, StatusAprovacao, ClasseStatus;
    var ProvaUm = $('#ProvaUm').val();
    var ProvaDois = $('#ProvaDois').val();
    var ProvaTres = $('#ProvaTres').val();
    var MediaUltimo = $('#MediaUltimo').val();
    var ClassePadraoDeElementoDeCorFundoStatusAprovacao = "content text-center cs_09 ";

    MediaUltimo = Number(MediaUltimo);

    if (MediaUltimo == "0") { MediaUltimo = 0 }

    var MediaNormal = CalculoMediaNormal(ProvaUm, ProvaDois, ProvaTres);

    Media = MediaNormal;

    switch (true) {
        case (MediaNormal < 4):

            StatusAprovacao = "Reprovado"
            ClasseStatus = "cs_09_Reprovado";

            break;
        case (MediaNormal > 6):

            StatusAprovacao = "Aprovado"
            ClasseStatus = "cs_09_Aprovado";

            if (MediaNormal > MediaUltimo) {

                StatusAprovacao = "Aprovado entre<br>os melhores";
                ClasseStatus = "cs_09_AprovadoEntreMelhores";

                Media = CalculoMediaEspecial(ProvaUm, ProvaDois, ProvaTres, Media);

            }

            break;
        default: // Recuperacao

            StatusAprovacao = "Recuperação"
            ClasseStatus = "cs_09_Recuperacao";



            Media = CalculoMediaRecuperacao(Media);



            if (Media >= 5) {
                StatusAprovacao = "Aprovado na<br>Recuperação"
                ClasseStatus = "cs_09_Aprovado";
            }
    }


    DisponibilidadeCamposEdicaoNota(StatusAprovacao);

    Media = Number(Media);
    Media = Media.toFixed(1);

    ClasseStatus = ClassePadraoDeElementoDeCorFundoStatusAprovacao + ClasseStatus;

    document.getElementById("ElementoCorFundoStatusAprovacao").className = ClasseStatus;
    $("#ElementoStatusAprovacao").html(StatusAprovacao);
    $("#ElementoMedia").html(Media);
    $("#Media").val(Media);

}


function DisponibilidadeCamposEdicaoNota(StatusAprovacao) {

    switch (StatusAprovacao) {
        case "Aprovado na<br>Recuperação":

            $('#ProvaFinal').prop("disabled", false);
            $('#ProvaEspecial').prop("disabled", true);
            $('#ProvaEspecial').val(0);

            break;
        case "Recuperação":

            $('#ProvaFinal').prop("disabled", false);
            $('#ProvaEspecial').prop("disabled", true);
            $('#ProvaEspecial').val(0);

            break;
        case "Aprovado":

            $('#ProvaFinal').prop("disabled", true);
            $('#ProvaEspecial').val(0);
            $('#ProvaEspecial').prop("disabled", true);
            $('#ProvaEspecial').val(0);

            break;
        case "Reprovado":

            $('#ProvaFinal').prop("disabled", true);
            $('#ProvaFinal').val(0);
            $('#ProvaEspecial').prop("disabled", true);
            $('#ProvaEspecial').val(0);

            break;
        case "Aprovado entre<br>os melhores":

            $('#ProvaFinal').prop("disabled", true);
            $('#ProvaFinal').val(0);
            $('#ProvaEspecial').prop("disabled", false);

            break;

    }

}

function CalculoMediaNormal(ProvaUm, ProvaDois, ProvaTres) {

    ProvaUm = Number(ProvaUm);
    ProvaDois = Number(ProvaDois);
    ProvaTres = Number(ProvaTres);

    var P1Ponderacao = Number(1);
    var P2Ponderacao = Number(1.2);
    var P3Ponderacao = Number(1.4);

    var MediaPonderada = ((ProvaUm * P1Ponderacao) + (ProvaDois * P2Ponderacao) + (ProvaTres * P3Ponderacao)) / (P1Ponderacao + P2Ponderacao + P3Ponderacao);

    MediaPonderada = Number(MediaPonderada);

    return MediaPonderada;
}

function CalculoMediaRecuperacao(MediaNormal) {

    var ProvaFinal = $('#ProvaFinal').val();
    ProvaFinal = Number(ProvaFinal);

    if (ProvaFinal == 0) {
        return MediaNormal
    }

    MediaNormal = Number(MediaNormal);

    var Media = (MediaNormal + ProvaFinal) / 2;

    Media = Number(Media);

    return Media;

}

function CalculoMediaEspecial(ProvaUm, ProvaDois, ProvaTres, Media) {

    var ProvaEspecial = $('#ProvaEspecial').val();
    ProvaEspecial = Number(ProvaEspecial);

    if (ProvaEspecial == 0) {
        return Media
    }

    ProvaUm = Number(ProvaUm);
    ProvaDois = Number(ProvaDois);
    ProvaTres = Number(ProvaTres);

    var P1Ponderacao = Number(1);
    var P2Ponderacao = Number(2);

    var MediaPonderada = (ProvaUm + ProvaDois + ProvaTres + (ProvaEspecial * P2Ponderacao)) / (P1Ponderacao + P2Ponderacao);

    MediaPonderada = Number(MediaPonderada);
    $("#MediaEspecial").val(MediaPonderada);
    return MediaPonderada;

}


//===============================================




$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})


$('button[name="remove_levels"]').on('click', function (e) {
    var $form = $(this).closest('form');
    e.preventDefault();
    $('#confirm').modal({
        backdrop: 'static',
        keyboard: false
    })
        .on('click', '#delete', function (e) {
            $form.trigger('submit');
        });
});

function ConfirmaExclusao(Objeto) {

    var $form = $(Objeto).closest('form');
    e.preventDefault();
    $('#confirm').modal({
        backdrop: 'static',
        keyboard: false
    })
        .on('click', '#delete', function (e) {
            $form.trigger('submit');
        });

}
