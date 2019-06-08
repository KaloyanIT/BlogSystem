"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var Comp = /** @class */ (function (_super) {
    __extends(Comp, _super);
    function Comp() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Comp.prototype.componentDidMount = function () {
        //if (!props.status) {
        //    this.props.dispatch(retrieveData());
        //}
    };
    Comp.prototype.render = function () {
        //const {status, count} = this.props;
        var content = null;
        if (status) {
            content = [
                React.createElement("div", null, "Data obtained from server:"),
                React.createElement("div", null,
                    "Status: ",
                    status),
            ];
        }
        return React.createElement("div", null,
            "Hello world!",
            content);
    };
    return Comp;
}(React.PureComponent));
exports.HelloWorld = react_redux_1.connect(function (state) {
    return __assign({}, state);
})(Comp);
//# sourceMappingURL=HelloWorld.js.map