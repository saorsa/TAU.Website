function submitNewsletter() {
    var form = $("#newsletterForm")[0];
    form.classList.add('was-validated')

    if (!form.checkValidity()) {
        return;
    }

    var siteKey = document.getElementById("newsletter").getAttribute("data-siteKey");

    grecaptcha.ready(function () {
        grecaptcha.execute(siteKey, {action: 'submit'}).then(function (token) {
            $("#newsLetterReCaptchaToken").val(token);
            var data = $("#newsletterForm").serialize();
            var statusMessage = "";
            $.ajax({
                type: 'POST',
                url: '/Newsletter/PostNewsletter',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success: function (result) {
                    form.classList.remove('was-validated')
                    form.reset();
                    statusMessage = "Email saved.";
                    $('#newsletterReturnStatus').text(statusMessage);
                    $('#newsletterModal').modal('show');
                },
                error: function () {
                    form.classList.remove('was-validated');
                    form.reset();
                    statusMessage = "Error while saving email.";
                    $('#newsletterReturnStatus').text(statusMessage);
                    $('#newsletterModal').modal('show');
                }
            })
        });
    });
}