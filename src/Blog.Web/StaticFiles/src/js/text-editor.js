/* eslint-disable no-undef */
// eslint-disable-next-line func-names
const textEditor = (function () {
    function init(cssSelector) {
        tinymce.init({
            selector: cssSelector,
            width: 800,
            height: 600,
            plugins: [
                'advlist autolink link image lists charmap print codesample code preview hr anchor pagebreak spellchecker',
                'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
                'table emoticons template paste help',
            ],
            toolbar:
                'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | ' +
                'bullist numlist outdent indent | link image | print preview media fullpage | ' +
                'forecolor backcolor emoticons | codesample code | help',
            menu: {
                favs: {
                    title: 'My Favorites',
                    items:
                        'code visualaid | searchreplace | spellchecker | emoticons',
                },
            },
            menubar:
                'favs file edit view insert format tools table help',
            codesample_languages: [
                { text: 'HTML/XML', value: 'markup' },
                { text: 'JavaScript', value: 'javascript' },
                { text: 'CSS', value: 'css' },
                { text: 'PHP', value: 'php' },
                { text: 'Ruby', value: 'ruby' },
                { text: 'Python', value: 'python' },
                { text: 'Java', value: 'java' },
                { text: 'C', value: 'c' },
                { text: 'C#', value: 'csharp' },
                { text: 'C++', value: 'cpp' },
            ],
        });
    }

    return {
        init,
    };
})();

export { textEditor };
