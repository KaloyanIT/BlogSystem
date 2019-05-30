"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_dom_1 = require("react-dom");
var redux_1 = require("redux");
var react_redux_1 = require("react-redux");
var redux_thunk_1 = require("redux-thunk");
var redux_reducers_1 = require("./redux-reducers");
var HelloWorld_1 = require("./HelloWorld");
var Store = redux_1.createStore(redux_reducers_1.helloWorld_reducers, redux_1.applyMiddleware(redux_thunk_1.default));
react_dom_1.render(React.createElement(react_redux_1.Provider, { store: Store },
    React.createElement(HelloWorld_1.HelloWorld, null)), document.querySelector('body'));
//# sourceMappingURL=entry.js.map