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



$(document).ready(function () {
    CKEDITOR.replace('TextFa');
    CKEDITOR.replace('TextEn');

    CKEDITOR.replace('SummaryFa');
    CKEDITOR.replace('SummaryEn');

    CKEDITOR.replace('DescrptionSectionTwoFa');
    CKEDITOR.replace('DescrptionSectionTwoEn');
});




$('#RelatedProduct').select2({
    ajax: {
        delay: 1000,
        url: '/Admin/Product/GetRelatedProducts',
        data: function (params) {
            return {
                search: params.term,Id:null
            };
        },
        processResults: function (data) {
            return {
                results: data.items || []
            };
        }
    },
    minimumInputLength: 1,
    placeholder: "محصول مورد نظر را جستجو کنید",
    language: "fa",
    escapeMarkup: function (markup) { return markup; },
    templateResult: function (data) {
        return data.text || '';
    },
    templateSelection: function (data) {
        return data.text || '';
    }
});