$(document).ready(function () {
    $('body').delegate('.display-modal', 'click', function () {
    var btn = $(this);
    var modal = $('#Modal'); 
        modal.find('#ModalLabel').text(btn.data('modaltitle'));
     

    $.get({
        url: btn.data('url'),
        success: function (form) {
            modal.find('.modal-body').html(form);
            $.validator.unobtrusive.parse(modal);
            /*applaySelect2();*/
        },
        error: function () {
            //showErrorMessage();
        }
    });

    modal.modal('show');
  });
});