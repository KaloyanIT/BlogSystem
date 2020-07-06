/* eslint-disable no-undef */

import { Data } from '../common/data';
// import { Logger } from '../common/logger';

const comments = (function () {
    const commentsContainerClass = '.comments-section';

    function init(itemId, itemType) {
        console.log(itemId, itemType);
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

            const data = {
                attachedItemId: itemId,
                commentItemType: itemType,
                content: value,
            };

            const headers = {
                'Content-Type': 'application/json',
                RequestVerificationToken: $(commentsContainerClass)
                    .find("input[name='__RequestVerificationToken']")
                    .val(),
            };

            Data.postJson({
                url: '/comments/addComment',
                data,
                headers,
            }).then(function (res) {
                console.log(res);
            });

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
