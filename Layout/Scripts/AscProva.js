$('#InputP1').keyup(function () { CalculoMedia(); });
$('#InputP2').keyup(function () { CalculoMedia(); });
$('#InputP3').keyup(function () { CalculoMedia(); });
$('#InputPf').keyup(function () { CalculoMedia(); });
$('#InputPe').keyup(function () { CalculoMedia(); });

function CalculoMedia() {

    var Media, StatusAprovacao, ClasseStatus;
    var Inputp1 = $('#InputP1').val();
    var Inputp2 = $('#InputP2').val();
    var Inputp3 = $('#InputP3').val();
    var MediaUltimo = $('#MediaUltimo').val();
    var ClassePadraoDeElementoDeCorFundoStatusAprovacao = "content text-center cs_09 ";

    MediaUltimo = Number(MediaUltimo);

    if (MediaUltimo == "0") { MediaUltimo = 0 }

    var MediaNormal = CalculoMediaNormal(Inputp1, Inputp2, Inputp3);

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

                Media = CalculoMediaEspecial(Inputp1, Inputp2, Inputp3, Media);

            }

            break;
        default: // Recuperacao

            StatusAprovacao = "Recuperação"
            ClasseStatus = "cs_09_Recuperacao";

            Media = CalculoMediaRecuperacao(Inputp1, Inputp2, Inputp3);

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

            $('#InputPf').prop("disabled", false);
            $('#InputPe').prop("disabled", true);
            $('#InputPe').val(0);

            break;
        case "Recuperação":

            $('#InputPf').prop("disabled", false);
            $('#InputPe').prop("disabled", true);
            $('#InputPe').val(0);

            break;
        case "Aprovado":

            $('#InputPf').prop("disabled", true);
            $('#InputPe').val(0);
            $('#InputPe').prop("disabled", true);
            $('#InputPe').val(0);

            break;
        case "Reprovado":

            $('#InputPf').prop("disabled", true);
            $('#InputPf').val(0);
            $('#InputPe').prop("disabled", true);
            $('#InputPe').val(0);

            break;
        case "Aprovado entre<br>os melhores":

            $('#InputPf').prop("disabled", true);
            $('#InputPf').val(0);
            $('#InputPe').prop("disabled", false);

            break;

    }

}

function CalculoMediaNormal(Inputp1, Inputp2, Inputp3) {

    Inputp1 = Number(Inputp1);
    Inputp2 = Number(Inputp2);
    Inputp3 = Number(Inputp3);

    var P1Ponderacao = Number(1);
    var P2Ponderacao = Number(1.2);
    var P3Ponderacao = Number(1.4);

    var MediaPonderada = ((Inputp1 * P1Ponderacao) + (Inputp2 * P2Ponderacao) + (Inputp3 * P3Ponderacao)) / (P1Ponderacao + P2Ponderacao + P3Ponderacao);

    MediaPonderada = Number(MediaPonderada);

    return MediaPonderada;
}

function CalculoMediaRecuperacao(MediaNormal) {

    var InputPf = $('#InputPf').val();

    MediaNormal = Number(MediaNormal);
    InputPf = Number(InputPf);

    var Media = (MediaNormal + InputPf) / 2;

    Media = Number(Media);

    return Media;

}

function CalculoMediaEspecial(Inputp1, Inputp2, Inputp3, Media) {

    var InputPe = $('#InputPe').val();
    InputPe = Number(InputPe);

    if (InputPe == 0) {
        return Media
    }

    Inputp1 = Number(Inputp1);
    Inputp2 = Number(Inputp2);
    Inputp3 = Number(Inputp3);

    var P1Ponderacao = Number(1);
    var P2Ponderacao = Number(2);

    var MediaPonderada = (Inputp1 + Inputp2 + Inputp3 + (InputPe * P2Ponderacao)) / (P1Ponderacao + P2Ponderacao);

    MediaPonderada = Number(MediaPonderada);
    $("#MediaEspecial").val(MediaPonderada);
    return MediaPonderada;

}


//===============================================


$('#InputP1').mask("#.#", { reverse: true });
$('#InputP2').mask("#.#", { reverse: true });
$('#InputP3').mask("#.#", { reverse: true });
$('#InputPf').mask("#.#", { reverse: true });
$('#InputPe').mask("#.#", { reverse: true });

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
