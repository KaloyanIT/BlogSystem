"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var redux_actions_1 = require("./redux-actions");
function retrieveData() {
    return function (dispatch, getState) {
        setTimeout(function () {
            dispatch(redux_actions_1.receiveHelloWorldData({ status: 'Data received', count: 5 }));
        }, 5000);
    };
}
exports.retrieveData = retrieveData;
//# sourceMappingURL=async-thunks.js.map