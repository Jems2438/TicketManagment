const { placeholder } = require("modernizr");

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodedurl = decodeURIComponent(url);

        $.get(decodedurl).done(function (data) {
            placeholderElement.Html(data);
        PlaceHolderElement.find('.modal').modal('show');
            })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal'.find('form'));
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        })
    })
}