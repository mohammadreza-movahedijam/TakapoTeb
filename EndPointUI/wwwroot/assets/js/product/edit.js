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
$(document).ready(function () {
    CKEDITOR.replace('TextFa');
    CKEDITOR.replace('TextEn');
});
$(document).ready(function () {
    let productId = document.getElementById("ProductId").value;

    
    $('#RelatedProduct').select2({
        ajax: {
            delay: 1000,
            url: '/Admin/Product/GetRelatedProducts',
            data: function (params) {
                return {
                    search: params.term,
                    Id: productId 
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

    $.get("/Admin/Product/GetRelateds?Id=" + productId, function (data, status) {
        let selected = [];

        let entries = Object.entries(data);
        for (const item of entries) {
            item[1].forEach(select => {
                selected.push(select.id); 
            });
        }

        $('#RelatedProduct').val(selected).trigger('change');

        selected.forEach(function (id) {
            if ($('#RelatedProduct').find("option[value='" + id + "']").length === 0) {
                let text = '';
                for (const item of entries) {
                    let found = item[1].find(x => x.id === id);
                    if (found) {
                        text = found.text;
                        break;
                    }
                }
                let newOption = new Option(text, id, true, true);
                $('#RelatedProduct').append(newOption).trigger('change');
            }
        });
    });
});