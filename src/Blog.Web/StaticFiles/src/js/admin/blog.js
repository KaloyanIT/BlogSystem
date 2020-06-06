/* eslint-disable func-names */
/* eslint-disable no-undef */
import { textEditor } from '../text-editor';

const blog = (function () {
  function create(selector) {
    console.log('Blog Create');
    textEditor.init(selector);
  }

  return {
    create,
  };
})();

window.blog = blog;
window.blog.create = blog.create;
