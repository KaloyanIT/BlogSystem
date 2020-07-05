/* eslint-disable no-undef */

// import { Data } from '../common/data';
// import { Logger } from '../common/logger';

const comments = (function () {
    const commentsContainerClass = '.comments-section';

    function init() {
        // let logger = new Logger('development');
        if ($(commentsContainerClass).length === 0) {
            console.log('Module is not initialized');
            return;
        }
        console.log('Script is loaded');

        const textAreaSelector = '.comments-content';
        const submitButtonSelector = '.comments-button';

        function onComment() {
            const value = $(commentsContainerClass)
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
