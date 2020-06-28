/* eslint-disable no-undef */
const comments = (function () {
    let commentsContainerClass = '.comments-section';

    function init() {
        if ($(commentsContainerClass).length == 0) {
            console.log('Module is not initialized');
            return;
        }
        console.log('Script is loaded');

        const textAreaSelector = '.comments-content';
        const submitButtonSelector = '.comments-button';

        function onComment(ev) {
            let value = $(commentsContainerClass)
                .find(textAreaSelector)
                .val();
            console.log(value);
        }

        $(commentsContainerClass).on(
            'click',
            submitButtonSelector,
            onComment,
        );
    }

    return {
        init,
    };
})();

window.comments = {};
window.comments.init = comments.init;
