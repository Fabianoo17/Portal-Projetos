$(function () {

    $("#metismenu").metisMenu();

    $(document).ajaxStart(function () {
        $.blockUI({
            message: '<div class="fa-3x"><i class="fa fa-spinner fa-spin"></i></div>',
            css: {
                backgroundColor: '#fff',
                color: '#222',
                opacity: 0.6,
                border: '1px solid #ddd',
                borderRadius: '4px',
                zIndex: 99999
            },
            overlayCSS: {
                backgroundColor: '#000',
                opacity: 0.6,
                zIndex: 99998
            }
        });
    }).ajaxStop($.unblockUI);

    $.fn.select2.defaults.set("theme", "bootstrap");
    $.fn.select2.defaults.set("language", "pt-BR");

    $('.select2').select2({});

    $('.select2-tags').select2({
        tags: true,
        tokenSeparators: [';', ',']
    });

    $('.cpf-mask').mask('000.000.000-00', { reverse: true });
    $('.date-mask').mask('00/00/0000', { placeholder: '__/__/____' });
    $('.money-mask').mask("#.##0,00", { reverse: true });

    $('.date-picker').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'pt-br'
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('.select2-usuarios-caixa').select2({
        minimumInputLength: 5,
        dataType: 'json',
        ajax: {
            url: $('#url-pesquisar-usuarios').data('url'),
            type: 'POST',
            data: function (params) {
                var query = {
                    matriculaOuNome: params.term
                }
                return query;
            }
        }
    });
});

function errorSummary(error, seletorInner) {
    var message = '';
    var messagesList = '';

    for (var i = 0, length = error.length; i < length; i++) {
        message = error[i];
        messagesList += '<li>' + message + '</li>';
    }

    if (error.length > 0) {

        var html = '<div class="alert alert-danger" fade show role="alert">';
        html += '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>';
        html += '<h4>Ops!</h4>';
        html += '<ul class="text-danger text-left">';
        html += messagesList;
        html += '</ul>';
        html += '</div>';

        $(seletorInner).html(html);
    }
}

function errorSweetAlert(data) {
    var message = '';
    var messagesList = '';

    for (var i = 0, length = data.length; i < length; i++) {
        message = data[i];
        messagesList += '<li>' + message + '</li>';
    }

    var html = '';
    html += '<ul class="text-danger text-left">';
    html += messagesList;
    html += '</ul>';

    return html;
}

function toTop() {
    $('html, body').animate({
        scrollTop: 0
    }, 500);
}

function erroAjax(error, funcAction) {
    var toastrOptions = {
        "closeButton": true,
        "timeOut": "10000",
        "positionClass": "toast-bottom-right"
    };

    if (error.status == 400) {
        Swal.fire({
            type: 'error',
            title: 'Ops!',
            html: errorSweetAlert(error.responseJSON.errors)
        });
        funcAction();
    } else if (error.status == 401) {
        toastr.options = toastrOptions;
        toastr["error"]('Sua sess&atilde;o expirou, efetue login novamente.');
        setTimeout(function () { window.location.href = '/'; }, 1500);
    } else if (error.status == 500) {
        toastr.options = toastrOptions;
        toastr["error"]('Erro interno.');
    } else {
        toastr.options = toastrOptions;
        toastr["error"]('Falha na conex&atilde;o.');
    }
}

function sucessoAjax(data, mensagem, funcAction) {
    if (data.success) {
        toastr.options = {
            "closeButton": true,
            "timeOut": "10000",
            "positionClass": "toast-bottom-right"
        }
        toastr["success"](mensagem);
        funcAction();
    }
}
