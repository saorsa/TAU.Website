Vue.component('whitePaper-block', {
    props: ['uid', 'model'],
    template: '<div class="block-body">' +
        '<form @submit.prevent="submitWhitePaperURL" @input="onChange($event)" id="whitePaperURLFrom" novalidate :class="validationClass">\n' +
        '    <div class="form-group ">\n' +
        '        <div class="">\n' +
        '            <input type="text" class="form-control" id="whitePaperURL" name="url" placeholder="Enter URL" v-model="urlInput" required>\n' +
        '            <div class="invalid-feedback">Url field is required.</div>' +
        '        </div>\n' +
        '    </div>\n' +
        '    <div class="form-group">\n' +
        '        <button class="btn btn-info" :disabled="someValue ? true : null">Save</button>\n' +
        '    </div>\n' +
        '</form>\n' +
        '</div>',
    data() {
        return {
            urlInput: "",
            savedUrl: "",
            someValue: false,
            validationClass: "needs-validation"
        }
    },
    methods: {
        submitWhitePaperURL() {
            this.validationClass = "was-validated"
            if (this.urlInput === "") {
                return
            }
            const requestOptions = {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify({"url": this.urlInput})
            };
            fetch("/WhitePaper/SaveWhitePaperUrlAsync", requestOptions)
                .then(response => response.json())
                .then(data => {
                    this.validationClass = "needs-validation";
                    this.savedUrl = this.urlInput;
                    this.onChange()
                });

        },
        getWhitePaperUrl() {
            fetch("/WhitePaper/GetWhitePaperUrlAsync").then(async (response) => {
                if (response.status === 200) {
                    var data = await response.json();
                    this.urlInput = data.value;
                    this.savedUrl = data.value;
                    this.onChange();
                }
            });
        },
        onChange(event) {
            if (this.urlInput === this.savedUrl ||this.urlInput === ""){
                this.someValue = true;
            }
            else {
                this.someValue = false;
            }
        }
    },
    beforeMount() {
        this.getWhitePaperUrl();
    }

});
