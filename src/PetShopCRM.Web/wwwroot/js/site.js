alertify.set('notifier', 'position', 'top-right');

$(document).on('submit', 'form[ajax="true"]', function (e) {
    e.preventDefault();

    $this = $(this);

    if ($this.valid()) {

        var href = $this.prop('href');

        if (href == undefined) href = window.location.pathname;

        var method = $this.prop('method');

        if (method == undefined) method = 'post';

        $.ajax({
            type: method,
            url: href,
            data: $this.serialize()
        }).done(function (result) {
            if (result.success) {
                if (result.hasRedirect) {
                    var newHref = `/${result.redirect.controller}/${result.redirect.action}`;

                    if (result.redirect.parameters != null) {
                        var parameters = result.redirect.parameters;

                        newHref += '?';

                        for (var i = 0; i < parameters.length; i++) {
                            newHref += `${parameters[i].key}=${parameters[i].value}`;

                            if (i < parameters.length - 1) newHref += '&';
                        }
                    }

                    location.href = newHref;
                }
            } else {
                if (result.hasValidation) {
                    for (var i = 0; i < result.validations.length; i++) {
                        var validation = result.validations[i];

                        var span = $(`span[data-val-msgfor="${validation.field}"]`);

                        var spanMessage = $(`<span id="exampleInputPassword1-error" class="">${validation.message}</span>`);

                        span.append(spanMessage);
                    }
                }

                if (result.hasNotification) {
                    var type = result.notification.type;
                    var message = result.notification.message;

                    if (type == 'Success') {
                        alertify.success(message);
                    } else if (type == 'Warning') {
                        alertify.warning(message);
                    } else if (type == 'Error') {
                        alertify.error(message);
                    }
                }
            }
        });
    }
});
