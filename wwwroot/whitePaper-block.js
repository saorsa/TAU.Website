Vue.component('whitePaper-block', {
    props: ['uid', 'model'],
    template: '<div class="block-body">\n' +
        '<div class="col-sm-10">\n' +
        '<input v-on:blur="onBlur" type="text" class="form-control" name="url"  v-model="model.contentUrl.value" placeholder="URL" required>\n' +
        '</div>\n' +
        '</div>',
    methods: {
        data: function () {
            return {
                contentUrl: this.model.contentUrl.value,
            };
        },
        beforeDestroy: function () {
            piranha.editor.remove(this.uid);
        },
        mounted: function () {
            piranha.editor.addInline(this.uid, this.toolbar, this.onChange);
            this.model.getTitle = function () {
                if (this.model.contentUrl != null) {
                    return this.model.contentUrl.value;
                } else {
                    return "";
                }
            };
        },
        onBlur: function(e) {
            
            this.$emit('update-title', {
                uid: this.uid,
                title: e.target.innerText
            });
        }
    }      
});
