Vue.component('whitePaper-block', {
    props: ['uid', 'model'],
    template: '<div class="block-body">' +
        '<form id="whitePaperURLFrom" novalidate class="needs-validation">\n' +
        '    <div class="form-group row-cols-lg-3">\n' +
        '        <div class="col-sm-10">\n' +
        '            <input type="text" class="form-control" id="whitePaperURL" name="url" placeholder="URL" required>\n' +
        '            <div class="invalid-feedback">Url field is required.</div>' +
        '        </div>\n' +
        '    </div>\n' +
        '    <div class="form-group">\n' +
        '        <button type="button" class="btn btn-info" onclick="submitWhitePaperURL()">Save</button>\n' +
        '    </div>\n' +
        '</form>\n' +
        '<script type="application/javascript" >' +
        'function submitWhitePaperURL() {\n' +
        '    var form = $("#whitePaperURLFrom");\n' +
        '    var data = form.serialize();\n' +
        '    \n' +
        '    form[0].classList.add(\'was-validated\');\n' +
        '    if (!form[0].checkValidity()) {\n' +
        '        return;\n' +
        '    }' +
        '    $.ajax({\n' +
        '        type: \'POST\',\n' +
        '        url: \'/WhitePaper/SaveWhitePaperUrlAsync\',\n' +
        '        contentType: \'application/x-www-form-urlencoded; charset=UTF-8\',\n' +
        '        data: data,\n' +
        '        success: function (result) {\n' +
        '            form[0].classList.remove(\'was-validated\')\n' +
        '            form[0].reset();\n' +
        '        },\n' +
        '        error: function (error) {\n' +
        '        }\n' +
        '    });\n' +
        '}' +
        '</script>' +
        '</div>'

});
