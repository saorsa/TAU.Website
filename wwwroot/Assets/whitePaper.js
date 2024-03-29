function displayWhitePaperForm() {
    var form = $("#whitePaperForm")[0]
    var modal = $('#whitePaperModal').modal('show');

    modal.modal('show')
    modal.on("hidden.bs.modal", function () {
        form.reset();
        form.classList.remove('was-validated')
    });
}

function submitWhitePaper() {
    var form = $("#whitePaperForm")[0];
    form.classList.add('was-validated')
    if (!form.checkValidity()) {
        return;
    }

    var siteKey = document.getElementById("whitePaper").getAttribute("data-siteKey");

    grecaptcha.ready(function () {
        grecaptcha.execute(siteKey, {action: 'submit'}).then(function (token) {
            $("#whitePaperReCaptchaToken").val(token);
            var data = $("#whitePaperForm").serialize();
            $.ajax({
                type: 'POST',
                url: '/WhitePaper/PostWhitePaper',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success: function (result) {
                    $('#whitePaperModal').modal('hide')
                    form.reset();
                    form.classList.remove('was-validated');
                    window.location.replace(result);
                },
                error: function () {
                    $('#whitePaperModal').modal('hide')
                    form.reset();
                    form.classList.remove('was-validated');
                }
            })
        });
    });
}

function closeModal() {
    var form = $("#whitePaperForm")[0];
    form.reset();
    form.classList.remove('was-validated')
}