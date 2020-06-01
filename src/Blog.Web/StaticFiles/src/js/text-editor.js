/* eslint-disable no-undef */
// eslint-disable-next-line func-names
const textEditor = (function () {
  function init(cssSelector) {
    tinymce.init({
      selector: cssSelector,
      width: 600,
      height: 300,
      plugins: [
        'advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker',
        'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
        'table emoticons template paste help',
      ],
      toolbar:
        'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | ' +
        'bullist numlist outdent indent | link image | print preview media fullpage | ' +
        'forecolor backcolor emoticons | help',
      menu: {
        favs: {
          title: 'My Favorites',
          items:
            'code visualaid | searchreplace | spellchecker | emoticons',
        },
      },
      menubar: 'favs file edit view insert format tools table help',
    });
  }

  return {
    init,
  };
})();

export { textEditor };
