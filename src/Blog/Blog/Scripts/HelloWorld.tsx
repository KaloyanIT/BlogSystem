﻿import * as React from 'react';
import { connect } from 'react-redux';
import { retrieveData } from './async-thunks';
import { IHelloWorldData } from './redux-actions';

export interface Props_redux extends IHelloWorldData {
    dispatch: <T>(action: any) => T
}

export interface IState {}

class Comp extends React.PureComponent<Props_redux, IState> {
    componentDidMount() {
        //if (!props.status) {
        //    this.props.dispatch(retrieveData());
        //}
    }

    render() {
        //const {status, count} = this.props;

        var content = null;
        if(status) {
            content = [
                <div>Data obtained from server:</div>,
                <div>Status: {status}</div>,
                //<div>Count: {count}</div>
            ]
        }

        return <div>Hello world!{content}</div>;
    }
}

export var HelloWorld: React.ComponentClass<{}> = connect(state => {
    return {
        ...state
    };
})(Comp)

