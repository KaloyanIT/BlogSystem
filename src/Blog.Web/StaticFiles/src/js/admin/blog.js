/* eslint-disable func-names */
/* eslint-disable no-undef */
import $ from 'jquery';
import { textEditor } from '../text-editor';

const blog = (function () {
    function create(selector) {
        console.log('Blog Create');
        textEditor.init(selector);

        $('#multiselect').multiselect();
    }

    return {
        create,
    };
})();

window.blog = blog;
window.blog.create = blog.create;
