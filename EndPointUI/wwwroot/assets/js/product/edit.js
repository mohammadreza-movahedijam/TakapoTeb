$('#category').select2({
    ajax: {
        delay: 1000,
        url: '/Admin/Product/FetchCategory',
        data: function (params) {
            return {
                search: params.term
            };
        },
        processResults: function (data) {
            return {
                results: data.items || []
            };
        }
    },
    initSelection: function (element, callback) {
        let CategorySelected = document.getElementById("CategorySelected");
        callback({
            id: CategorySelected.getAttribute("key"),
            text: CategorySelected.getAttribute("value")
        });
    },
    minimumInputLength: 1,
    placeholder: "دسته‌بندی مورد نظر را جستجو کنید",
    language: "fa",
    escapeMarkup: function (markup) { return markup; },
    templateResult: function (data) {
        return data.text || '';
    },
    templateSelection: function (data) {
        return data.text || '';
    }
}).on('select2:open', function () {
    $(this).data('select2').dropdown.$search.attr('placeholder', 'جستجو...');
});